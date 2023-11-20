﻿#region Header Info

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
    public class TheReplaceTranslationMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanReplaceTranslation()
        {
            var input = new PhraseOptions()
            {
                Text = "hello"
            };
            var createResult = await ApplicationPhrasesProxy.CreatePhraseAsync(ApplicationId, input);

            input.Text = "goodbye";

            var replacementInput = new TranslationReplacementOptions()
            {
                LanguageId = "es",
                Text = "hola mae"
            };

            var updateResult = await ApplicationTranslationsProxy.ReplaceTranslation(ApplicationId, int.Parse(createResult.Id.ToString()), replacementInput);

            Assert.IsTrue(updateResult.Succeeded);
        }
    }
}