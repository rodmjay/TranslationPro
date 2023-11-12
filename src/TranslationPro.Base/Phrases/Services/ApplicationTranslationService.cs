using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Applications.Entities;
using TranslationPro.Base.Applications.Extensions;
using TranslationPro.Base.Common.Data.Enums;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Phrases.Entities;
using TranslationPro.Base.Phrases.Interfaces;
using TranslationPro.Shared.Common;

namespace TranslationPro.Base.Phrases.Services;

public class ApplicationTranslationService : BaseService<ApplicationTranslation>, IApplicationTranslationService
{
    private readonly IRepositoryAsync<ApplicationPhrase> _applicationPhraseRepository;
    private readonly IRepositoryAsync<Application> _applicationRepository;

    public ApplicationTranslationService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _applicationPhraseRepository = UnitOfWork.RepositoryAsync<ApplicationPhrase>();
        _applicationRepository = UnitOfWork.RepositoryAsync<Application>();
    }

    private IQueryable<Application> Applications => _applicationRepository.Queryable().Include(x => x.Languages);

    private IQueryable<ApplicationPhrase> ApplicationPhrases => _applicationPhraseRepository.Queryable()
        .Include(x=>x.Translations)
        .Include(x=>x.Phrase).ThenInclude(x=>x.MachineTranslations);

    public async Task<Result> CopyTranslationFromPhraseList(Guid applicationId, int phraseId)
    {
        var application = await Applications.Where(x => x.Id == applicationId).FirstAsync();

        var applicationPhrase = await ApplicationPhrases.Where(x=>x.ApplicationId == applicationId && x.Id == phraseId)
            .FirstOrDefaultAsync();

        if (applicationPhrase == null)
        {
            return Result.Failed();
        }

        foreach (var language in application.EnabledLanguages())
        {
            var machineTranslation = applicationPhrase.Phrase.MachineTranslations.FirstOrDefault(x => x.LanguageId == language);

            if (machineTranslation != null)
            {
                if (applicationPhrase.Translations.All(x => x.LanguageId != language))
                {
                    applicationPhrase.Translations.Add(new ApplicationTranslation()
                    {
                        Text = machineTranslation.Text,
                        LanguageId = language,
                        ObjectState = ObjectState.Added
                    });
                }

                applicationPhrase.ObjectState = ObjectState.Modified;
            }

        }

        if (applicationPhrase.ObjectState == ObjectState.Modified)
        {
            var records = _applicationPhraseRepository.Update(applicationPhrase, true);
            if (records > 0)
            {
                return Result.Success(phraseId);
            }
        }
        else
        {
            return Result.Success(phraseId);
        }


        return Result.Failed();

    }

    public async Task<Result> CopyTranslationsFromLanguage(Guid applicationId, string languageId)
    {
        var applicationPhrases = await ApplicationPhrases.Where(x => x.ApplicationId == applicationId)
            .ToListAsync();

        foreach (var phrase in applicationPhrases)
        {
            await CopyTranslationFromPhraseList(applicationId, phrase.Id);
        }

        return Result.Success();
    }
}