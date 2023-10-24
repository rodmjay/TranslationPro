#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace TranslationPro.Base.Email.Services;

public class NoopEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        return Task.CompletedTask;
    }
}