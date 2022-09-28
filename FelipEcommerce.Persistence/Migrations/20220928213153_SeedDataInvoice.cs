using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class SeedDataInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientId", "Discount", "InvoiceDate", "InvoiceNumber", "Isv", "SubTotal", "Total", "UserId" },
                values: new object[] { 1, 1, 19, new DateTime(2022, 9, 28, 16, 31, 52, 680, DateTimeKind.Local).AddTicks(8033), null, 0, 1000m, 10000m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
