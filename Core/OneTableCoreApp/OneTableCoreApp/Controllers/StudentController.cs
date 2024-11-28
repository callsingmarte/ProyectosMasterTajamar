using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneTableCoreApp.Data;
using OneTableCoreApp.Models;
namespace OneTableCoreApp.Controllers
{
    public class StudentController : Controller
    {
        StudentDbContext? _db;

        public StudentController(StudentDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> AllStudent()
        {
            var students = await _db!.Students.ToListAsync();
            return View(students);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddStudent() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _db!.Add(student);
            await _db.SaveChangesAsync();

            return RedirectToAction("AllStudent");
        }

        public async Task<IActionResult> EditStudent(int id) 
        {
            Student? student;
            student = await _db!.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            _db!.Update(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllStudent");
        }

        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student? student = await _db!.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student student)
        {
            _db!.Remove(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllStudent");
        }
    }
}
