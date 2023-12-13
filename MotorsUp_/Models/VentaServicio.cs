using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class VentaServicio
    {
        public int IdVentaServicio { get; set; }
        public DateTime FechaHora { get; set; }
        public bool EstadoVenta { get; set; }
        public bool MetodoPago { get; set; }
        public int ValorManoDeObra { get; set; }
        public int ValorInsumos { get; set; }
        public int Total { get; set; }
        public int IdCliente { get; set; }
        public int IdCotizacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
    }
}
