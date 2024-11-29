using IdentityUniversityCoreApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityUniversityCoreApp.ViewModels
{
    public class StudentAddEnrollmentViewModel
    {
        public SelectList? CourseList { get; set; }
        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
