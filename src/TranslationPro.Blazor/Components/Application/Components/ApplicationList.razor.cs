using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Components;

public partial class ApplicationList : ComponentBase, IHandle<ApplicationCreatedEvent>
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    public IEnumerable<ApplicationOutput> Apps { get; set; }

    [Inject]
    public IApplicationsController ApplicationService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    public async Task LoadData()
    {
        Apps = await ApplicationService.GetApplicationsAsync();
    }

    private void HandleRowClicked(DataGridRowMouseEventArgs<ApplicationOutput> evnt)
    {
        NavigationManager.NavigateTo($"applications/{evnt.Item.Id}");
    }

    public async Task HandleAsync(ApplicationCreatedEvent message)
    {
        await LoadData();
    }
}