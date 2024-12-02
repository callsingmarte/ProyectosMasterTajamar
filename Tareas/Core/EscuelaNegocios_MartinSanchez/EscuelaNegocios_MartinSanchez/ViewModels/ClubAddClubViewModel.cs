using EscuelaNegocios_MartinSanchez.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscuelaNegocios_MartinSanchez.ViewModels
{
    public class ClubAddClubViewModel
    {
        public Club? Club { get; set; }
        public SelectList? DepartmentList { get; set; }
    }
}
