using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLengthToApplicationPhrase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "int",
                nullable: false,
                computedColumnSql: "LEN([Text])");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationPhrase");
        }
    }
}
