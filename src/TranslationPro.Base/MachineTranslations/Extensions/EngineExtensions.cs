using System.Linq;
using TranslationPro.Base.MachineTranslations.Entities;

namespace TranslationPro.Base.MachineTranslations.Extensions
{
    public static class EngineExtensions
    {
        public static bool HasLanguageEnabled(this Engine engine, string language)
        {
            return engine.Languages.Any(x => x.LanguageId == language);
        }
    }
}
