using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class BlazorClientAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                keyColumn: "Id",
                keyValue: 5,
                column: "RedirectUri",
                value: "https://localhost:7243/authentication/login-callback");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                keyColumn: "Id",
                keyValue: 5,
                column: "RedirectUri",
                value: "https://localhost:7243");
        }
    }
}
