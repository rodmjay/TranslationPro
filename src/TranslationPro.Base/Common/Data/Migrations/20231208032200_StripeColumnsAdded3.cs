using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeColumnsAdded3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Stripe",
                table: "Plan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Amount",
                schema: "Stripe",
                table: "Plan",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountDecimal",
                schema: "Stripe",
                table: "Plan",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interval",
                schema: "Stripe",
                table: "Plan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IntervalCount",
                schema: "Stripe",
                table: "Plan",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Stripe",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Stripe",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "AmountDecimal",
                schema: "Stripe",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Interval",
                schema: "Stripe",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "IntervalCount",
                schema: "Stripe",
                table: "Plan");
        }
    }
}
