using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreStripeFields6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceId",
                schema: "Stripe",
                table: "UsageRecordSummary",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEnd",
                schema: "Stripe",
                table: "UsageRecordSummary",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStart",
                schema: "Stripe",
                table: "UsageRecordSummary",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionItemId",
                schema: "Stripe",
                table: "UsageRecordSummary",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TotalUsage",
                schema: "Stripe",
                table: "UsageRecordSummary",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UsageRecordSummary_InvoiceId",
                schema: "Stripe",
                table: "UsageRecordSummary",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UsageRecordSummary_SubscriptionItemId",
                schema: "Stripe",
                table: "UsageRecordSummary",
                column: "SubscriptionItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsageRecordSummary_Invoice_InvoiceId",
                schema: "Stripe",
                table: "UsageRecordSummary",
                column: "InvoiceId",
                principalSchema: "Stripe",
                principalTable: "Invoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsageRecordSummary_SubscriptionItem_SubscriptionItemId",
                schema: "Stripe",
                table: "UsageRecordSummary",
                column: "SubscriptionItemId",
                principalSchema: "Stripe",
                principalTable: "SubscriptionItem",
                principalColumn: "StripeItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsageRecordSummary_Invoice_InvoiceId",
                schema: "Stripe",
                table: "UsageRecordSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageRecordSummary_SubscriptionItem_SubscriptionItemId",
                schema: "Stripe",
                table: "UsageRecordSummary");

            migrationBuilder.DropIndex(
                name: "IX_UsageRecordSummary_InvoiceId",
                schema: "Stripe",
                table: "UsageRecordSummary");

            migrationBuilder.DropIndex(
                name: "IX_UsageRecordSummary_SubscriptionItemId",
                schema: "Stripe",
                table: "UsageRecordSummary");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                schema: "Stripe",
                table: "UsageRecordSummary");

            migrationBuilder.DropColumn(
                name: "PeriodEnd",
                schema: "Stripe",
                table: "UsageRecordSummary");

            migrationBuilder.DropColumn(
                name: "PeriodStart",
                schema: "Stripe",
                table: "UsageRecordSummary");

            migrationBuilder.DropColumn(
                name: "SubscriptionItemId",
                schema: "Stripe",
                table: "UsageRecordSummary");

            migrationBuilder.DropColumn(
                name: "TotalUsage",
                schema: "Stripe",
                table: "UsageRecordSummary");
        }
    }
}
