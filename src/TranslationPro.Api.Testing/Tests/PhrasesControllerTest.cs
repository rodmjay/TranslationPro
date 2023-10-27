#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Threading.Tasks;
using EllipticCurve;
using FluentValidation.Internal;
using NUnit.Framework;
using TranslationPro.Base.Common.Models;
using TranslationPro.Base.Phrases.Models;

namespace TranslationPro.Api.Testing.Tests;

[TestFixture]
public class PhrasesControllerTest : BaseApiTest
{
    [TestFixture]
    public class TheBulkUploadMethod : BaseApiTest
    {
    }

    [TestFixture]
    public class TheCreatePhraseMethod : BaseApiTest
    {
        [Test]
        public async Task CanCreatePhrase()
        {
            var input = new PhraseInput()
            {
                Text = "hello"
            };

            var result = await CreatePhrase(ApplicationId, input);

            Assert.IsTrue(result.Succeeded);
        }
    }

    [TestFixture]
    public class TheUpdatePhraseMethod : BaseApiTest
    {
        [Test]
        public async Task CanUpdatePhrase()
        {
            var input = new PhraseInput()
            {
                Text = "hello"
            };
            var createResult = await CreatePhrase(ApplicationId, input);

            input.Text = "goodbye";

            var updateResult = await UpdatePhrase(ApplicationId, int.Parse(createResult.Id.ToString()), input);

            Assert.IsTrue(updateResult.Succeeded);
        }
    }

    [TestFixture]
    public class TheGetPhrasesMethod : BaseApiTest
    {
        [Test]
        public async Task CanGetPhrases()
        {
            var input = new PhraseInput()
            {
                Text = "hello"
            };
            var createResult = await CreatePhrase(ApplicationId, input);

            var phrases = await GetPhrases(ApplicationId, new PagingQuery(), new PhraseFilters());

            Assert.AreEqual(1, phrases.Items.Count);

        }
    }

    [TestFixture]
    public class TheGetPhrasesForApplicationAndLanguageMethod : BaseApiTest
    {
        [Test]
        public async Task CanGetPhrasesForApplicationAndLanguage()
        {
            var input = new PhraseInput()
            {
                Text = "hello"
            };
            var createResult = await CreatePhrase(ApplicationId, input);

            var phrases = await GetPhrasesForApplicationAndLanguage(ApplicationId, "en");

            Assert.AreEqual(1, phrases.Count);
        }
    }

    [TestFixture]
    public class TheDeletePhraseMethod : BaseApiTest
    {
        [Test]
        public async Task CanDeletePhrase()
        {
            var input = new PhraseInput()
            {
                Text = "hello"
            };
            var createResult = await CreatePhrase(ApplicationId, input);

            var deleteResult = await DeletePhrase(ApplicationId, int.Parse(createResult.Id.ToString()));

            Assert.IsTrue(deleteResult.Succeeded);
        }
    }
}