#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using TranslationPro.Shared.Common;
using TranslationPro.Shared.Models;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class ApplicationLanguagesControllerTest : BaseApiTest
{

    [TestFixture]
    public class TheAddLanguageToApplicationMethod : ApplicationLanguagesControllerTest
    {
        [TestCase("es")]
        [TestCase("fr")]
        [TestCase("de")]
        [TestCase("ja")]
        [TestCase("fil")]
        [TestCase("ar")]
        [TestCase("as")]
        public async Task CanAddLanguageToApplication(string language)
        {
            var createApplicationOptions = new ApplicationCreateOptions()
            {
                Name = "Test",
                Languages = new List<string>() { "en" }
            };

            var createApplication = await ApplicationsProxy.CreateApplicationAsync(createApplicationOptions);

            Assert.IsTrue(createApplication.Succeeded);

            var applicationId = Guid.Parse(createApplication.Id.ToString());

            var createPhraseOptions = new ApplicationPhrasesCreateOptions()
            {
                Texts = new List<string>() {"house"}
            };

            var createPhrase = await ApplicationPhrasesProxy.CreatePhrasesAsync(applicationId, createPhraseOptions);
            Assert.IsNotNull(createPhrase);

            var getApplication =
                await ApplicationsProxy.GetApplicationAsync(applicationId);


            Assert.AreEqual(1, getApplication.PhraseCount);
            Assert.AreEqual(1, getApplication.TranslationCount);

            Assert.IsNotNull(getApplication);


            Assert.AreEqual(createApplicationOptions.Languages.Count, getApplication.Languages.Count);

            var addApplicationLanguageOptions = new ApplicationLanguageOptions()
            {
                LanguageId = language
            };

            var addApplicationLanguageOptionsResult =
                await ApplicationLanguageProxy.AddLanguageToApplicationAsync(applicationId,
                    addApplicationLanguageOptions);

            Assert.IsTrue(addApplicationLanguageOptionsResult.Succeeded);

            getApplication = await ApplicationsProxy.GetApplicationAsync(applicationId);

            Assert.AreEqual(2, getApplication.Languages.Count);
            Assert.AreEqual(1, getApplication.PhraseCount);
            Assert.AreEqual(2, getApplication.TranslationCount);

            createPhraseOptions = new ApplicationPhrasesCreateOptions()
            {
                Texts = new List<string>() {"street"}
            };
            createPhrase = await ApplicationPhrasesProxy.CreatePhrasesAsync(applicationId, createPhraseOptions);
            Assert.IsNotNull(createPhrase);

            getApplication = await ApplicationsProxy.GetApplicationAsync(applicationId);

            Assert.AreEqual(2, getApplication.PhraseCount);
            Assert.AreEqual(4, getApplication.TranslationCount);

            var getPhrases = await ApplicationPhrasesProxy.GetPhraseAsync(applicationId, int.Parse(createPhrase[0].Id.ToString()));

            foreach (var phrase in getPhrases.Translations)
            {
                Assert.IsNotNull(phrase.Text);
            }

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