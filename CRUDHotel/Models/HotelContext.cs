﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDHotel.Models
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Habitacion> Habitaciones { get; set; } = null!;
        public virtual DbSet<Reservacion> Reservaciones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D59466422700EFF6");

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.IdCliente, "IX_Cliente")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasMaxLength(50);

                entity.Property(e => e.NombreCliente).HasMaxLength(80);

                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.NumeroHabitacion)
                    .HasName("PK__Habitaci__08B8232EA4FDF586");

                entity.ToTable("Habitacion");

                entity.HasIndex(e => e.NumeroHabitacion, "IX_Habitacion")
                    .IsUnique();

                entity.Property(e => e.NumeroHabitacion).ValueGeneratedNever();
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Reservacion");

                entity.HasIndex(e => e.NumeroHabitacion, "IX_Reservacion");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasMaxLength(50);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservacion_Cliente");

                entity.HasOne(d => d.NumeroHabitacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NumeroHabitacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservacion_Habitacion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
