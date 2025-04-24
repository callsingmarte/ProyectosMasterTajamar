
using Amazon.S3.Model.Internal.MarshallTransformations;
using Microsoft.Extensions.Logging;
using PracticaKinesis.Controllers;
using PracticaKinesis.Models;
using PracticaKinesis.Services;

namespace PracticaKinesis
{
    public class SensorSimulationProcess : IHostedService
    {
        private readonly ILogger<SensorSimulationProcess> _logger;
        private readonly KinesisService _kinesisService;
        private CancellationTokenSource _cts;
        private Task _backgroundTask;

        public SensorSimulationProcess(ILogger<SensorSimulationProcess> logger, KinesisService kinesis)
        {
            _logger = logger;
            _kinesisService = kinesis;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _backgroundTask = Task.Run(() => RunAsync(_cts.Token));
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cts.Cancel();
            return _backgroundTask ?? Task.CompletedTask;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                SensorEvent sensorEvent = GenerarEvento();
                bool result = await _kinesisService.SendMessageAsync(sensorEvent);
                if (result)
                {
                    _logger.LogDebug($"exito al subir los datos del sensor {sensorEvent.DeviceId}");
                }
                else
                {
                    _logger.LogWarning($"Se ha producido un error al subir los datos del sensor {sensorEvent.DeviceId}");
                }

                await Task.Delay(500, cancellationToken);
            }
        }

        private static SensorEvent GenerarEvento()
        {
            var random = new Random();

            double temperature = Math.Round(random.NextDouble() * 100 - 10, 2); // -10°C a 100°C
            double humidity = Math.Round(random.NextDouble() * 100, 2);        // 0% a 100%
            double batteryLevel = Math.Round(random.NextDouble() * 100, 1);    // 0 a 100%

            string status = "OK";

            // Evaluamos cada parámetro
            bool tempDanger = temperature < 0 || temperature > 75;
            bool tempWarning = temperature < 5 || temperature > 35;

            bool humidityDanger = humidity < 20 || humidity > 90;
            bool humidityWarning = humidity < 30 || humidity > 80;

            bool batteryDanger = batteryLevel < 10;
            bool batteryWarning = batteryLevel < 30;

            if (tempDanger || humidityDanger || batteryDanger)
            {
                status = "Danger";
            }
            else if (tempWarning || humidityWarning || batteryWarning)
            {
                status = "Warning";
            }

            return new SensorEvent
            {
                DeviceId = $"sensor-{random.Next(1, 5):D3}",
                Temperature = temperature,
                Humidity = humidity,
                Location = $"Zona {random.Next(1, 4)}",
                Timestamp = DateTime.UtcNow,
                BatteryLevel = batteryLevel,
                Status = status
            };
        }
    }
}
