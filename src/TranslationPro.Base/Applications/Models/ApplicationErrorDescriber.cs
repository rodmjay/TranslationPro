#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Base.Common.Models;

namespace TranslationPro.Base.Applications.Models;

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