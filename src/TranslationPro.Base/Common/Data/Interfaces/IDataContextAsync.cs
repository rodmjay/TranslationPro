#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Threading;
using System.Threading.Tasks;

namespace TranslationPro.Base.Common.Data.Interfaces
{
    public interface IDataContextAsync : IDataContext
    {
        //Task BeginTransactionAsync(DbIsolationLevel isolationLevel);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
        Task SyncObjectsStatePostCommitAsync();
        Task<int> ExecuteSqlAsync(string query, params object[] parameters);
    }
}