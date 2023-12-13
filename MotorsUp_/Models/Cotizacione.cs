using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class Cotizacione
    {
        public Cotizacione()
        {
            AgendamientoCita = new HashSet<AgendamientoCita>();
            DetalleXcotizaciones = new HashSet<DetalleXcotizacione>();
        }

        public int IdCotizacion { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
        public double ValorManoDeObra { get; set; }
        public double ValorCotizacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Placa { get; set; } = null!;

        public virtual Vehiculo PlacaNavigation { get; set; } = null!;
        public virtual ICollection<AgendamientoCita> AgendamientoCita { get; set; }
        public virtual ICollection<DetalleXcotizacione> DetalleXcotizaciones { get; set; }
    }
}
