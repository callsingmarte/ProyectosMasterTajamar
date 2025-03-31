using System.ComponentModel.DataAnnotations;

namespace PracticaAzServiceBus.Models
{
    public class Transaccion
    {
        [Key]
        public int TransaccionId { get; set; }
        [Display(Name = "Monto")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public decimal Monto  { get; set; }
        public string? TipoTransaccion { get; set; }
        [Display(Name = "Cuenta Destino")]
        [RegularExpression(@"^[A-Z]{2}\d{22}$", ErrorMessage = "Formato de cuenta bancaria inválido (IBAN).")]
        public string? CuentaDestino { get; set; }
        public string? DetallesAdicionales { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaProcesamiento { get; set; }
        public DateTime? FechaNotificacion { get; set; }
    }
}
