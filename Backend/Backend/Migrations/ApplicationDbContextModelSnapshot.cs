﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SkiShop.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Göteborgsvägen 50",
                            City = "Alingsås",
                            Email = "annaa@example.com",
                            FirstName = "Anna",
                            IsAdmin = false,
                            LastName = "Andersson",
                            Password = "annaa",
                            Phone = "1234567890",
                            PostalCode = "44143",
                            UserName = "annaa"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Alingsåsvägen 10",
                            City = "Borås",
                            Email = "bennyb@example.com",
                            FirstName = "Benny",
                            IsAdmin = false,
                            LastName = "Bengtsson",
                            Password = "bennyb",
                            Phone = "2345678901",
                            PostalCode = "50467",
                            UserName = "bennyb"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Boråsvägen 100",
                            City = "Göteborg",
                            Email = "gunnarg@example.com",
                            FirstName = "Gunnar",
                            IsAdmin = false,
                            LastName = "Gunnarsson",
                            Password = "gunnarg",
                            Phone = "3456789012",
                            PostalCode = "41276",
                            UserName = "gunnarg"
                        });
                });

            modelBuilder.Entity("SkiShop.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("SkiShop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comments = "Deliver asap",
                            CustomerID = 1,
                            Date = new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliveryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShippedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Delieverd"
                        },
                        new
                        {
                            Id = 2,
                            Comments = "",
                            CustomerID = 2,
                            Date = new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliveryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShippedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Shipped"
                        },
                        new
                        {
                            Id = 3,
                            Comments = "Deliver after October 30 2022",
                            CustomerID = 3,
                            Date = new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeliveryDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShippedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Pending"
                        });
                });

            modelBuilder.Entity("SkiShop.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("RowAmount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderID = 1,
                            ProductID = 1,
                            Quantity = 1,
                            RowAmount = 0.0
                        },
                        new
                        {
                            Id = 2,
                            OrderID = 1,
                            ProductID = 3,
                            Quantity = 1,
                            RowAmount = 0.0
                        },
                        new
                        {
                            Id = 3,
                            OrderID = 2,
                            ProductID = 6,
                            Quantity = 1,
                            RowAmount = 0.0
                        },
                        new
                        {
                            Id = 4,
                            OrderID = 2,
                            ProductID = 8,
                            Quantity = 2,
                            RowAmount = 0.0
                        },
                        new
                        {
                            Id = 5,
                            OrderID = 3,
                            ProductID = 4,
                            Quantity = 1,
                            RowAmount = 0.0
                        },
                        new
                        {
                            Id = 6,
                            OrderID = 3,
                            ProductID = 6,
                            Quantity = 2,
                            RowAmount = 0.0
                        });
                });

            modelBuilder.Entity("SkiShop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Produktbeskrivning...",
                            InStock = 10,
                            Name = "Skidor, Dam",
                            Price = 4000.0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Produktbeskrivning...",
                            InStock = 12,
                            Name = "Skidor, Herr",
                            Price = 5000.0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Produktbeskrivning...",
                            InStock = 2,
                            Name = "Pjäxa, Dam",
                            Price = 5300.0
                        },
                        new
                        {
                            Id = 4,
                            Description = "Produktbeskrivning...",
                            InStock = 6,
                            Name = "Pjäxa, Herr",
                            Price = 6000.0
                        },
                        new
                        {
                            Id = 5,
                            Description = "Produktbeskrivning...",
                            InStock = 12,
                            Name = "Stavar, Dam",
                            Price = 900.0
                        },
                        new
                        {
                            Id = 6,
                            Description = "Produktbeskrivning...",
                            InStock = 4,
                            Name = "Stavar, Herr",
                            Price = 1100.0
                        },
                        new
                        {
                            Id = 7,
                            Description = "Produktbeskrivning...",
                            InStock = 11,
                            Name = "Hjälm, Dam",
                            Price = 2300.0
                        },
                        new
                        {
                            Id = 8,
                            Description = "Produktbeskrivning...",
                            InStock = 9,
                            Name = "Hjälm, Herr",
                            Price = 2100.0
                        });
                });

            modelBuilder.Entity("SkiShop.Models.Image", b =>
                {
                    b.HasOne("SkiShop.Models.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkiShop.Models.Order", b =>
                {
                    b.HasOne("SkiShop.Models.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkiShop.Models.OrderItem", b =>
                {
                    b.HasOne("SkiShop.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SkiShop.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SkiShop.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("SkiShop.Models.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
