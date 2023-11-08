using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTranslationEngines4 : Migration
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
                value: new DateTime(2023, 11, 8, 6, 10, 14, 678, DateTimeKind.Utc).AddTicks(6373));

            migrationBuilder.InsertData(
                table: "EngineLanguage",
                columns: new[] { "EngineId", "LanguageId" },
                values: new object[,]
                {
                    { 1, "ar" },
                    { 1, "cs" },
                    { 1, "da" },
                    { 1, "de" },
                    { 1, "el" },
                    { 1, "en" },
                    { 1, "es" },
                    { 1, "fi" },
                    { 1, "fr" },
                    { 1, "hi" },
                    { 1, "hu" },
                    { 1, "it" },
                    { 1, "iw" },
                    { 1, "ja" },
                    { 1, "ko" },
                    { 1, "nl" },
                    { 1, "no" },
                    { 1, "pl" },
                    { 1, "pt" },
                    { 1, "ru" },
                    { 1, "sv" },
                    { 1, "th" },
                    { 1, "tr" },
                    { 1, "vi" },
                    { 1, "zh-CN" },
                    { 1, "zh-TW" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "ar" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "cs" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "da" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "de" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "el" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "en" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "es" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "fi" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "fr" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "hi" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "hu" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "it" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "iw" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "ja" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "ko" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "nl" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "no" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "pl" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "pt" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "ru" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "sv" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "th" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "tr" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "vi" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "zh-CN" });

            migrationBuilder.DeleteData(
                table: "EngineLanguage",
                keyColumns: new[] { "EngineId", "LanguageId" },
                keyValues: new object[] { 1, "zh-TW" });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 6, 7, 5, 269, DateTimeKind.Utc).AddTicks(7379));
        }
    }
}
