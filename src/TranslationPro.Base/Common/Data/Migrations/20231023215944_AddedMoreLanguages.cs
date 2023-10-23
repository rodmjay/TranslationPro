using Microsoft.EntityFrameworkCore.Migrations;

namespace TranslationPro.Base.Common.Data.Migrations
{
    public partial class AddedMoreLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "es",
                column: "Name",
                value: "Spanish");

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "cs", "Czech" },
                    { "pl", "Polish" },
                    { "vi", "Vietnamese" },
                    { "th", "Thai" },
                    { "iw", "Hebrew" },
                    { "tr", "Turkish" },
                    { "el", "Greek" },
                    { "fi", "Finnish" },
                    { "da", "Danish" },
                    { "no", "Norwegian" },
                    { "hu", "Hungarian" },
                    { "sv", "Swedish" },
                    { "it", "Italian" },
                    { "pt", "Portugese" },
                    { "hi", "Hindi" },
                    { "ar", "Arabic" },
                    { "ru", "Russian" },
                    { "ko", "Korean" },
                    { "ja", "Japanese" },
                    { "zh-TW", "Chinese (Traditional)" },
                    { "zh-CN", "Chinese (Simplified)" },
                    { "de", "German" },
                    { "nl", "Dutch" },
                    { "fr", "French" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ar");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "cs");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "da");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "de");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "el");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "fi");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "fr");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "hi");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "hu");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "it");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "iw");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ja");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ko");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "nl");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "no");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "pl");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "pt");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ru");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sv");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "th");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "tr");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "vi");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "zh-CN");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "zh-TW");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "es",
                column: "Name",
                value: "Spanish;Castilian");
        }
    }
}
