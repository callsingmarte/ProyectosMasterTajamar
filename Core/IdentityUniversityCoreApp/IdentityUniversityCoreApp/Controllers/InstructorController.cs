using IdentityUniversityCoreApp.Data;
using IdentityUniversityCoreApp.Models;
using IdentityUniversityCoreApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IdentityUniversityCoreApp.Controllers
{
    [Authorize(Roles = "Instructor, Admin")]
    public class InstructorController : Controller
    {
        private readonly ApplicationDbContext? _db;

        public InstructorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Registrado"] = false;
            if (User.Identity!.Name != null)
            {
                //dbo.AspNetUsers
                //ahora miro si esta en la tabla de Instructors
                var instructor = await _db!.Instructors.FirstOrDefaultAsync(s => s.InstructorUser == User.Identity.Name);
                if(instructor != null)
                {
                    ViewBag.InstructorId = instructor.InstructorId;
                    ViewData["Registrado"] = true;
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllProfiles()
        {
            var instructors = await _db!.Instructors.ToListAsync();
            return View(instructors);
        }

        public IActionResult AddProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(Instructor instructor)
        {
            _db!.Add(instructor);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllProfiles");
        }

        public async Task<IActionResult> EditProfile(int id)
        {
            var instructorToUpdate = await _db!.Instructors.FirstOrDefaultAsync(i => i.InstructorId == id);

            return View(instructorToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(Instructor instructor)
        {
            _db!.Update(instructor);
            await _db.SaveChangesAsync();

            //Si es Admin redireccionar a AllProfiles sino a Index
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AllProfiles");
            }
            else
            {
                return View("Index");
            }

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCourse()
        {
            var instructorDisplay = await _db!.Instructors.Select(x => new {
                Id = x.InstructorId,
                Value = x.InstructorName
            }).ToListAsync();
            
            InstructorAddCourseViewModel vm = new InstructorAddCourseViewModel();
            vm.InstructorList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(instructorDisplay, "Id", "Value");

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(InstructorAddCourseViewModel vm)
        {
            var instructor = await _db!.Instructors.SingleOrDefaultAsync(i => i.InstructorId == vm.Instructor!.InstructorId);
            vm.Course!.Instructor = instructor;
            _db.Add(vm.Course);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> GradeCourse()
        {
            var currentUserId = User.Identity!.Name;
            Instructor? instructorToShow = await _db!.Instructors.SingleOrDefaultAsync(i => i.InstructorUser == currentUserId);

            if (instructorToShow != null)
            {
                List<Course> listaCursosInstructor = await _db.Courses.Where(c => c.Instructor!.InstructorId == instructorToShow.InstructorId).ToListAsync();

                var cursoDisplay = listaCursosInstructor.Select(x => new
                {
                    Id = x.CourseId,
                    Value = x.CourseTitle
                }).ToList();

                InstructorGradeCourseViewModel vm = new InstructorGradeCourseViewModel();
                vm.CourseList = new SelectList(cursoDisplay, "Id", "Value");
                vm.Instructor = instructorToShow;
                return View(vm);
            }
            else
            {
                return View();
            }
        }

        public async Task<List<Enrollment>> DevuelveMatriculas(int dato)
        {
            List<Enrollment> Matriculados = await _db!.Enrollments.
                    Include(e => e.Student).Where(e => e.Course!.CourseId == dato).ToListAsync();
            return Matriculados;
        }

        public async Task<IActionResult> Califica(int dato, char nota)
        {
            Enrollment? enrollment = await _db!.Enrollments.Where(e => e.Student!.StudentId == dato).FirstOrDefaultAsync();
            if (enrollment != null)
            {
                enrollment.LetterGrade = (LetterGrade)nota;
                _db.Update(enrollment);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Instructor");

        }
    }
}
