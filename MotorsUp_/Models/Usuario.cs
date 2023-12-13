using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorsUp_.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Correo no valido")]
        public string CorreoUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        //8 caracteres, una letra mayúscula, una letra minúscula y un número
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Contraseña no válida")]
        public string ContrasenaUsuario { get; set; } = null!;
        public int IdRol { get; set; }
        public virtual Role? IdRolNavigation { get; set; } = null!;
    }
}
