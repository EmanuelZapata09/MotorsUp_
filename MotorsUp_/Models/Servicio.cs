using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            ServXagendamientos = new HashSet<ServXagendamiento>();
        }

        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;
        public int IdCategoria { get; set; }
        public virtual CategoriaServicio? IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<ServXagendamiento> ServXagendamientos { get; set; }
    }
}
