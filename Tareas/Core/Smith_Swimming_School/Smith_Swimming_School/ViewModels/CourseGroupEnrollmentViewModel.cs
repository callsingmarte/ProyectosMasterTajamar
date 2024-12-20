using Smith_Swimming_School.Models;

namespace Smith_Swimming_School.ViewModels
{
    public class CourseGroupEnrollmentViewModel
    {
        public int Id_Enrollment { get; set; }
        public int Id_Course { get; set; }
        public int? Id_Grouping { get; set; }
        public Group? Grouping { get; set; }
    }
}
