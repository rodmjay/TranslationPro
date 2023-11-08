using System;
using System.Threading.Tasks;
using TranslationPro.App.Bases;
using TranslationPro.App.Shared;

namespace TranslationPro.App.Pages
{
    public partial class ApplicationDetails : ApplicationDetailsBase
    {
        public PhraseList PhraseList;

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
