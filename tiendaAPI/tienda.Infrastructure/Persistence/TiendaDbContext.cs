using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using tienda.Domain.Entities;


namespace tienda.Infrastructure.Persistence
{
    internal class TiendaDbContext(DbContextOptions<TiendaDbContext> options) : DbContext(options)
    {
        
        internal DbSet<Pedido> pedidos { get; set; }

        internal DbSet<Producto> productos { get; set; }

        internal DbSet<DetallePedido> detalles { get; set; }

        internal DbSet<Usuario> usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.ToTable("Usuarios");
                entity.Property(u => u.Id).HasColumnName("UserID");
                entity.Property(u => u.Nombre).HasColumnName("Nombre");
                entity.Property(u => u.Correo).HasColumnName("CorreoElectronico");
                entity.Property(u => u.Clave).HasColumnName("Clave");
                entity.Property(u => u.Rol).HasColumnName("Rol");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.ToTable("Productos");
                entity.Property(p => p.Id).HasColumnName("ProductoID");
                entity.Property(p => p.Nombre).HasColumnName("Nombre");
                entity.Property(p => p.Descripcion).HasColumnName("Descripcion");
                entity.Property(p => p.Precio).HasColumnName("Precio");
                entity.Property(p => p.Stock).HasColumnName("CantidadDisponible");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.ToTable("Pedidos");
                entity.Property(p => p.Id).HasColumnName("PedidoID");
                entity.Property(p => p.Estado).HasColumnName("EstadoPedido");
                entity.Property(p => p.FechaCreacion).HasColumnName("FechaPedido");
                entity.Property(p => p.usuarioId).HasColumnName("UsuarioID");

                entity.HasOne(p => p.Usuario).WithMany(u => u.Pedidos).HasForeignKey(p => p.usuarioId)
        .HasPrincipalKey(u => u.Id);


            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.ToTable("DetallesPedido");
                entity.Property(c => c.Id).HasColumnName("DetalleID");
                entity.Property(c => c.PedidoId).HasColumnName("PedidoID");
                entity.Property(c => c.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.pedido).WithMany(d => d.Detalles).HasForeignKey(d => d.PedidoId);
                entity.HasOne(d => d.producto).WithMany().HasForeignKey(d => d.ProductoId);
            });
        }
    }
}
