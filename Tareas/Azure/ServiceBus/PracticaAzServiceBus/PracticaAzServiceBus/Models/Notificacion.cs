namespace PracticaAzServiceBus.Models
{
    public class Notificacion
    {
        public int NotificacionId { get; set; }
        public int TransaccionId { get; set; }
        public virtual Transaccion? Transaccion { get; set; }
        public string? EmailCliente { get; set; }
        public string? EstadoNotificacion { get; set; }
        public DateTime? FechaEnvio { get; set; }
    }
}
