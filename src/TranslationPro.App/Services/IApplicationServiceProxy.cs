#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Applications;

namespace TranslationPro.App.Services;

public interface IApplicationServiceProxy
{
    Task<List<ApplicationDto>> GetApplications();
}