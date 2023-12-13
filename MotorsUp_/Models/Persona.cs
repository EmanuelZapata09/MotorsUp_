using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorsUp_.Models
{
    public partial class Persona
    {
        public Persona()
        {
            AgendamientoCita = new HashSet<AgendamientoCita>();
        }
        [RegularExpression(@"[0-9]+", ErrorMessage = "Este id no es valido.")]
        public int IdPersona { get; set; }
        public string TipoPersona { get; set; } = null!;
        [RegularExpression(@"[a-zA-Z\s]+", ErrorMessage = "Este tipo no es valido.")]
        [MaxLength(70), MinLength(8)]
        public string NombrePersona { get; set; } = null!;
        [RegularExpression(@"[a-zA-Z0-9\s\-,.#]+", ErrorMessage = "Direccion no valida.")]
        [MaxLength(30), MinLength(8)]
        public string DireccionPersona { get; set; } = null!;
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Correo no valido.")]
        [MinLength(8), MaxLength(45)]
        public string CorreoPersona { get; set; } = null!;
        [RegularExpression(@"[0-9]+", ErrorMessage ="Este telefonono es valido.")]
        [MinLength(8), MaxLength(15)]
        public string TelefonoPersona { get; set; } = null!;
        public bool EstadoPersona { get; set; }

        public virtual ICollection<AgendamientoCita> AgendamientoCita { get; set; }
    }
}
