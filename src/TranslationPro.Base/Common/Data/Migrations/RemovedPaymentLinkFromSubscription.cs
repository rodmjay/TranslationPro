using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPaymentLinkFromSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentLink",
                schema: "TranslationPro",
                table: "Subscription");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                schema: "TranslationPro",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_SubscriptionId",
                schema: "TranslationPro",
                table: "Application",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Subscription_SubscriptionId",
                schema: "TranslationPro",
                table: "Application",
                column: "SubscriptionId",
                principalSchema: "TranslationPro",
                principalTable: "Subscription",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Subscription_SubscriptionId",
                schema: "TranslationPro",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_SubscriptionId",
                schema: "TranslationPro",
                table: "Application");

            migrationBuilder.AddColumn<string>(
                name: "PaymentLink",
                schema: "TranslationPro",
                table: "Subscription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                schema: "TranslationPro",
                table: "Application",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
