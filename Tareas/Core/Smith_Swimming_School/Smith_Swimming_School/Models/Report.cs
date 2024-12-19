using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smith_Swimming_School.Models
{
    public class Report
    {
        [Key]
        public int Id_Report { get; set; }
        public string? ProgressReport { get; set; }
        [ForeignKey("Enrollment")]
        public int Id_Enrollment { get; set; }
        public virtual Enrollment? Enrollment { get; set; }
    }
}
