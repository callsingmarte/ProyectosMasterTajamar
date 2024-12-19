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
    public class SwimmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SwimmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Home()
        {
            var swimmer = await _context.Swimmers.SingleOrDefaultAsync(s => s.SwimmerUser == User.Identity.Name);
            if (swimmer == null) {
                return NotFound();
            }
            else
            {
                //Muestra listado de cursos del nadador
                var swimmerCourses = await _context.Enrollments
                    .Where(e => e.Id_Swimmer == swimmer.Id_Swimmer)
                    .Include(e => e.Course)
                    .Select(e => new SwimmerCoursesViewModel
                    {
                        Course = e.Course,
                    }).Distinct()
                    .ToListAsync();

                SwimmersHomeViewModel vm = new SwimmersHomeViewModel
                {
                    Courses = swimmerCourses,
                    Swimmer = swimmer
                };

                return View(vm);
            }
        }

        // GET: Swimmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Swimmers.ToListAsync());
        }

        // GET: Swimmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swimmer = await _context.Swimmers
                .FirstOrDefaultAsync(m => m.Id_Swimmer == id);
            if (swimmer == null)
            {
                return NotFound();
            }

            return View(swimmer);
        }

        // GET: Swimmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Swimmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Swimmer,Name,Phone_Number,SwimmerUser,Genre,Birth_Date")] Swimmer swimmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(swimmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(swimmer);
        }

        // GET: Swimmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swimmer = await _context.Swimmers.FindAsync(id);
            if (swimmer == null)
            {
                return NotFound();
            }
            return View(swimmer);
        }

        // POST: Swimmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Swimmer,Name,Phone_Number,SwimmerUser,Genre,Birth_Date")] Swimmer swimmer)
        {
            if (id != swimmer.Id_Swimmer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(swimmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SwimmerExists(swimmer.Id_Swimmer))
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
            return View(swimmer);
        }

        // GET: Swimmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var swimmer = await _context.Swimmers
                .FirstOrDefaultAsync(m => m.Id_Swimmer == id);
            if (swimmer == null)
            {
                return NotFound();
            }

            return View(swimmer);
        }

        // POST: Swimmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var swimmer = await _context.Swimmers.FindAsync(id);
            if (swimmer != null)
            {
                _context.Swimmers.Remove(swimmer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SwimmerExists(int id)
        {
            return _context.Swimmers.Any(e => e.Id_Swimmer == id);
        }
    }
}
