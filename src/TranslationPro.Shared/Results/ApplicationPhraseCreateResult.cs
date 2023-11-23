using System.Collections.Generic;
using TranslationPro.Shared.Common;

namespace TranslationPro.Shared.Results
{
    public class ApplicationPhraseCreateResult
    {

        public bool Succeeded { get; set; }

        public int TranslationsCreated { get; set; }
        public int TranslationsCopied { get; set; }
        public int? PhraseId { get; set; }
        public IEnumerable<Error> Errors { get; set; }
    }
}
