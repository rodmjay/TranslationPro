using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.App
{
    public partial class App
    {
        [Inject]
        public IApplicationsController ApplicationProxy { get; set; }
    }
}
