using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhraseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhraseId",
                schema: "TranslationPro",
                table: "ApplicationPhrase");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhraseId",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
