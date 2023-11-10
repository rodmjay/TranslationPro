#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class ApplicationUsersControllerTest : BaseApiTest
{
    [TestFixture]
    public class TheInviteUserMethod : ApplicationUsersControllerTest
    {
        [Test]
        public async Task CanInviteUser()
        {
            var invitation = new ApplicationUserCreateOptions()
            {
                FirstName = "test",
                LastName = "test",
                Email = "test@test.com"
            };

            var result = await ApplicationUsersProxy.InviteUserAsync(ApplicationId, invitation);

            Assert.IsTrue(result.Succeeded);
        }
    }
}