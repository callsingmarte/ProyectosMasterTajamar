﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidosBlazor.Data;

#nullable disable

namespace PedidosBlazor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PedidosBlazor.Models.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Category = "Sports Equipment",
                            Name = "Soccer Ball",
                            Price = 25.99m
                        },
                        new
                        {
                            ID = 2,
                            Category = "Footwear",
                            Name = "Running Shoes",
                            Price = 80.00m
                        },
                        new
                        {
                            ID = 3,
                            Category = "Sports Equipment",
                            Name = "Boxing Gloves",
                            Price = 45.50m
                        },
                        new
                        {
                            ID = 4,
                            Category = "Sports Equipment",
                            Name = "Basketball",
                            Price = 30.00m
                        },
                        new
                        {
                            ID = 5,
                            Category = "Sports Equipment",
                            Name = "Tennis Racket",
                            Price = 120.00m
                        });
                });

            modelBuilder.Entity("PedidosBlazor.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("ArticleID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            ArticleID = 1,
                            CompanyName = "Sports World",
                            OrderDate = new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 15
                        },
                        new
                        {
                            OrderID = 2,
                            ArticleID = 2,
                            CompanyName = "Footwear Co.",
                            OrderDate = new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 20
                        },
                        new
                        {
                            OrderID = 3,
                            ArticleID = 3,
                            CompanyName = "Fitness Depot",
                            OrderDate = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 10
                        },
                        new
                        {
                            OrderID = 4,
                            ArticleID = 4,
                            CompanyName = "Pro Hoops",
                            OrderDate = new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 12
                        },
                        new
                        {
                            OrderID = 5,
                            ArticleID = 5,
                            CompanyName = "Tennis Experts",
                            OrderDate = new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("PedidosBlazor.Models.Order", b =>
                {
                    b.HasOne("PedidosBlazor.Models.Article", null)
                        .WithMany("Orders")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PedidosBlazor.Models.Article", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}