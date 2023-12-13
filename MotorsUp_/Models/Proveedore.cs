using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorsUp_.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Compras = new HashSet<Compra>();
        }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El id del proveedor debe ser de tipo numerico")]
        public int IdProveedor { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El nombre del proveedor solo puede contener letras y espacios.")]
        public string NombreProveedor { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingresa un correo electrónico valido")]
        public string CorreoProveedor { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"[a-zA-Z0-9\s\-,.#]+", ErrorMessage = "Ingresa una dirección válida")]
        public string DireccionProveedor { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El telefono del proveedor debe ser de tipo numerico")]
        public string TelefonoProveedor { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
