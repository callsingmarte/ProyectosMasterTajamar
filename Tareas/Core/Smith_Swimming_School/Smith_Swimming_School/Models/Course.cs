using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smith_Swimming_School.Models
{
    public class Course
    {
        [Key]
        public int Id_Course { get; set; }
        [ForeignKey("Coach")]
        public int Id_Coach { get; set; }
        public virtual Coach? Coach { get; set; }
        public string? Title { get; set; }
        public int TotalPlaces { get; set; }
    }
}
