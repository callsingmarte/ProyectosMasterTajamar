using Microsoft.AspNetCore.Mvc.Rendering;
using MultiplesTablesCoreApp.Models;

namespace MultiplesTablesCoreApp.ViewModels
{
    public class CourseAddCourseViewModel
    {
        public Course? Course { get; set; }
        public Instructor? Instructor { get; set; }
        public SelectList? InstructorList { get; set; }
    }
}
