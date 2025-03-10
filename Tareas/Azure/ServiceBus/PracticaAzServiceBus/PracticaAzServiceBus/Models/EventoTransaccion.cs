using System.ComponentModel.DataAnnotations;

namespace PracticaAzServiceBus.Models
{
    public class EventoTransaccion
    {
        [Key]
        public int EventoId  { get; set; }
        public int TransaccionId { get; set; }
        public virtual Transaccion? Transaccion { get; set; }
        public string? TipoEvento { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaEvento { get; set; }
    }
}
