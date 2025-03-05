using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductosWebAPI.Models
{
    public class Products_DB
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey(nameof(CategoryID))]
        public virtual Categories_DB? Category { get; set; }
        public decimal Price { get; set; }
    }
}
