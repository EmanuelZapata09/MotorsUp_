using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class AgendamientoCita
    {
        public AgendamientoCita()
        {
            ServXagendamientos = new HashSet<ServXagendamiento>();
        }

        public int IdAgendamiento { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int IdCotizacion { get; set; }
        public int IdPersona { get; set; }
        public int IdEstado { get; set; }

        public virtual Cotizacione IdCotizacionNavigation { get; set; } = null!;
        public virtual EstadoCita IdEstadoNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<ServXagendamiento> ServXagendamientos { get; set; }
    }
}
