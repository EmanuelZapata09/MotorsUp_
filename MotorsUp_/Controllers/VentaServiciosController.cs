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
    public class VentaServiciosController : Controller
    {
        private readonly tallerContext _context;

        public VentaServiciosController(tallerContext context)
        {
            _context = context;
        }

        // GET: VentaServicios
        public async Task<IActionResult> Index()
        {
            var tallerContext = _context.VentaServicios.Include(v => v.IdClienteNavigation);
            return View(await tallerContext.ToListAsync());
        }

        // GET: VentaServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VentaServicios == null)
            {
                return NotFound();
            }

            var ventaServicio = await _context.VentaServicios
                .Include(v => v.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaServicio == id);
            if (ventaServicio == null)
            {
                return NotFound();
            }

            return View(ventaServicio);
        }

        // GET: VentaServicios/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            return View();
        }

        // POST: VentaServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaServicio,FechaHora,EstadoVenta,MetodoPago,ValorManoDeObra,ValorInsumos,Total,IdCliente,IdCotizacion")] VentaServicio ventaServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventaServicio.IdCliente);
            return View(ventaServicio);
        }

        // GET: VentaServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VentaServicios == null)
            {
                return NotFound();
            }

            var ventaServicio = await _context.VentaServicios.FindAsync(id);
            if (ventaServicio == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventaServicio.IdCliente);
            return View(ventaServicio);
        }

        // POST: VentaServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVentaServicio,FechaHora,EstadoVenta,MetodoPago,ValorManoDeObra,ValorInsumos,Total,IdCliente,IdCotizacion")] VentaServicio ventaServicio)
        {
            if (id != ventaServicio.IdVentaServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaServicioExists(ventaServicio.IdVentaServicio))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventaServicio.IdCliente);
            return View(ventaServicio);
        }

        // GET: VentaServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VentaServicios == null)
            {
                return NotFound();
            }

            var ventaServicio = await _context.VentaServicios
                .Include(v => v.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaServicio == id);
            if (ventaServicio == null)
            {
                return NotFound();
            }

            return View(ventaServicio);
        }

        // POST: VentaServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VentaServicios == null)
            {
                return Problem("Entity set 'tallerContext.VentaServicios'  is null.");
            }
            var ventaServicio = await _context.VentaServicios.FindAsync(id);
            if (ventaServicio != null)
            {
                _context.VentaServicios.Remove(ventaServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaServicioExists(int id)
        {
          return (_context.VentaServicios?.Any(e => e.IdVentaServicio == id)).GetValueOrDefault();
        }
    }
}
