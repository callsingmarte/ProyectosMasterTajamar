﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductosWebAPI.Context;

#nullable disable

namespace ProductosWebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductosWebAPI.Models.Categories_DB", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Watersports"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Soccer"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Chess"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Tenis"
                        });
                });

            modelBuilder.Entity("ProductosWebAPI.Models.Products_DB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryID = 1,
                            Name = "Kayak",
                            Price = 286m
                        },
                        new
                        {
                            Id = 2,
                            CategoryID = 1,
                            Name = "Lifejacket",
                            Price = 48.95m
                        },
                        new
                        {
                            Id = 3,
                            CategoryID = 2,
                            Name = "Soccer Ball",
                            Price = 19.50m
                        },
                        new
                        {
                            Id = 4,
                            CategoryID = 2,
                            Name = "Corner Flags",
                            Price = 34.95m
                        },
                        new
                        {
                            Id = 5,
                            CategoryID = 3,
                            Name = "Stadium",
                            Price = 79500m
                        },
                        new
                        {
                            Id = 6,
                            CategoryID = 3,
                            Name = "Thinking Cap",
                            Price = 16.00m
                        },
                        new
                        {
                            Id = 7,
                            CategoryID = 3,
                            Name = "TUnsteady Chair",
                            Price = 29.95m
                        },
                        new
                        {
                            Id = 8,
                            CategoryID = 3,
                            Name = "Human Chess Board",
                            Price = 75m
                        },
                        new
                        {
                            Id = 9,
                            CategoryID = 3,
                            Name = "Bling Bling King",
                            Price = 1200m
                        });
                });

            modelBuilder.Entity("ProductosWebAPI.Models.Products_DB", b =>
                {
                    b.HasOne("ProductosWebAPI.Models.Categories_DB", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
