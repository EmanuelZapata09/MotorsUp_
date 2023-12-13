using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorsUp_.Models;

namespace MotorsUp_.Controllers
{
    public class AgendamientoCitasController : Controller
    {
        private readonly tallerContext _context;

        public AgendamientoCitasController(tallerContext context)
        {
            _context = context;
        }

        // GET: AgendamientoCitas
        public async Task<IActionResult> Index()
        {
            var tallerContext = _context.AgendamientoCitas.Include(a => a.IdCotizacionNavigation).Include(a => a.IdEstadoNavigation).Include(a => a.IdPersonaNavigation);
            return View(await tallerContext.ToListAsync());
        }

        // GET: AgendamientoCitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AgendamientoCitas == null)
            {
                return NotFound();
            }

            var agendamientoCita = await _context.AgendamientoCitas
                .Include(a => a.IdCotizacionNavigation)
                .Include(a => a.IdEstadoNavigation)
                .Include(a => a.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdAgendamiento == id);
            if (agendamientoCita == null)
            {
                return NotFound();
            }

            return View(agendamientoCita);
        }

        // GET: AgendamientoCitas/Create
        public IActionResult Create()
        {
            ViewData["IdCotizacion"] = new SelectList(_context.Cotizaciones, "IdCotizacion", "IdCotizacion");
            ViewData["IdEstado"] = new SelectList(_context.EstadoCitas, "IdEstado", "IdEstado");
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: AgendamientoCitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgendamiento,Fecha,Hora,IdCotizacion,IdPersona,IdEstado")] AgendamientoCita agendamientoCita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamientoCita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCotizacion"] = new SelectList(_context.Cotizaciones, "IdCotizacion", "IdCotizacion", agendamientoCita.IdCotizacion);
            ViewData["IdEstado"] = new SelectList(_context.EstadoCitas, "IdEstado", "IdEstado", agendamientoCita.IdEstado);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", agendamientoCita.IdPersona);
            return View(agendamientoCita);
        }

        // GET: AgendamientoCitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AgendamientoCitas == null)
            {
                return NotFound();
            }

            var agendamientoCita = await _context.AgendamientoCitas.FindAsync(id);
            if (agendamientoCita == null)
            {
                return NotFound();
            }
            ViewData["IdCotizacion"] = new SelectList(_context.Cotizaciones, "IdCotizacion", "IdCotizacion", agendamientoCita.IdCotizacion);
            ViewData["IdEstado"] = new SelectList(_context.EstadoCitas, "IdEstado", "IdEstado", agendamientoCita.IdEstado);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", agendamientoCita.IdPersona);
            return View(agendamientoCita);
        }

        // POST: AgendamientoCitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAgendamiento,Fecha,Hora,IdCotizacion,IdPersona,IdEstado")] AgendamientoCita agendamientoCita)
        {
            if (id != agendamientoCita.IdAgendamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamientoCita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamientoCitaExists(agendamientoCita.IdAgendamiento))
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
            ViewData["IdCotizacion"] = new SelectList(_context.Cotizaciones, "IdCotizacion", "IdCotizacion", agendamientoCita.IdCotizacion);
            ViewData["IdEstado"] = new SelectList(_context.EstadoCitas, "IdEstado", "IdEstado", agendamientoCita.IdEstado);
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", agendamientoCita.IdPersona);
            return View(agendamientoCita);
        }

        // GET: AgendamientoCitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AgendamientoCitas == null)
            {
                return NotFound();
            }

            var agendamientoCita = await _context.AgendamientoCitas
                .Include(a => a.IdCotizacionNavigation)
                .Include(a => a.IdEstadoNavigation)
                .Include(a => a.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdAgendamiento == id);
            if (agendamientoCita == null)
            {
                return NotFound();
            }

            return View(agendamientoCita);
        }

        // POST: AgendamientoCitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AgendamientoCitas == null)
            {
                return Problem("Entity set 'tallerContext.AgendamientoCitas'  is null.");
            }
            var agendamientoCita = await _context.AgendamientoCitas.FindAsync(id);
            if (agendamientoCita != null)
            {
                _context.AgendamientoCitas.Remove(agendamientoCita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamientoCitaExists(int id)
        {
          return (_context.AgendamientoCitas?.Any(e => e.IdAgendamiento == id)).GetValueOrDefault();
        }
    }
}
