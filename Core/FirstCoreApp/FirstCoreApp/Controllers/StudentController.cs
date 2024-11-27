using FirstCoreApp.Models;
using FirstCoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstCoreApp.Controllers
{
    public class StudentController : Controller
    {
        static List<string> allCourses = new List<string>{};
        static List<Student> allStudents = new List<Student>();

        static List<Major> allMajor = new List<Major>
        {
            new Major(){MajorId = 1, MajorName="Computer Science"},
            new Major(){MajorId = 2, MajorName="Business Computer"},
            new Major(){MajorId = 3, MajorName="Undecided"},
        };

        public IActionResult AllStudent()
        {
            return View(allStudents);
        }

        public IActionResult AddStudent()
        {
            var majorDisplay = allMajor.Select(x => new {Id = x.MajorId, Value=x.MajorName});
            StudentAllMajorViewModel vm = new StudentAllMajorViewModel();
            vm.MajorList = new SelectList(majorDisplay, "Id", "Value"); 
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddStudent(StudentAllMajorViewModel vm)
        {
            var major = allMajor.SingleOrDefault(x => x.MajorId == vm.Major.MajorId);
            vm.Student.Major = major;
 
            allStudents.Add(vm.Student);
            return RedirectToAction("AllStudent");
        }

        public IActionResult Course()
        {
            ViewData["Courses"] = allCourses;
            return View();
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(string courseNumber, string courseTitle)
        {
            string valor = courseNumber + "/" + courseTitle;
            allCourses.Add(valor);

            return RedirectToAction("Course", "Student");
        }

        public IActionResult Index()
        {
            return View();
        }

        public string CheckGrade(string name, int score)
        {
            char letterGrade;
            if(score >= 90)
            {
                letterGrade = 'A';
            }else if(score >= 80)
            {
                letterGrade = 'B';
            }else if(score >= 70)
            {
                letterGrade = 'C';
            }
            else
            {
                letterGrade = 'F';
            }

            return $"{name}'s grade is {letterGrade}";        
        }

        public string PayRate(char grado)
        {
            char letter = grado;
            return $"you should work hard yo get the grade of {letter}";
        }
    }
}
