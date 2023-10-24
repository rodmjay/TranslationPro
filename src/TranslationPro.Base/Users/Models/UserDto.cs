#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using TranslationPro.Base.Users.Interfaces;

namespace TranslationPro.Base.Users.Models;

public class UserDto : IUser
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}