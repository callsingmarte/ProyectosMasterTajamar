using StackExchange.Redis;
using System.Net.Sockets;

namespace SegundoProyectoRedis
{
    public class RedisConnection : IDisposable
    {

        //variables 3 para rastrear eventos relacionados con errores y conexiones
        private long _lastReconnectTicks = DateTimeOffset.MinValue.UtcTicks;
        private DateTimeOffset _firstErrorTime = DateTimeOffset.MinValue;
        private DateTimeOffset _previousErrorTime = DateTimeOffset.MinValue;

        private readonly TimeSpan ReconnectMinInterval = TimeSpan.FromSeconds(60);

        //Si supera los 60 creo una nueva instancia de Redis
        private readonly TimeSpan ReconnectErrorThreshold = TimeSpan.FromSeconds(30);
        private readonly TimeSpan RestartConnectionTimeOut = TimeSpan.FromSeconds(15);
        private const int RetryMaxAttemps = 5;

        private readonly string? _connectionString;
        private ConnectionMultiplexer? _connection;
        private SemaphoreSlim _reconnectSemaphore = new SemaphoreSlim(initialCount: 1, maxCount: 1);
        private IDatabase? _database;

        private RedisConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static async Task<RedisConnection> InitializeAsync(string connectionString)
        {
            var redisConnection = new RedisConnection(connectionString);
            await redisConnection.ForceReconnectAsync(initializing: true);

            return redisConnection;
        }

        public async Task<T> BasicRetryAsync<T>(Func<IDatabase, Task<T>> func)
        {
            int reconnectRetry = 0;

            while (true)
            {
                try
                {
                    return await func(_database);
                }
                catch (Exception ex) when(ex is RedisConnectionException || ex is SocketException || ex is ObjectDisposedException)
                {
                    reconnectRetry++;
                    if(reconnectRetry > RetryMaxAttemps)
                    {
                        throw;
                    }

                    try
                    {
                        await ForceReconnectAsync();
                    }
                    catch (ObjectDisposedException)
                    {

                    }

                    return await func(_database);
                }
            }                
        }

        private async Task ForceReconnectAsync(bool initializing = false)
        {
            long previousTicks = Interlocked.Read(ref _lastReconnectTicks);
            var previousReconnectTime = new DateTimeOffset(previousTicks, TimeSpan.Zero);
            TimeSpan elapsedSinceLastReconnect = DateTimeOffset.UtcNow - previousReconnectTime;

            // Queremos limitar la frecuencia con la que realizamos esta reconexión de nivel superior,
            // por lo que verificamos cuánto tiempo ha pasado desde nuestro último intento.
            if (elapsedSinceLastReconnect < ReconnectMinInterval)
            {
                return;
            }

            try
            {
                await _reconnectSemaphore.WaitAsync(RestartConnectionTimeOut);
            }
            catch
            {
                // Si no logramos ingresar el semáforo, entonces es posible que otro hilo ya lo haya hecho.
                // ForceReconnectAsync() se puede volver a intentar mientras persisten los problemas de conectividad.
                return;
            }

            try
            {
                var utcNow = DateTimeOffset.UtcNow;
                elapsedSinceLastReconnect = utcNow - previousReconnectTime;

                if (_firstErrorTime == DateTimeOffset.MinValue && !initializing)
                {
                    // No hemos visto un error desde la última reconexión, así que establezca los valores iniciales.
                    _firstErrorTime = utcNow;
                    _previousErrorTime = utcNow;
                    return;
                }

                if (elapsedSinceLastReconnect < ReconnectMinInterval)
                {
                    return; // Algun otro thread paso anteriormente por lo que no hay que hacer nada
                }

                TimeSpan elapsedSinceFirstError = utcNow - _firstErrorTime;
                TimeSpan elapsedSinceMostRecentError = utcNow - _previousErrorTime;

                bool shouldReconnect =
                    elapsedSinceFirstError >= ReconnectErrorThreshold // Asegura que multiplexor tiene tiempo suficiente para que se vuelva a conectar por si solo si pudiera
                    && elapsedSinceMostRecentError <= ReconnectErrorThreshold; // Esto asegura que no estamos trabajando con datos obsoletos).

                // Actualiza previousErrorTime timestamp para que sea ahora.
                _previousErrorTime = utcNow;

                if (!shouldReconnect && !initializing)
                {
                    return;
                }

                _firstErrorTime = DateTimeOffset.MinValue;
                _previousErrorTime = DateTimeOffset.MinValue;

                if (_connection != null)
                {
                    try
                    {
                        await _connection.CloseAsync();
                    }
                    catch
                    {
                        // Ignora cualquier error
                    }
                }

                Interlocked.Exchange(ref _connection, null);
                ConnectionMultiplexer newConnection = await ConnectionMultiplexer.ConnectAsync(_connectionString);
                Interlocked.Exchange(ref _connection, newConnection);

                Interlocked.Exchange(ref _lastReconnectTicks, utcNow.UtcTicks);
                IDatabase newDatabase = _connection.GetDatabase();
                Interlocked.Exchange(ref _database, newDatabase);
            }
            finally
            {
                _reconnectSemaphore.Release();
            }
        }
        public void Dispose()
        {
            try
            {
                _connection?.Dispose();
            }
            catch
            {

            }
        }       
    }
}
