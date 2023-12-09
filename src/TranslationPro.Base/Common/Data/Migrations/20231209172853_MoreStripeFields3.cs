using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreStripeFields3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Amount",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AmountExcludingTax",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEnd",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStart",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitAmountExcludingTax",
                schema: "Stripe",
                table: "InvoiceLine",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "AmountExcludingTax",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "Currency",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "PeriodEnd",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "PeriodStart",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Stripe",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "UnitAmountExcludingTax",
                schema: "Stripe",
                table: "InvoiceLine");
        }
    }
}
