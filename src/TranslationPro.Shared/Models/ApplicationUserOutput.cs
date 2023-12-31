﻿using System;
using System.Text.Json.Serialization;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Shared.Models;

public class ApplicationUserOutput
{
    public string Name { get; set; }
    public ApplicationRole Role { get; set; }

    public DateTime? InvitationDate { get; set; }

    [JsonIgnore]
    public DateTime? InvitationReceivedDate { get; set; }

    public string Status
    {
        get
        {
            if (Role == ApplicationRole.Owner)
            {
                return "Administrator";
            }
            else
            {
                if (InvitationDate != null && InvitationReceivedDate == null)
                {
                    return "Pending Invite";
                }

                if (InvitationDate != null && InvitationReceivedDate != null)
                {
                    return "Contributor";
                }
            }

            return "Contributor";
        }
    }
}