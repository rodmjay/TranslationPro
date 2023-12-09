using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreStripeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AmountDue",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AmountPaid",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AmountRemaining",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AttemptCount",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Attempted",
                schema: "Stripe",
                table: "Invoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AutoAdvance",
                schema: "Stripe",
                table: "Invoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BillingReason",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChargeId",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollectionMethod",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "Stripe",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                schema: "Stripe",
                table: "Invoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EffectiveAt",
                schema: "Stripe",
                table: "Invoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EndingBalance",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HostedInvoiceUrl",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoicePdf",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextPaymentAttempt",
                schema: "Stripe",
                table: "Invoice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                schema: "Stripe",
                table: "Invoice",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEnd",
                schema: "Stripe",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStart",
                schema: "Stripe",
                table: "Invoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReceiptNumber",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Stripe",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Subtotal",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SubtotalExcludingTax",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Tax",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Total",
                schema: "Stripe",
                table: "Invoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Charge",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ChargeId",
                schema: "Stripe",
                table: "Invoice",
                column: "ChargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Charge_ChargeId",
                schema: "Stripe",
                table: "Invoice",
                column: "ChargeId",
                principalSchema: "Stripe",
                principalTable: "Charge",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Charge_ChargeId",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropTable(
                name: "Charge",
                schema: "Stripe");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ChargeId",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AmountDue",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AmountRemaining",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AttemptCount",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Attempted",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AutoAdvance",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "BillingReason",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ChargeId",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CollectionMethod",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Currency",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "DueDate",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "EffectiveAt",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "EndingBalance",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "HostedInvoiceUrl",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "InvoicePdf",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "NextPaymentAttempt",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Paid",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PeriodEnd",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PeriodStart",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ReceiptNumber",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "SubtotalExcludingTax",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Tax",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Total",
                schema: "Stripe",
                table: "Invoice");
        }
    }
}
