#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TemplateBase.Common.Data.Interfaces
{
    public interface IDataContext : IDisposable
    {
        DatabaseFacade DatabaseFacade { get; }
        object GetKey<TEntity>(TEntity entity);
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, IObjectState;
        void SyncObjectsStatePostCommit();
    }
}