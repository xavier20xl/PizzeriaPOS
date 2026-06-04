using Microsoft.EntityFrameworkCore;
using PizzeriaPOS.Data.Entities;

namespace PizzeriaPOS.Data.Context
{
    public class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.NombreUsuario).IsUnique();
                entity.Property(e => e.NombreUsuario).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.NombreCompleto).HasMaxLength(200);
            });

            // Configuración de Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Categoria).HasMaxLength(100);
            });

            // Configuración de Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(200);
            });

            // Configuración de Direccion
            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Calle).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Numero).HasMaxLength(20);
                entity.Property(e => e.Colonia).HasMaxLength(200);
                entity.Property(e => e.Ciudad).HasMaxLength(100);
                entity.Property(e => e.CodigoPostal).HasMaxLength(10);
                entity.Property(e => e.Referencia).HasMaxLength(500);

                // Relación con Cliente
                entity.HasOne(d => d.Cliente)
                      .WithMany(c => c.Direcciones)
                      .HasForeignKey(d => d.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de Pedido
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Estado).HasMaxLength(50);
                entity.Property(e => e.Notas).HasMaxLength(500);

                // Relación con Cliente
                entity.HasOne(p => p.Cliente)
                      .WithMany(c => c.Pedidos)
                      .HasForeignKey(p => p.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación con Direccion
                entity.HasOne(p => p.Direccion)
                      .WithMany()
                      .HasForeignKey(p => p.DireccionId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Configuración de PedidoDetalle
            modelBuilder.Entity<PedidoDetalle>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Notas).HasMaxLength(300);

                // Relación con Pedido
                entity.HasOne(d => d.Pedido)
                      .WithMany(p => p.Detalles)
                      .HasForeignKey(d => d.PedidoId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación con Producto
                entity.HasOne(d => d.Producto)
                      .WithMany()
                      .HasForeignKey(d => d.ProductoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

