using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smith_Swimming_School.Models
{
    public class Enrollment
    {
        [Key]
        public int Id_Enrollment { get; set; }
        [ForeignKey("Course")]
        public int Id_Course { get; set; }
        public virtual Course? Course { get; set; }
        [ForeignKey("Swimmer")]
        public int Id_Swimmer { get; set; }
        public virtual Swimmer? Swimmer { get; set; }
        [ForeignKey("Grouping")]
        public int Id_Grouping { get; set; }
        public virtual Group? Grouping { get; set; }
    }
}
