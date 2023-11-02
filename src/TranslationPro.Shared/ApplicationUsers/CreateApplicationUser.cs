﻿using System.Text.Json.Serialization;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Shared.ApplicationUsers
{
    public class ApplicationUserDto
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
    public class CreateApplicationUser
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}