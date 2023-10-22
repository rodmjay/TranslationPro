using TranslationPro.Base.Common.Models;

namespace TranslationPro.Base.Translations.Models;

public class TranslationErrorDescriber
{
    public virtual Error PhraseDoesntExist(int id)
    {
        return new()
        {
            Code = nameof(PhraseDoesntExist),
            Description = $"Phrase '{id}' doesn't exist"
        };
    }

    public virtual Error UnableToDeletePhrase(int id)
    {
        return new()
        {
            Code = nameof(UnableToDeletePhrase),
            Description = $"Unable to delete phrase '{id}'"
        };
    }
}