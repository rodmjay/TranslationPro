using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Components.Application.Components;

namespace TranslationPro.Blazor.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase
    {
        private PhraseList list;

        protected override async Task LoadData()
        {
            await base.LoadData();
        }

        public async Task Reload()
        {
            await LoadData();
            await list.Reload();
            StateHasChanged();
        }
        
    }
}
