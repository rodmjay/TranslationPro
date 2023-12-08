using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeCustomerAddedToUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripeCustomerId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "SubscriptionItem",
                schema: "TranslationPro",
                columns: table => new
                {
                    StripeItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionItem", x => x.StripeItemId);
                    table.ForeignKey(
                        name: "FK_SubscriptionItem_Subscription_UserId",
                        column: x => x.UserId,
                        principalSchema: "TranslationPro",
                        principalTable: "Subscription",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItem_UserId",
                schema: "TranslationPro",
                table: "SubscriptionItem",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionItem",
                schema: "TranslationPro");

            migrationBuilder.AddColumn<string>(
                name: "StripeCustomerId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "StripeCustomerId",
                value: null);
        }
    }
}
