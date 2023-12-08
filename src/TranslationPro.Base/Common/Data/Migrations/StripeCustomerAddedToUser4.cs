using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeCustomerAddedToUser4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceTier",
                schema: "Stripe",
                columns: table => new
                {
                    PriceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatAmount = table.Column<long>(type: "bigint", nullable: true),
                    FlatAmountDecimal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitAmount = table.Column<long>(type: "bigint", nullable: true),
                    UnitAmountDecimal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UpTo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTier", x => new { x.PriceId, x.Id });
                    table.ForeignKey(
                        name: "FK_PriceTier_Price_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "Stripe",
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceTier",
                schema: "Stripe");
        }
    }
}
