using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class Observacione
    {
        public int IdObservacion { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdServXagendamiento { get; set; }

        public virtual ServXagendamiento IdServXagendamientoNavigation { get; set; } = null!;
    }
}
