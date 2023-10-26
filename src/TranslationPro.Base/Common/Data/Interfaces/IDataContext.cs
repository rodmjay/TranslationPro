#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface IDataContext : IDisposable
{
    DatabaseFacade DatabaseFacade { get; }
    object GetKey<TEntity>(TEntity entity);
    int SaveChanges();
    void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState;
    void SyncObjectsStatePostCommit();
}