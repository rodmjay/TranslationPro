using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipApplicationTranslationAndLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTranslation_ApplicationId_LanguageId",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                columns: new[] { "ApplicationId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationTranslation_ApplicationLanguage_ApplicationId_LanguageId",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                columns: new[] { "ApplicationId", "LanguageId" },
                principalSchema: "TranslationPro",
                principalTable: "ApplicationLanguage",
                principalColumns: new[] { "ApplicationId", "LanguageId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationTranslation_ApplicationLanguage_ApplicationId_LanguageId",
                schema: "TranslationPro",
                table: "ApplicationTranslation");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationTranslation_ApplicationId_LanguageId",
                schema: "TranslationPro",
                table: "ApplicationTranslation");
        }
    }
}
