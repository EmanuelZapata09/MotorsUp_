using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorsUp_.Models
{
    public partial class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "El precio debe ser de tipo numerico")]
        public float Precio { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "La cantidad debe ser de tipo numerico")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "El subtotal debe ser de tipo numerico")]
        public float Subtotal { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }

        public virtual Compra? IdCompraNavigation { get; set; } = null!;
        public virtual Producto? IdProductoNavigation { get; set; } = null!;
    }
}
