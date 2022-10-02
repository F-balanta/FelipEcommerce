using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class FixingseeddataanddeletePriceColumnofInvoiceDetailEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "InvoicesDetail");

            migrationBuilder.UpdateData(
                table: "InvoicesDetail",
                keyColumn: "Id",
                keyValue: 1,
                column: "Qty",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "InvoicesDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "InvoicesDetail",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Qty" },
                values: new object[] { 5000m, 5 });
        }
    }
}
