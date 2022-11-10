using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkiShop.Models;
using System;

namespace Backend.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add roles

            string adminRoleID = Guid.NewGuid().ToString();
            string userRoleID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleID,
                Name = "Admin",
                NormalizedName = "ADMIN",
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleID,
                Name = "User",
                NormalizedName = "USER",
            });

            // Add users

            string adminID = Guid.NewGuid().ToString();
            string userID1 = Guid.NewGuid().ToString();
            string userID2 = Guid.NewGuid().ToString();
            string userID3 = Guid.NewGuid().ToString();
            PasswordHasher<ApplicationUser> hasher = new();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminID,
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                UserName = "admin@example.com", // For simplicity's sake, keep same as email
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                FirstName = "Admin",
                LastName = "Adminsson",
                Address = "Gatan 1",
                PostalCode = "11122",
                City = "Köping",
                PhoneNumber = "9999999999",
                PasswordHash = hasher.HashPassword(null, "admin"),
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userID1,
                Email = "annaa@example.com",
                NormalizedEmail = "ANNAA@EXAMPLE.COM",
                UserName = "annaa@example.com", // For simplicity's sake, keep username same as email
                NormalizedUserName = "ANNAA@EXAMPLE.COM",
                FirstName = "Anna",
                LastName = "Andersson",
                Address = "Göteborgsvägen 50",
                PostalCode = "44143",
                City = "Alingsås",
                PhoneNumber = "1234567890",
                PasswordHash = hasher.HashPassword(null, "annaa"),
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userID2,
                Email = "bennyb@example.com",
                NormalizedEmail = "BENNYB@EXAMPLE.COM",
                UserName = "bennyb@example.com", // For simplicity's sake, keep username same as email
                NormalizedUserName = "BENNYB@EXAMPLE.COM",
                FirstName = "Benny",
                LastName = "Bengtsson",
                Address = "Alingsåsvägen 10",
                PostalCode = "50467",
                City = "Borås",
                PhoneNumber = "2345678901",
                PasswordHash = hasher.HashPassword(null, "bennyb"),
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userID3,
                Email = "gunnarg@example.com",
                NormalizedEmail = "GUNNARG@EXAMPLE.COM",
                UserName = "gunnarg@example.com", // For simplicity's sake, keep username same as email
                NormalizedUserName = "GUNNARG@EXAMPLE.COM",
                FirstName = "Gunnar",
                LastName = "Gunnarsson",
                Address = "Boråsvägen 100",
                PostalCode = "41276",
                City = "Göteborg",
                PhoneNumber = "3456789012",
                PasswordHash = hasher.HashPassword(null, "gunnarg"),
            });


            // Assign roles to users

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleID,
                UserId = adminID,
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = userRoleID,
                UserId = userID1,
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = userRoleID,
                UserId = userID2,
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = userRoleID,
                UserId = userID3,
            });


            //Products

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
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


            // Images

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 1,
                ProductID = 1,
                Name = "Black Crows",
                Src = "image/BLACKCrowsNocta22-23page3.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 2,
                ProductID = 2,
                Name = "VÖLKL Deacon V Werks",
                Src = "image/VÖLKLDeaconVWerks.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 3,
                ProductID = 3,
                Name = "SCARPA Alien",
                Src = "image/SCARPAAlien.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 4,
                ProductID = 4,
                Name = "SCARPA Alien",
                Src = "image/SCARPAAlien.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 5,
                ProductID = 5,
                Name = "BLACK Diamond Quickdraw Probe",
                Src = "image/BLACKDiamondQuickdrawProbe.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 6,
                ProductID = 6,
                Name = "BLACK Diamond Quickdraw Probe",
                Src = "image/BLACKDiamondQuickdrawProbe.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 7,
                ProductID = 7,
                Name = "PEAK Performance Hat Black",
                Src = "image/PEAKPerformanceHatBlack.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 8,
                ProductID = 8,
                Name = "PEAK Performance Hat Black",
                Src = "image/PEAKPerformanceHatBlack.png",
                Alt = ""
            });


            //Orders

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                ApplicationUserId = userID1,
                Date = new DateTime(2022, 10, 26),
                Status = "Delivered",
                Comments = "Deliver asap",
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 2,
                ApplicationUserId = userID2,
                Date = new DateTime(2022, 10, 27),
                Status = "Shipped",
                Comments = "",
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 3,
                ApplicationUserId = userID3,
                Date = new DateTime(2022, 10, 28),
                Status = "Pending",
                Comments = "Deliver after October 30 2022",
            });


            //Order items

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 1,
                OrderID = 1,
                ProductID = 1, // Skidor, dam
                Name = "Skidor, Dam",
                Price = 4000,
                Quantity = 1,
                RowAmount = 4000
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 2,
                OrderID = 1,
                ProductID = 3, // Pjäxor, dam
                Name = "Pjäxa, Dam",
                Price = 5300,
                Quantity = 1,
                RowAmount = 5300
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 3,
                OrderID = 2,
                ProductID = 6, // Stavar, herr
                Name = "Stavar, Herr",
                Price = 1100,
                Quantity = 1,
                RowAmount = 1100,
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 4,
                OrderID = 2,
                ProductID = 8, // Hjälm, herr
                Name = "Hjälm, Herr",
                Price = 2100,
                Quantity = 2,
                RowAmount = 4200
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 5,
                OrderID = 3,
                ProductID = 4, // Pjäxa, herr
                Name = "Pjäxa, Herr",
                Price = 6000,
                Quantity = 1,
                RowAmount = 6000
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 6,
                OrderID = 3,
                ProductID = 6, // Stavar, herr
                Name = "Stavar, Herr",
                Price = 1100,
                Quantity = 2,
                RowAmount = 2200
            });

        }
    }
}
