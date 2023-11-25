using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCurrentPhraseIdToApplication2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"update [TranslationPro].[Application]
	set [TranslationPro].[Application].[CurrentPhraseId] = (Select max (ID) from [TranslationPro].[ApplicationPhrase] 
	where [TranslationPro].[ApplicationPhrase].[ApplicationId] = [TranslationPro].[Application].Id)
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
