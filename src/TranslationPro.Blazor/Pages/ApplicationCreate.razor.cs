using TranslationPro.Blazor.Components.Application.Bases;

namespace TranslationPro.Blazor.Pages
{
    public partial class ApplicationCreate : AuthenticatedBase
    {
        protected override void BuildBreadcrumbs()
        {
            Console.WriteLine("ApplicationCreate.BuildBreadcrumbs");

            base.NavigationItems.Clear();
            this.NavigationItems.Add(new NavigationItem()
            {
                Title = "Applications",
                Url = "/applications"
            });
            NavigationItems.Add(new NavigationItem()
            {
                Title = "Create Application"
            });
        }
    }
}
