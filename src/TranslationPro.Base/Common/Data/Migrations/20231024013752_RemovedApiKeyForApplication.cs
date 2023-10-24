using Microsoft.EntityFrameworkCore.Migrations;

namespace TranslationPro.Base.Common.Data.Migrations
{
    public partial class RemovedApiKeyForApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "Application");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
