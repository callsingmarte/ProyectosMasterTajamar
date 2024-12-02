using EscuelaNegocios_MartinSanchez.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscuelaNegocios_MartinSanchez.ViewModels
{
    public class StudentClubAddStudentClubViewModel
    {
        public StudentClub? StudentClub { get; set; }
        public SelectList? StudentList { get; set; }
    }
}
