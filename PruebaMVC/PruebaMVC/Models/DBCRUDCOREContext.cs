using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaMVC.Models
{
    public partial class DBCRUDCOREContext : DbContext
    {
        public DBCRUDCOREContext()
        {
        }

        public DBCRUDCOREContext(DbContextOptions<DBCRUDCOREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabecera> Cabeceras { get; set; } = null!;
        public virtual DbSet<Detalle> Detalles { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=DBCRUDCORE;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabecera>(entity =>
            {
                entity.HasKey(e => e.IdCabecera)
                    .HasName("PK__CABECERA__A708B08D6F29DA00");

                entity.ToTable("CABECERA");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Detalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DETALLE");

                entity.Property(e => e.Enviar)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrdenCompra)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Terminos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vendedor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Codigo)
                    .HasConstraintName("FK_Detalle_Productos");

                entity.HasOne(d => d.IdCabeceraNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCabecera)
                    .HasConstraintName("FK_Detalle_Facturar");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__PRODUCTO__06370DADC0FC778B");

                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
