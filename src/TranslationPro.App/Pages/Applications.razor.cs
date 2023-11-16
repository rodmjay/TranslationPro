using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationPro.App.Bases;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Pages
{
    public partial class Applications : AuthenticatedBase
    {
        public IEnumerable<ApplicationOutput> Apps { get; set; }

        protected override async Task LoadData()
        {
            await base.LoadData();
            Apps = await ApplicationService.GetApplicationsAsync();
        }
    }
}
