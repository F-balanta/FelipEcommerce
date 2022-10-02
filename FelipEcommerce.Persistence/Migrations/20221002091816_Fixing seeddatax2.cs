using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class Fixingseeddatax2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Discount",
                value: 0);

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientId", "Discount", "InvoiceDate", "InvoiceNumber", "Isv", "SubTotal", "Total", "UserId" },
                values: new object[] { 2, 2, 10, new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), "8D65S96X8D", 19, 5000m, 10000m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Discount",
                value: 10);
        }
    }
}
