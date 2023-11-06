using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeRelationships3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LiveMode",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LiveMode",
                schema: "Stripe",
                table: "SubscriptionItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Stripe",
                table: "PaymentLink",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowPromotionCodes",
                schema: "Stripe",
                table: "PaymentLink",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressCollection",
                schema: "Stripe",
                table: "PaymentLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                schema: "Stripe",
                table: "PaymentLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerCreation",
                schema: "Stripe",
                table: "PaymentLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Livemode",
                schema: "Stripe",
                table: "PaymentLink",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodCollection",
                schema: "Stripe",
                table: "PaymentLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmitType",
                schema: "Stripe",
                table: "PaymentLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "Stripe",
                table: "PaymentLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LineItem",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AmountDiscount = table.Column<long>(type: "bigint", nullable: false),
                    AmountSubtotal = table.Column<long>(type: "bigint", nullable: false),
                    AmountTax = table.Column<long>(type: "bigint", nullable: false),
                    AmountTotal = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: true),
                    PriceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentLinkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StripePaymentLinkLineItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_LineItem_StripePaymentLinkLineItemId",
                        column: x => x.StripePaymentLinkLineItemId,
                        principalSchema: "Stripe",
                        principalTable: "LineItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineItem_PaymentLink_PaymentLinkId",
                        column: x => x.PaymentLinkId,
                        principalSchema: "Stripe",
                        principalTable: "PaymentLink",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineItem_Price_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "Stripe",
                        principalTable: "Price",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 6, 1, 45, 36, 939, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_PaymentLinkId",
                schema: "Stripe",
                table: "LineItem",
                column: "PaymentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_PriceId",
                schema: "Stripe",
                table: "LineItem",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_StripePaymentLinkLineItemId",
                schema: "Stripe",
                table: "LineItem",
                column: "StripePaymentLinkLineItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem",
                schema: "Stripe");

            migrationBuilder.DropColumn(
                name: "LiveMode",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.DropColumn(
                name: "LiveMode",
                schema: "Stripe",
                table: "SubscriptionItem");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "AllowPromotionCodes",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "BillingAddressCollection",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "Currency",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "CustomerCreation",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "Livemode",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "PaymentMethodCollection",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "SubmitType",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.DropColumn(
                name: "Url",
                schema: "Stripe",
                table: "PaymentLink");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 5, 19, 17, 3, 160, DateTimeKind.Utc).AddTicks(4669));
        }
    }
}
