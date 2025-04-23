using PracticaKinesis.Models;
using System.Text.Json;

namespace PracticaKinesis.Services
{
    public class SensorEventParser
    {
        public static SensorEvent? ParseJson(string json)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return JsonSerializer.Deserialize<SensorEvent>(json, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar evento: {ex.Message}");
                return null;
            }
        }
    }
}
