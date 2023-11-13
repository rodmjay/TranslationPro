using System.Linq;
using TranslationPro.Base.Entities;

namespace TranslationPro.Base.Extensions
{
    public static class EngineExtensions
    {
        public static bool HasLanguageEnabled(this Engine engine, string language)
        {
            return engine.Languages.Any(x => x.LanguageId == language);
        }
    }
}
