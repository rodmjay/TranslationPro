using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationPro.Base.Common.Middleware.Builders;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TranslationPro.Base.Translations.Interfaces;
using TranslationPro.Base.Translations.Models;
using TranslationPro.Base.Translations.Services;


namespace TranslationPro.Base.Translations.Extensions
{
    public static class AppBuilderExtensions
    {
        public static AppBuilder AddTranslationDependencies(this AppBuilder builder)
        {
            builder.Services.TryAddTransient<TranslationErrorDescriber>();
            builder.Services.TryAddScoped<ITranslationService, TranslationService>();
            builder.Services.TryAddScoped<IPhraseService, PhraseService>();

            return builder;
        }
    }
}
