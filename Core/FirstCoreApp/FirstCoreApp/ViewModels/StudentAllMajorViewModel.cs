using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstCoreApp.ViewModels
{
    public class StudentAllMajorViewModel
    {
        public Student? Student { get; set; }
        public Major? Major { get; set; }
        public SelectList? MajorList { get; set; }
    }
}
