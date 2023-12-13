using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Colors;
using iText.Layout.Renderer;
using iText.Kernel.Pdf.Canvas;
using iText.IO.Image;
using System;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;
using MotorsUp_.Models;
namespace MotorsUp_.Controllers
{
    public class DetalleComprasController : Controller
    {
        private readonly tallerContext _context;
       

        public DetalleComprasController(tallerContext context)
        {
            _context = context;
        }

        // GET: DetalleCompras
        public async Task<IActionResult> Index()
        {
            var tallerContext = _context.DetalleCompras.Include(d => d.IdCompraNavigation).Include(d => d.IdProductoNavigation);
            return View(await tallerContext.ToListAsync());
        }

        // GET: DetalleCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleCompras == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompras
                .Include(d => d.IdCompraNavigation)
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleCompra == id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            return View(detalleCompra);
        }

        // GET: DetalleCompras/Create
        public IActionResult Create()
        {
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: DetalleCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleCompra,Precio,Cantidad,Subtotal,IdCompra,IdProducto")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Datos incorectos";
                return View();
            }
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detalleCompra.IdCompra);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", detalleCompra.IdProducto);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleCompras == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompra == null)
            {
                return NotFound();
            }
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detalleCompra.IdCompra);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", detalleCompra.IdProducto);
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleCompra,Precio,Cantidad,Subtotal,IdCompra,IdProducto")] DetalleCompra detalleCompra)
        {
            if (id != detalleCompra.IdDetalleCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCompraExists(detalleCompra.IdDetalleCompra))
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
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", detalleCompra.IdCompra);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", detalleCompra.IdProducto);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleCompras == null)
            {
                return NotFound();
            }

            var detalleCompra = await _context.DetalleCompras
                .Include(d => d.IdCompraNavigation)
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleCompra == id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            return View(detalleCompra);
        }

        // POST: DetalleCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleCompras == null)
            {
                return Problem("Entity set 'tallerContext.DetalleCompras'  is null.");
            }
            var detalleCompra = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompra != null)
            {
                _context.DetalleCompras.Remove(detalleCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCompraExists(int id)
        {
            return (_context.DetalleCompras?.Any(e => e.IdDetalleCompra == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> GenerarReportePDF()
        {
            var detallesCompra = await _context.DetalleCompras.ToListAsync();

            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = new PdfWriter(memoryStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);


            Paragraph titulo = new Paragraph("Reporte Detalle de Compras").SetTextAlignment(TextAlignment.CENTER);
            document.Add(titulo);


            document.Add(new Paragraph("\n"));


            Div div = new Div().SetHorizontalAlignment(HorizontalAlignment.CENTER);


            Table table = new Table(3);
            table.AddHeaderCell("Precio");
            table.AddHeaderCell("Cantidad");
            table.AddHeaderCell("Subtotal");


            foreach (var detalleCompra in detallesCompra)
            {
                table.AddCell(detalleCompra.Precio.ToString());
                table.AddCell(detalleCompra.Cantidad.ToString());
                table.AddCell(detalleCompra.Subtotal.ToString());
            }


            div.Add(table);


            document.Add(div);
            document.Close();

            return File(memoryStream.ToArray(), "application/pdf", "ReporteDetallesCompra.pdf");
        }

        public async Task<IActionResult> GenerarReporteExcelConGrafico()
        {
            var detallesCompra = await _context.DetalleCompras.ToListAsync();

             ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("ReporteCompras");

                // Agregar datos de las compras al archivo Excel
                worksheet.Cells[1, 1].Value = "Precio";
                worksheet.Cells[1, 2].Value = "Cantidad";
                worksheet.Cells[1, 3].Value = "Subtotal";

                int row = 2;
                foreach (var detalleCompra in detallesCompra)
                {
                    worksheet.Cells[row, 1].Value = detalleCompra.Precio;
                    worksheet.Cells[row, 2].Value = detalleCompra.Cantidad;
                    worksheet.Cells[row, 3].Value = detalleCompra.Subtotal;
                    row++;
                }

                // Crear un gráfico con los datos
                var chart = worksheet.Drawings.AddChart("ChartTitle", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
                chart.SetPosition(1, 0, 5, 0);
                chart.SetSize(600, 400);
                chart.Series.Add(worksheet.Cells["B2:B" + (row - 1)], worksheet.Cells["A2:A" + (row - 1)]);

                return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteCompras.xlsx");
            }

        }

    }
}
