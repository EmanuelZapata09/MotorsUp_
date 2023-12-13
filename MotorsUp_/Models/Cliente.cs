using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            VentaServicios = new HashSet<VentaServicio>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string TelefonoCliente { get; set; } = null!;
        public string CorreoCliente { get; set; } = null!;
        public string DireccionCliente { get; set; } = null!;
        public bool EstadoCliente { get; set; }

        public virtual ICollection<VentaServicio> VentaServicios { get; set; }
    }
}
