using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MotorsUp_.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
            DetalleXcotizaciones = new HashSet<DetalleXcotizacione>();
            DetalleXventa = new HashSet<DetalleXventa>();
        }

        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El nombre del producto solo puede contener letras y espacios.")]
        public string NombreProducto { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "El precio de compra debe ser de tipo numerico")]
        public float PrecioCompra { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "El precio de venta debe ser de tipo numerico")]
        public float PrecioVenta { get; set; }
        public string EstadoProducto { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "La saldo de existencias debe ser de tipo numerico")]
        public int SaldoExistencias { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El stock minimo debe ser de tipo numerico")]
        public int StockMinimo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El stock maximo debe ser de tipo numerico")]
        public int StockMaximo { get; set; }

        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleXcotizacione> DetalleXcotizaciones { get; set; }
        public virtual ICollection<DetalleXventa> DetalleXventa { get; set; }
    }
}
