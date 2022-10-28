using Microsoft.EntityFrameworkCore;
using SkiShop.Models;

namespace Backend.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customers

            modelBuilder.Entity<Customer>().HasData(new Customer {
                Id = 1,
                UserName = "annaa", 
                FirstName = "Anna", 
                LastName = "Andersson", 
                Address = "Göteborgsvägen 50",
                PostalCode = "44143",
                City = "Alingsås",
                Phone = "1234567890",
                Email = "annaa@example.com",
                Password = "annaa", //replace with password hash
                IsAdmin = false
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 2,
                UserName = "bennyb",
                FirstName = "Benny",
                LastName = "Bengtsson",
                Address = "Alingsåsvägen 10",
                PostalCode = "50467",
                City = "Borås",
                Phone = "2345678901",
                Email = "bennyb@example.com",
                Password = "bennyb", //replace with password hash
                IsAdmin = false
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 3,
                UserName = "gunnarg",
                FirstName = "Gunnar",
                LastName = "Gunnarsson",
                Address = "Boråsvägen 100",
                PostalCode = "41276",
                City = "Göteborg",
                Phone = "3456789012",
                Email = "gunnarg@example.com",
                Password = "gunnarg", //replace with password hash
                IsAdmin = false
            });

            //Products

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id=1,
                Name = "Skidor, Dam",
                Description = "Produktbeskrivning...",
                Price = 4000,
                InStock = 10
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Skidor, Herr",
                Description = "Produktbeskrivning...",
                Price = 5000,
                InStock = 12
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Pjäxa, Dam",
                Description = "Produktbeskrivning...",
                Price = 5300,
                InStock = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Pjäxa, Herr",
                Description = "Produktbeskrivning...",
                Price = 6000,
                InStock = 6
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Stavar, Dam",
                Description = "Produktbeskrivning...",
                Price = 900,
                InStock = 12
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Stavar, Herr",
                Description = "Produktbeskrivning...",
                Price = 1100,
                InStock = 4
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Hjälm, Dam",
                Description = "Produktbeskrivning...",
                Price = 2300,
                InStock = 11
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Hjälm, Herr",
                Description = "Produktbeskrivning...",
                Price = 2100,
                InStock = 9
            });
        }
    }
}
