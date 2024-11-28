using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplesTablesCoreApp.Data;
using MultiplesTablesCoreApp.Models;

namespace MultiplesTablesCoreApp.Controllers
{
    public class InstructorController : Controller
    {
        SchoolDbContext? _db;

        public InstructorController(SchoolDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllInstructor()
        {
            var instructors = await _db!.Instructors.ToListAsync();
            return View(instructors);
        }

        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInstructor(Instructor instructor)
        {
            _db!.Add(instructor);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllInstructor");
        }

        public async Task<IActionResult> InstructorDetails(int id)
        {
            Instructor? instructor = await _db!.Instructors.FindAsync(id);
            return View(instructor);
        }
    }
}
