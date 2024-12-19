using Smith_Swimming_School.Models;

namespace Smith_Swimming_School.ViewModels
{
    public class GroupSwimmersViewModel
    {
        public List<Enrollment>?  Enrollments { get; set; }
        public Course? Course { get; set; }
        public Group? Group { get; set; }
    }
}
