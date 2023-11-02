#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class TranslationsControllerTest : BaseApiTest
{
    [TestFixture]
    public class TheSaveTranslationMethod : BaseApiTest
    {
        [Test]
        public async Task CanSaveTranslation()
        {
            var input = new PhraseInput()
            {
                Text = "hello"
            };
            var createResult = await CreatePhraseAsync(ApplicationId, input);

            var input2 = new TranslationInput()
            {
                LanguageId = "es",
                Text = "hola mae"
            };

            var updateResult = await SaveTranslation(ApplicationId, int.Parse(createResult.Id.ToString()), input2);

            Assert.IsTrue(updateResult.Succeeded);
        }
    }
}