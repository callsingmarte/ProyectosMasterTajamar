using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscuelaNegocios_MartinSanchez.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? OfficeLocation { get; set; }
        public ICollection<Club>? Clubs { get; set; }
    }
}
