using IdentityUniversityCoreApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityUniversityCoreApp.ViewModels
{
    public class InstructorAddCourseViewModel
    {
        public Course? Course { get; set; }
        public Instructor? Instructor { get; set; }
        public SelectList? InstructorList { get; set; }
    }
}
