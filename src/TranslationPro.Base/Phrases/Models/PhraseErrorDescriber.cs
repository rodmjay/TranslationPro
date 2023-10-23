using TranslationPro.Base.Common.Models;

namespace TranslationPro.Base.Phrases.Models;

public class PhraseErrorDescriber
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

    public virtual Error UnableToCreatePhrase()
    {
        return new()
        {
            Code = nameof(UnableToCreatePhrase),
            Description = $"Unable to create phrase"
        };
    }

    public virtual Error UnableToUpdatePhrase(int id)
    {
        return new()
        {
            Code = nameof(UnableToUpdatePhrase),
            Description = $"Unable to update phrase '{id}'"
        };
    }
}