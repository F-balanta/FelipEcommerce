using System;
using FelipEcommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FelipEcommerce.Persistence
{
    public class FelipEcommerceContext : DbContext
    {
        public FelipEcommerceContext(DbContextOptions<FelipEcommerceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Juan Felipe Balanta Rentería",
                    UserName = "felipe",
                    Password = "felipe123"
                }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Address = "XXX",
                    Dni = "1X2X3X",
                    FirstName = "Gina",
                    LastName = "Balanta",
                    Phone = "123456789"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Televisor",
                    Code = "das54a5da",
                    Minimum = 50,
                    Maximum = 708,
                    PurshacePrice = 1500000,
                    SellingPrice = 1700000,
                    Type = "XDXDXD"
                });

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 1,
                    ClientId = 1,
                    UserId = 1,
                    Discount = 19,
                    SubTotal = 1000,
                    Total = 10000,
                    InvoiceDate = DateTime.Now
                });

            modelBuilder.Entity<InvoiceDetail>().HasData(
                new InvoiceDetail
                {
                    Id = 1,
                    InvoiceId = 1,
                    Qty = 5,
                    Price = 5000,
                    ProductId = 1
                });

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = 1,
                    Type = "XD",
                    ProductId = 1,
                    Qty = 50,
                    InventoryDate = DateTime.Now
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}