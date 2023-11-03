using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.App.Shared;

public partial class ApplicationList
{
    [CascadingParameter]
    Task<AuthenticationState> authenticationStateTask { get; set; }

    public IEnumerable<ApplicationDto>? Apps { get; set; }

    [Inject]
    public IApplicationsController? ApplicationService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Apps = (await ApplicationService!.GetApplicationsAsync()).ToList();
    }
}