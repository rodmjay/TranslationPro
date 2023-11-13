using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Shared.Common;

namespace TranslationPro.Shared.Results
{
    public class CreatePhraseResult
    {

        public bool Succeeded { get; set; }

        public int TranslationsCreated { get; set; }
        public int TranslationsCopied { get; set; }
        public int? PhraseId { get; set; }
        public IEnumerable<Error> Errors { get; set; }
    }
}
