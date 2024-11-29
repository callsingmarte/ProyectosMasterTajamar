using IdentityUniversityCoreApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityUniversityCoreApp.ViewModels
{
    public class InstructorGradeCourseViewModel
    {
        public Instructor? Instructor { get; set; }
        public Course? Course { get; set; }
        public SelectList? CourseList { get; set; }
    }
}
