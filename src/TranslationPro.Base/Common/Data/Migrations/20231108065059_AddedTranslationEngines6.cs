using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTranslationEngines6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Engine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 6, 50, 59, 91, DateTimeKind.Utc).AddTicks(2718));

            migrationBuilder.UpdateData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 1,
                column: "Enabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 2,
                column: "Enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 3,
                column: "Enabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "Engine",
                keyColumn: "Id",
                keyValue: 4,
                column: "Enabled",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Engine");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 6, 39, 2, 423, DateTimeKind.Utc).AddTicks(5763));
        }
    }
}
