using System.ComponentModel.DataAnnotations;

namespace Smith_Swimming_School.Models
{
    public class Course
    {
        [Key]
        public int Id_Course { get; set; }
        public int Id_Coach { get; set; }
        public virtual Coach? Coach { get; set; }
        public string? Title { get; set; }
        public int TotalPlaces { get; set; }
    }
}
