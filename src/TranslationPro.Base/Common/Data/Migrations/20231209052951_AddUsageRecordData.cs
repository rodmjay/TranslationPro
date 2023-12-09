using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsageRecordData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillDate",
                schema: "TranslationPro",
                table: "ApplicationTranslation");

            migrationBuilder.DropColumn(
                name: "BillDate",
                schema: "TranslationPro",
                table: "ApplicationPhrase");

            migrationBuilder.AddColumn<string>(
                name: "UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsageRecord",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubscriptionItemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsageRecord_SubscriptionItem_SubscriptionItemId",
                        column: x => x.SubscriptionItemId,
                        principalSchema: "Stripe",
                        principalTable: "SubscriptionItem",
                        principalColumn: "StripeItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTranslation_UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                column: "UsageRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationPhrase_UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                column: "UsageRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_UsageRecord_SubscriptionItemId",
                schema: "Stripe",
                table: "UsageRecord",
                column: "SubscriptionItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationPhrase_UsageRecord_UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                column: "UsageRecordId",
                principalSchema: "Stripe",
                principalTable: "UsageRecord",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationTranslation_UsageRecord_UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                column: "UsageRecordId",
                principalSchema: "Stripe",
                principalTable: "UsageRecord",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationPhrase_UsageRecord_UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationPhrase");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationTranslation_UsageRecord_UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationTranslation");

            migrationBuilder.DropTable(
                name: "UsageRecord",
                schema: "Stripe");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationTranslation_UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationTranslation");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationPhrase_UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationPhrase");

            migrationBuilder.DropColumn(
                name: "UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationTranslation");

            migrationBuilder.DropColumn(
                name: "UsageRecordId",
                schema: "TranslationPro",
                table: "ApplicationPhrase");

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "datetime2",
                nullable: true);
        }
    }
}
