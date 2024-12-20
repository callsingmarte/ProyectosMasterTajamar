using Smith_Swimming_School.Models;

namespace Smith_Swimming_School.ViewModels
{
    public class SwimmerReportsViewmodel
    {
        public  Swimmer? Swimmer { get; set; }
        public List<Report>? Reports { get; set; }
        public Enrollment? Enrollment { get; set; }
    }
}
