#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Blazor.Components.Application.Bases;

public class ApplicationUsersBase : ApplicationDetailsBase
{
    protected override async Task LoadData()
    {
        await base.LoadData();
        NavigationItems.Add(new NavigationItem()
        {
            Title = "Application Users",
            Url = $"/applications/{ApplicationId}/users"
        });
    }
}