#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion


namespace TranslationPro.Base.Common
{
    public static class ErrorMessages
    {
        public static class UserErrors
        {
            public const string UserWithSameEmailAlreadyExist = "A user with the same email already exists";
            public const string UnableToCreateUser = "Unable to create user";
            public const string UserDoesNotExist = "User does not exist or account is deactivated";
            public const string UsernameAlreadyExists = "Username already exists";
            public const string InvalidPassword = "Your password was invalid";
            public const string PasswordRequired = "Password is a required field";
        }
    }
}