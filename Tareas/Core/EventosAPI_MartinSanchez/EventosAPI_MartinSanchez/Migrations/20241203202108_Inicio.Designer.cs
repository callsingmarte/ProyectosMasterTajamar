﻿// <auto-generated />
using System;
using EventosAPI_MartinSanchez.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventosAPI_MartinSanchez.Migrations
{
    [DbContext(typeof(EventoContext))]
    [Migration("20241203202108_Inicio")]
    partial class Inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventosAPI_MartinSanchez.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fecha = new DateTime(2024, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Boda de Ana y Carlos",
                            Ubicacion = "Hacienda Las Flores"
                        },
                        new
                        {
                            Id = 2,
                            Fecha = new DateTime(2024, 4, 20, 19, 30, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Concierto de Primavera",
                            Ubicacion = "Auditorio Nacional"
                        },
                        new
                        {
                            Id = 3,
                            Fecha = new DateTime(2024, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Conferencia de Tecnología",
                            Ubicacion = "Centro de Convenciones"
                        },
                        new
                        {
                            Id = 4,
                            Fecha = new DateTime(2024, 12, 31, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Fiesta de Fin de Año",
                            Ubicacion = "Hotel Gran Lujo"
                        });
                });

            modelBuilder.Entity("EventosAPI_MartinSanchez.Models.Invitado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Confirmado")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Invitados");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Confirmado = true,
                            Email = "juan.perez@example.com",
                            EventoId = 1,
                            Nombre = "Juan Pérez"
                        },
                        new
                        {
                            Id = 2,
                            Confirmado = false,
                            Email = "maria.lopez@example.com",
                            EventoId = 3,
                            Nombre = "María López"
                        },
                        new
                        {
                            Id = 3,
                            Confirmado = true,
                            Email = "carlos.sanchez@example.com",
                            EventoId = 2,
                            Nombre = "Carlos Sánchez"
                        },
                        new
                        {
                            Id = 4,
                            Confirmado = false,
                            Email = "ana.martinez@example.com",
                            EventoId = 2,
                            Nombre = "Ana Martínez"
                        },
                        new
                        {
                            Id = 5,
                            Confirmado = true,
                            Email = "pedro.gomez@example.com",
                            EventoId = 1,
                            Nombre = "Pedro Gómez"
                        },
                        new
                        {
                            Id = 6,
                            Confirmado = true,
                            Email = "lucia.fernandez@example.com",
                            EventoId = 3,
                            Nombre = "Lucía Fernández"
                        },
                        new
                        {
                            Id = 7,
                            Confirmado = false,
                            Email = "sofia.diaz@example.com",
                            EventoId = 3,
                            Nombre = "Sofía Díaz"
                        },
                        new
                        {
                            Id = 8,
                            Confirmado = true,
                            Email = "miguel.rodriguez@example.com",
                            EventoId = 2,
                            Nombre = "Miguel Rodríguez"
                        },
                        new
                        {
                            Id = 9,
                            Confirmado = false,
                            Email = "elena.jimenez@example.com",
                            EventoId = 1,
                            Nombre = "Elena Jiménez"
                        },
                        new
                        {
                            Id = 10,
                            Confirmado = true,
                            Email = "javier.torres@example.com",
                            EventoId = 1,
                            Nombre = "Javier Torres"
                        });
                });

            modelBuilder.Entity("EventosAPI_MartinSanchez.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Coste")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Servicio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Proveedores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Coste = 5000.50m,
                            EventoId = 3,
                            Nombre = "Gourmet Catering Co.",
                            Servicio = 1
                        },
                        new
                        {
                            Id = 2,
                            Coste = 3000.75m,
                            EventoId = 1,
                            Nombre = "Melodía Viva",
                            Servicio = 2
                        },
                        new
                        {
                            Id = 3,
                            Coste = 2500.30m,
                            EventoId = 4,
                            Nombre = "Estilo Floral",
                            Servicio = 3
                        },
                        new
                        {
                            Id = 4,
                            Coste = 4000m,
                            EventoId = 2,
                            Nombre = "Evento Perfecto",
                            Servicio = 4
                        },
                        new
                        {
                            Id = 5,
                            Coste = 4500m,
                            EventoId = 3,
                            Nombre = "Fiestas Elite",
                            Servicio = 1
                        },
                        new
                        {
                            Id = 6,
                            Coste = 3500m,
                            EventoId = 2,
                            Nombre = "Ritmo y Sabor",
                            Servicio = 2
                        });
                });

            modelBuilder.Entity("EventosAPI_MartinSanchez.Models.Invitado", b =>
                {
                    b.HasOne("EventosAPI_MartinSanchez.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("EventosAPI_MartinSanchez.Models.Proveedor", b =>
                {
                    b.HasOne("EventosAPI_MartinSanchez.Models.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });
#pragma warning restore 612, 618
        }
    }
}
