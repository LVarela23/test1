using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestBodega.Models;

#nullable disable

namespace TestBodega.Data
{
    public partial class TestBodegaContext : DbContext
    {
        
        public TestBodegaContext(DbContextOptions<TestBodegaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovimientoInventario> MovimientoInventarios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TiposDetalle> TiposDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data source=DESKTOP-8T6JHVS; Initial Catalog=TestBodega; user id=sa; password=Clave.1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<MovimientoInventario>(entity =>
            {
                entity.ToTable("MovimientoInventario");

                entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.MovimientoInventarios)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__Movimient__IdPro__36B12243");

                entity.HasOne(d => d.TipoMovimientoNavigation)
                    .WithMany(p => p.MovimientoInventarios)
                    .HasForeignKey(d => d.TipoMovimiento)
                    .HasConstraintName("FK__Movimient__TipoM__3D5E1FD2");
            });

            modelBuilder.Entity<Producto>(entity =>
            {

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposDetalle>(entity =>
            {
                entity.ToTable("TiposDetalle");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
