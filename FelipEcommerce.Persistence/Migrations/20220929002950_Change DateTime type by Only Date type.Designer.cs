﻿// <auto-generated />
using System;
using FelipEcommerce.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FelipEcommerce.Persistence.Migrations
{
    [DbContext(typeof(FelipEcommerceContext))]
    [Migration("20220929002950_Change DateTime type by Only Date type")]
    partial class ChangeDateTimetypebyOnlyDatetype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "XXX",
                            Age = 34,
                            Dni = "1X2X3X",
                            FirstName = "Gina",
                            LastName = "Balanta",
                            Phone = "123456789"
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InventoryDate")
                        .HasColumnType("Date");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Inventory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InventoryDate = new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            ProductId = 1,
                            Qty = 50,
                            Type = "XD"
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("Date");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Isv")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Discount = 19,
                            InvoiceDate = new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            Isv = 0,
                            SubTotal = 1000m,
                            Total = 10000m,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceDetail");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InvoiceId = 1,
                            Price = 5000m,
                            ProductId = 1,
                            Qty = 5
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Maximum")
                        .HasColumnType("int");

                    b.Property<int>("Minimum")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurshacePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "das54a5da",
                            Maximum = 708,
                            Minimum = 50,
                            Name = "Televisor",
                            PurshacePrice = 1500000m,
                            SellingPrice = 1700000m,
                            Type = "XDXDXD"
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Juan Felipe Balanta Rentería",
                            Password = "felipe123",
                            UserName = "felipe"
                        });
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Inventory", b =>
                {
                    b.HasOne("FelipEcommerce.Domain.Models.Product", "Product")
                        .WithOne("Inventory")
                        .HasForeignKey("FelipEcommerce.Domain.Models.Inventory", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Invoice", b =>
                {
                    b.HasOne("FelipEcommerce.Domain.Models.Client", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FelipEcommerce.Domain.Models.User", "User")
                        .WithMany("Invonces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.InvoiceDetail", b =>
                {
                    b.HasOne("FelipEcommerce.Domain.Models.Invoice", "Invoice")
                        .WithOne("InvoiceDetail")
                        .HasForeignKey("FelipEcommerce.Domain.Models.InvoiceDetail", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FelipEcommerce.Domain.Models.Product", "Product")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Client", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetail");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.Product", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("FelipEcommerce.Domain.Models.User", b =>
                {
                    b.Navigation("Invonces");
                });
#pragma warning restore 612, 618
        }
    }
}
