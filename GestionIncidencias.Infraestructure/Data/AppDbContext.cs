using GestionIncidencias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GestionIncidencias.Infraestructure.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<TipoIncidencia> TipoIncidencia { get; set; }
        public DbSet<Encargado> Encargado { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<FlujoIncidencia> FlujoIncidencia { get; set; }
        public DbSet<Incidencia> Incidencia { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet <TipoSolucion> TipoSolucion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoIncidencia>(entity =>
            {
                entity.ToTable("TipoIncidencia");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<Encargado>(entity =>
            {
                entity.ToTable("Encargado");
                entity.HasKey(en => en.Id);
                entity.Property(en => en.Nombre).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");
                entity.HasKey(es => es.Id);
                entity.Property(es => es.Solicitud).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<FlujoIncidencia>(entity =>
            {
                entity.ToTable("FlujoIncidencia");
                entity.HasKey(f => f.Id);
                entity.Property(f => f.FechaMovimiento).IsRequired().HasMaxLength(50);
                entity.HasOne(f => f.Encargado)
               .WithMany()
               .HasForeignKey(f => f.IdEncargado)
               .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.Estado)
               .WithMany()
               .HasForeignKey(f => f.IdEstado)
               .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(f => f.Incidencia)
               .WithMany()
               .HasForeignKey(f => f.IdIncidencia)
               .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Incidencia>(entity =>
            {
                entity.ToTable("Incidencia");
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Requerimiento).IsRequired().HasMaxLength(2000);
                entity.Property(g => g.DescripcionProblema).IsRequired().HasMaxLength(2000);
                entity.Property(g => g.FechaIncidencia).IsRequired();
                entity.Property(g => g.Prioridad).IsRequired().HasMaxLength(50);
                entity.Property(g => g.DescripcionSolucion).HasMaxLength(2000);
                entity.Property(g => g.UsuarioFuente).HasMaxLength(50);
                entity.Property(g => g.TipoFuente).HasMaxLength(50);
                entity.Property(g => g.ImagenBase64).IsUnicode(false).HasColumnType("varchar(max)");

                entity.HasOne(g => g.Usuario)
               .WithMany()
               .HasForeignKey(g => g.IdUsuario)
               .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.TipoIncidencia)
               .WithMany()
               .HasForeignKey(g => g.IdTipoIncidencia)
               .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.Estado)
                .WithMany()
                .HasForeignKey(g => g.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Apellido).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Area).IsRequired().HasMaxLength(50);
                entity.Property(u => u.IdUsuario).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(50);
            }).Entity<Usuario>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<TipoSolucion>(entity =>
            {
                entity.ToTable("TipoSolucion");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Descripcion).IsRequired().HasMaxLength(2000);
            });

        }
    }
}

