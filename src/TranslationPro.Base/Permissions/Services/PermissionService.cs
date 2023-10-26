﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Permissions.Interfaces;

namespace TranslationPro.Base.Permissions.Services;

public class PermissionService : BaseService, IPermissionService
{
    public PermissionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}