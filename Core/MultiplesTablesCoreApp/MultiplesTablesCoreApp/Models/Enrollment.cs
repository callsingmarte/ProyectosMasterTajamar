using System.ComponentModel.DataAnnotations;

namespace MultiplesTablesCoreApp.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollementId { get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public int CourseId { get; set; }
        public virtual Course? Course { get; set; }
    }
}
