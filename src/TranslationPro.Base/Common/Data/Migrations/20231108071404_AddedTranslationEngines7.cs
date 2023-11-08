using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTranslationEngines7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 7, 14, 3, 830, DateTimeKind.Utc).AddTicks(4263));

            migrationBuilder.InsertData(
                table: "EngineLanguage",
                columns: new[] { "EngineId", "LanguageId" },
                values: new object[,]
                {
                    { 3, "af" },
                    { 3, "am" },
                    { 3, "ar" },
                    { 3, "az" },
                    { 3, "bg" },
                    { 3, "bn" },
                    { 3, "bs" },
                    { 3, "ca" },
                    { 3, "cs" },
                    { 3, "da" },
                    { 3, "en" },
                    { 3, "et" },
                    { 3, "fa" },
                    { 3, "fi" },
                    { 3, "fr" },
                    { 3, "hr" },
                    { 3, "hy" },
                    { 3, "nl" },
                    { 3, "sq" },
                    { 3, "zh-CN" },
                    { 3, "zh-TW" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "es-MX", "Spanish (Mexico)" },
                    { "tl", "Filipino (Tagalog)" }
                });

            migrationBuilder.InsertData(
                table: "EngineLanguage",
                columns: new[] { "EngineId", "LanguageId" },
                values: new object[] { 3, "tl" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "af" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "am" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "ar" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "az" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "bg" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "bn" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "bs" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "ca" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "cs" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "da" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "en" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "et" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "fa" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "fi" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "fr" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "hr" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "hy" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "nl" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "sq" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "tl" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "zh-CN" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 3, "zh-TW" });

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "es-MX");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "tl");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 6, 50, 59, 91, DateTimeKind.Utc).AddTicks(2718));
        }
    }
}
