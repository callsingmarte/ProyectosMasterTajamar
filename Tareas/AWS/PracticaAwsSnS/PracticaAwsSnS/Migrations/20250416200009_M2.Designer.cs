﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaAwsSnS.Data;

#nullable disable

namespace PracticaAwsSnS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250416200009_M2")]
    partial class M2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticaAwsSnS.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = 1,
                            Nombre = "Caja de 40 tornillos estrella",
                            Precio = 1.60m
                        },
                        new
                        {
                            Id = 2,
                            Cantidad = 1,
                            Nombre = "Destornillador de estrella",
                            Precio = 2.50m
                        },
                        new
                        {
                            Id = 3,
                            Cantidad = 1,
                            Nombre = "Destornillador plano",
                            Precio = 2.50m
                        },
                        new
                        {
                            Id = 4,
                            Cantidad = 1,
                            Nombre = "Martillo",
                            Precio = 3.50m
                        },
                        new
                        {
                            Id = 5,
                            Cantidad = 1,
                            Nombre = "Caja de 40 tornillos planos",
                            Precio = 1.60m
                        },
                        new
                        {
                            Id = 6,
                            Cantidad = 1,
                            Nombre = "Regla de 3 metros",
                            Precio = 3.20m
                        },
                        new
                        {
                            Id = 7,
                            Cantidad = 1,
                            Nombre = "Caja de 20 tacos",
                            Precio = 1.30m
                        });
                });

            modelBuilder.Entity("PracticaAwsSnS.Models.PedidoUsuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdUsuario");

                    b.ToTable("PedidosUsuarios");
                });

            modelBuilder.Entity("PracticaAwsSnS.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PracticaAwsSnS.Models.PedidoUsuario", b =>
                {
                    b.HasOne("PracticaAwsSnS.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticaAwsSnS.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
