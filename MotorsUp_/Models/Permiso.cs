using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorsUp_.Models
{
    public partial class Permiso
    {
        public Permiso()
        {
            RolXpermisos = new HashSet<RolXpermiso>();
        }

        public int IdPermiso { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Nombre no válido")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enlace no valido")]
        public string Enlace { get; set; } = null!;

        public virtual ICollection<RolXpermiso> RolXpermisos { get; set; }
    }
}
