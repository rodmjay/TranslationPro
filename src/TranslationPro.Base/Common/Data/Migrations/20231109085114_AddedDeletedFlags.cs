using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeletedFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Translation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Phrase",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Phrase");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Application");
        }
    }
}
