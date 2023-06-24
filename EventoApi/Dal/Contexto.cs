﻿using System;
using System.Collections.Generic;
using EventoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventoApi.Dal;

public partial class Contexto : DbContext
{
    public Contexto()
    {
    }

    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=EventoTicketDb.mssql.somee.com;Database=EventoTicketDb;Trusted_Connection=false; User id=psolorin_SQLLogin_1; pwd=rr7l319qcp; encrypt=false;persist security info=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Evento__3213E83FF4FDC094");

            entity.ToTable("Evento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Imagen)
                  .HasMaxLength(200)
                  .IsUnicode(false)
                  .HasColumnName("Imagen");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Lugar)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lugar");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3213E83FA4B3483D");

            entity.ToTable("Ticket");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F9E320C8A");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
