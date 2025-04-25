using SampleAPI.Domain;

namespace SampleAPI.Models
{
    public class CourseModel
    {
        public List<Course> coursesList { get; }

        public CourseModel(List<Course> course_list)
        {
            coursesList = course_list;
        }

    }
}
