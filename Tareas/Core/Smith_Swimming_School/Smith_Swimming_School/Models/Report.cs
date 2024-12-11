using System.ComponentModel.DataAnnotations;

namespace Smith_Swimming_School.Models
{
    public class Report
    {
        [Key]
        public int Id_Report { get; set; }
        public string? ProgressReport { get; set; }
        public int Id_Enrollment { get; set; }
        public virtual Enrollment? Enrollment { get; set; }
    }
}
