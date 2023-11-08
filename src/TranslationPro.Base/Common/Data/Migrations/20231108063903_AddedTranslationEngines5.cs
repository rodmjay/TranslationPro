using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTranslationEngines5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 6, 39, 2, 423, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "pt",
                column: "Name",
                value: "Portugese (Brazil)");

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "af", "Afrikaans" },
                    { "am", "Amharic" },
                    { "as", "Assamese" },
                    { "az", "Azerbaijani (Latin)" },
                    { "ba", "Bashkir" },
                    { "bg", "Bulgarian" },
                    { "bho", "Bhojpuri" },
                    { "bn", "Bangla" },
                    { "bo", "Tibetan" },
                    { "brx", "Bodo" },
                    { "bs", "Bosnian (Latin)" },
                    { "ca", "Catalan" },
                    { "cy", "Welsh" },
                    { "doi", "Dogri" },
                    { "dsb", "Lower Sorbian" },
                    { "dv", "Divehi" },
                    { "et", "Estonian" },
                    { "eu", "Basque" },
                    { "fa", "Persian" },
                    { "fil", "Filipino" },
                    { "fj", "Fijian" },
                    { "fo", "Faroese" },
                    { "fr-ca", "French (Canada)" },
                    { "gl", "Galician" },
                    { "gom", "Konkani" },
                    { "gu", "Gujarati" },
                    { "ha", "Hausa" },
                    { "hr", "Croatian" },
                    { "hsb", "Upper Sorbian" },
                    { "ht", "Haitian Creole" },
                    { "hy", "Armenian" },
                    { "id", "Indonesian" },
                    { "ig", "Igbo" },
                    { "ikt", "Inuinnaqtun" },
                    { "ir", "Irish" },
                    { "is", "Icelandic" },
                    { "itu-Latin", "Inuktitut (Latin)" },
                    { "iu", "Inuktitut" },
                    { "ka", "Georgian" },
                    { "kk", "Kazahk" },
                    { "km", "Kymer" },
                    { "kmr", "Kurdish (Northern)" },
                    { "kn", "Kannada" },
                    { "ks", "Kashmiri" },
                    { "ku", "Kurdish (Central)" },
                    { "ky", "Kyrgyz" },
                    { "ln", "Lingala" },
                    { "lo", "Lao" },
                    { "lt", "Lithuanian" },
                    { "lug", "Liganda" },
                    { "lv", "Latvian" },
                    { "mai", "Maithili" },
                    { "mg", "Malagasy" },
                    { "mi", "Maori" },
                    { "mk", "Macedonian" },
                    { "ml", "Malayalam" },
                    { "mn-Cyrl", "Mongolian (Cyrillic)" },
                    { "mn-Mong", "Mongilian (Traditional)" },
                    { "mr", "Marathi" },
                    { "ms", "Malay (Latin)" },
                    { "mt", "Maltese" },
                    { "mww", "Hmong Daw (Latin)" },
                    { "my", "Myanmar" },
                    { "mya", "Nyanja" },
                    { "ne", "Nepali" },
                    { "nso", "Sesotho sa Leboa" },
                    { "or", "Odia" },
                    { "otq", "Queretaro" },
                    { "pa", "Punjabi" },
                    { "prs", "Dari" },
                    { "ps", "Pashto" },
                    { "pt-pt", "Portugese (Portugal)" },
                    { "ro", "Romanian" },
                    { "run", "Rundi" },
                    { "rw", "Kiyarwanda" },
                    { "sd", "Sindhi" },
                    { "si", "Sinhala" },
                    { "sk", "Slovak" },
                    { "sl", "Slovenian" },
                    { "sm", "Samoan (Latin)" },
                    { "so", "Somali (Arabic)" },
                    { "sq", "Albanian" },
                    { "sr-Cyrl", "Serbian (Cyrillic)" },
                    { "sr-Latn", "Serbian (Latin)" },
                    { "st", "Sesotho" },
                    { "sw", "Swahili (Latin)" },
                    { "ta", "Tamil" },
                    { "te", "Telugu" },
                    { "ti", "Tigrinya" },
                    { "tk", "Tirkmen (Latin)" },
                    { "tlh-Latn", "Klingon" },
                    { "tn", "Setswana" },
                    { "to", "Tongan" },
                    { "tt", "Tatar (Latin)" },
                    { "ty", "Tahitian" },
                    { "ug", "Uyghur (Arabic)" },
                    { "uk", "Ukranian" },
                    { "ur", "Urdu" },
                    { "uz", "Uzbek (Latin)" },
                    { "xh", "Zhosa" },
                    { "yo", "Yoruba" },
                    { "yua", "Yucatec Maya" },
                    { "zu", "Zulu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "af");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "am");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "as");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "az");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ba");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "bg");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "bho");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "bn");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "bo");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "brx");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "bs");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ca");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "cy");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "doi");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "dsb");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "dv");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "et");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "eu");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "fa");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "fil");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "fj");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "fo");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "fr-ca");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "gl");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "gom");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "gu");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ha");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "hr");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "hsb");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ht");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "hy");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "id");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ig");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ikt");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ir");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "is");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "itu-Latin");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "iu");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ka");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "kk");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "km");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "kmr");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "kn");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ks");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ku");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ky");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ln");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "lo");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "lt");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "lug");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "lv");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mai");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mg");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mi");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mk");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ml");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mn-Cyrl");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mn-Mong");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mr");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ms");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mt");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mww");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "my");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "mya");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ne");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "nso");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "or");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "otq");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "pa");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "prs");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ps");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "pt-pt");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ro");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "run");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "rw");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sd");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "si");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sk");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sl");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sm");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "so");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sq");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sr-Cyrl");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sr-Latn");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "st");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "sw");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ta");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "te");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ti");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "tk");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "tlh-Latn");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "tn");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "to");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "tt");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ty");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ug");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "uk");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "ur");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "uz");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "xh");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "yo");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "yua");

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "zu");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 8, 6, 10, 14, 678, DateTimeKind.Utc).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: "pt",
                column: "Name",
                value: "Portugese");
        }
    }
}
