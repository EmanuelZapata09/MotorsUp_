using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MotorsUp_.Models
{
    public partial class tallerContext : DbContext
    {
        public tallerContext()
        {
        }

        public tallerContext(DbContextOptions<tallerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgendamientoCita> AgendamientoCitas { get; set; } = null!;
        public virtual DbSet<CategoriaServicio> CategoriaServicios { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Cotizacione> Cotizaciones { get; set; } = null!;
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; } = null!;
        public virtual DbSet<DetalleXcotizacione> DetalleXcotizaciones { get; set; } = null!;
        public virtual DbSet<DetalleXventa> DetalleXventas { get; set; } = null!;
        public virtual DbSet<EstadoCita> EstadoCitas { get; set; } = null!;
        public virtual DbSet<Observacione> Observaciones { get; set; } = null!;
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<RolXpermiso> RolXpermisos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<ServXagendamiento> ServXagendamientos { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public virtual DbSet<VentaServicio> VentaServicios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //              optionsBuilder.UseSqlServer("server=LAPTOP-FOM2CQ9D\\SQLEXPRESS01;database=taller;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendamientoCita>(entity =>
            {
                entity.HasKey(e => e.IdAgendamiento)
                    .HasName("PK__Agendami__65BDA7E6957DC573");

                entity.Property(e => e.IdAgendamiento).HasColumnName("id_agendamiento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.AgendamientoCita)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agendamie__id_co__7D439ABD");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.AgendamientoCita)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agendamie__id_es__7F2BE32F");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.AgendamientoCita)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agendamie__id_pe__7E37BEF6");
            });

            modelBuilder.Entity<CategoriaServicio>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__CD54BC5AF03EC8BE");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.EstadoCategoria).HasColumnName("estado_categoria");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_categoria");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__677F38F54F82F64E");

                entity.Property(e => e.IdCliente)
                    .ValueGeneratedNever()
                    .HasColumnName("id_cliente");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo_cliente");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("direccion_cliente");

                entity.Property(e => e.EstadoCliente).HasColumnName("estado_cliente");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cliente");

                entity.Property(e => e.TelefonoCliente)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono_cliente");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compras__C4BAA6044636068B");

                entity.Property(e => e.IdCompra).HasColumnName("id_compra");

                entity.Property(e => e.DescripcionCompra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion_compra");

                entity.Property(e => e.EstadoCompra)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("estado_compra");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("date")
                    .HasColumnName("fecha_compra");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Compras__id_prov__5812160E");
            });

            modelBuilder.Entity<Cotizacione>(entity =>
            {
                entity.HasKey(e => e.IdCotizacion)
                    .HasName("PK__Cotizaci__9713D174DB886086");

                entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Placa)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.Property(e => e.ValorCotizacion).HasColumnName("valor_cotizacion");

                entity.Property(e => e.ValorManoDeObra).HasColumnName("valor_mano_de_obra");

                entity.HasOne(d => d.PlacaNavigation)
                    .WithMany(p => p.Cotizaciones)
                    .HasForeignKey(d => d.Placa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vehiculos");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PK__DetalleC__BD16E27946CE8CB2");

                entity.Property(e => e.IdDetalleCompra).HasColumnName("id_detalle_compra");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdCompra).HasColumnName("id_compra");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_compra");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_producto");
            });

            modelBuilder.Entity<DetalleXcotizacione>(entity =>
            {
                entity.HasKey(e => e.IdDetalleXcotizaciones)
                    .HasName("PK__DetalleX__01F2E7BF9B9E2310");

                entity.ToTable("DetalleXCotizaciones");

                entity.Property(e => e.IdDetalleXcotizaciones).HasColumnName("id_detalleXCotizaciones");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.SubtotalProducto).HasColumnName("subtotal_producto");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.DetalleXcotizaciones)
                    .HasForeignKey(d => d.IdCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cotizacion");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleXcotizaciones)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto");
            });

            modelBuilder.Entity<DetalleXventa>(entity =>
            {
                entity.HasKey(e => e.IdDetalleXventa)
                    .HasName("PK__DetalleX__F317BDD5EA00AF72");

                entity.ToTable("DetalleXVentas");

                entity.Property(e => e.IdDetalleXventa).HasColumnName("id_detalleXVenta");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hora");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");


                entity.Property(e => e.MetodoPago)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("metodo_pago");

                entity.Property(e => e.PrecioVenta).HasColumnName("precio_venta");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleXventa)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productoo");
            });

            modelBuilder.Entity<EstadoCita>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__EstadoCi__86989FB249136038");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.NombreEstado)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_estado");
            });

            modelBuilder.Entity<Observacione>(entity =>
            {
                entity.HasKey(e => e.IdObservacion)
                    .HasName("PK__Observac__4CA8E7235D6F9322");

                entity.Property(e => e.IdObservacion).HasColumnName("id_observacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdServXagendamiento).HasColumnName("id_servXAgendamiento");

                entity.HasOne(d => d.IdServXagendamientoNavigation)
                    .WithMany(p => p.Observaciones)
                    .HasForeignKey(d => d.IdServXagendamiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Observaci__id_se__14270015");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__Permisos__228F224F6F2644EF");

                entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");

                entity.Property(e => e.Enlace)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("enlace");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Personas__228148B087F56F51");

                entity.Property(e => e.IdPersona)
                    .ValueGeneratedNever()
                    .HasColumnName("id_persona");

                entity.Property(e => e.CorreoPersona)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("correo_persona");

                entity.Property(e => e.DireccionPersona)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("direccion_persona");

                entity.Property(e => e.EstadoPersona).HasColumnName("estado_persona");

                entity.Property(e => e.NombrePersona)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_persona");

                entity.Property(e => e.TelefonoPersona)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("telefono_persona");

                entity.Property(e => e.TipoPersona)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("tipo_persona");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__FF341C0D8E1DF1DB");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.EstadoProducto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado_producto");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto");

                entity.Property(e => e.PrecioCompra).HasColumnName("precio_compra");

                entity.Property(e => e.PrecioVenta).HasColumnName("precio_venta");

                entity.Property(e => e.SaldoExistencias).HasColumnName("saldo_existencias");

                entity.Property(e => e.StockMaximo).HasColumnName("stock_maximo");

                entity.Property(e => e.StockMinimo).HasColumnName("stock_minimo");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__8D3DFE288013FF2D");

                entity.Property(e => e.IdProveedor)
                    .ValueGeneratedNever()
                    .HasColumnName("id_proveedor");

                entity.Property(e => e.CorreoProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo_proveedor");

                entity.Property(e => e.DireccionProveedor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("direccion_proveedor");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.NombreProveedor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_proveedor");

                entity.Property(e => e.TelefonoProveedor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telefono_proveedor");
            });

            modelBuilder.Entity<RolXpermiso>(entity =>
            {
                entity.HasKey(e => e.IdRolXpermiso)
                    .HasName("PK__RolXPerm__5CF76003D2DD6FB6");

                entity.ToTable("RolXPermisos");

                entity.Property(e => e.IdRolXpermiso).HasColumnName("id_rolXpermiso");

                entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.RolXpermisos)
                    .HasForeignKey(d => d.IdPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_permiso");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolXpermisos)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_rol");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__6ABCB5E0FE5CB512");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ServXagendamiento>(entity =>
            {
                entity.HasKey(e => e.IdServXagendamiento)
                    .HasName("PK__ServXAge__A0B0E80442FF6E9D");

                entity.ToTable("ServXAgendamiento");

                entity.Property(e => e.IdServXagendamiento).HasColumnName("id_servXAgendamiento");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdAgendamiento).HasColumnName("id_agendamiento");

                entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

                entity.HasOne(d => d.IdAgendamientoNavigation)
                    .WithMany(p => p.ServXagendamientos)
                    .HasForeignKey(d => d.IdAgendamiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_agendamiento");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.ServXagendamientos)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_servicio");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__Servicio__6FD07FDC1C50448E");

                entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre_servicio");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Servicios__id_ca__0A9D95DB");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__4E3E04AD24B0533C");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.ContrasenaUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasena_usuario");

                entity.Property(e => e.CorreoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo_usuario");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__id_rol__5165187F");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Placa)
                    .HasName("PK__Vehiculo__0C057424818833E2");

                entity.Property(e => e.Placa)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.Property(e => e.Chasis).HasColumnName("chasis");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Modelo).HasColumnName("modelo");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("referencia");
            });

            modelBuilder.Entity<VentaServicio>(entity =>
            {
                entity.HasKey(e => e.IdVentaServicio)
                    .HasName("PK__VentaSer__291F10F3B8742432");

                entity.ToTable("VentaServicio");

                entity.Property(e => e.IdVentaServicio).HasColumnName("id_ventaServicio");

                entity.Property(e => e.EstadoVenta).HasColumnName("estado_venta");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hora");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");

                entity.Property(e => e.MetodoPago).HasColumnName("metodo_pago");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.ValorInsumos).HasColumnName("valor_insumos");

                entity.Property(e => e.ValorManoDeObra).HasColumnName("valor_mano_de_obra");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.VentaServicios)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VentaServ__id_cl__17F790F9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
