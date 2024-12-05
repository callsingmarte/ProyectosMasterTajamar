using System.ComponentModel.DataAnnotations;

namespace PedidosBlazor.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        public int Quantity { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OrderDate { get; set; }
        public int ArticleID { get; set; }
    }
}
