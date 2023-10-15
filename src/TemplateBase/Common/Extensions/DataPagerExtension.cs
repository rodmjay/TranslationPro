#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TemplateBase.Common.Data.Interfaces;
using TemplateBase.Common.Models;
using TemplateBase.Common.Queries;
using TemplateBase.Common.Services.Interfaces;

namespace TemplateBase.Common.Extensions
{
    public static class DataPagerExtension
    {
        public static async Task<PagedList<TOutput>> PaginateAsync<TEntity, TOutput>(
            this IService<TEntity> service,
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, bool>> query,
            PagingQuery paging)
            where TEntity : class, IObjectState
        {
            var combinedExpr = PredicateBuilder.True<TEntity>();

            combinedExpr = combinedExpr.And(filter);
            combinedExpr = combinedExpr.And(query);

            return await PaginateAsync<TEntity, TOutput>(service, combinedExpr, paging);
        }

        public static async Task<PagedList<TOutput>> PaginateAsync<TEntity, TOutput>(
            this IService<TEntity> service,
            Expression<Func<TEntity, bool>> filter,
            PagingQuery paging)
            where TEntity : class, IObjectState
        {
            var paged = new PagedList<TOutput>();

            paging.Page = paging.Page <= 0 ? 1 : paging.Page;
            paging.Size = paging.Size > 0 ? paging.Size : 10;

            paged.CurrentPage = paging.Page;
            paged.PageSize = paging.Size;

            var totalCount = await service.Repository.Queryable()
                .Where(filter)
                .CountAsync();

            var startRow = (paging.Page - 1) * paging.Size;

            paged.Items = await service.Repository.Queryable()
                .Where(filter)
                .OrderBy(paging.Sort)
                .ProjectTo<TOutput>(service.ProjectionMapping)
                .Skip(startRow)
                .Take(paging.Size)
                .ToListAsync();


            paged.TotalItems = totalCount;
            paged.TotalPages = (int) Math.Ceiling(paged.TotalItems / (double) paging.Size);

            return paged;
        }
    }
}