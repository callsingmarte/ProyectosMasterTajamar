using EscuelaNegocios_MartinSanchez.Data;
using EscuelaNegocios_MartinSanchez.Models;
using EscuelaNegocios_MartinSanchez.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EscuelaNegocios_MartinSanchez.Controllers
{
    [Authorize(Roles = "Admin, Student")]
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext? _db;

        public ClubController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _db!.Clubs.Include(c => c.Department).ToListAsync();
            return View(clubs);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddClub() 
        {
            var departmentList = await _db!.Departments.Select(d => new
            {
                Id = d.Id,
                Value = d.Name
            }).ToListAsync();

            ClubAddClubViewModel vm = new ClubAddClubViewModel();
            vm.DepartmentList = new SelectList(departmentList, "Id", "Value");

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddClub(Club club)
        {
            _db!.Clubs.Add(club);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
