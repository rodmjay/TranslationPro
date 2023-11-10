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
    public class TheSaveTranslationMethod : TranslationsControllerTest
    {
        [Test]
        public async Task CanSaveTranslation()
        {
            var input = new PhraseOptions()
            {
                Text = "hello"
            };
            var createResult = await PhrasesProxy.CreatePhraseAsync(ApplicationId, input);

            var input2 = new TranslationOptions()
            {
                LanguageId = "es",
                Text = "hola mae"
            };

            var updateResult = await TranslationsProxy.SaveTranslation(ApplicationId, int.Parse(createResult.Id.ToString()), input2);

            Assert.IsTrue(updateResult.Succeeded);
        }
    }
}