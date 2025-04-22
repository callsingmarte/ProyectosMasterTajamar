using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaAwsSnS.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public int Cantidad { get; set; } = 1;
        public decimal Precio { get; set; }
    }
}
