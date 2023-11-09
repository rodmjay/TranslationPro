using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTranslationEngines11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "Engine",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 9, 6, 24, 10, 624, DateTimeKind.Utc).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 1,
                column: "EngineId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 2,
                column: "EngineId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 3,
                column: "EngineId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 4,
                column: "EngineId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Engine");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 7, 22, 29, 991, DateTimeKind.Utc).AddTicks(6038));
        }
    }
}
