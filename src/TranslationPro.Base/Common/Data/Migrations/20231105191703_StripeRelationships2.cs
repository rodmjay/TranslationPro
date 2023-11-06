using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeRelationships2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledAt",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EndBehavior",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleasedAt",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReleasedSubscription",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 5, 19, 17, 3, 160, DateTimeKind.Utc).AddTicks(4669));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanceledAt",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.DropColumn(
                name: "EndBehavior",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.DropColumn(
                name: "ReleasedAt",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.DropColumn(
                name: "ReleasedSubscription",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 5, 18, 55, 23, 752, DateTimeKind.Utc).AddTicks(2675));
        }
    }
}
