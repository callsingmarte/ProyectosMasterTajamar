using EscuelaNegocios_MartinSanchez.Data;
using EscuelaNegocios_MartinSanchez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscuelaNegocios_MartinSanchez.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext? _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _db!.Departments.ToListAsync();
            return View(departments);
        }

        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            _db!.Add(department);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DepartmentDetails(int id)
        {
            Department? department = await _db!.Departments.SingleOrDefaultAsync(d => d.Id == id);

            return View(department);
        }

    }
}
