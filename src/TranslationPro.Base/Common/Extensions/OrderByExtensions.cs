#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Linq;
using TranslationPro.Base.Common.Models;

namespace TranslationPro.Base.Common.Extensions;

public static class OrderByExtensions
{
    public static IQueryable<TSource> OrderBy<TSource>(
        this IQueryable<TSource> queryable,
        string sorts)
    {
        if (string.IsNullOrWhiteSpace(sorts))
            return queryable;

        var sort = new SortCollection<TSource>(sorts);
        return sort.Apply(queryable);
    }

    public static IQueryable<TSource> OrderBy<TSource>(
        this IQueryable<TSource> queryable,
        params string[] sorts)
    {
        var sort = new SortCollection<TSource>(sorts);
        return sort.Apply(queryable);
    }

    public static IQueryable<TSource> OrderBy<TSource>(
        this IQueryable<TSource> queryable,
        string sorts,
        out SortCollection<TSource> sortCollection)
    {
        sortCollection = new SortCollection<TSource>(sorts);
        return sortCollection.Apply(queryable);
    }
}