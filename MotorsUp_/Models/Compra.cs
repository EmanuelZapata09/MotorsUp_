using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace MotorsUp_.Models
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }

        public int IdCompra { get; set; }
        public string EstadoCompra { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "La descripción solo puede contener letras y espacios.")]
        public string DescripcionCompra { get; set; } = null!;

        [Required(ErrorMessage = "Ingresa una fecha válida.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateNotInPast(ErrorMessage = "La fecha de compra no puede ser en el pasado.")]
        public DateTime? FechaCompra { get; set; }
        public int IdProveedor { get; set; }

        public virtual Proveedore? IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
