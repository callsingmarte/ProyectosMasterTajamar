using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplesTablesCoreApp.Data;
using MultiplesTablesCoreApp.ViewModels;

namespace MultiplesTablesCoreApp.Controllers
{
    public class CourseController : Controller
    {
        SchoolDbContext? _db;

        public CourseController(SchoolDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllCourse()
        {
            var courses = await _db!.Courses.Include(c => c.Instructor).ToListAsync();

            return View(courses);
        }

        public async Task<IActionResult> AddCourse()
        {
            var instructorDisplay = await _db!.Instructors.Select(x => new
            {
                Id = x.InstructorId, 
                Value = x.InstructorName
            }).ToListAsync();

            CourseAddCourseViewModel vm = new CourseAddCourseViewModel();
            vm.InstructorList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(instructorDisplay, "Id", "Value");

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseAddCourseViewModel vm)
        {
            var instructor = await _db!.Instructors.SingleOrDefaultAsync(i => i.InstructorId == vm.Instructor!.InstructorId);

            vm.Course!.Instructor = instructor;

            _db.Add(vm.Course);
            await _db.SaveChangesAsync();

            return RedirectToAction("AllCourse");
        }

    }
}
