using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Common.Middleware.Builders;
using TranslationPro.Base.Languages.Interfaces;
using TranslationPro.Base.Languages.Services;

namespace TranslationPro.Base.Languages.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddLanguageDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddScoped<ILanguageService, LanguageService>();

            return builder;
        }
    }
}
