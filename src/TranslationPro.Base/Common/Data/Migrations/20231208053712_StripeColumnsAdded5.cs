using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeColumnsAdded5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                schema: "Stripe",
                table: "SubscriptionItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlanId",
                schema: "Stripe",
                table: "SubscriptionItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItem_PlanId",
                schema: "Stripe",
                table: "SubscriptionItem",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItem_ProductId",
                schema: "Stripe",
                table: "SubscriptionItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionItem_Plan_PlanId",
                schema: "Stripe",
                table: "SubscriptionItem",
                column: "PlanId",
                principalSchema: "Stripe",
                principalTable: "Plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionItem_Product_ProductId",
                schema: "Stripe",
                table: "SubscriptionItem",
                column: "ProductId",
                principalSchema: "Stripe",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionItem_Plan_PlanId",
                schema: "Stripe",
                table: "SubscriptionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionItem_Product_ProductId",
                schema: "Stripe",
                table: "SubscriptionItem");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionItem_PlanId",
                schema: "Stripe",
                table: "SubscriptionItem");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionItem_ProductId",
                schema: "Stripe",
                table: "SubscriptionItem");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                schema: "Stripe",
                table: "SubscriptionItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlanId",
                schema: "Stripe",
                table: "SubscriptionItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
