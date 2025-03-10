namespace PracticaAzServiceBus.Models
{
    public class ColaTransaccionesNoEntregadas
    {
        public int? TransaccionId { get; set; }
        public string? Error { get; set; }
        public DateTime? FechaError { get; set; }
    }
}
