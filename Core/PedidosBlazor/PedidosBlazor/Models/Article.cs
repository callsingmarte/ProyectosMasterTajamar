using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosBlazor.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Category { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
