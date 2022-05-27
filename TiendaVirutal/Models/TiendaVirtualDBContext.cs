using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TiendaVirutal.Models
{
    public partial class TiendaVirtualDBContext : DbContext
    {
        public TiendaVirtualDBContext()
        {
        }

        public TiendaVirtualDBContext(DbContextOptions<TiendaVirtualDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TiendaVirtualDB;Trusted_Connection=True;
");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellidos).HasMaxLength(100);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Dni).HasMaxLength(8);

                entity.Property(e => e.Nombres).HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Pedido_Cliente");

                entity.HasOne(d => d.IdTarjetaNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdTarjeta)
                    .HasConstraintName("FK_Pedido_Tarjeta");
            });

            modelBuilder.Entity<PedidoDetalle>(entity =>
            {
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoDetalle)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK_PedidoDetalle_Pedido");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.PedidoDetalle)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_PedidoDetalle_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Producto_Categoria");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Producto_Marca");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.Property(e => e.Marca).HasMaxLength(50);

                entity.Property(e => e.Numero).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Contrasena).HasMaxLength(100);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Dni).HasMaxLength(8);

                entity.Property(e => e.Nombres).HasMaxLength(50);
            });
        }
    }
}
