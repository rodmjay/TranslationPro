using Microsoft.EntityFrameworkCore.Migrations;

namespace TranslationPro.Base.Common.Data.Migrations
{
    public partial class UpdatedUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "NormalizedUserName", "PhoneNumber", "UserName" },
                values: new object[] { "Rod", "Johnson", "ADMIN@ADMIN.COM", "123-123-1234", "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "NormalizedUserName", "PhoneNumber", "UserName" },
                values: new object[] { null, null, "ADMIN", "", "admin" });
        }
    }
}
