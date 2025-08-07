using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly LibrosDBContext _context;

        public PrestamosController(LibrosDBContext context)
        {
            _context = context;
        }

        // GET: Prestamos
        public async Task<IActionResult> Index()
        {
            // Incluye los libros relacionados
            var prestamos = await _context.Prestamos
                .Include(p => p.Libro)
                .ToListAsync();

            // Separa los préstamos en activos y devueltos
            var prestamosActivos = prestamos.Where(p => p.Libro != null && !p.Libro.Disponible).ToList();
            var prestamosDevueltos = prestamos.Where(p => p.Libro != null && p.Libro.Disponible).ToList();

            // Usa una ViewModel para enviar ambos
            var viewModel = new PrestamosIndexViewModel
            {
                PrestamosActivos = prestamosActivos,
                PrestamosDevueltos = prestamosDevueltos
            };

            return View(viewModel);
        }

        // GET: Prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamos/Create
        public IActionResult Create()
        {
            // Solo mostrar libros que están disponibles
            var librosDisponibles = _context.Libros
                .Where(l => l.Disponible)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Titulo
                }).ToList();

            ViewBag.Libros = librosDisponibles;

            return View();
        }


        // POST: Prestamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LibroId,Estudiante,FechaPrestamo,FechaDevolucion")] Prestamo prestamo)
        {
            // Validación personalizada
            if (prestamo.FechaDevolucion <= prestamo.FechaPrestamo)
            {
                ModelState.AddModelError("FechaDevolucion", "La fecha de devolución debe ser mayor que la fecha de préstamo.");
            }

            if (ModelState.IsValid)
            {
                // Marcar libro como NO disponible
                var libro = await _context.Libros.FindAsync(prestamo.LibroId);
                if (libro != null)
                {
                    libro.Disponible = false;
                }

                _context.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores, volver a cargar libros en el ViewBag
            ViewBag.Libros = _context.Libros
                .Where(l => l.Disponible)
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Titulo
                }).ToList();

            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LibroId,Estudiante,FechaPrestamo,FechaDevolucion")] Prestamo prestamo)
        {
            if (id != prestamo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.Id))
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
            return View(prestamo);
        }

        //POST: Prestamos/Devolver/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Devolver(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            // Marcar libro como disponible
            var libro = await _context.Libros.FindAsync(prestamo.LibroId);
            if (libro != null)
            {
                libro.Disponible = true;
            }

            // Eliminar el préstamo (opcional) o mantenerlo como historial
            //_context.Prestamos.Remove(prestamo);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.Id == id);
        }
    }
}
