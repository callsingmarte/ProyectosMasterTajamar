using System.ComponentModel.DataAnnotations;

namespace Smith_Swimming_School.Models
{
    public class Enrollment
    {
        [Key]
        public int Id_Enrollment { get; set; }
        public int Id_Course { get; set; }
        public virtual Course? Course { get; set; }
        public int Id_Swimmer { get; set; }
        public virtual Swimmer? Swimmer { get; set; }
        public int Id_Grouping { get; set; }
        public virtual Group? Grouping { get; set; }
    }
}
