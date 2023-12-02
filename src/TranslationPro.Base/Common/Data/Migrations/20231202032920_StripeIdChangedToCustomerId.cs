using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeIdChangedToCustomerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StripeId",
                schema: "TranslationPro",
                table: "Subscription",
                newName: "PaymentLink");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                schema: "TranslationPro",
                table: "Subscription",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "TranslationPro",
                table: "Subscription");

            migrationBuilder.RenameColumn(
                name: "PaymentLink",
                schema: "TranslationPro",
                table: "Subscription",
                newName: "StripeId");
        }
    }
}
