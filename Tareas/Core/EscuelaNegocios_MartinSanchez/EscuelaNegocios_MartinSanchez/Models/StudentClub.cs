using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscuelaNegocios_MartinSanchez.Models
{
    [Table("StudentsClubs")]
    public class StudentClub
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public int ClubId { get; set; }
        public virtual Club? Club { get; set; }
    }
}
