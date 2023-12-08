using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeCustomerAddedToUser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Stripe");

            migrationBuilder.RenameTable(
                name: "SubscriptionItem",
                schema: "TranslationPro",
                newName: "SubscriptionItem",
                newSchema: "Stripe");

            migrationBuilder.RenameTable(
                name: "Subscription",
                schema: "TranslationPro",
                newName: "Subscription",
                newSchema: "Stripe");

            migrationBuilder.CreateTable(
                name: "Price",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Stripe",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_ProductId",
                schema: "Stripe",
                table: "Plan",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Price",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Stripe");

            migrationBuilder.RenameTable(
                name: "SubscriptionItem",
                schema: "Stripe",
                newName: "SubscriptionItem",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "Subscription",
                schema: "Stripe",
                newName: "Subscription",
                newSchema: "TranslationPro");
        }
    }
}
