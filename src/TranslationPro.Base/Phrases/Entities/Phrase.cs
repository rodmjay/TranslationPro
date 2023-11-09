#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Phrases.Entities;

public class Phrase : BaseEntity<Phrase>, IPhrase
{
    public int Id { get; set; }

    public string Text { get; set; }

    public ICollection<ApplicationPhrase> Applications { get; set; }
    public ICollection<MachineTranslation> Translations { get; set; }

    public override void Configure(EntityTypeBuilder<Phrase> builder)
    {
        builder.HasKey(x => x.Id);

    }
}