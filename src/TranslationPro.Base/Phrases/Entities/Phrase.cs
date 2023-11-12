#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Stripe.Interfaces;
using TranslationPro.Base.Translations.Entities;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Base.Phrases.Entities;

public class Phrase : BaseEntity<Phrase>, IPhrase, ISoftDelete, ICreated
{
    public Phrase()
    {
        MachineTranslations = new List<MachineTranslation>();
    }

    public int Id { get; set; }
    public string Text { get; set; }
    public DateTimeOffset Created { get; set; }

    public ICollection<ApplicationPhrase> Applications { get; set; }
    public ICollection<MachineTranslation> MachineTranslations { get; set; }

    public override void Configure(EntityTypeBuilder<Phrase> builder)
    {
        builder.ToTable(nameof(Phrase), "TranslationPro");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn(1);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }

    public bool IsDeleted { get; set; }
}