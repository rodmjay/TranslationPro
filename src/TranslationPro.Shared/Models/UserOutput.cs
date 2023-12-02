#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Shared.Models;

public class UserOutput : IUser
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public SubscriptionOutput Subscription { get; set; }

}