using Smith_Swimming_School.Models;

namespace Smith_Swimming_School.ViewModels
{
    public class CourseGroupsViewModel
    {
        public List<CourseGroupEnrollmentViewModel> courseGroupEnrollment { get; set; }
        public Course Course { get; set; }
    }
}
