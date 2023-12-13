using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorsUp_.Models
{
    public partial class Role
    {
        public Role()
        {
            RolXpermisos = new HashSet<RolXpermiso>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El nombre del rol solo puede contener letras y espacios.")]
        public string Nombre { get; set; } = null!;

        public virtual ICollection<RolXpermiso> RolXpermisos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
