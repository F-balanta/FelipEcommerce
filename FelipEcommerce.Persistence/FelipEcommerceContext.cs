using FelipEcommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using FelipEcommerce.Persistence.Data;

namespace FelipEcommerce.Persistence
{
    public class FelipEcommerceContext : DbContext
    {
        public FelipEcommerceContext(DbContextOptions<FelipEcommerceContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(SeedData.Users);
            modelBuilder.Entity<Client>().HasData(SeedData.Clients);
            modelBuilder.Entity<Product>().HasData(SeedData.Products);
            modelBuilder.Entity<Invoice>().HasData(SeedData.Invoices);
            modelBuilder.Entity<InvoiceDetail>().HasData(SeedData.InvoiceDetails);
            modelBuilder.Entity<Inventory>().HasData(SeedData.Inventories);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoicesDetail { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}