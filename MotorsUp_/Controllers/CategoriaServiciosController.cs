using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorsUp_.Models;

namespace MotorsUp_.Controllers
{
    public class CategoriaServiciosController : Controller
    {
        private readonly tallerContext _context;

        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";

        public int pageSize, skip, recordsTotal;

        public CategoriaServiciosController(tallerContext context)
        {
            _context = context;
        }

        // GET: CategoriaServicios
        public async Task<IActionResult> Index(int? pag)
        {
            var categoriasServicios = from CategoriaServicio in _context.CategoriaServicios select CategoriaServicio;

            return _context.CategoriaServicios != null ?
                          View(await _context.CategoriaServicios.ToListAsync()) :
                          Problem("Entity set 'tallerContext.CategoriaServicios'  is null.");
        }

        /*public ActionResult Index()
        {

            List<CategoriaServicio> csm = new List<CategoriaServicio>();

            

            pageSize = !string.IsNullOrEmpty(length) ? Convert.ToInt32(length) : 0;
            skip = !string.IsNullOrEmpty(start) ? Convert.ToInt32(start) : 0;
            recordsTotal = 0;

            using (tallerContext db = new tallerContext())
            {
                csm = (from d in db.CategoriaServicios
                       select new CategoriaServicio
                       {
                           NombreCategoria = d.NombreCategoria,
                           EstadoCategoria = d.EstadoCategoria
                       }).ToList();
                recordsTotal = csm.Count();

                csm = csm.Skip(skip).Take(pageSize).ToList().ToList();
            }
            return Json(new {draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data =  csm});
        }*/

        // GET: CategoriaServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoriaServicios == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }

            return View(categoriaServicio);
        }

        // GET: CategoriaServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,NombreCategoria,EstadoCategoria")] CategoriaServicio categoriaServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categoriaServicio);
        }

        // GET: CategoriaServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoriaServicios == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios.FindAsync(id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }
            return View(categoriaServicio);
        }

        // POST: CategoriaServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,NombreCategoria,EstadoCategoria")] CategoriaServicio categoriaServicio)
        {
            if (id != categoriaServicio.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaServicioExists(categoriaServicio.IdCategoria))
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
            return View(categoriaServicio);
        }

        // GET: CategoriaServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoriaServicios == null)
            {
                return NotFound();
            }

            var categoriaServicio = await _context.CategoriaServicios
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaServicio == null)
            {
                return NotFound();
            }

            return View(categoriaServicio);
        }

        // POST: CategoriaServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoriaServicios == null)
            {
                return Problem("Entity set 'tallerContext.CategoriaServicios'  is null.");
            }
            var categoriaServicio = await _context.CategoriaServicios.FindAsync(id);
            if (categoriaServicio != null)
            {
                _context.CategoriaServicios.Remove(categoriaServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaServicioExists(int id)
        {
            return (_context.CategoriaServicios?.Any(e => e.IdCategoria == id)).GetValueOrDefault();
        }
    }
}
