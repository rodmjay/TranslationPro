﻿using TranslationPro.Blazor.Components.Application.Bases;

namespace TranslationPro.Blazor.Pages
{
    public partial class PhraseCreate : ApplicationDetailsBase
    {
        protected override void BuildBreadcrumbs()
        {
            base.BuildBreadcrumbs();

            NavigationItems.Add(new NavigationItem()
            {
                Title = "Create Phrase"
            });
        }

    }
}
