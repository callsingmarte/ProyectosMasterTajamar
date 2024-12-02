using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscuelaNegocios_MartinSanchez.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? StudentUser { get; set; }
    }
}
