using TranslationPro.Blazor.Components.Application.Bases;

namespace TranslationPro.Blazor.Pages
{
    public partial class PhraseDetails : PhraseDetailsBase
    {
        public bool Disabled { get; set; }


        private Modal deletePhrase;

        private Task ShowModal()
        {
            return deletePhrase.Show();
        }
        private Task HideModal()
        {
            return deletePhrase.Hide();
        }

        public async Task DeletePhrase()
        {
            await HideModal();
            Disabled = true;
            await ApplicationPhraseService.DeletePhraseAsync(ApplicationId, PhraseId);
            Disabled = false;
            NavigationManager.NavigateTo($"/applications/{ApplicationId}");
        }
    }
}
