﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smith_Swimming_School.Data;
using Smith_Swimming_School.Models;
using Smith_Swimming_School.ViewModels;

namespace Smith_Swimming_School.Controllers
{
    [Authorize(Roles ="Administrator, Coach, Swimmer")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Courses.Include(c => c.Coach);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Coach)
                .FirstOrDefaultAsync(m => m.Id_Course == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public async Task<IActionResult> CourseGroups(int id)
        {

            if (User.IsInRole("Swimmer"))
            {
                var swimmer = await _context.Swimmers.SingleOrDefaultAsync(s => s.SwimmerUser == User.Identity!.Name);
                if (swimmer == null) {
                    return NotFound();
                }

            }
            else if (User.IsInRole("Coach"))
            {
                var coach = await _context.Coaches.SingleOrDefaultAsync(c => c.CoachUser == User.Identity!.Name);
                if (coach == null) {
                    return NotFound();
                }
            }

            var groups = await _context.Enrollments.Where(e => e.Id_Course == id)
                .Include(e => e.Grouping)
                .Select(e => new CourseGroupEnrollmentViewModel
                {
                    Id_Course = e.Id_Course,
                    Id_Grouping = e.Id_Grouping,
                    Grouping = e.Grouping,
                })
                .Distinct()
                .ToListAsync();

            CourseGroupsViewModel vm = new CourseGroupsViewModel
            {
                courseGroupEnrollment = groups,
                Course = await _context.Courses.SingleAsync(c => c.Id_Course == id)
            };

            return View(vm);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["Id_Coach"] = new SelectList(_context.Coaches, "Id_Coach", "Id_Coach");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Course,Id_Coach,Title,TotalPlaces")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Coach"] = new SelectList(_context.Coaches, "Id_Coach", "Id_Coach", course.Id_Coach);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["Id_Coach"] = new SelectList(_context.Coaches, "Id_Coach", "Id_Coach", course.Id_Coach);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Course,Id_Coach,Title,TotalPlaces")] Course course)
        {
            if (id != course.Id_Course)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id_Course))
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
            ViewData["Id_Coach"] = new SelectList(_context.Coaches, "Id_Coach", "Id_Coach", course.Id_Coach);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Coach)
                .FirstOrDefaultAsync(m => m.Id_Course == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id_Course == id);
        }
    }
}