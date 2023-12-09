using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreStripeFields4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLine_InvoiceItem_InvoiceItemId",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLine_InvoiceItemId",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "InvoiceItemId",
                schema: "Stripe",
                table: "InvoiceLine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceItemId",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_InvoiceItemId",
                schema: "Stripe",
                table: "InvoiceLine",
                column: "InvoiceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLine_InvoiceItem_InvoiceItemId",
                schema: "Stripe",
                table: "InvoiceLine",
                column: "InvoiceItemId",
                principalSchema: "Stripe",
                principalTable: "InvoiceItem",
                principalColumn: "Id");
        }
    }
}
