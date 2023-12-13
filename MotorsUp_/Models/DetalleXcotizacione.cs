using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class DetalleXcotizacione
    {
        public int IdDetalleXcotizaciones { get; set; }
        public double Descuento { get; set; }
        public double SubtotalProducto { get; set; }
        public int IdProducto { get; set; }
        public int IdCotizacion { get; set; }

        public virtual Cotizacione IdCotizacionNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
