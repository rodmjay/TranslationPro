#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

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