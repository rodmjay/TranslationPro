using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLengthToApplicationPhrase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                type: "int",
                nullable: false,
                computedColumnSql: "DATALENGTH([Text])");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "int",
                nullable: false,
                computedColumnSql: "DATALENGTH([Text])",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "LEN([Text])");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationTranslation");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "int",
                nullable: false,
                computedColumnSql: "LEN([Text])",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "DATALENGTH([Text])");
        }
    }
}
