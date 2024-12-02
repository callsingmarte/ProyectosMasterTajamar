using EscuelaNegocios_MartinSanchez.Data;
using EscuelaNegocios_MartinSanchez.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscuelaNegocios_MartinSanchez.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext? _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _db!.Students.ToListAsync();

            return View(students);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _db!.Add(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
