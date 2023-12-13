using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class DetalleXventa
    {
        public int IdDetalleXventa { get; set; }
        public double PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaHora { get; set; }
        public string? MetodoPago { get; set; }
        public double Total { get; set; }

        public virtual Producto? IdProductoNavigation { get; set; } = null!;
    }
}
