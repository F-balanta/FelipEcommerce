using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class Fixingseeddatax4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientId", "Discount", "InvoiceDate", "InvoiceNumber", "Isv", "SubTotal", "Total", "UserId" },
                values: new object[] { 1, 2, 10, new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), "8D65S96X8D", 19, 0m, 0m, 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "UrlImage" },
                values: new object[] { 21, "XD", "Producto de prueba", 5000m, "https://fakestoreapi.com/img/61pHAEJ4NML._AC_UX679_.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientId", "Discount", "InvoiceDate", "InvoiceNumber", "Isv", "SubTotal", "Total", "UserId" },
                values: new object[] { 2, 2, 10, new DateTime(2022, 10, 2, 0, 0, 0, 0, DateTimeKind.Local), "8D65S96X8D", 19, 0m, 0m, 2 });
        }
    }
}
