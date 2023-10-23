using TranslationPro.Base.Common.Middleware.Builders;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;
using TranslationPro.Base.Translations.Services;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Base.Phrases.Services;

namespace TranslationPro.Base.Translations.Extensions
{

    public static class AppBuilderExtensions
    {
        public static AppBuilder AddTranslationDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddTransient<TranslationErrorDescriber>();
            builder.Services.TryAddScoped<ITranslationService, TranslationService>();

            return builder;
        }
    }
}
