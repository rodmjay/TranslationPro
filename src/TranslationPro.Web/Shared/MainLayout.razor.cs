using System.Security.Claims;
using Duende.IdentityServer;
using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Base.Applications.Interfaces;
using TranslationPro.Base.Applications.Models;
using TranslationPro.Base.Applications.Services;
using TranslationPro.Base.Users.Interfaces;
using TranslationPro.Base.Users.Managers;
using TranslationPro.Web.Areas.Identity;

namespace TranslationPro.Web.Shared
{
    public partial class MainLayout
    {
        private List<ApplicationDto> _applications;
        [Inject]
        public IApplicationService? ApplicationService { get; set; }

        [Inject]
        public IUserAccessor? UserAccessor { get; set; }
        [Inject]

        public UserManager? UserManager { get; set; }

        [Inject]
        public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
           
        }

        public async Task Click()
        {
          
        }
    }
}
