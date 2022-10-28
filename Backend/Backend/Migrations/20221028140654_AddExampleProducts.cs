using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class AddExampleProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
