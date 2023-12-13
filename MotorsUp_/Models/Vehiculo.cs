using System;
using System.Collections.Generic;

namespace MotorsUp_.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Cotizaciones = new HashSet<Cotizacione>();
        }

        public string Placa { get; set; } = null!;
        public string Referencia { get; set; } = null!;
        public int Modelo { get; set; }
        public int Chasis { get; set; }
        public string Color { get; set; } = null!;

        public virtual ICollection<Cotizacione> Cotizaciones { get; set; }
    }
}
