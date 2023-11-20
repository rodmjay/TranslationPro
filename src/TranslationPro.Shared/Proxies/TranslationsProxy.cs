using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Shared.Models;

namespace TranslationPro.Shared.Proxies
{
    public class TranslationsProxy : BaseProxy
    {
        public TranslationsProxy(HttpClient httpClient) : base(httpClient)
        {

        }

        public Task<List<PhraseOutput>> Translate(PhraseBulkCreateOptions options)
        {
            return DoPost<PhraseBulkCreateOptions, List<PhraseOutput>>("/v1.0/translate", options);
        }
    }
}
