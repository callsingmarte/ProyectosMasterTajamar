using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcAppAws_MartinSanchez.Data;
using MvcAppAws_MartinSanchez.Interfaces;
using MvcAppAws_MartinSanchez.Models;

namespace MvcAppAws_MartinSanchez.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly AppDbContext _context;

        public AlumnosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alumnos.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            var estadosAlumno = new List<SelectListItem>()
            {
                new SelectListItem() { Text = IEstadosAlumnos.Activo, Value = IEstadosAlumnos.Activo },
                new SelectListItem() { Text = IEstadosAlumnos.Finalizado, Value = IEstadosAlumnos.Finalizado },
                new SelectListItem() { Text = IEstadosAlumnos.Espera, Value = IEstadosAlumnos.Espera }
            };

            ViewBag.EstadosAlumno = estadosAlumno;

            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,Matricula,Carrera,EmpresaAsignada,FechaInicio,FechaFin,Estado")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                Alumno ultimoAlumno = await _context.Alumnos.OrderBy(a => a.Id).LastOrDefaultAsync();

                if (ultimoAlumno == null)
                {
                    alumno.Id = 1;
                }
                else
                {
                    alumno.Id = ultimoAlumno.Id + 1;
                }

                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var estadosAlumno = new List<SelectListItem>()
            {
                new SelectListItem() { Text = IEstadosAlumnos.Activo, Value = IEstadosAlumnos.Activo },
                new SelectListItem() { Text = IEstadosAlumnos.Finalizado, Value = IEstadosAlumnos.Finalizado },
                new SelectListItem() { Text = IEstadosAlumnos.Espera, Value = IEstadosAlumnos.Espera }
            };

            ViewBag.EstadosAlumno = estadosAlumno;

            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            var estadosAlumno = new List<SelectListItem>()
            {
                new SelectListItem() { Text = IEstadosAlumnos.Activo, Value = IEstadosAlumnos.Activo },
                new SelectListItem() { Text = IEstadosAlumnos.Finalizado, Value = IEstadosAlumnos.Finalizado },
                new SelectListItem() { Text = IEstadosAlumnos.Espera, Value = IEstadosAlumnos.Espera }
            };

            ViewBag.EstadosAlumno = estadosAlumno;

            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,Matricula,Carrera,EmpresaAsignada,FechaInicio,FechaFin,Estado")] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.Id))
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

            var estadosAlumno = new List<SelectListItem>()
            {
                new SelectListItem() { Text = IEstadosAlumnos.Activo, Value = IEstadosAlumnos.Activo },
                new SelectListItem() { Text = IEstadosAlumnos.Finalizado, Value = IEstadosAlumnos.Finalizado },
                new SelectListItem() { Text = IEstadosAlumnos.Espera, Value = IEstadosAlumnos.Espera }
            };

            ViewBag.EstadosAlumno = estadosAlumno;

            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumnos.Any(e => e.Id == id);
        }
    }
}
