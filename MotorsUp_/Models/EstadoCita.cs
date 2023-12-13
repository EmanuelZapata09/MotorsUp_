using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class EstadoCita
    {
        public EstadoCita()
        {
            AgendamientoCita = new HashSet<AgendamientoCita>();
        }

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = null!;

        public virtual ICollection<AgendamientoCita> AgendamientoCita { get; set; }
    }
}
