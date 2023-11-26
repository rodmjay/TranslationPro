using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Components;

public partial class ApplicationList : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    public IEnumerable<ApplicationOutput> Apps { get; set; }

    [Inject]
    public IApplicationsController ApplicationService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Apps = await ApplicationService.GetApplicationsAsync();
    }

    private void Callback(DataGridRowMouseEventArgs<ApplicationOutput> evnt)
    {
        NavigationManager.NavigateTo($"applications/{evnt.Item.Id}");
    }
}