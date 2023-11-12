#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Filters;
using TranslationPro.Shared.Models;
using TranslationPro.Testing.TestCases;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class PhrasesControllerTest : BaseApiTest
{

    [TestFixture]
    public class TheCreatePhraseMethod : PhrasesControllerTest
    {
        [TestCaseSource(typeof(PhraseTestCases), nameof(PhraseTestCases.PhrasesWithTranslations))]
        public async Task CanCreatePhraseWithTranslations(PhraseOptions input, Dictionary<string, string> translations)
        {

            var result = await PhrasesProxy.CreatePhraseAsync(ApplicationId, input);

            Assert.IsTrue(result.Succeeded);

            var phrase = await PhrasesProxy.GetPhraseAsync(ApplicationId, int.Parse(result.Id.ToString()));

            Assert.IsNotNull(phrase);

            foreach (var (language, translation) in translations)
            {
                var foundTranslation = phrase.Translations.FirstOrDefault(x => x.LanguageId == language);
                Assert.IsNotNull(foundTranslation);
                Assert.AreEqual(translation, foundTranslation.Text);
            }

        }
    }

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
            var createResult = await PhrasesProxy.CreatePhraseAsync(ApplicationId, input);

            input.Text = "goodbye";

            var replacementInput = new TranslationReplacementOptions()
            {
                LanguageId = "es",
                Text = "hola mae"
            };

            var updateResult = await PhrasesProxy.ReplaceTranslation(ApplicationId, int.Parse(createResult.Id.ToString()), replacementInput);

            Assert.IsTrue(updateResult.Succeeded);
        }
    }

    [TestFixture]
    public class TheGetPhrasesMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanGetPhrases()
        {
            var input = new PhraseOptions()
            {
                Text = "hello"
            };
            var createResult = await PhrasesProxy.CreatePhraseAsync(ApplicationId, input);

            var phrases = await PhrasesProxy.GetPhrasesAsync(ApplicationId, new PagingQuery(), new PhraseFilters());

            Assert.AreEqual(1, phrases.Items.Count);

        }
    }

    [TestFixture]
    public class TheGetPhrasesForApplicationAndLanguageMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanGetPhrasesForApplicationAndLanguage()
        {
            var input = new PhraseOptions()
            {
                Text = "hello"
            };
            var createResult = await PhrasesProxy.CreatePhraseAsync(ApplicationId, input);

            var phrases = await PhrasesProxy.GetPhrasesForApplicationAndLanguageAsync(ApplicationId, "en");

            Assert.AreEqual(1, phrases.Count);
        }
    }

    [TestFixture]
    public class TheDeletePhraseMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanDeletePhrase()
        {
            var input = new PhraseOptions()
            {
                Text = "hello"
            };
            var createResult = await PhrasesProxy.CreatePhraseAsync(ApplicationId, input);

            var deleteResult = await PhrasesProxy.DeletePhraseAsync(ApplicationId, int.Parse(createResult.Id.ToString()));

            Assert.IsTrue(deleteResult.Succeeded);
        }
    }
}