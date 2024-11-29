using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MultiplesTablesCoreApp.Data;
using MultiplesTablesCoreApp.Models;
using MultiplesTablesCoreApp.ViewModels;

namespace MultiplesTablesCoreApp.Controllers
{
    public class EnrollmentController : Controller
    {
        SchoolDbContext _db;

        public EnrollmentController(SchoolDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //id references courseId
        public async Task<IActionResult> EnrollmentAdd(int id)
        {
            Course? course = await _db.Courses.FindAsync(id);

            var studentsList = await _db.Students.Select(s => new
            {
                Id = s.StudentId,
                Value = s.StudentName
            }).ToListAsync();

            EnrollmentAddViewModel vm = new EnrollmentAddViewModel();
            vm.Course = course;
            vm.StudentList = new SelectList(studentsList, "Id", "Value");

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EnrollmentAdd(EnrollmentAddViewModel vm)
        {
            Enrollment? studentEnrolled = await _db.Enrollments
                .Where(e => e.CourseId == vm.Course!.CourseId && e.StudentId == vm.Student!.StudentId)
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync();

            if (studentEnrolled != null) {
               return View("AlreadyEnrolled", studentEnrolled);
            }
            else
            {
                Course course = await _db.Courses.SingleAsync(c => c.CourseId == vm.Course!.CourseId);

                if (course != null)
                {
                    if(course.SeatCapacity > 0)
                    {
                        Enrollment enrollment = new Enrollment
                        {
                            CourseId = vm.Course!.CourseId,
                            StudentId = vm.Student!.StudentId
                        };
                        _db.Enrollments.Add(enrollment);
                        await _db.SaveChangesAsync();

                        course.SeatCapacity -= 1;
                        _db.Update(course);
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        return View("CourseFilled", course);
                    }
                }

                return RedirectToAction("AllCourse", "Course");
            }
        }

        //id references course id
        public async Task<IActionResult> EnrolledStudents(int id)
        {
            var enrolledStudents = await _db.Enrollments
                .Where(e => e.CourseId == id)
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();

            return View(enrolledStudents);
        }
    }
}
