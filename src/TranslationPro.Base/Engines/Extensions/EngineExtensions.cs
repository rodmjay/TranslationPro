using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Base.Engines.Entities;

namespace TranslationPro.Base.Engines.Extensions
{
    public static class EngineExtensions
    {
        public static bool HasLanguageEnabled(this Engine engine, string language)
        {
            return engine.Languages.Any(x=>x.LanguageId == language);
        } 
    }
}
