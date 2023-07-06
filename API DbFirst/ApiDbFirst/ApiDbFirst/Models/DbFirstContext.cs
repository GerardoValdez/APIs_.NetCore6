using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiDbFirst.Models;

public partial class DbFirstContext : DbContext
{
    public DbFirstContext()
    {
    }

    public DbFirstContext(DbContextOptions<DbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deporte> Deportes { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<TipoDeporte> TipoDeportes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=DbFirst;Port=5432;User Id=geraValdez;Password=123456;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deporte>(entity =>
        {
            entity.HasKey(e => e.IdTipoDeporte).HasName("deportes_pkey");

            entity.ToTable("deportes");

            entity.HasIndex(e => e.IdTipoDeporte, "fki_fk_tipoDeporte");

            entity.Property(e => e.IdTipoDeporte).ValueGeneratedNever();
            entity.Property(e => e.Deporte1).HasColumnName("deporte");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");

            entity.HasOne(d => d.IdTipoDeporteNavigation).WithOne(p => p.Deporte)
                .HasForeignKey<Deporte>(d => d.IdTipoDeporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipoDeporte");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("personas_pkey");

            entity.ToTable("personas");

            entity.HasIndex(e => e.IdSexo, "fki_fk_sexo");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdSexo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sexo");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sexos_pkey");

            entity.ToTable("sexos");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Sexo1).HasColumnName("sexo");
        });

        modelBuilder.Entity<TipoDeporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipoDeportes_pkey");

            entity.ToTable("tipoDeportes");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TipoDeporte1).HasColumnName("tipoDeporte");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.IdRol, "fki_fk_rol");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
