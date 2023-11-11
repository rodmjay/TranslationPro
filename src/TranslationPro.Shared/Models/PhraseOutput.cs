#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using System.Linq;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Shared.Models;

public class PhraseWithTranslation : PhraseOutput
{
    private Dictionary<string, string> _dictionary = new Dictionary<string, string>();
    public PhraseWithTranslation()
    {

    }

    public List<HumanTranslationOutput> HumanTranslations { get; set; }
    public List<MachineTranslationOutput> MachineTranslations { get; set; }

    public Dictionary<string, string> Translations
    {
        get
        {
            _dictionary = MachineTranslations.GroupBy(x => x.LanguageId)
                .ToDictionary(x => x.Key, x => x.First().Text);

            return _dictionary;
        }
    }

}

public class PhraseOutput : IPhrase
{
    public int TranslationCount { get; set; }
    public int PendingTranslationCount { get; set; }
    public int Id { get; set; }
    public string Text { get; set; }
}