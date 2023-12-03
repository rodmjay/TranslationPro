using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Blazor
{
    public partial class App
    {
        [Inject]
        public IEventAggregator EventAggregator { get; set; }

        [Inject]
        public IApplicationsController ApplicationProxy { get; set; }

        private Theme theme = new()
        {
            BarOptions = new()
            {
                HorizontalHeight = "72px"
            },
            ColorOptions = new()
            {
                Primary = "#3498db",
                Secondary = "#9b59b6",
                Success = "#23C02E",
                Info = "#9BD8FE",
                Warning = "#F8B86C",
                Danger = "#F95741",
                Light = "#F0F0F0",
                Dark = "#535353",
            },
            BackgroundOptions = new()
            {
                Primary = "#3498db",
                Secondary = "#9b59b6",
                Success = "#23C02E",
                Info = "#9BD8FE",
                Warning = "#F8B86C",
                Danger = "#F95741",
                Light = "#F0F0F0",
                Dark = "#535353",
            },
            InputOptions = new()
            {
                CheckColor = "#0288D1",
            }
        };

    }
}
