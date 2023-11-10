using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftDeletes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TranslationPro",
                table: "Phrase",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TranslationPro",
                table: "MachineTranslation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TranslationPro",
                table: "HumanTranslation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "TranslationPro",
                table: "ApplicationUser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TranslationPro",
                table: "Phrase");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TranslationPro",
                table: "MachineTranslation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TranslationPro",
                table: "HumanTranslation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "TranslationPro",
                table: "ApplicationUser");
        }
    }
}
