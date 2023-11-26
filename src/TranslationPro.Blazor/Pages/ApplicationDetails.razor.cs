using TranslationPro.Blazor.Components.Application.Bases;
using TranslationPro.Blazor.Components.Application.Components;

namespace TranslationPro.Blazor.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase
    {
        private PhraseList list;
        
        public async Task Reload()
        {
            await LoadData();
            await list.Reload();
            StateHasChanged();
        }
        
    }
}
