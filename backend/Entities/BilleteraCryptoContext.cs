using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class BilleteraCryptoContext : DbContext
    {
        public BilleteraCryptoContext()
        {
        }

        public BilleteraCryptoContext(DbContextOptions<BilleteraCryptoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Billeteras> Billeteras { get; set; } = null!;
        public virtual DbSet<Operaciones> Operaciones { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MJ229U0; Database=BilleteraCrypto; User=sa; Password=1234; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billeteras>(entity =>
            {
                entity.HasKey(e => e.IdBilletera)
                    .HasName("pk_ID_Billetera");

                entity.Property(e => e.IdBilletera).HasColumnName("ID_Billetera");

                entity.Property(e => e.CvuBille).HasColumnName("CVU_Bille");

                entity.Property(e => e.EstadoBille).HasColumnName("Estado_bille");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.SaldoArsBille)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Saldo_ars_bille");

                entity.Property(e => e.SaldoBtcBille)
                    .HasColumnType("decimal(10, 6)")
                    .HasColumnName("Saldo_btc_bille");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Billeteras)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_ID_Usuario");
            });

            modelBuilder.Entity<Operaciones>(entity =>
            {
                entity.HasKey(e => e.IdTransferencia)
                    .HasName("pk_ID_Transferencia");

                entity.Property(e => e.IdTransferencia).HasColumnName("ID_Transferencia");

                entity.Property(e => e.IdBilletera).HasColumnName("ID_Billetera");

                entity.Property(e => e.MontoArsTransf)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Monto_ars_transf");

                entity.Property(e => e.MontoBtcTrans)
                    .HasColumnType("decimal(10, 6)")
                    .HasColumnName("Monto_btc_trans");

                entity.Property(e => e.TipoTransf)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Transf");

                entity.HasOne(d => d.IdBilleteraNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdBilletera)
                    .HasConstraintName("fk_ID_Billetera");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("pk_ID_Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.ApellidoUsu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_usu");

                entity.Property(e => e.DniUsu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DNI_usu");

                entity.Property(e => e.EmailUsu)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("Email_usu");

                entity.Property(e => e.FechaAltaUsu)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaAlta_usu");

                entity.Property(e => e.FechaBajaUsu)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaBaja_usu");

                entity.Property(e => e.FechaNacUsu)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Nac_usu");

                entity.Property(e => e.NombreUsu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_usu");

                entity.Property(e => e.PasswordUsu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Password_usu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
