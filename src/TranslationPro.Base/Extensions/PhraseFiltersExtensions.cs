#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq.Expressions;
using TranslationPro.Base.Common.Queries;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Filters;

namespace TranslationPro.Base.Extensions;

public static class PhraseFiltersExtensions
{
    public static Expression<Func<ApplicationPhrase, bool>> GetExpression(this PhraseFilters query)
    {
        var expr = PredicateBuilder.True<ApplicationPhrase>();

        if (query.ContainsText != null)
            expr = expr.And(x => x.Text.Contains(query.ContainsText));

        if (query.Id != null)
            expr = expr.And(x => x.Id == query.Id.Value);

        return expr;
    }
}