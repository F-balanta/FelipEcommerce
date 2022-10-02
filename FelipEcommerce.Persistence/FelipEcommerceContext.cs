using FelipEcommerce.Domain.Models;
using FelipEcommerce.Persistence.Data;
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
            modelBuilder.Entity<User>().HasData(SeedData.Users);
            modelBuilder.Entity<Client>().HasData(SeedData.Clients);
            modelBuilder.Entity<Product>().HasData(SeedData.Products);
            modelBuilder.Entity<Invoice>().HasData(SeedData.Invoices);
            modelBuilder.Entity<Inventory>().HasData(SeedData.Inventories);

            modelBuilder.Entity<Invoice>().HasIndex(x => x.InvoiceNumber).IsUnique();
            modelBuilder.Entity<Invoice>().Property(x => x.InvoiceNumber).IsRequired(false);


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