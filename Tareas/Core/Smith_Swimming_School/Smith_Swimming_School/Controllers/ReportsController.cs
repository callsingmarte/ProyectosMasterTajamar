using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smith_Swimming_School.Data;
using Smith_Swimming_School.Models;
using Smith_Swimming_School.ViewModels;

namespace Smith_Swimming_School.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reports.Include(r => r.Enrollment);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> SwimmerReports(int id)
        {
            Swimmer? swimmer = null;
            if (User.IsInRole("Swimmer"))
            {
                swimmer = await _context.Swimmers.SingleOrDefaultAsync(s => s.SwimmerUser == User.Identity!.Name);
                if (swimmer == null) {
                    return NotFound();
                }
            }
            var enrollment = await _context.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Grouping)
                .SingleOrDefaultAsync(e => e.Id_Enrollment == id);
            var swimmerReports = await _context.Reports.Where(r => r.Id_Enrollment == id).ToListAsync();

            SwimmerReportsViewmodel vm = new SwimmerReportsViewmodel
            {
                Swimmer = swimmer,
                Reports = swimmerReports,
                Enrollment = enrollment
            };

            return View(vm);
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports
                .Include(r => r.Enrollment)
                .FirstOrDefaultAsync(m => m.Id_Report == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            ViewData["Id_Enrollment"] = new SelectList(_context.Enrollments, "Id_Enrollment", "Id_Enrollment");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Report,ProgressReport,Id_Enrollment")] Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Enrollment"] = new SelectList(_context.Enrollments, "Id_Enrollment", "Id_Enrollment", report.Id_Enrollment);
            return View(report);
        }
        public async Task<IActionResult> CreateReportFromEnrollment(int enrollmentId)
        {

            ReportEnrollmentViewModel vm = new ReportEnrollmentViewModel
            {
                Enrollment = await _context.Enrollments
                .Where(e => e.Id_Enrollment == enrollmentId)
                .Include(e => e.Grouping)
                .Include(e => e.Course)
                .Include(e => e.Swimmer)
                .SingleAsync(),
                Report = new Report
                {
                    Id_Enrollment = enrollmentId,
                }
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateReportFromEnrollment([Bind("Id_Report,ProgressReport,Id_Enrollment")] Report report)
        {
            var enrollement = await _context.Enrollments.SingleOrDefaultAsync(e => e.Id_Enrollment == report.Id_Enrollment);

            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction("GroupSwimmers", "Groups", new
                {
                    idCourse = enrollement.Id_Course,
                    idGroup = enrollement.Id_Grouping
                }
                );
            }

            return RedirectToAction("GroupSwimmers", "Groups", new
            {
                idCourse = enrollement.Id_Course,
                idGroup = enrollement.Id_Grouping
            }
            );
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            ViewData["Id_Enrollment"] = new SelectList(_context.Enrollments, "Id_Enrollment", "Id_Enrollment", report.Id_Enrollment);
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Report,ProgressReport,Id_Enrollment")] Report report)
        {
            if (id != report.Id_Report)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.Id_Report))
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
            ViewData["Id_Enrollment"] = new SelectList(_context.Enrollments, "Id_Enrollment", "Id_Enrollment", report.Id_Enrollment);
            return View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports
                .Include(r => r.Enrollment)
                .FirstOrDefaultAsync(m => m.Id_Report == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
            return _context.Reports.Any(e => e.Id_Report == id);
        }
    }
}
