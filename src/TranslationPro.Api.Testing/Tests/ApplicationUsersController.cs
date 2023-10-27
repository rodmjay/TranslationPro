#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Base.ApplicationUsers.Models;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class ApplicationUsersController : BaseApiTest
{
    [TestFixture]
    public class TheInviteUserMethod : BaseApiTest
    {
        [Test]
        public async Task CanInviteUser()
        {
            var invitation = new CreateApplicationUser()
            {
                FirstName = "test",
                LastName = "test",
                Email = "test@test.com"
            };

            var result = await InviteUserAsync(ApplicationId, invitation);

            Assert.IsTrue(result.Succeeded);
        }
    }
}