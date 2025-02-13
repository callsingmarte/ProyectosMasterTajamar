using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientsInvoices.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ClientId")]
        public int? ClientId { get; set; }
        public virtual Client? Client { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Title { get; set; }
    }
}
