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
    public class RolXpermisoesController : Controller
    {
        private readonly tallerContext _context;

        public RolXpermisoesController(tallerContext context)
        {
            _context = context;
        }

        // GET: RolXpermisoes
        public async Task<IActionResult> Index()
        {
            var tallerContext = _context.RolXpermisos.Include(r => r.IdPermisoNavigation).Include(r => r.IdRolNavigation);
            return View(await tallerContext.ToListAsync());
        }

        // GET: RolXpermisoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RolXpermisos == null)
            {
                return NotFound();
            }

            var rolXpermiso = await _context.RolXpermisos
                .Include(r => r.IdPermisoNavigation)
                .Include(r => r.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdRolXpermiso == id);
            if (rolXpermiso == null)
            {
                return NotFound();
            }

            return View(rolXpermiso);
        }

        // GET: RolXpermisoes/Create
        public IActionResult Create()
        {
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso");
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return View();
        }

        // POST: RolXpermisoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRolXpermiso,IdRol,IdPermiso")] RolXpermiso rolXpermiso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolXpermiso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", rolXpermiso.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", rolXpermiso.IdRol);
            return View(rolXpermiso);
        }

        // GET: RolXpermisoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RolXpermisos == null)
            {
                return NotFound();
            }

            var rolXpermiso = await _context.RolXpermisos.FindAsync(id);
            if (rolXpermiso == null)
            {
                return NotFound();
            }
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", rolXpermiso.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", rolXpermiso.IdRol);
            return View(rolXpermiso);
        }

        // POST: RolXpermisoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRolXpermiso,IdRol,IdPermiso")] RolXpermiso rolXpermiso)
        {
            if (id != rolXpermiso.IdRolXpermiso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolXpermiso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolXpermisoExists(rolXpermiso.IdRolXpermiso))
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
            ViewData["IdPermiso"] = new SelectList(_context.Permisos, "IdPermiso", "IdPermiso", rolXpermiso.IdPermiso);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", rolXpermiso.IdRol);
            return View(rolXpermiso);
        }

        // GET: RolXpermisoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RolXpermisos == null)
            {
                return NotFound();
            }

            var rolXpermiso = await _context.RolXpermisos
                .Include(r => r.IdPermisoNavigation)
                .Include(r => r.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdRolXpermiso == id);
            if (rolXpermiso == null)
            {
                return NotFound();
            }

            return View(rolXpermiso);
        }

        // POST: RolXpermisoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RolXpermisos == null)
            {
                return Problem("Entity set 'tallerContext.RolXpermisos'  is null.");
            }
            var rolXpermiso = await _context.RolXpermisos.FindAsync(id);
            if (rolXpermiso != null)
            {
                _context.RolXpermisos.Remove(rolXpermiso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolXpermisoExists(int id)
        {
          return (_context.RolXpermisos?.Any(e => e.IdRolXpermiso == id)).GetValueOrDefault();
        }
    }
}
