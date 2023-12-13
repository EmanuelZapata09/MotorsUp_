using MotorsUp_.Models;
using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
namespace MotorsUp_.Controllers
{
    public class DetalleXventasController : Controller
    {
        private readonly tallerContext _context;

        public DetalleXventasController(tallerContext context)
        {
            _context = context;
        }

        // GET: DetalleXventas
        public async Task<IActionResult> Index()
        {
            var tallerContext = _context.DetalleXventas.Include(d => d.IdProductoNavigation);
            return View(await tallerContext.ToListAsync());
        }

        // GET: DetalleXventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleXventas == null)
            {
                return NotFound();
            }

            var detalleXventa = await _context.DetalleXventas
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleXventa == id);
            if (detalleXventa == null)
            {
                return NotFound();
            }

            return View(detalleXventa);
        }

        // GET: DetalleXventas/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "NombreProducto");
            return View();
        }

        // POST: DetalleXventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleXventa,PrecioVenta,Cantidad,IdProducto,IdVenta,FechaHora,MetodoPago,Total")] DetalleXventa detalleXventa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleXventa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "NombreProducto", detalleXventa.IdProducto);
            return View(detalleXventa);
        }

        // GET: DetalleXventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleXventas == null)
            {
                return NotFound();
            }

            var detalleXventa = await _context.DetalleXventas.FindAsync(id);
            if (detalleXventa == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "NombreProducto", detalleXventa.IdProducto);
            return View(detalleXventa);
        }

        // POST: DetalleXventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleXventa,PrecioVenta,Cantidad,IdProducto,IdVenta,FechaHora,MetodoPago,Total")] DetalleXventa detalleXventa)
        {
            if (id != detalleXventa.IdDetalleXventa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleXventa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleXventaExists(detalleXventa.IdDetalleXventa))
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
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "NombreProducto", detalleXventa.IdProducto);
            return View(detalleXventa);
        }

        // GET: DetalleXventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleXventas == null)
            {
                return NotFound();
            }

            var detalleXventa = await _context.DetalleXventas
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleXventa == id);
            if (detalleXventa == null)
            {
                return NotFound();
            }

            return View(detalleXventa);
        }

        // POST: DetalleXventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleXventas == null)
            {
                return Problem("Entity set 'tallerContext.DetalleXventas'  is null.");
            }
            var detalleXventa = await _context.DetalleXventas.FindAsync(id);
            if (detalleXventa != null)
            {
                _context.DetalleXventas.Remove(detalleXventa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GenerarReportePDF()
        {
            var detallesxventas = await _context.DetalleXventas.ToListAsync();

            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = new PdfWriter(memoryStream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);


            Paragraph titulo = new Paragraph("Reporte Detalle de Compras").SetTextAlignment(TextAlignment.CENTER);
            document.Add(titulo);


            document.Add(new Paragraph("\n"));


            Div div = new Div().SetHorizontalAlignment(HorizontalAlignment.CENTER);


            Table table = new Table(5);
            table.AddHeaderCell("Precio");
            table.AddHeaderCell("Cantidad");
            table.AddHeaderCell("Fecha");
            table.AddHeaderCell("Metodo de pago");
            table.AddHeaderCell("Total");


            foreach (var detalleventas in detallesxventas)
            {
                table.AddCell(detalleventas.PrecioVenta.ToString());
                table.AddCell(detalleventas.Cantidad.ToString());
                table.AddCell(detalleventas.FechaHora.ToString());
                table.AddCell(detalleventas.MetodoPago.ToString());
                table.AddCell(detalleventas.Total.ToString());   
            }


            div.Add(table);


            document.Add(div);
            document.Close();

            return File(memoryStream.ToArray(), "application/pdf", "ReporteDetallesVentas.pdf");
        }
        public async Task<IActionResult> GenerarReporteExcelConGrafico()
        {
            var detalleventas = await _context.DetalleXventas.ToListAsync();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("ReporteCompras");

                // Agregar datos de las compras al archivo Excel
                worksheet.Cells[1, 1].Value = "Precio";
                worksheet.Cells[1, 2].Value = "Cantidad";
                worksheet.Cells[1, 3].Value = "Fecha";
                worksheet.Cells[1, 4].Value = "Metodo de pago";
                worksheet.Cells[1, 5].Value = "Total";

                int row = 2;
                foreach (var detalleventa in detalleventas)
                {
                    worksheet.Cells[row, 1].Value = detalleventa.PrecioVenta;
                    worksheet.Cells[row, 2].Value = detalleventa.Cantidad;
                    worksheet.Cells[row, 3].Value = detalleventa.FechaHora;
                    worksheet.Cells[row, 4].Value = detalleventa.MetodoPago;
                    worksheet.Cells[row, 5].Value = detalleventa.Total;
                    row++;
                }

                // Crear un gráfico con los datos
                var chart = worksheet.Drawings.AddChart("ChartTitle", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
                chart.SetPosition(1, 0, 5, 0);
                chart.SetSize(600, 400);
                chart.Series.Add(worksheet.Cells["B2:B" + (row - 1)], worksheet.Cells["A2:A" + (row - 1)]);

                return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReporteVentas.xlsx");
            }



        }

        private bool DetalleXventaExists(int id)
        {
          return (_context.DetalleXventas?.Any(e => e.IdDetalleXventa == id)).GetValueOrDefault();
        }
    }
}
