using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class AddExampleCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Email", "FirstName", "IsAdmin", "LastName", "Password", "Phone", "PostalCode", "UserName" },
                values: new object[] { 1, "Göteborgsvägen 50", "Alingsås", "annaa@example.com", "Anna", false, "Andersson", "annaa", "1234567890", "44143", "annaa" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Email", "FirstName", "IsAdmin", "LastName", "Password", "Phone", "PostalCode", "UserName" },
                values: new object[] { 2, "Alingsåsvägen 10", "Borås", "bennyb@example.com", "Benny", false, "Bengtsson", "bennyb", "2345678901", "50467", "bennyb" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "City", "Email", "FirstName", "IsAdmin", "LastName", "Password", "Phone", "PostalCode", "UserName" },
                values: new object[] { 3, "Boråsvägen 100", "Göteborg", "gunnarg@example.com", "Gunnar", false, "Gunnarsson", "gunnarg", "3456789012", "41276", "gunnarg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
