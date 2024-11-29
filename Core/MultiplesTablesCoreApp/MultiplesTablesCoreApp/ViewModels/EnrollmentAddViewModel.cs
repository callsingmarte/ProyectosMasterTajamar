using Microsoft.AspNetCore.Mvc.Rendering;
using MultiplesTablesCoreApp.Models;

namespace MultiplesTablesCoreApp.ViewModels
{
    public class EnrollmentAddViewModel
    {
        public Course? Course { get; set; }
        public Student? Student { get; set; }
        public SelectList? StudentList { get; set; }
    }
}
