using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnabledMicrosoft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "TranslationPro",
                table: "Engine",
                keyColumn: "Id",
                keyValue: 2,
                column: "Enabled",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "TranslationPro",
                table: "Engine",
                keyColumn: "Id",
                keyValue: 2,
                column: "Enabled",
                value: false);
        }
    }
}
