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
                    { "08d502ec-38ec-4a21-bea8-93c0858d6298", "8002f336-405a-4840-9aa6-6a1ed591ae21", "User", "USER" },
                    { "e5e03676-1178-4bdb-befc-b1df99b4d305", "43257e96-eb50-4156-814a-154eaee6095e", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6638885c-4dfe-42c9-be7c-5e7be2b9a14d", 0, "Göteborgsvägen 50", "Alingsås", "71dc6f51-587c-4867-a688-c39fe911d0b5", "annaa@example.com", false, "Anna", "Andersson", false, null, "ANNAA@EXAMPLE.COM", "ANNAA@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGmvIaJsfYs/xUIKW1Ot2GObeC6E6l7DH6R3I916qz7YoI/L30jYydWH0ZSQtq/fKA==", "1234567890", false, "44143", "6accc9f9-178d-4cc9-8953-780ab43a51fe", false, "annaa@example.com" },
                    { "7753ea16-760b-435c-bb52-59d78bcb0ff5", 0, "Alingsåsvägen 10", "Borås", "1856f579-b697-4bbc-9393-48b15eb5db38", "bennyb@example.com", false, "Benny", "Bengtsson", false, null, "BENNYB@EXAMPLE.COM", "BENNYB@EXAMPLE.COM", "AQAAAAEAACcQAAAAEEu8cykow8YFRmyrxdPK1S14XYOJ2FiIQ2Dbolwkf+B005LHlc+HiuT9L9GbptnS7w==", "2345678901", false, "50467", "f3b67561-5ad7-4b92-b65a-5a889457bd61", false, "bennyb@example.com" },
                    { "789e8807-28fc-482c-8232-b4bc840e747d", 0, "Boråsvägen 100", "Göteborg", "024f8461-e257-4505-8829-9ffe05ec4503", "gunnarg@example.com", false, "Gunnar", "Gunnarsson", false, null, "GUNNARG@EXAMPLE.COM", "GUNNARG@EXAMPLE.COM", "AQAAAAEAACcQAAAAEMt9S0eUSP0mlcaU/shnaQ6ItMYw6Ap+xI5Cctjjpo5iD+eDZ62bwEYGilOoavrh8Q==", "3456789012", false, "41276", "f2329f3d-9c49-4615-848e-54901112a2ea", false, "gunnarg@example.com" },
                    { "95a466e2-663c-453d-9b3a-d2c312832f0a", 0, "Gatan 1", "Köping", "db42b155-7c83-4a47-a0ef-d6cf2c78551c", "admin@example.com", false, "Admin", "Adminsson", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKkr+oB4xyMQRy6EWzCElZmQQK+Ie3Ibz7iKbYWKFfMQiRkHkA4AG18Z6lfOWuqiMQ==", "9999999999", false, "11122", "fa9a4732-0423-4c74-9c97-b5fd8e8a9c27", false, "admin@example.com" }
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
                    { 15, "Black Diamond Deploy", 15, "Spade", 799.0 },
                    { 16, "Patagonia W Powerslayer Smolder Blue", 3, "Patagonia Womens Jacket", 8099.0 },
                    { 17, "Norröna M Lofoten Gore-Tex Jacket Hawaiian Blue", 5, "Norröna M Lofoten Jacket", 9999.0 },
                    { 18, "Marker King Pin 13 binding", 5, "Marker King Pin 13", 5199.0 },
                    { 19, "King Ping Pt 16", 5, "King Ping Pt 16", 6199.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "08d502ec-38ec-4a21-bea8-93c0858d6298", "6638885c-4dfe-42c9-be7c-5e7be2b9a14d" },
                    { "08d502ec-38ec-4a21-bea8-93c0858d6298", "7753ea16-760b-435c-bb52-59d78bcb0ff5" },
                    { "08d502ec-38ec-4a21-bea8-93c0858d6298", "789e8807-28fc-482c-8232-b4bc840e747d" },
                    { "e5e03676-1178-4bdb-befc-b1df99b4d305", "95a466e2-663c-453d-9b3a-d2c312832f0a" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "Name", "ProductID", "Src" },
                values: new object[,]
                {
                    { 1, "", "VÖLKL Katana VWerks Offpist", 1, "images/VÖLKLKatanaVWerks.png" },
                    { 2, "", "VÖLKL Deacon V Werks", 2, "images/VÖLKLDeaconVWerks.png" },
                    { 3, "", "VÖLKL Racetiger", 3, "images/VÖLKLRacetiger.png" },
                    { 4, "", "Black Crows", 4, "images/BLACKCrowsNocta22-23.png" },
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
                    { 15, "", "Black Diamond Deploy", 15, "images/BlackDiamondDeploy.png" },
                    { 16, "", "", 16, "images/PatagoniaWPowSlayerJacketSmolderBlue.png" },
                    { 17, "", "", 17, "images/NorrönaMLofotenProJacket.png" },
                    { 18, "", "", 18, "images/MarkerKing113.png" },
                    { 19, "", "", 19, "images/MarkerDuke.png" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "Comments", "Date", "DeliveryDate", "OrderAmount", "ShippedDate", "Status" },
                values: new object[,]
                {
                    { 1, "6638885c-4dfe-42c9-be7c-5e7be2b9a14d", "Deliver asap", new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28694.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 2, "7753ea16-760b-435c-bb52-59d78bcb0ff5", "", new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11500.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped" },
                    { 3, "789e8807-28fc-482c-8232-b4bc840e747d", "Deliver after October 30 2022", new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11498.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Name", "OrderID", "Price", "ProductID", "Quantity", "RowAmount" },
                values: new object[,]
                {
                    { 1, "VÖLKL Katana VWerks Offpist", 1, 10990.0, 1, 1, 10990.0 },
                    { 2, "Marker King Pin 13", 1, 5199.0, 18, 1, 10990.0 },
                    { 3, "SCARPA Alien 1.1 mens boot", 1, 10495.0, 5, 1, 10495.0 },
                    { 4, "Black Crows Duo Firebird poles", 1, 1400.0, 6, 1, 1400.0 },
                    { 5, "Peak Performance Mason Hat Black", 1, 550.0, 13, 2, 550.0 },
                    { 6, "Peak Performance M Alpine Red", 2, 6500.0, 7, 1, 6500.0 },
                    { 7, "Houdini M Purpose Pants Bucket Blue", 2, 5000.0, 11, 1, 5000.0 },
                    { 8, "Black Crows W Ora Body Map Jacket Dark Blue", 3, 5749.0, 11, 1, 5749.0 }
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
