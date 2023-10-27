#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class ApplicationLanguagesControllerTest : BaseApiTest
{
    [TestFixture]
    public class TheAddLanguageToApplicationMethod : BaseApiTest
    {
        [Test]
        public async Task CanAddLanguageToApplication()
        {
            var applicationId = Guid.Parse(ApplicationResult.Id.ToString());


        }
    }

    [TestFixture]
    public class TheRemoveLanguageFromApplicationMethod : BaseApiTest
    {
        [Test]
        public async Task CanRemoveLanguageFromApplication()
        {

        }
    }
}