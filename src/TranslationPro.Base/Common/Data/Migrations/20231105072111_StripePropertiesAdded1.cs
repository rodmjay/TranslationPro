using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripePropertiesAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StripeInvoiceLine");

            migrationBuilder.DropTable(
                name: "StripeSchedule");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "StripeCustomer",
                newName: "TaxExempt");

            migrationBuilder.AlterColumn<long>(
                name: "Amount",
                table: "StripePaymentIntent",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Balance",
                table: "StripeCustomer",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line1",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line2",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Created",
                table: "StripeCustomer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "StripeCustomer",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Delinquent",
                table: "StripeCustomer",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoicePrefix",
                table: "StripeCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NextInvoiceSequence",
                table: "StripeCustomer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AmountOff",
                table: "StripeCoupon",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Created",
                table: "StripeCoupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "StripeCoupon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "StripeCoupon",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "StripeCoupon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DurationInMonths",
                table: "StripeCoupon",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LiveMode",
                table: "StripeCoupon",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "MaxRedemptions",
                table: "StripeCoupon",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StripeCoupon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentOff",
                table: "StripeCoupon",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RedeemBy",
                table: "StripeCoupon",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TimesRedeemed",
                table: "StripeCoupon",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "StripeCoupon",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "Amount",
                table: "StripeCharge",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "AmountCaptured",
                table: "StripeCharge",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AmountRefunded",
                table: "StripeCharge",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "AuthorizationCode",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalculatedStatementDescriptor",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Captured",
                table: "StripeCharge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Created",
                table: "StripeCharge",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Disputed",
                table: "StripeCharge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FailureCode",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FailureMessage",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "StripeCharge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptEmail",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptNumber",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptUrl",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Refunded",
                table: "StripeCharge",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StatementDescriptor",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatementDescriptorSuffix",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "StripeCharge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ExpYear",
                table: "StripeCard",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "ExpMonth",
                table: "StripeCard",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressCountry",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1Check",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressState",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressZip",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressZipCheck",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DefaultForCurrency",
                table: "StripeCard",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "StripeCard",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DynamicLast4",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fingerprint",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Funding",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Iin",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Issuer",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenizationMethod",
                table: "StripeCard",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StripeDiscount",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeDiscount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripeDispute",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeDispute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripeInvoiceLineItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeInvoiceLineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeInvoiceLineItem_StripeInvoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "StripeInvoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeSubscriptionSchedule",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeSubscriptionSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeSubscriptionSchedule_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 5, 7, 21, 10, 887, DateTimeKind.Utc).AddTicks(9570));

            migrationBuilder.CreateIndex(
                name: "IX_StripeInvoiceLineItem_InvoiceId",
                table: "StripeInvoiceLineItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeSubscriptionSchedule_CustomerId",
                table: "StripeSubscriptionSchedule",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StripeDiscount");

            migrationBuilder.DropTable(
                name: "StripeDispute");

            migrationBuilder.DropTable(
                name: "StripeInvoiceLineItem");

            migrationBuilder.DropTable(
                name: "StripeSubscriptionSchedule");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Address_Line1",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Address_Line2",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Delinquent",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "InvoicePrefix",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "NextInvoiceSequence",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "AmountOff",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "DurationInMonths",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "LiveMode",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "MaxRedemptions",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "PercentOff",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "RedeemBy",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "TimesRedeemed",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "Valid",
                table: "StripeCoupon");

            migrationBuilder.DropColumn(
                name: "AmountCaptured",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "AmountRefunded",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "AuthorizationCode",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "CalculatedStatementDescriptor",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "Captured",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "Disputed",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "FailureCode",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "FailureMessage",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "ReceiptEmail",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "ReceiptNumber",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "ReceiptUrl",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "Refunded",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "StatementDescriptor",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "StatementDescriptorSuffix",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StripeCharge");

            migrationBuilder.DropColumn(
                name: "AddressCity",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "AddressCountry",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "AddressLine1Check",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "AddressState",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "AddressZip",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "AddressZipCheck",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "DefaultForCurrency",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "DynamicLast4",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Fingerprint",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Funding",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Iin",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Issuer",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StripeCard");

            migrationBuilder.DropColumn(
                name: "TokenizationMethod",
                table: "StripeCard");

            migrationBuilder.RenameColumn(
                name: "TaxExempt",
                table: "StripeCustomer",
                newName: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "StripePaymentIntent",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "StripeCustomer",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "StripeCharge",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ExpYear",
                table: "StripeCard",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ExpMonth",
                table: "StripeCard",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "StripeInvoiceLine",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeInvoiceLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeInvoiceLine_StripeInvoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "StripeInvoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeSchedule",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeSchedule_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 4, 21, 0, 50, 579, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.CreateIndex(
                name: "IX_StripeInvoiceLine_InvoiceId",
                table: "StripeInvoiceLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeSchedule_CustomerId",
                table: "StripeSchedule",
                column: "CustomerId");
        }
    }
}
