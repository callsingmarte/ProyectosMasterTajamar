using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscuelaNegocios_MartinSanchez.Models
{
    [Table("Clubs")]
    public class Club
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Students { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
