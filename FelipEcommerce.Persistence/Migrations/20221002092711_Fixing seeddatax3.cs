using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class Fixingseeddatax3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SubTotal", "Total" },
                values: new object[] { 0m, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SubTotal", "Total" },
                values: new object[] { 5000m, 10000m });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientId", "Discount", "InvoiceDate", "InvoiceNumber", "Isv", "SubTotal", "Total", "UserId" },
                values: new object[] { 1, 1, 0, new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), "1FA4X57X95", 19, 1000m, 10000m, 1 });
        }
    }
}
