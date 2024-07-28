using TranslationPro.Blazor.Components.Application.Bases;

namespace TranslationPro.Blazor.Pages
{
    public partial class Dashboard : AuthenticatedBase
    {
        protected override void BuildBreadcrumbs()
        {
            Console.WriteLine("Dashboard.BuildBreadcrumbs");

            base.NavigationItems.Clear();
            this.NavigationItems.Add(new NavigationItem()
            {
                Title = "Applications",
                Url = "/applications"
            });
        }
    }
}
