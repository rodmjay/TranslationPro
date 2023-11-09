using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMicrosoftTranslations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mya");

            migrationBuilder.InsertData(
                table: "EngineLanguage",
                columns: new[] { "EngineId", "LanguageId" },
                values: new object[,]
                {
                    { 2, "dsb" },
                    { 2, "gom" },
                    { 2, "kmr" },
                    { 2, "ko" },
                    { 2, "ku" },
                    { 2, "ky" },
                    { 2, "ln" },
                    { 2, "lo" },
                    { 2, "lt" },
                    { 2, "lug" },
                    { 2, "lv" },
                    { 2, "mai" },
                    { 2, "mg" },
                    { 2, "mi" },
                    { 2, "mk" },
                    { 2, "ml" },
                    { 2, "mr" },
                    { 2, "ms" },
                    { 2, "mt" },
                    { 2, "my" },
                    { 2, "ne" },
                    { 2, "no" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[] { "nya", "Nyanja" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "dsb" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "gom" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "kmr" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ko" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ku" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ky" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ln" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "lo" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "lt" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "lug" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "lv" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "mai" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "mg" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "mi" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "mk" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ml" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "mr" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ms" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "mt" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "my" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ne" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "no" });

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "nya");

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[] { "mya", "Nyanja" });
        }
    }
}
