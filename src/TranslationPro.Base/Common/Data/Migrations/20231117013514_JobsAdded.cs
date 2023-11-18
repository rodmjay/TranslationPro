using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                schema: "TranslationPro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "TranslationPro",
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobLanguage",
                schema: "TranslationPro",
                columns: table => new
                {
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLanguage", x => new { x.JobId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_JobLanguage_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "TranslationPro",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "TranslationPro",
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPhrase",
                schema: "TranslationPro",
                columns: table => new
                {
                    PhraseId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPhrase", x => new { x.JobId, x.PhraseId });
                    table.ForeignKey(
                        name: "FK_JobPhrase_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "TranslationPro",
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobPhrase_Phrase_PhraseId",
                        column: x => x.PhraseId,
                        principalSchema: "TranslationPro",
                        principalTable: "Phrase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_ApplicationId",
                schema: "TranslationPro",
                table: "Job",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobLanguage_LanguageId",
                schema: "TranslationPro",
                table: "JobLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPhrase_PhraseId",
                schema: "TranslationPro",
                table: "JobPhrase",
                column: "PhraseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobLanguage",
                schema: "TranslationPro");

            migrationBuilder.DropTable(
                name: "JobPhrase",
                schema: "TranslationPro");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "TranslationPro");
        }
    }
}
