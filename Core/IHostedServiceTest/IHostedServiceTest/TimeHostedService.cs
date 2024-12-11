namespace IHostedServiceTest
{
    public class TimeHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TimeHostedService>? _logger;

        private Timer? _timer;
        public TimeHostedService(ILogger<TimeHostedService> logger)
        {
            _logger = logger; 
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger!.LogInformation("Servicio en segundo plano iniciado");
            _timer = new Timer(DoWork!,null,TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void DoWork(Object state)
        {
            _logger!.LogInformation($"Tarea ejecutada a las {DateTime.Now}");
        }

        public Task StopAsync(CancellationToken cancellationToken) 
        {
            _logger!.LogInformation("Servicio en segundo plano finalizado");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
