using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class ServXagendamiento
    {
        public ServXagendamiento()
        {
            Observaciones = new HashSet<Observacione>();
        }

        public int IdServXagendamiento { get; set; }
        public bool Estado { get; set; }
        public int IdAgendamiento { get; set; }
        public int IdServicio { get; set; }

        public virtual AgendamientoCita IdAgendamientoNavigation { get; set; } = null!;
        public virtual Servicio IdServicioNavigation { get; set; } = null!;
        public virtual ICollection<Observacione> Observaciones { get; set; }
    }
}
