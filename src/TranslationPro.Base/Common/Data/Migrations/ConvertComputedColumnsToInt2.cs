using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertComputedColumnsToInt2 : Migration
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
                computedColumnSql: "IIF([Text] is not null, CAST(DATALENGTH([Text]) AS INT), 0)",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "CAST(DATALENGTH([Text]) AS INT)");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "int",
                nullable: false,
                computedColumnSql: "IIF([Text] is not null, CAST(DATALENGTH([Text]) AS INT), 0)",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "CAST(DATALENGTH([Text]) AS INT)");
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
                computedColumnSql: "CAST(DATALENGTH([Text]) AS INT)",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "IIF([Text] is not null, CAST(DATALENGTH([Text]) AS INT), 0)");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterCount",
                schema: "TranslationPro",
                table: "ApplicationPhrase",
                type: "int",
                nullable: false,
                computedColumnSql: "CAST(DATALENGTH([Text]) AS INT)",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "IIF([Text] is not null, CAST(DATALENGTH([Text]) AS INT), 0)");
        }
    }
}
