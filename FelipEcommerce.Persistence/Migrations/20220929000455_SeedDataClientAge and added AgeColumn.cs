using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class SeedDataClientAgeandaddedAgeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Age",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "InventoryDate",
                value: new DateTime(2022, 9, 28, 19, 4, 55, 167, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2022, 9, 28, 19, 4, 55, 164, DateTimeKind.Local).AddTicks(8984));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "Id",
                keyValue: 1,
                column: "InventoryDate",
                value: new DateTime(2022, 9, 28, 16, 35, 4, 767, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2022, 9, 28, 16, 35, 4, 766, DateTimeKind.Local).AddTicks(6121));
        }
    }
}
