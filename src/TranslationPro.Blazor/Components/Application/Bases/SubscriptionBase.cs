#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Blazor.Components.Application.Bases;

public abstract class SubscriptionBase : AuthenticatedBase
{
    protected override void BuildBreadcrumbs()
    {
        Console.WriteLine("SubscriptionBase.BuildBreadcrumbs");

        this.NavigationItems.Clear();
        this.NavigationItems.Add(new NavigationItem()
        {
            Title = "Subscription",
            Url = "/subscription"
        });
    }
    
}