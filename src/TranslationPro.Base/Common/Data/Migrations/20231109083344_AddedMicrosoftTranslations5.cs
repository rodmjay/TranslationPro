using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMicrosoftTranslations5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EngineLanguage",
                columns: new[] { "EngineId", "LanguageId" },
                values: new object[,]
                {
                    { 2, "bo" },
                    { 2, "cy" },
                    { 2, "es" },
                    { 2, "fa" },
                    { 2, "hsb" },
                    { 2, "nso" },
                    { 2, "nya" },
                    { 2, "or" },
                    { 2, "otq" },
                    { 2, "pa" },
                    { 2, "pl" },
                    { 2, "ps" },
                    { 2, "pt" },
                    { 2, "pt-pt" },
                    { 2, "ro" },
                    { 2, "ru" },
                    { 2, "run" },
                    { 2, "sd" },
                    { 2, "si" },
                    { 2, "sk" },
                    { 2, "sl" },
                    { 2, "sm" },
                    { 2, "so" },
                    { 2, "st" },
                    { 2, "sv" },
                    { 2, "sw" },
                    { 2, "ta" },
                    { 2, "te" },
                    { 2, "th" },
                    { 2, "ti" },
                    { 2, "tk" },
                    { 2, "tn" },
                    { 2, "to" },
                    { 2, "tr" },
                    { 2, "tt" },
                    { 2, "ty" },
                    { 2, "ug" },
                    { 2, "uk" },
                    { 2, "ur" },
                    { 2, "uz" },
                    { 2, "vi" },
                    { 2, "yo" },
                    { 2, "yua" },
                    { 2, "zu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "bo" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "cy" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "es" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "fa" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "hsb" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "nso" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "nya" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "or" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "otq" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "pa" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "pl" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ps" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "pt" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "pt-pt" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ro" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ru" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "run" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "sd" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "si" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "sk" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "sl" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "sm" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "so" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "st" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "sv" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "sw" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ta" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "te" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "th" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ti" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "tk" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "tn" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "to" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "tr" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "tt" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ty" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ug" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "uk" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ur" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "uz" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "vi" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "yo" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "yua" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "zu" });
        }
    }
}
