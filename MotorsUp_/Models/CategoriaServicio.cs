using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorsUp_.Models
{
    public partial class CategoriaServicio
    {
        public CategoriaServicio()
        {
            Servicios = new HashSet<Servicio>();
        }

        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El campo NombreCategoria es obligatorio.")]
        public string NombreCategoria { get; set; } = null!;

        [Display(Name = "Estado de la Categoría")]
        public bool EstadoCategoria { get; set; }

        public virtual ICollection<Servicio> Servicios { get; set; }
    }
}
