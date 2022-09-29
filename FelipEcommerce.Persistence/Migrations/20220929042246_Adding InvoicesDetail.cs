using Microsoft.EntityFrameworkCore.Migrations;

namespace FelipEcommerce.Persistence.Migrations
{
    public partial class AddingInvoicesDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Invoices_InvoiceId",
                table: "InvoiceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDetail",
                table: "InvoiceDetail");

            migrationBuilder.RenameTable(
                name: "InvoiceDetail",
                newName: "InvoicesDetail");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoicesDetail",
                newName: "IX_InvoicesDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoicesDetail",
                newName: "IX_InvoicesDetail_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoicesDetail",
                table: "InvoicesDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesDetail_Invoices_InvoiceId",
                table: "InvoicesDetail",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesDetail_Products_ProductId",
                table: "InvoicesDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesDetail_Invoices_InvoiceId",
                table: "InvoicesDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesDetail_Products_ProductId",
                table: "InvoicesDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoicesDetail",
                table: "InvoicesDetail");

            migrationBuilder.RenameTable(
                name: "InvoicesDetail",
                newName: "InvoiceDetail");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesDetail_ProductId",
                table: "InvoiceDetail",
                newName: "IX_InvoiceDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicesDetail_InvoiceId",
                table: "InvoiceDetail",
                newName: "IX_InvoiceDetail_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDetail",
                table: "InvoiceDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Invoices_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Products_ProductId",
                table: "InvoiceDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
