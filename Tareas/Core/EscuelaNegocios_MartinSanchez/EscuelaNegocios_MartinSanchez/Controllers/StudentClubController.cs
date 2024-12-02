using EscuelaNegocios_MartinSanchez.Data;
using EscuelaNegocios_MartinSanchez.Models;
using EscuelaNegocios_MartinSanchez.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EscuelaNegocios_MartinSanchez.Controllers
{
    public class StudentClubController : Controller
    {
        private readonly ApplicationDbContext? _db;

        public StudentClubController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> ClubStudents(int id)
        {
            Club? club = await _db!.Clubs.SingleOrDefaultAsync(c => c.Id == id);
            ViewBag.ClubName = club!.Name;

            var clubStudents = await _db!.StudentsClubs
                .Where(sc => sc.ClubId == id)
                .Include(sc => sc.Student)
                .ToListAsync();

            return View(clubStudents);
        }

        public async Task<IActionResult> AddStudentClub(int clubId)
        {
            var studentsList = await _db!.Students.Select(s => new
            {
                Id = s.Id,
                Value = s.Name
            }).ToListAsync();

            StudentClubAddStudentClubViewModel vm = new StudentClubAddStudentClubViewModel();
            vm.StudentList = new SelectList(studentsList, "Id", "Value");

            Club? club = await _db!.Clubs.SingleOrDefaultAsync(c => c.Id == clubId);
            vm.StudentClub = new StudentClub
            {
                ClubId = clubId,
                Club = club
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentClub(StudentClubAddStudentClubViewModel vm)
        {
            var studentClub = await _db!.StudentsClubs.Where(sc => sc.StudentId == vm.StudentClub!.StudentId && sc.ClubId == vm.StudentClub.ClubId).SingleOrDefaultAsync();
            Club? club = await _db.Clubs.SingleOrDefaultAsync(c => c.Id == vm.StudentClub!.ClubId);
            Student? student = await _db!.Students.SingleAsync(s => s.Id == vm.StudentClub!.StudentId);
            vm.StudentClub!.Club = club;
            vm.StudentClub!.Student = student;
            if (studentClub != null)
            {
                return View("StudentAlreadyInClub", vm);
            }
            else
            {

                _db.StudentsClubs.Add(vm.StudentClub!);
                club!.Students++;
                _db.Clubs.Update(club);

                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Club");
            }
        }
    }
}
