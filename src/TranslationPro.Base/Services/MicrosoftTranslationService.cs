using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Entities;
using TranslationPro.Base.Extensions;
using TranslationPro.Base.Interfaces;
using TranslationPro.Shared.Enums;

namespace TranslationPro.Base.Services;

public class GenericTranslationResult
{
    public string Text { get; set; }
    public string To { get; set; }
}
public class MicrosoftTranslationService : BaseService<Engine>, ITranslationProcessor
{
    private readonly IConfiguration _configuration;
    private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com";
    private static readonly string location = "eastus";
    public MicrosoftTranslationService(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
    {
        _configuration = configuration;
    }

    private IQueryable<Engine> Engines => Repository.Queryable().Include(x => x.Languages);

    private string GetKey()
    {
        string microsoftTranslateApiKey = Environment.GetEnvironmentVariable("TranslationProMicrosoftApi");
        if (string.IsNullOrEmpty(microsoftTranslateApiKey))
        {
            microsoftTranslateApiKey = _configuration["TranslationProMicrosoftApi"];
        }

        return microsoftTranslateApiKey;
    }

    public async Task<Dictionary<string, List<GenericTranslationResult>>> Process(Dictionary<string, List<string>> dictionary)
    {
        var retVal = new Dictionary<string, List<GenericTranslationResult>>();

        var engine = await Engines.Where(x => x.Id == TranslationEngine.Azure).FirstAsync();

        foreach (var kvp in dictionary)
        {
            var languageTarget = kvp.Key;

            if (engine.HasLanguageEnabled(languageTarget))
            {
                string route = $"/translate?api-version=3.0&from=en&to={languageTarget}";

                object[] body = kvp.Value.Select(x => new { Text = x }).ToArray();

                var requestBody = JsonConvert.SerializeObject(body);

                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage())
                    {
                        request.Method = HttpMethod.Post;
                        request.RequestUri = new Uri(endpoint + route);
                        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                        request.Headers.Add("Ocp-Apim-Subscription-Region", location);
                        request.Headers.Add("Ocp-Apim-Subscription-Key", GetKey());

                        HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

                        string result = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine(result);
                            //JObject obj = JObject.Parse(result);

                            List<Dictionary<string, List<GenericTranslationResult>>> deserializedResult = JsonConvert.DeserializeObject<List<Dictionary<string, List<GenericTranslationResult>>>>(result);

                            if (deserializedResult != null)
                            {
                                for (var i = 0; i < deserializedResult.Count; i++)
                                {
                                    var originalPhrase = kvp.Value[i];

                                    var item = deserializedResult[i];
                                    var translationResult = item.First(x => x.Key == "translations");
                                    for (var index = 0; index < translationResult.Value.Count; index++)
                                    {
                                        var translatedPhrase = translationResult.Value[index];

                                        if (!retVal.ContainsKey(originalPhrase))
                                        {
                                            retVal.Add(originalPhrase, new List<GenericTranslationResult>());
                                        }

                                        retVal[originalPhrase].Add(translatedPhrase);

                                        Console.WriteLine(
                                            $"{originalPhrase} translates to: {translatedPhrase.Text} in {kvp.Key}");
                                    }
                                }
                            }
                        }
                    }
                }
            }


        }
        return retVal;
    }
}