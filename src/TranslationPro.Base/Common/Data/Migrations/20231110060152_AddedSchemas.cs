using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "Phrase",
                newName: "Phrase",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "MachineTranslation",
                newName: "MachineTranslation",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Language",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "HumanTranslation",
                newName: "HumanTranslation",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "EngineLanguage",
                newName: "EngineLanguage",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "Engine",
                newName: "Engine",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "ApplicationUser",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "ApplicationTranslation",
                newName: "ApplicationTranslation",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "ApplicationPhrase",
                newName: "ApplicationPhrase",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "ApplicationLanguage",
                newName: "ApplicationLanguage",
                newSchema: "TranslationPro");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Application",
                newSchema: "TranslationPro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Phrase",
                schema: "TranslationPro",
                newName: "Phrase");

            migrationBuilder.RenameTable(
                name: "MachineTranslation",
                schema: "TranslationPro",
                newName: "MachineTranslation");

            migrationBuilder.RenameTable(
                name: "Language",
                schema: "TranslationPro",
                newName: "Language");

            migrationBuilder.RenameTable(
                name: "HumanTranslation",
                schema: "TranslationPro",
                newName: "HumanTranslation");

            migrationBuilder.RenameTable(
                name: "EngineLanguage",
                schema: "TranslationPro",
                newName: "EngineLanguage");

            migrationBuilder.RenameTable(
                name: "Engine",
                schema: "TranslationPro",
                newName: "Engine");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                schema: "TranslationPro",
                newName: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationTranslation",
                schema: "TranslationPro",
                newName: "ApplicationTranslation");

            migrationBuilder.RenameTable(
                name: "ApplicationPhrase",
                schema: "TranslationPro",
                newName: "ApplicationPhrase");

            migrationBuilder.RenameTable(
                name: "ApplicationLanguage",
                schema: "TranslationPro",
                newName: "ApplicationLanguage");

            migrationBuilder.RenameTable(
                name: "Application",
                schema: "TranslationPro",
                newName: "Application");
        }
    }
}
