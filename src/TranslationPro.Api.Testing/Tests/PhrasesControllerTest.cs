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

            //foreach (var kvp in translations)
            //{
            //    var foundTranslation = phrase.Translations.FirstOrDefault(x => x.LanguageId == kvp.Key);
            //    Assert.IsNotNull(foundTranslation);

            //    Assert.AreEqual(kvp.Value, foundTranslation.Text);
            //}

            Assert.IsNotNull(phrase);
        }
    }

    [TestFixture]
    public class TheUpdatePhraseMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanUpdatePhrase()
        {
            var input = new PhraseOptions()
            {
                Text = "hello"
            };
            var createResult = await PhrasesProxy.CreatePhraseAsync(ApplicationId, input);

            input.Text = "goodbye";

            var updateResult = await PhrasesProxy.UpdatePhraseAsync(ApplicationId, int.Parse(createResult.Id.ToString()), input);

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