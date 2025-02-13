using System.ComponentModel.DataAnnotations;

namespace ClientsInvoices.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
