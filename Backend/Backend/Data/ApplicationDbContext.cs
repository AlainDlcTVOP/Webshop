using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using SkiShop.Models;
using System;

namespace Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

        public DbSet<CartContent> CartContents { get; set; }

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
                Name = "Skidor, Herr",
                Description = "VÖLKL Katana V-Werks 22-23",
                Price = 10990,
                InStock = 6
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Skidor, Herr",
                Description = "VÖLKL Deacon V Werks",
                Price = 13499,
                InStock = 12
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Skidor, Herr",
                Description = "VÖLKL Racetiger SL 22-23",
                Price = 9999,
                InStock = 10
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Skidor, Herr",
                Description = "Black Crows Nocta 22-23",
                Price = 8000,
                InStock = 10
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Pjäxa",
                Description = "SCARPA Alien 1.1 mens boot",
                Price = 10495,
                InStock = 2
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Pjäxa",
                Description = "Dalbello Lupo Pro HD",
                Price = 7499,
                InStock = 4
            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "Jacka, Herr",
                Description = "Peak Performance M Alpine RED",
                Price = 6500,
                InStock = 6
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "Jacka, Dam",
                Description = "Peak Performance W Ski Down Jacket Black",
                Price = 7000,
                InStock = 6
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Jacka, Dam",
                Description = "Black Crows W Ora Body Map Jacket Dark Blue",
                Price = 5749,
                InStock = 3
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Byxor, Herr",
                Description = "Norröna M Lofoten Gore-Tex Pants Indigo Night",
                Price = 6999,
                InStock = 6
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Name = "Byxor, Herr",
                Description = "Houdini M Purpose Pants Bucket Blue",
                Price = 5000,
                InStock = 8
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Probe",
                Description = "BLACK Diamond Quick Draw Probe",
                Price = 699,
                InStock = 12
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                Name = "Mössa, Unisex",
                Description = "PEAK Performance Mason Hat Black",
                Price = 550,
                InStock = 25
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 14,
                Name = "Stavar, Unisex",
                Description = "Black Crows Duo Firebird poles",
                Price = 1400,
                InStock = 15
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 15,
                Name = "Spade",
                Description = "Black Diamond Deploy",
                Price = 799,
                InStock = 15
            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 16,
                Name = "Patagonia Womens Jacket",
                Description = "Patagonia W Powerslayer Smolder Blue",
                Price = 8099,
                InStock = 3
            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 17,
                Name = "Norröna M Lofoten Jacket",
                Description = "Norröna M Lofoten Gore-Tex Jacket Hawaiian Blue",
                Price = 9999,
                InStock = 5
            });



            // Images

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 1,
                ProductID = 1,
                Name = "VÖLKL Katana VWerks Offpist",
                Src = "images/VÖLKLKatanaVWerks.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 2,
                ProductID = 2,
                Name = "VÖLKL Deacon V Werks",
                Src = "images/VÖLKLDeaconVWerks.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 3,
                ProductID = 3,
                Name = "VÖLKL Racetiger",
                Src = "images/VÖLKLRacetiger.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 4,
                ProductID = 4,
                Name = "Black Crows",
                Src = "images/BLACKCrowsNocta22-23page3.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 5,
                ProductID = 5,
                Name = "SCARPA Alien 1.1 mens boot",
                Src = "images/SCARPAAlien.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 6,
                ProductID = 6,
                Name = "Dalbello Lupo Pro HD",
                Src = "images/DALBELLOLupoProHD.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 7,
                ProductID = 7,
                Name = "Peak Performance M Alpine Red",
                Src = "images/PeakPerformanceAlpineJacket.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 8,
                ProductID = 8,
                Name = "PeakPerformance W Ski Down Jacket Black",
                Src = "images/PeakPerformanceWAlpineJacket.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 9,
                ProductID = 9,
                Name = "Black Crows W Ora Body Map Jacket Dark Blue",
                Src = "images/BlackCrowsWJacketDBlue.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 10,
                ProductID = 10,
                Name = "Norröna M Lofoten Pants Indigo Night ",
                Src = "images/NorrönaLofotenProPants.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 11,
                ProductID = 11,
                Name = "Houdini M Purpose Pants Bucket Blue",
                Src = "images/HoudiniPurposePantsBlue.png",
                Alt = ""
            });


            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 12,
                ProductID = 12,
                Name = "Black Diamond Probe",
                Src = "images/BlackDiamondQuickDrawProbe.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 13,
                ProductID = 13,
                Name = "Peak Performance Mason Hat Black",
                Src = "images/PeakPerformanceHatBlack.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 14,
                ProductID = 14,
                Name = "Black Crows Duo Firebird poles",
                Src = "images/BlackCrowsPoles.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 15,
                ProductID = 15,
                Name = "Black Diamond Deploy",
                Src = "images/BlackDiamondDeploy.png",
                Alt = ""
            });



            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 16,
                ProductID = 16,
                Name = "",
                Src = "images/PatagoniaWPowSlayerJacketSmolderBlue.png",
                Alt = ""
            });

            modelBuilder.Entity<Image>().HasData(new Image
            {
                Id = 17,
                ProductID = 17,
                Name = "",
                Src = "images/NorrönaMLofotenProJacket.png",
                Alt = ""
            });


            //Orders

            modelBuilder.HasSequence("OrderNrSequence", x => x.StartsAt(2022001).IncrementsBy(1));
            modelBuilder.Entity<Order>().Property(o => o.OrderNr).HasDefaultValueSql("NEXT VALUE FOR OrderNrSequence");

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                ApplicationUserId = userID1,
                Date = new DateTime(2022, 10, 26),
                OrderAmount = 23435,
                Status = "Delivered",
                Comments = "Deliver asap",
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 2,
                ApplicationUserId = userID2,
                Date = new DateTime(2022, 10, 27),
                OrderAmount = 11500,
                Status = "Shipped",
                Comments = "",
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 3,
                ApplicationUserId = userID3,
                Date = new DateTime(2022, 10, 28),
                OrderAmount = 11498,
                Status = "Pending",
                Comments = "Deliver after October 30 2022",
            });


            //Order items

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 1,
                OrderID = 1,
                ProductID = 1, // Skidor, Herr
                Name = "VÖLKL Katana VWerks Offpist",
                Price = 10990,
                Quantity = 1,
                RowAmount = 10990
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 2,
                OrderID = 1,
                ProductID = 5,
                Name = "SCARPA Alien 1.1 mens boot",
                Price = 10495,
                Quantity = 1,
                RowAmount = 10495
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 3,
                OrderID = 1,
                ProductID = 6,
                Name = "Black Crows Duo Firebird poles",
                Price = 1400,
                Quantity = 1,
                RowAmount = 1400,
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 4,
                OrderID = 1,
                ProductID = 13, // Mössa
                Name = "Peak Performance Mason Hat Black",
                Price = 550,
                Quantity = 2,
                RowAmount = 550
            });


            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 5,
                OrderID = 2,
                ProductID = 7, // Jacka, herr
                Name = "Peak Performance M Alpine Red",
                Price = 6500,
                Quantity = 1,
                RowAmount = 6500
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 6,
                OrderID = 2,
                ProductID = 11, // Byxor, herr
                Name = "Houdini M Purpose Pants Bucket Blue",
                Price = 5000,
                Quantity = 1,
                RowAmount = 5000
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 7,
                OrderID = 3,
                ProductID = 11, // Jacka, Dam
                Name = "Black Crows W Ora Body Map Jacket Dark Blue",
                Price = 5749,
                Quantity = 1,
                RowAmount = 5749
            });

        }
    }
}
