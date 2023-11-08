using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTranslationEngines1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "Translation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationEngine",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEngine", x => new { x.ApplicationId, x.EngineId });
                    table.ForeignKey(
                        name: "FK_ApplicationEngine_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationEngine_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 5, 55, 36, 566, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.CreateIndex(
                name: "IX_Translation_ApplicationId_EngineId",
                table: "Translation",
                columns: new[] { "ApplicationId", "EngineId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEngine_EngineId",
                table: "ApplicationEngine",
                column: "EngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_ApplicationEngine_ApplicationId_EngineId",
                table: "Translation",
                columns: new[] { "ApplicationId", "EngineId" },
                principalTable: "ApplicationEngine",
                principalColumns: new[] { "ApplicationId", "EngineId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Translation_ApplicationEngine_ApplicationId_EngineId",
                table: "Translation");

            migrationBuilder.DropTable(
                name: "ApplicationEngine");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropIndex(
                name: "IX_Translation_ApplicationId_EngineId",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Translation");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 7, 4, 41, 25, 772, DateTimeKind.Utc).AddTicks(7644));
        }
    }
}
