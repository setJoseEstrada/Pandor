using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos.Models;

public partial class PandoraContext : DbContext
{
    public PandoraContext()
    {
    }

    public PandoraContext(DbContextOptions<PandoraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<ItemCliente> ItemClientes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-3MTV0N0F ; Database=Pandora;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC076DCCDC14");

            entity.Property(e => e.Contra).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Usuario).HasMaxLength(100);

            entity.HasOne(d => d.Rol).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Clientes__RolId__398D8EEE");
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imagen__3214EC0716D07B52");

            entity.ToTable("Imagen");

            entity.Property(e => e.Imagen1).HasColumnName("Imagen");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<ItemCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemClie__3214EC0703581D96");

            entity.ToTable("ItemCliente");

            entity.Property(e => e.Clase).HasMaxLength(100);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Material).HasMaxLength(200);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Serie).HasMaxLength(200);

            entity.HasOne(d => d.Usuario).WithMany(p => p.ItemClientes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__ItemClien__Image__3C69FB99");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC0776790576");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07ED49F880");

            entity.Property(e => e.Contra).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .HasColumnName("Usuario");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Usuarios__RolId__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
