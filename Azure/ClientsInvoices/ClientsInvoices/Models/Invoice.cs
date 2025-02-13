using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientsInvoices.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public Decimal? AmountDue { get; set; }
        public DateTime? DueDate { get; set; }
        [ForeignKey("ProjectID")]
        public int? ProjectID { get; set; }
        public virtual Project? Project { get; set; }
    }
}
