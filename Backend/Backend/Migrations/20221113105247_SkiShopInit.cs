﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class SkiShopInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "OrderNrSequence",
                startValue: 2022001L);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNr = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR OrderNrSequence"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderAmount = table.Column<double>(type: "float", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartContents",
                columns: table => new
                {
                    CartContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartContents", x => x.CartContentId);
                    table.ForeignKey(
                        name: "FK_CartContents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RowAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31a066ae-bda5-4882-9e85-8d48074bbda8", "e91ffc5c-034d-4773-8568-b5944b420e50", "User", "USER" },
                    { "db2240f4-2b0f-499a-bba4-8bb56b195a7d", "81c5b7df-94ed-4d6f-8bbc-abf50fa8f390", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "14a18be9-1761-4036-8eda-2e716de92bba", 0, "Göteborgsvägen 50", "Alingsås", "c3d8a796-b98a-434a-b94c-864e2d674a99", "annaa@example.com", false, "Anna", "Andersson", false, null, "ANNAA@EXAMPLE.COM", "ANNAA@EXAMPLE.COM", "AQAAAAEAACcQAAAAEIufpnxYmQru6ZNs45e4MmXMs/ZoESO7BMvTtgiUH4WKJHL5RrWjrl7ei6w54zPDbQ==", "1234567890", false, "44143", "4bfbd4c0-127f-4fd6-a32a-5f21a0aed4d6", false, "annaa@example.com" },
                    { "6996e217-3b23-4951-8f7d-d9dcb002aefc", 0, "Boråsvägen 100", "Göteborg", "80d7393e-e1ac-447e-ba1a-4ad51b3a98a9", "gunnarg@example.com", false, "Gunnar", "Gunnarsson", false, null, "GUNNARG@EXAMPLE.COM", "GUNNARG@EXAMPLE.COM", "AQAAAAEAACcQAAAAEIYUjM3BKpPu8S4uEKEsCkMmHraPwOTb9XDy2Y3m3s4bP0y0YBg8RMc+xnBx20nN+Q==", "3456789012", false, "41276", "cff85004-1385-4ea0-af5f-bb4e068b8ff4", false, "gunnarg@example.com" },
                    { "941150db-63ee-4f38-9b0a-ccc032935c6c", 0, "Alingsåsvägen 10", "Borås", "afe8a24c-c40e-40ed-bce5-067b3cfeb863", "bennyb@example.com", false, "Benny", "Bengtsson", false, null, "BENNYB@EXAMPLE.COM", "BENNYB@EXAMPLE.COM", "AQAAAAEAACcQAAAAEISvIAoYZ8bwkgUa3eNN+3t+uOV8OgLe9ILHPJnq4ZT7a2Yi0BgkWj7MsksX/otOuw==", "2345678901", false, "50467", "ae938cb7-bb31-40f1-9e31-34b1bd76da22", false, "bennyb@example.com" },
                    { "b030e5de-36af-437a-9d28-c618533f3c2c", 0, "Gatan 1", "Köping", "603d1535-35fd-4d88-a567-39aad111fbab", "admin@example.com", false, "Admin", "Adminsson", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEIskK59PKNjvjlSP0VQ/3aqoogJg4cMGAZHy8Z1Cmkt4o2QlLV6B6Kj4pJXFIAUvUw==", "9999999999", false, "11122", "da692aa9-e181-475d-bcd5-29d37780f7c8", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "InStock", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "VÖLKL Katana V-Werks 22-23", 6, "Skidor, Herr", 10990.0 },
                    { 2, "VÖLKL Deacon V Werks", 12, "Skidor, Herr", 13499.0 },
                    { 3, "VÖLKL Racetiger SL 22-23", 10, "Skidor, Herr", 9999.0 },
                    { 4, "Black Crows Nocta 22-23", 10, "Skidor, Herr", 8000.0 },
                    { 5, "SCARPA Alien 1.1 mens boot", 2, "Pjäxa", 10495.0 },
                    { 6, "Dalbello Lupo Pro HD", 4, "Pjäxa", 7499.0 },
                    { 7, "Peak Performance M Alpine RED", 6, "Jacka, Herr", 6500.0 },
                    { 8, "Peak Performance W Ski Down Jacket Black", 6, "Jacka, Dam", 7000.0 },
                    { 9, "Black Crows W Ora Body Map Jacket Dark Blue", 3, "Jacka, Dam", 5749.0 },
                    { 10, "Norröna M Lofoten Gore-Tex Pants Indigo Night", 6, "Byxor, Herr", 6999.0 },
                    { 11, "Houdini M Purpose Pants Bucket Blue", 8, "Byxor, Herr", 5000.0 },
                    { 12, "BLACK Diamond Quick Draw Probe", 12, "Probe", 699.0 },
                    { 13, "PEAK Performance Mason Hat Black", 25, "Mössa, Unisex", 550.0 },
                    { 14, "Black Crows Duo Firebird poles", 15, "Stavar, Unisex", 1400.0 },
                    { 15, "Black Diamond Deploy", 15, "Spade", 799.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "31a066ae-bda5-4882-9e85-8d48074bbda8", "14a18be9-1761-4036-8eda-2e716de92bba" },
                    { "31a066ae-bda5-4882-9e85-8d48074bbda8", "6996e217-3b23-4951-8f7d-d9dcb002aefc" },
                    { "31a066ae-bda5-4882-9e85-8d48074bbda8", "941150db-63ee-4f38-9b0a-ccc032935c6c" },
                    { "db2240f4-2b0f-499a-bba4-8bb56b195a7d", "b030e5de-36af-437a-9d28-c618533f3c2c" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "Name", "ProductID", "Src" },
                values: new object[,]
                {
                    { 1, "", "VÖLKL Katana VWerks Offpist", 1, "images/VÖLKLKatanaVWerks.png" },
                    { 2, "", "VÖLKL Deacon V Werks", 2, "images/VÖLKLDeaconVWerks.png" },
                    { 3, "", "VÖLKL Racetiger", 3, "images/VÖLKLRacetiger.png" },
                    { 4, "", "Black Crows", 4, "images/BLACKCrowsNocta22-23page3.png" },
                    { 5, "", "SCARPA Alien 1.1 mens boot", 5, "images/SCARPAAlien.png" },
                    { 6, "", "Dalbello Lupo Pro HD", 6, "images/DALBELLOLupoProHD.png" },
                    { 7, "", "Peak Performance M Alpine Red", 7, "images/PeakPerformanceAlpineJacket.png" },
                    { 8, "", "PeakPerformance W Ski Down Jacket Black", 8, "images/PeakPerformanceWAlpineJacket.png" },
                    { 9, "", "Black Crows W Ora Body Map Jacket Dark Blue", 9, "images/BlackCrowsWJacketDBlue.png" },
                    { 10, "", "Norröna M Lofoten Pants Indigo Night ", 10, "images/NorrönaLofotenProPants.png" },
                    { 11, "", "Houdini M Purpose Pants Bucket Blue", 11, "images/HoudiniPurposePantsBlue.png" },
                    { 12, "", "Black Diamond Probe", 12, "images/BlackDiamondQuickDrawProbe.png" },
                    { 13, "", "Peak Performance Mason Hat Black", 13, "images/PeakPerformanceHatBlack.png" },
                    { 14, "", "Black Crows Duo Firebird poles", 14, "images/BlackCrowsPoles.png" },
                    { 15, "", "Black Diamond Deploy", 15, "images/BlackDiamondDeploy.png" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "Comments", "Date", "DeliveryDate", "OrderAmount", "ShippedDate", "Status" },
                values: new object[,]
                {
                    { 1, "14a18be9-1761-4036-8eda-2e716de92bba", "Deliver asap", new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23435.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 2, "941150db-63ee-4f38-9b0a-ccc032935c6c", "", new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11500.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped" },
                    { 3, "6996e217-3b23-4951-8f7d-d9dcb002aefc", "Deliver after October 30 2022", new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11498.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Name", "OrderID", "Price", "ProductID", "Quantity", "RowAmount" },
                values: new object[,]
                {
                    { 1, "VÖLKL Katana VWerks Offpist", 1, 10990.0, 1, 1, 10990.0 },
                    { 2, "SCARPA Alien 1.1 mens boot", 1, 10495.0, 5, 1, 10495.0 },
                    { 3, "Black Crows Duo Firebird poles", 1, 1400.0, 6, 1, 1400.0 },
                    { 4, "Peak Performance Mason Hat Black", 1, 550.0, 13, 2, 550.0 },
                    { 5, "Peak Performance M Alpine Red", 2, 6500.0, 7, 1, 6500.0 },
                    { 6, "Houdini M Purpose Pants Bucket Blue", 2, 5000.0, 11, 1, 5000.0 },
                    { 7, "Black Crows W Ora Body Map Jacket Dark Blue", 3, 5749.0, 11, 1, 5749.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartContents_ProductId",
                table: "CartContents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductID",
                table: "Images",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartContents");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "OrderNrSequence");
        }
    }
}
