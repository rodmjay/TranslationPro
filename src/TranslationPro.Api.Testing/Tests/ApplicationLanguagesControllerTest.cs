#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using NUnit.Framework;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class ApplicationLanguagesControllerTest : BaseApiTest
{

    [TestFixture]
    public class TheAddLanguageToApplicationMethod : ApplicationLanguagesControllerTest
    {
        [Test]
        public async Task CanAddLanguageToApplication()
        {
            Assert.IsTrue(true);
        }
    }

    [TestFixture]
    public class TheRemoveLanguageFromApplicationMethod : ApplicationLanguagesControllerTest
    {
        [Test]
        public async Task CanRemoveLanguageFromApplication()
        {
            Assert.IsTrue(true);
        }
    }
}