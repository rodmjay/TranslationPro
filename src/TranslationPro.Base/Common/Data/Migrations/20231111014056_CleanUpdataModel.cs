using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class CleanUpdataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationTranslation",
                schema: "TranslationPro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationTranslation",
                schema: "TranslationPro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationLanguageApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationLanguageLanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhraseId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationTranslation_ApplicationLanguage_ApplicationLanguageApplicationId_ApplicationLanguageLanguageId",
                        columns: x => new { x.ApplicationLanguageApplicationId, x.ApplicationLanguageLanguageId },
                        principalSchema: "TranslationPro",
                        principalTable: "ApplicationLanguage",
                        principalColumns: new[] { "ApplicationId", "LanguageId" });
                    table.ForeignKey(
                        name: "FK_ApplicationTranslation_ApplicationPhrase_ApplicationId_PhraseId",
                        columns: x => new { x.ApplicationId, x.PhraseId },
                        principalSchema: "TranslationPro",
                        principalTable: "ApplicationPhrase",
                        principalColumns: new[] { "ApplicationId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationTranslation_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "TranslationPro",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationTranslation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "TranslationPro",
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTranslation_ApplicationId_PhraseId",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                columns: new[] { "ApplicationId", "PhraseId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTranslation_ApplicationLanguageApplicationId_ApplicationLanguageLanguageId",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                columns: new[] { "ApplicationLanguageApplicationId", "ApplicationLanguageLanguageId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTranslation_LanguageId",
                schema: "TranslationPro",
                table: "ApplicationTranslation",
                column: "LanguageId");
        }
    }
}
