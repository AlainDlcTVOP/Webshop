using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "12a460f9-828b-48fa-9104-a04d2f072c7b", "3e4fe47e-87a1-4648-91c5-95d623bcc200", "Admin", "ADMIN" },
                    { "d8e46e17-04d0-4aeb-9f7f-b501ca905977", "ef12a4dd-ed49-4f6c-9c7d-56acd21626c0", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06b30315-a5fe-4ca3-a2dc-b42896053959", 0, "Gatan 1", "Köping", "e907acc4-5ff7-4236-a98a-d2a87922c7e8", "admin@example.com", false, "Admin", "Adminsson", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAENGRvPaG2iSwT6tV911/zZPyy/Uce5X3mxgj3KA665bE/JFqoOSRB872qJnt35L8ww==", "9999999999", false, "11122", "10b3be21-4dae-496b-b764-0ceefc3f8af2", false, "admin@example.com" },
                    { "385cdb8c-736f-4c29-af1c-6b2016833b1f", 0, "Göteborgsvägen 50", "Alingsås", "16089f59-b40a-42d3-b10f-4c994d31d3be", "annaa@example.com", false, "Anna", "Andersson", false, null, "ANNAA@EXAMPLE.COM", "ANNAA@EXAMPLE.COM", "AQAAAAEAACcQAAAAENvmw/LkrKL9mnG9Tycntab5q8VUWwuKUW/dHp8thDd+T720+bo6fTwHZThyqAGlpw==", "1234567890", false, "44143", "3b3e7053-b763-4c99-842c-8192ac3019a9", false, "annaa@example.com" },
                    { "46197de3-d49e-4993-a8ee-43854addc870", 0, "Boråsvägen 100", "Göteborg", "6448d50c-81b5-4c1f-8e70-582debe37505", "gunnarg@example.com", false, "Gunnar", "Gunnarsson", false, null, "GUNNARG@EXAMPLE.COM", "GUNNARG@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKY+aOIU1CEXscvVsB425LTSc2zPlCU0zngj7kidMhp4fijJJh6fQg2GgaGQ8xRkZg==", "3456789012", false, "41276", "1c3faf5e-fcd9-4186-8923-4fb5b20406be", false, "gunnarg@example.com" },
                    { "bb5bb342-378b-4cb4-97b3-e6fb43a85357", 0, "Alingsåsvägen 10", "Borås", "a0a8916c-3409-4b3c-9b41-b5cedbcba2fa", "bennyb@example.com", false, "Benny", "Bengtsson", false, null, "BENNYB@EXAMPLE.COM", "BENNYB@EXAMPLE.COM", "AQAAAAEAACcQAAAAEMe7+EOdUuW1FCgm+RHFHSUXZj3zwu3loHi1r0m2Cb+4ZEPoBdpbHwP9ZR+oGgZXpA==", "2345678901", false, "50467", "861a5e1b-66eb-4085-b0ec-5825e54e5f90", false, "bennyb@example.com" }
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
                    { "12a460f9-828b-48fa-9104-a04d2f072c7b", "06b30315-a5fe-4ca3-a2dc-b42896053959" },
                    { "d8e46e17-04d0-4aeb-9f7f-b501ca905977", "385cdb8c-736f-4c29-af1c-6b2016833b1f" },
                    { "d8e46e17-04d0-4aeb-9f7f-b501ca905977", "46197de3-d49e-4993-a8ee-43854addc870" },
                    { "d8e46e17-04d0-4aeb-9f7f-b501ca905977", "bb5bb342-378b-4cb4-97b3-e6fb43a85357" }
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
                    { 1, "385cdb8c-736f-4c29-af1c-6b2016833b1f", "Deliver asap", new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23435.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 2, "bb5bb342-378b-4cb4-97b3-e6fb43a85357", "", new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11500.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped" },
                    { 3, "46197de3-d49e-4993-a8ee-43854addc870", "Deliver after October 30 2022", new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11498.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" }
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
        }
    }
}
