﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Bases
{
    public class ApplicationUsersBase : ApplicationDetailsBase
    {
        protected override async Task LoadData()
        {
            await base.LoadData();
            NavigationItems.Add(new NavigationItem()
            {
                Title = "Application Users",
                Url = $"/applications/{ApplicationId}/users"
            });
        }
    }

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
