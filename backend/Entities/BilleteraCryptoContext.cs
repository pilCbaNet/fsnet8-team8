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
        public virtual DbSet<Estados> Estados { get; set; } = null!;
        public virtual DbSet<Localidades> Localidades { get; set; } = null!;
        public virtual DbSet<Monedas> Monedas { get; set; } = null!;
        public virtual DbSet<Provincias> Provincias { get; set; } = null!;
        public virtual DbSet<Transferencias> Transferencias { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuariosMonedas> UsuariosMonedas { get; set; } = null!;
        public virtual DbSet<VistaUsuario> VistaUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MJ229U0; Database=BilleteraCrypto; User=sa; Password=1234; TrustServerCertificate=True");
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

                entity.Property(e => e.IdEstado).HasColumnName("ID_Estado");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Billeteras)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("fk_ID_Estado");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Billeteras)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_billetera_ID_Usuario");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("pk_ID_Estado");

                entity.Property(e => e.IdEstado).HasColumnName("ID_Estado");

                entity.Property(e => e.NombreEst)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_est");
            });

            modelBuilder.Entity<Localidades>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad)
                    .HasName("pk_ID_Localidad");

                entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");

                entity.Property(e => e.IdProvincia).HasColumnName("ID_provincia");

                entity.Property(e => e.NomLocalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nom_localidad");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Localidades)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("fk_ID_Provincia");
            });

            modelBuilder.Entity<Monedas>(entity =>
            {
                entity.HasKey(e => e.IdMoneda)
                    .HasName("pk_ID_Moneda");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.NombreMon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_mon");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("pk_ID_Provincia");

                entity.Property(e => e.IdProvincia).HasColumnName("ID_Provincia");

                entity.Property(e => e.NomProvincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nom_Provincia");
            });

            modelBuilder.Entity<Transferencias>(entity =>
            {
                entity.HasKey(e => e.IdTransferencia)
                    .HasName("pk_ID_Transferencia");

                entity.Property(e => e.IdTransferencia).HasColumnName("ID_Transferencia");

                entity.Property(e => e.CvuDestinoTransf).HasColumnName("CVU_Destino_transf");

                entity.Property(e => e.CvuOrigenTransf).HasColumnName("CVU_Origen_transf");

                entity.Property(e => e.IdBilletera).HasColumnName("ID_Billetera");

                entity.Property(e => e.MontoTransf).HasColumnName("Monto_transf");

                entity.HasOne(d => d.IdBilleteraNavigation)
                    .WithMany(p => p.Transferencia)
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

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("DNI");

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

                entity.Property(e => e.IdLocalidad).HasColumnName("ID_Localidad");

                entity.Property(e => e.NombreUsu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_usu");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdLocalidad)
                    .HasConstraintName("fk_ID_Localidad");
            });

            modelBuilder.Entity<UsuariosMonedas>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioMoneda)
                    .HasName("pk_ID_Usuario_Moneda");

                entity.ToTable("Usuarios_Monedas");

                entity.Property(e => e.IdUsuarioMoneda).HasColumnName("ID_Usuario_Moneda");

                entity.Property(e => e.IdMoneda).HasColumnName("ID_Moneda");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.UsuariosMoneda)
                    .HasForeignKey(d => d.IdMoneda)
                    .HasConstraintName("fk_ID_Moneda");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosMoneda)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_ID_Usuario");
            });

            modelBuilder.Entity<VistaUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VistaUsuarios");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha de nacimiento");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
