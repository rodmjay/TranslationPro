using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Extensions;
using TranslationPro.Shared.Enums;
using TranslationPro.Shared.Results;

namespace TranslationPro.Base.Services
{
    public class GoogleTranslationService : BaseService<Engine>, ITranslationProcessor
    {
        private readonly TranslationClient _googleClient;

        public GoogleTranslationService(IServiceProvider serviceProvider, TranslationClient googleClient) : base(serviceProvider)
        {
            _googleClient = googleClient;
        }


        private IQueryable<Engine> Engines => Repository.Queryable().Include(x => x.Languages);


        public async Task<Dictionary<string, List<GenericTranslationResult>>> Process(Dictionary<string, List<string>> dictionary)
        {
            var retVal = new Dictionary<string, List<GenericTranslationResult>>();

            var engine = await Engines.Where(x => x.Id == TranslationEngine.Azure).FirstAsync();

            foreach (var kvp in dictionary)
            {
                var targetLanguage = kvp.Key;

                if (engine.HasLanguageEnabled(targetLanguage))
                {
                    var texts = kvp.Value.Select(x => x.ToString()).ToList();

                    var translations = await _googleClient.TranslateTextAsync(texts, targetLanguage);

                    foreach (var translation in translations)
                    {
                        if (!retVal.ContainsKey(translation.OriginalText))
                        {
                            retVal.Add(translation.OriginalText, new List<GenericTranslationResult>());
                        }

                        retVal[translation.OriginalText].Add(new GenericTranslationResult()
                        {
                            Text = translation.TranslatedText,
                            To = targetLanguage
                        });
                    }
                }

            }

            return retVal;
        }
    }
}
