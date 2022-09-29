using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class ThestructureoftheInvoicestableischanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoicesDetail_InvoiceId",
                table: "InvoicesDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesDetail_InvoiceId",
                table: "InvoicesDetail",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoicesDetail_InvoiceId",
                table: "InvoicesDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesDetail_InvoiceId",
                table: "InvoicesDetail",
                column: "InvoiceId",
                unique: true);
        }
    }
}
