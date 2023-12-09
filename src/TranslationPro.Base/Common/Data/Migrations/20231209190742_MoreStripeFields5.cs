using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreStripeFields5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsageRecordSummary",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageRecordSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsageRecordSummary_InvoiceItem_InvoiceItemId",
                        column: x => x.InvoiceItemId,
                        principalSchema: "Stripe",
                        principalTable: "InvoiceItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsageRecordSummary_InvoiceItemId",
                schema: "Stripe",
                table: "UsageRecordSummary",
                column: "InvoiceItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsageRecordSummary",
                schema: "Stripe");
        }
    }
}
