using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplesTablesCoreApp.Data;
using MultiplesTablesCoreApp.Models;

namespace MultiplesTablesCoreApp.Controllers
{
    public class StudentController : Controller
    {
        SchoolDbContext db;
        public StudentController(SchoolDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> AllStudent()
        {
            var student = await db.Students.ToListAsync();
            return View(student);
        }
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            db.Add(student);
            await db.SaveChangesAsync();
            return RedirectToAction("AllStudent");
        }
        public async Task<ActionResult> EnrollCourse(int? id)
        {
            var course = await db.Courses.SingleOrDefaultAsync(c => c.CourseId == id);
            ViewBag.Course = course;
            return View();
        }
    }
}
