#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using TranslationPro.Base.Common.Data.Enums;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    event EventHandler OnSaveChanges;
    int SaveChanges();
    void Dispose(bool disposing);
    IRepository<TEntity> Repository<TEntity>() where TEntity : class, IObjectState;
    void BeginTransaction(DbIsolationLevel isolationLevel = DbIsolationLevel.Unspecified);
    bool Commit();
    void Rollback();
}