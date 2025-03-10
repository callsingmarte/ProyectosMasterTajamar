using System.ComponentModel.DataAnnotations;

namespace PracticaAzServiceBus.Models
{
    public class Transaccion
    {
        [Key]
        public int TransaccionId { get; set; }
        public decimal Monto  { get; set; }
        public string? TipoTransaccion { get; set; }
        public string? CuentaDestino { get; set; }
        public string? DetallesAdicionales { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaProcesamiento { get; set; }
        public DateTime? FechaNotificacion { get; set; }
    }
}
