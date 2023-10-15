#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Linq.Expressions;
using TemplateBase.Common.Queries;
using TemplateBase.Geography.Entities;
using TemplateBase.Geography.Models;

namespace TemplateBase.Geography.Extensions
{
    public static class CountryQueryExtensions
    {
        public static Expression<Func<Country, bool>> GetExpression(this CountryQuery query)
        {
            var expr = PredicateBuilder.True<Country>();

            if (query.Enabled is true)
                expr = expr.And(x => x.EnabledCountry != null);

            if (query.Enabled is false)
                expr = expr.And(x => x.EnabledCountry == null);

            return expr;
        }
    }
}