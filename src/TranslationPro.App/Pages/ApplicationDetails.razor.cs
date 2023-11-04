using System;
using System.Threading.Tasks;
using TranslationPro.App.Pages.Bases;
using TranslationPro.App.Shared;

namespace TranslationPro.App.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase
    {
        public PhraseList PhraseList;

        public async Task ReloadPhrases()
        {
            

            await LoadData();
        }

        protected override async Task LoadData()
        {
            await base.LoadData();

            if (PhraseList != null)
            {
                await PhraseList.LoadData();
            }
        }
    }
}
