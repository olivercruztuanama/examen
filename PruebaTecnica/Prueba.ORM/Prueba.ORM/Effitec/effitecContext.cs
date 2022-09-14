using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Prueba.ORM.Effitec
{
    public partial class effitecContext : DbContext
    {
        public effitecContext()
        {
        }

        public effitecContext(DbContextOptions<effitecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductoDetalle> ProductoDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IT2C2K0\\SQLEXPRESS;Database=effitec;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Precio)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("precio");
            });

            modelBuilder.Entity<ProductoDetalle>(entity =>
            {
                entity.HasKey(e => e.Iddet);

                entity.ToTable("producto_detalle");

                entity.Property(e => e.Iddet).HasColumnName("iddet");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecharegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Total)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.ProductoDetalles)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_producto_detalle_producto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
