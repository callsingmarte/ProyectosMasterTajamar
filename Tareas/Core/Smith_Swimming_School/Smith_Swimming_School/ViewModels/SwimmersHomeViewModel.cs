using Smith_Swimming_School.Models;

namespace Smith_Swimming_School.ViewModels
{
    public class SwimmersHomeViewModel
    {
        public List<SwimmerCoursesViewModel>  Courses { get; set; }
        public Swimmer Swimmer { get; set; }
    }
}
