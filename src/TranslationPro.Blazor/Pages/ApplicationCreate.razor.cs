using TranslationPro.Blazor.Components.Application.Bases;

namespace TranslationPro.Blazor.Pages
{
    public partial class ApplicationCreate
    {

        protected override void BuildBreadcrumbs()
        {
            base.BuildBreadcrumbs();

            NavigationItems.Add(new NavigationItem()
            {
                Title = "Create Application"
            });
        }
    }
}
