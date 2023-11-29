using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertComputedColumnsToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                type: "int",
                nullable: false,
                computedColumnSql: "CAST(DATALENGTH([Text]) AS INT)",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "DATALENGTH([Text])");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "int",
                nullable: false,
                computedColumnSql: "CAST(DATALENGTH([Text]) AS INT)",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "DATALENGTH([Text])");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                type: "int",
                nullable: false,
                computedColumnSql: "DATALENGTH([Text])",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "CAST(DATALENGTH([Text]) AS INT)");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "int",
                nullable: false,
                computedColumnSql: "DATALENGTH([Text])",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "CAST(DATALENGTH([Text]) AS INT)");
        }
    }
}
