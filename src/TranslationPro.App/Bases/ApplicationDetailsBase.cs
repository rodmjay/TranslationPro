using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Bases
{
    public class ApplicationDetailsBase : AuthenticatedBase
    {
        [Parameter]
        public Guid ApplicationId { get; set; }

        protected ApplicationOutput Application { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }
        

        protected override async Task LoadData()
        {
            StateHasChanged();
            await base.LoadData();

            Application = await ApplicationService.GetApplicationAsync(ApplicationId);

            this.NavigationItems.Add(new NavigationItem()
            {
                Title = Application.Name,
                Url = $"/applications/{Application.Id}"
            });
        }
    }
}
