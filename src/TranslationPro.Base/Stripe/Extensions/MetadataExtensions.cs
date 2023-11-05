#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Stripe;

namespace TranslationPro.Base.Stripe.Extensions;

public static class MetadataExtensions
{
    public static int GetUserIdFromMetadata(this IHasMetadata input)
    {
        return int.Parse(input.Metadata["UserId"]);
    }

    public static void AddUserIdToMetadata(this IHasMetadata input, int userId)
    {
        input.Metadata.Add("UserId", userId.ToString());
    }
}