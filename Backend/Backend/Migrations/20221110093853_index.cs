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
                    { "c43faf17-272d-4015-bc96-2d8246f7b210", "b06dc2fa-509b-4e34-a86d-a0cf8d635609", "Admin", "ADMIN" },
                    { "fe6931a5-e048-4e75-9338-9695aaac1ec6", "4a8cb2d8-4d95-4816-bb21-52e2cea9c836", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "69464244-4205-4bf5-ac3b-fd878316ef26", 0, "Boråsvägen 100", "Göteborg", "d89c8e6c-4447-485d-8da4-9084ae220b9d", "gunnarg@example.com", false, "Gunnar", "Gunnarsson", false, null, "GUNNARG@EXAMPLE.COM", "GUNNARG@EXAMPLE.COM", "AQAAAAEAACcQAAAAEMaNawzd2sebtQgEnEFLJNNqh7JPQx+18zBNt6+hTiJXhGQeHNW3/W8+N6WDT2PH5g==", "3456789012", false, "41276", "917dbb60-db9b-42a2-b450-1995d4cf023d", false, "gunnarg@example.com" },
                    { "95dbff2b-8bbc-47f1-bf5f-da1a5b02f2f7", 0, "Göteborgsvägen 50", "Alingsås", "f34d854e-c1cd-46f5-afe7-b017cdc1c7a6", "annaa@example.com", false, "Anna", "Andersson", false, null, "ANNAA@EXAMPLE.COM", "ANNAA@EXAMPLE.COM", "AQAAAAEAACcQAAAAEFpfSd+UoooSZeQKgIhW/M158W3A3VJSPpQ7fZaD11s22niQa+IoxxQCd8mHfNJFpA==", "1234567890", false, "44143", "c5d9c7aa-7317-41af-89e8-c41592fc6e99", false, "annaa@example.com" },
                    { "c62b8495-e495-4080-9b37-e663b61dca1a", 0, "Alingsåsvägen 10", "Borås", "0a9b9949-c09c-4821-96ee-27aee7799bea", "bennyb@example.com", false, "Benny", "Bengtsson", false, null, "BENNYB@EXAMPLE.COM", "BENNYB@EXAMPLE.COM", "AQAAAAEAACcQAAAAEFN3gQ3z3CIu8MuEgtVyro+Gmh4ha5695OYPYINff0XFfCfa3+GHvy6JDW3nJZ0ZUw==", "2345678901", false, "50467", "91c98ac5-27c4-4ad6-9f04-b76e48ede327", false, "bennyb@example.com" },
                    { "e4d3f5db-2a9b-4861-b868-4ecacdf55bdc", 0, "Gatan 1", "Köping", "91ce149e-e2e8-40a4-aaee-2fb2ca70d2a9", "admin@example.com", false, "Admin", "Adminsson", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEOWtKLFgF5q7ZEIcbCoyRLK9vU757d+a8bZVh9Dg6+nLIV/hRqG7Vspnd3UUotnKoA==", "9999999999", false, "11122", "1c9e5890-93be-4067-b2cc-6ec69be70b84", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "InStock", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Produktbeskrivning...", 10, "Skidor, Dam", 4000.0 },
                    { 2, "Produktbeskrivning...", 12, "Skidor, Herr", 5000.0 },
                    { 3, "Produktbeskrivning...", 2, "Pjäxa, Dam", 5300.0 },
                    { 4, "Produktbeskrivning...", 6, "Pjäxa, Herr", 6000.0 },
                    { 5, "Produktbeskrivning...", 12, "Stavar, Dam", 900.0 },
                    { 6, "Produktbeskrivning...", 4, "Stavar, Herr", 1100.0 },
                    { 7, "Produktbeskrivning...", 11, "Hjälm, Dam", 2300.0 },
                    { 8, "Produktbeskrivning...", 9, "Hjälm, Herr", 2100.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fe6931a5-e048-4e75-9338-9695aaac1ec6", "69464244-4205-4bf5-ac3b-fd878316ef26" },
                    { "fe6931a5-e048-4e75-9338-9695aaac1ec6", "95dbff2b-8bbc-47f1-bf5f-da1a5b02f2f7" },
                    { "fe6931a5-e048-4e75-9338-9695aaac1ec6", "c62b8495-e495-4080-9b37-e663b61dca1a" },
                    { "c43faf17-272d-4015-bc96-2d8246f7b210", "e4d3f5db-2a9b-4861-b868-4ecacdf55bdc" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "Name", "ProductID", "Src" },
                values: new object[,]
                {
                    { 1, "", "Black Crows", 1, "~/image/BLACK Crows Nocta 22-23 page 3.png" },
                    { 2, "", "VÖLKL Deacon V Werks", 2, "~/image/VÖLKL Deacon V Werks.png" },
                    { 3, "", "SCARPA Alien", 3, "~/image/SCARPA Alien.png" },
                    { 4, "", "SCARPA Alien", 4, "~/image/SCARPA Alien.png" },
                    { 5, "", "BLACK Diamond Quickdraw Probe", 5, "~/image/BLACK Diamond Quickdraw Probe.png" },
                    { 6, "", "BLACK Diamond Quickdraw Probe", 6, "~/image/BLACK Diamond Quickdraw Probe.png" },
                    { 7, "", "PEAK Performance Hat Black", 7, "~/image/PEAK Performance Hat Black.png" },
                    { 8, "", "PEAK Performance Hat Black", 8, "~/image/PEAK Performance Hat Black.png" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "Comments", "Date", "DeliveryDate", "ShippedDate", "Status" },
                values: new object[,]
                {
                    { 1, "95dbff2b-8bbc-47f1-bf5f-da1a5b02f2f7", "Deliver asap", new DateTime(2022, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 2, "c62b8495-e495-4080-9b37-e663b61dca1a", "", new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped" },
                    { 3, "69464244-4205-4bf5-ac3b-fd878316ef26", "Deliver after October 30 2022", new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Name", "OrderID", "Price", "ProductID", "Quantity", "RowAmount" },
                values: new object[,]
                {
                    { 1, "Skidor, Dam", 1, 4000.0, 1, 1, 4000.0 },
                    { 2, "Pjäxa, Dam", 1, 5300.0, 3, 1, 5300.0 },
                    { 3, "Stavar, Herr", 2, 1100.0, 6, 1, 1100.0 },
                    { 4, "Hjälm, Herr", 2, 2100.0, 8, 2, 4200.0 },
                    { 5, "Pjäxa, Herr", 3, 6000.0, 4, 1, 6000.0 },
                    { 6, "Stavar, Herr", 3, 1100.0, 6, 2, 2200.0 }
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
