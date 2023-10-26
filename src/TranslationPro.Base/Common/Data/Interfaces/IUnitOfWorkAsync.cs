#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Threading;
using System.Threading.Tasks;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface IUnitOfWorkAsync : IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : class, IObjectState;
}