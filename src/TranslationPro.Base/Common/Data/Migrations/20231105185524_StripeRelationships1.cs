using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeRelationships1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Amount",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AmountExcludingTax",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Discountable",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LiveMode",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PriceId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Proration",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Quantity",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionItemId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitAmountExcludingTax",
                schema: "Stripe",
                table: "InvoiceLineItem",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 5, 18, 55, 23, 752, DateTimeKind.Utc).AddTicks(2675));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_PriceId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_SubscriptionId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_SubscriptionItemId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "SubscriptionItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLineItem_Price_PriceId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "PriceId",
                principalSchema: "Stripe",
                principalTable: "Price",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLineItem_SubscriptionItem_SubscriptionItemId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "SubscriptionItemId",
                principalSchema: "Stripe",
                principalTable: "SubscriptionItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLineItem_Subscription_SubscriptionId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "SubscriptionId",
                principalSchema: "Stripe",
                principalTable: "Subscription",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLineItem_Price_PriceId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLineItem_SubscriptionItem_SubscriptionItemId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLineItem_Subscription_SubscriptionId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLineItem_PriceId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLineItem_SubscriptionId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLineItem_SubscriptionItemId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "AmountExcludingTax",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "Currency",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "Discountable",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "LiveMode",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "PriceId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "Proration",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "SubscriptionItemId",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.DropColumn(
                name: "UnitAmountExcludingTax",
                schema: "Stripe",
                table: "InvoiceLineItem");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 5, 18, 44, 49, 5, DateTimeKind.Utc).AddTicks(5619));
        }
    }
}
