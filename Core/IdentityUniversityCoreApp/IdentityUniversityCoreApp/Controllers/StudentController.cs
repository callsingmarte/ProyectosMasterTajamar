using Humanizer;
using IdentityUniversityCoreApp.Data;
using IdentityUniversityCoreApp.Models;
using IdentityUniversityCoreApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IdentityUniversityCoreApp.Controllers
{
    [Authorize(Roles = "Student, Admin")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Registrado"] = false;
            if (User.Identity!.Name != null)
            {
                //Esta en la tabla de usuarios
                //ahora miramos si esta en la tabla de Students
                var student = await _db.Students.FirstOrDefaultAsync(s => s.StudentUser == User.Identity.Name);
                if (student != null)
                {
                    //Existe en la de Students tambien
                    ViewBag.StudentId = student.StudentId;
                    ViewData["Registrado"] = true;
                }
            }
            return View();
        }

        public async Task<IActionResult> EditProfile()
        {
            var user = User.Identity!.Name;
            var studentToUpdate = await _db.Students.FirstOrDefaultAsync(es => es.StudentUser == user);
            return View(studentToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(Student student)
        {
            _db.Update(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult AddProfile()
        {
            var currentUserId = User.Identity!.Name;
            Student student = new Student();
            student.StudentUser = currentUserId;

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(Student student)
        {
            _db.Add(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EnrollCourse()
        {
            var currentUserId = User.Identity?.Name;
            Student? studentToShow = await _db.Students.FirstOrDefaultAsync(s => s.StudentUser == currentUserId);

            var courseDislay = await _db.Courses.Select(c => new
            {
                Id = c.CourseId,
                Value = c.CourseTitle
            }).ToListAsync();

            StudentAddEnrollmentViewModel vm = new StudentAddEnrollmentViewModel();
            vm.CourseList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(courseDislay, "Id", "Value");
            vm.Student = studentToShow;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EnrollCourse(StudentAddEnrollmentViewModel vm)
        {
            Course? course = await _db.Courses.Where(c => c.CourseId == vm.Course!.CourseId)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync();
            Student? student = await _db.Students.FirstOrDefaultAsync(es => es.StudentId == vm.Student!.StudentId);
            //Comprobar que el estudiante no este ya matriculado en este curso

            Enrollment? yaMatriculado = _db.Enrollments
                .Where(es => es.Student == student && es.Course == course)
                .FirstOrDefault();

            if (yaMatriculado != null) 
            {
                //Mostramos una vista diciendo que esta ya matriculado
            }
            else
            {
                //Comprobamos si hay plazas
                if(course!.SeatCapacity > 0)
                {
                    Enrollment enrollment = new Enrollment();
                    enrollment.Student = student;
                    enrollment.Course = course;
                    _db.Add(enrollment);

                    //disminucion de plazas
                    course.SeatCapacity--;
                    _db.Update(course);

                    await _db.SaveChangesAsync();
                }
                else
                {
                    //Mostramos una vista diciendo que no hay plazas
                }
            }
            return RedirectToAction("Index");
        }

        public int? DevuelveCapacidad(int dato)
        {
            Course? course = _db.Courses.Where(_c => _c.CourseId == dato).FirstOrDefault();
            if (course != null)
            {
                return course.SeatCapacity;
            }
            else
            {
                return null;
            }
        }
    }
}
