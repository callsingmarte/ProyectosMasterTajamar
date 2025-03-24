using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaAzServiceBus.Models
{
    public class Notificacion
    {
        [Key]
        public int NotificacionId { get; set; }
        [ForeignKey("Transaccion")]
        public int TransaccionId { get; set; }
        public virtual Transaccion? Transaccion { get; set; }
        public string? EmailCliente { get; set; }
        public string? EstadoNotificacion { get; set; }
        public DateTime? FechaEnvio { get; set; }
    }
}
