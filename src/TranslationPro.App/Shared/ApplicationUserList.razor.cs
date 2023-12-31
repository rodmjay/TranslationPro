﻿using Microsoft.AspNetCore.Components;
using Solutaris.InfoWARE.ProtectedBrowserStorage.Services;
using System.Collections.Generic;
using System;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;
using System.Threading.Tasks;
using TranslationPro.App.Extensions;

namespace TranslationPro.App.Shared
{
    public partial class ApplicationUserList
    {
        [Inject]
        public IApplicationsController ApplicationsController { get; set; }
        
        [Inject]
        public IApplicationUsersController ApplicationUsersController { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }

        public ICollection<ApplicationUserOutput> ApplicationUsers { get; set; }

        [Parameter]
        public EventCallback UsersChanged { get; set; }

        [CascadingParameter]
        private RouteData RouteData { get; set; }


        public Guid ApplicationId => RouteData.GetApplicationId();

        public ApplicationOutput Application { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public async Task LoadData()
        {
            this.Application = null;
            Application = await ApplicationsController.GetApplicationAsync(ApplicationId);
        }
        
    }
}
