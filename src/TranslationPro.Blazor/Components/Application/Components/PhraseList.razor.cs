using EventAggregator.Blazor;
using Microsoft.AspNetCore.Components;
using TranslationPro.Blazor.Events;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Interfaces;
using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Components.Application.Components
{
    public partial class PhraseList : IHandle<LanguagesChangedEvent>
    {
        [CascadingParameter]
        public IEventAggregator EventAggregator { get; set; }

        [CascadingParameter]
        public ApplicationOutput Application { get; set; }
        
        private PagingQuery PagingQuery { get; set; } = new();

        [Inject]
        public IApplicationPhrasesController PhraseData { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private PagedList<ApplicationPhraseOutput> PagedList { get; set; }

        protected override void OnInitialized()
        {
            EventAggregator.Subscribe(this);
        }

        public async Task LoadData()
        {
            PagedList = await PhraseData.GetPhrasesAsync(Application.Id, PagingQuery, new PhraseFilters());
        }
        
        protected override async Task OnParametersSetAsync()
        {
            await LoadData();
        }

        private async Task OnReadData(DataGridReadDataEventArgs<ApplicationPhraseOutput> e)
        {
            if (!e.CancellationToken.IsCancellationRequested)
            {

            }
        }

        private void ItemSelected(DataGridRowMouseEventArgs<ApplicationPhraseOutput> evnt)
        {
            NavigationManager.NavigateTo($"/applications/{Application.Id}/phrases/{evnt.Item.Id}");
        }

        private async Task PageChanged(DataGridPageChangedEventArgs args)
        {
            var reload = false;

            if (PagedList.CurrentPage != args.Page)
            {
                reload = true;
                PagingQuery.Page = args.Page;
            }

            if (PagedList.PageSize != args.PageSize)
            {
                reload = true;
                PagingQuery.Size = args.PageSize;
            }

            if (reload)
            {
                await LoadData();
            }

        }

        public async Task HandleAsync(LanguagesChangedEvent message)
        {
            await LoadData();
        }
    }
}
