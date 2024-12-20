using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smith_Swimming_School.Data;
using Smith_Swimming_School.Models;

namespace Smith_Swimming_School.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enrollments.Include(e => e.Course).Include(e => e.Grouping).Include(e => e.Swimmer);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> SwimmerEnrollCourse(int idCourse)
        {
            Swimmer swimmer = await _context.Swimmers.SingleOrDefaultAsync(s => s.SwimmerUser == User.Identity.Name);
            if (swimmer == null) {
                return NotFound();
            }
            Course course = await _context.Courses.SingleOrDefaultAsync(c => c.Id_Course == idCourse);
            if (course == null) {
                return NotFound();
            }
            var enrolledCourse = await _context.Enrollments
                .Where(e => e.Id_Course == idCourse && e.Id_Swimmer == swimmer.Id_Swimmer)
                .Include(e => e.Course)
                .Include(e => e.Swimmer)
                .FirstOrDefaultAsync();

            if(enrolledCourse != null)
            {
                //Retornar vista ya esta matriculado en ese curso
                return View("AlreadyEnrolled", enrolledCourse);
            }

            Enrollment enrollment = new Enrollment
            {
                Id_Course = course.Id_Course,
                Id_Swimmer = swimmer.Id_Swimmer
            };

            _context.Enrollments.Add(enrollment);
            //Reducimos el numero de plazas del curso
            course.TotalPlaces--;
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return RedirectToAction("Home", "Swimmers");
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Grouping)
                .Include(e => e.Swimmer)
                .FirstOrDefaultAsync(m => m.Id_Enrollment == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["Id_Course"] = new SelectList(_context.Courses, "Id_Course", "Id_Course");
            ViewData["Id_Grouping"] = new SelectList(_context.Groups, "Id_Grouping", "Name");
            ViewData["Id_Swimmer"] = new SelectList(_context.Swimmers, "Id_Swimmer", "Name");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Enrollment,Id_Course,Id_Swimmer,Id_Grouping")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Course"] = new SelectList(_context.Courses, "Id_Course", "Title", enrollment.Id_Course);
            ViewData["Id_Grouping"] = new SelectList(_context.Groups, "Id_Grouping", "Name", enrollment.Id_Grouping);
            ViewData["Id_Swimmer"] = new SelectList(_context.Swimmers, "Id_Swimmer", "Name", enrollment.Id_Swimmer);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["Id_Course"] = new SelectList(_context.Courses, "Id_Course", "Id_Course", enrollment.Id_Course);
            ViewData["Id_Grouping"] = new SelectList(_context.Groups, "Id_Grouping", "Name", enrollment.Id_Grouping);
            ViewData["Id_Swimmer"] = new SelectList(_context.Swimmers, "Id_Swimmer", "Name", enrollment.Id_Swimmer);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Enrollment,Id_Course,Id_Swimmer,Id_Grouping")] Enrollment enrollment)
        {
            if (id != enrollment.Id_Enrollment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id_Enrollment))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Course"] = new SelectList(_context.Courses, "Id_Course", "Id_Course", enrollment.Id_Course);
            ViewData["Id_Grouping"] = new SelectList(_context.Groups, "Id_Grouping", "Name", enrollment.Id_Grouping);
            ViewData["Id_Swimmer"] = new SelectList(_context.Swimmers, "Id_Swimmer", "Name", enrollment.Id_Swimmer);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Grouping)
                .Include(e => e.Swimmer)
                .FirstOrDefaultAsync(m => m.Id_Enrollment == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.Id_Enrollment == id);
        }
    }
}
