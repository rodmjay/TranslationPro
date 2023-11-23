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
    public class TheCreatePhrasesMethod : PhrasesControllerTest
    {
        [TestCaseSource(typeof(PhraseTestCases), nameof(PhraseTestCases.PhrasesWithTranslations))]
        public async Task CanCreatePhrasesWithTranslations(ApplicationPhrasesCreateOptions input, Dictionary<string, string> translations)
        {

            var result = await ApplicationPhrasesProxy.CreatePhrasesAsync(ApplicationId, input);

            Assert.IsNotNull(result);

            var phrase = await ApplicationPhrasesProxy.GetPhraseAsync(ApplicationId, int.Parse(result[0].Id.ToString()));

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
    public class TheGetPhrasesMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanGetPhrases()
        {
            var input = new ApplicationPhrasesCreateOptions()
            {
                Texts = new List<string>() {"hello"}
            };
            var createResult = await ApplicationPhrasesProxy.CreatePhrasesAsync(ApplicationId, input);

            var phrases = await ApplicationPhrasesProxy.GetPhrasesAsync(ApplicationId, new PagingQuery(), new PhraseFilters());

            Assert.AreEqual(1, phrases.Items.Count);

        }
    }

    [TestFixture]
    public class TheGetPhrasesForApplicationAndLanguageMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanGetPhrasesForApplicationAndLanguage()
        {
            var input = new ApplicationPhrasesCreateOptions()
            {
                Texts = new List<string>() {"hello"}
            };
            var createResult = await ApplicationPhrasesProxy.CreatePhrasesAsync(ApplicationId, input);

            var phrases = await ApplicationPhrasesProxy.GetPhrasesForApplicationAndLanguageAsync(ApplicationId, "en");

            Assert.AreEqual(1, phrases.Count);
        }
    }

    [TestFixture]
    public class TheDeletePhraseMethod : PhrasesControllerTest
    {
        [Test]
        public async Task CanDeletePhrase()
        {
            var input = new ApplicationPhrasesCreateOptions()
            {
                Texts = new List<string>() {"hello"}
            };
            var createResult = await ApplicationPhrasesProxy.CreatePhrasesAsync(ApplicationId, input);

            var deleteResult = await ApplicationPhrasesProxy.DeletePhraseAsync(ApplicationId, int.Parse(createResult[0].Id.ToString()));

            Assert.IsTrue(deleteResult.Succeeded);
        }
    }
}