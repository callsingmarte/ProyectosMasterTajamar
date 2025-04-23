namespace PracticaKinesis.Models
{
    public class SensorEvent
    {
        public string DeviceId { get; set; }             // Identificador único del sensor
        public double Temperature { get; set; }          // Temperatura en grados Celsius
        public double Humidity { get; set; }             // Porcentaje de humedad
        public string Location { get; set; }             // Ubicación o zona del sensor
        public DateTime Timestamp { get; set; }          // Fecha y hora del evento (UTC)
        public double? BatteryLevel { get; set; }        // Nivel de batería del sensor (opcional)
        public string Status { get; set; }               // Estado (ej: "OK", "Warning", "Offline")
    }
}
