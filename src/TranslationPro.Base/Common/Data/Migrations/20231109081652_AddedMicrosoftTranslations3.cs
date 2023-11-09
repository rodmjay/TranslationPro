using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMicrosoftTranslations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EngineLanguage",
                columns: new[] { "EngineId", "LanguageId" },
                values: new object[,]
                {
                    { 2, "ha" },
                    { 2, "hi" },
                    { 2, "hu" },
                    { 2, "id" },
                    { 2, "ig" },
                    { 2, "ikt" },
                    { 2, "ir" },
                    { 2, "is" },
                    { 2, "it" },
                    { 2, "iu" },
                    { 2, "iw" },
                    { 2, "ja" },
                    { 2, "kk" },
                    { 2, "km" },
                    { 2, "kn" },
                    { 2, "ks" },
                    { 2, "mww" },
                    { 2, "rw" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ha" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "hi" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "hu" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "id" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ig" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ikt" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ir" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "is" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "it" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "iu" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "iw" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ja" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "kk" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "km" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "kn" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "ks" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "mww" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 2, "rw" });
        }
    }
}
