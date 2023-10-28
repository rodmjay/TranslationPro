using Microsoft.EntityFrameworkCore.Migrations;

namespace TranslationPro.Base.common.data.migrations
{
    public partial class ModifiedApplicaitonTranslationRelationshipToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Application_ApplicationId",
                table: "Translation");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Application_ApplicationId",
                table: "Translation",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_Application_ApplicationId",
                table: "Translation");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Application_ApplicationId",
                table: "Translation",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "Id");
        }
    }
}
