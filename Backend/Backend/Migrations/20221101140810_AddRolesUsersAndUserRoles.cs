using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class AddRolesUsersAndUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9113f298-cd8d-4165-ab22-a20ce97cdd78", "87bf0478-51d1-4e28-9c37-e06d8cb4d7ec", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da3b85ac-2d59-428e-8f4d-0d703e04d883", "289159e9-fd2e-4ec3-b8fa-f0be38fde7fd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ef9fd375-dd9d-46ed-8aea-e62c5338e989", 0, "3942782c-bdb8-45f3-a79c-e9684d0b0c36", "admin@example.com", false, "Admin", "Adminsson", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAEPOM8UPcPjoncR4ZNA2TS56tXJjlUVc1OPf8oegoSa3YDJaoeZJlr08LRIkiyMDtkw==", null, false, "4978eb9e-d1f0-4e37-ae90-626794e1383d", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9113f298-cd8d-4165-ab22-a20ce97cdd78", "ef9fd375-dd9d-46ed-8aea-e62c5338e989" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da3b85ac-2d59-428e-8f4d-0d703e04d883");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9113f298-cd8d-4165-ab22-a20ce97cdd78", "ef9fd375-dd9d-46ed-8aea-e62c5338e989" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9113f298-cd8d-4165-ab22-a20ce97cdd78");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef9fd375-dd9d-46ed-8aea-e62c5338e989");
        }
    }
}
