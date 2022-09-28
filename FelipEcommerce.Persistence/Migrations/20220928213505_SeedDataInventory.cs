using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class SeedDataInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "InventoryDate", "ProductId", "Qty", "Type" },
                values: new object[] { 1, new DateTime(2022, 9, 28, 16, 35, 4, 767, DateTimeKind.Local).AddTicks(6661), 1, 50, "XD" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2022, 9, 28, 16, 35, 4, 766, DateTimeKind.Local).AddTicks(6121));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2022, 9, 28, 16, 33, 36, 458, DateTimeKind.Local).AddTicks(4513));
        }
    }
}
