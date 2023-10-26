using Microsoft.EntityFrameworkCore.Migrations;

namespace TranslationPro.Base.Common.Data.Migrations
{
    public partial class AddRelationshipTranslationToApplicationLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Translation_ApplicationId_LanguageId",
                table: "Translation",
                columns: new[] { "ApplicationId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_ApplicationLanguage_ApplicationId_LanguageId",
                table: "Translation",
                columns: new[] { "ApplicationId", "LanguageId" },
                principalTable: "ApplicationLanguage",
                principalColumns: new[] { "ApplicationId", "LanguageId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_ApplicationLanguage_ApplicationId_LanguageId",
                table: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_Translation_ApplicationId_LanguageId",
                table: "Translation");
        }
    }
}
