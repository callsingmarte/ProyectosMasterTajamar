using Amazon;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using System.Text;
using System.Text.Json;

const string streamName = "mi-stream-kinesis"; // <-- Cambiar por el nombre real
const string region = "us-east-1";

var kinesisClient = new AmazonKinesisClient(RegionEndpoint.GetBySystemName(region));

Console.WriteLine("🎯 Enviando datos simulados a Kinesis... Ctrl+C para detener");

while (true)
{
    var sensorEvent = GenerarEvento();
    var json = JsonSerializer.Serialize(sensorEvent);

    var request = new PutRecordRequest
    {
        StreamName = streamName,
        PartitionKey = sensorEvent.DeviceId,
        Data = new MemoryStream(Encoding.UTF8.GetBytes(json))
    };

    try
    {
        var response = await kinesisClient.PutRecordAsync(request);
        Console.WriteLine($"✅ {sensorEvent.DeviceId} @ {sensorEvent.Timestamp} | Temp: {sensorEvent.Temperature} °C | Seq: {response.SequenceNumber}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }

    await Task.Delay(1000);
}

static SensorEvent GenerarEvento()
{
    var random = new Random();
    return new SensorEvent
    {
        DeviceId = $"sensor-{random.Next(1, 5):D3}",
        Temperature = Math.Round(random.NextDouble() * 30 + 10, 2),
        Humidity = Math.Round(random.NextDouble() * 50 + 30, 2),
        Location = $"Zona {random.Next(1, 4)}",
        Timestamp = DateTime.UtcNow,
        BatteryLevel = Math.Round(random.NextDouble() * 100, 1),
        Status = "OK"
    };
}

public class SensorEvent
{
    public string DeviceId { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public string Location { get; set; }
    public DateTime Timestamp { get; set; }
    public double? BatteryLevel { get; set; }
    public string Status { get; set; }
}
