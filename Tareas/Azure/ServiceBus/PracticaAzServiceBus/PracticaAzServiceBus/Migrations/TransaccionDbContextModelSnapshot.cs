﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaAzServiceBus.Data;

#nullable disable

namespace PracticaAzServiceBus.Migrations
{
    [DbContext(typeof(TransaccionDbContext))]
    partial class TransaccionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticaAzServiceBus.Models.EventoTransaccion", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventoId"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaEvento")
                        .HasColumnType("datetime2");

                    b.Property<string>("TipoEvento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransaccionId")
                        .HasColumnType("int");

                    b.HasKey("EventoId");

                    b.HasIndex("TransaccionId");

                    b.ToTable("EventosTransacciones");
                });

            modelBuilder.Entity("PracticaAzServiceBus.Models.Notificacion", b =>
                {
                    b.Property<int>("NotificacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificacionId"));

                    b.Property<string>("EmailCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoNotificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransaccionId")
                        .HasColumnType("int");

                    b.HasKey("NotificacionId");

                    b.HasIndex("TransaccionId");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("PracticaAzServiceBus.Models.Transaccion", b =>
                {
                    b.Property<int>("TransaccionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransaccionId"));

                    b.Property<string>("CuentaDestino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DetallesAdicionales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaNotificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaProcesamiento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoTransaccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransaccionId");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("PracticaAzServiceBus.Models.EventoTransaccion", b =>
                {
                    b.HasOne("PracticaAzServiceBus.Models.Transaccion", "Transaccion")
                        .WithMany()
                        .HasForeignKey("TransaccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaccion");
                });

            modelBuilder.Entity("PracticaAzServiceBus.Models.Notificacion", b =>
                {
                    b.HasOne("PracticaAzServiceBus.Models.Transaccion", "Transaccion")
                        .WithMany()
                        .HasForeignKey("TransaccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaccion");
                });
#pragma warning restore 612, 618
        }
    }
}
