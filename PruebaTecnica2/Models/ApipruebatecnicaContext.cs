using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PruebaTecnica2.Models;

public partial class ApipruebatecnicaContext : DbContext
{
    public ApipruebatecnicaContext()
    {
    }

    public ApipruebatecnicaContext(DbContextOptions<ApipruebatecnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuariosnegocio> Usuariosnegocios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Usuariosnegocio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuariosnegocios");

            entity.HasIndex(e => e.CorreoElectronico, "CorreoElectronico").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Contraseña).HasMaxLength(100);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Dirección).HasMaxLength(200);
            entity.Property(e => e.NombreNegocio).HasMaxLength(100);
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .HasColumnName("RUC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
