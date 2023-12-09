using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeColumnsAdded6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancelAt",
                schema: "Stripe",
                table: "Subscription",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CancelAtPeriodEnd",
                schema: "Stripe",
                table: "Subscription",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledAt",
                schema: "Stripe",
                table: "Subscription",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollectionMethod",
                schema: "Stripe",
                table: "Subscription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "Stripe",
                table: "Subscription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentPeriodEnd",
                schema: "Stripe",
                table: "Subscription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentPeriodStart",
                schema: "Stripe",
                table: "Subscription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "DaysUntilDue",
                schema: "Stripe",
                table: "Subscription",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                schema: "Stripe",
                table: "Subscription",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "Stripe",
                table: "Subscription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelAt",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "CancelAtPeriodEnd",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "CanceledAt",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "CollectionMethod",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "CurrentPeriodEnd",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "CurrentPeriodStart",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "DaysUntilDue",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "EndedAt",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "Stripe",
                table: "Subscription");
        }
    }
}
