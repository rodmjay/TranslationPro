﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Errors;

public class ApplicationErrorDescriber
{

    public virtual Error UnableToDeleteApplication(string name)
    {
        return new Error
        {
            Code = nameof(UnableToDeleteApplication),
            Description = $"Unable to delete application '{name}'"
        };
    }

    public virtual Error NoSubscription()
    {
        return new Error
        {
            Code = nameof(NoSubscription),
            Description = "Unable to create application because there is no subscription"
        };
    }

    public virtual Error UnableToCreateApplication()
    {
        return new Error
        {
            Code = nameof(UnableToCreateApplication),
            Description = "Unable to create application"
        };
    }

    public virtual Error UnableToUpdateApplication(string name)
    {
        return new Error
        {
            Code = nameof(UnableToUpdateApplication),
            Description = $"Unable to update application '{name}'"
        };
    }
}