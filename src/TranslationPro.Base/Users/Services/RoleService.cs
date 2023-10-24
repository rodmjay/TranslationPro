#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Users.Entities;
using TranslationPro.Base.Users.Interfaces;

namespace TranslationPro.Base.Users.Services;

public partial class RoleService : BaseService<Role>, IRoleService
{
    private readonly IdentityErrorDescriber _errors;

    private readonly IRepositoryAsync<RoleClaim> _roleClaimRepository;
    private bool _disposed;

    public RoleService(
        IdentityErrorDescriber _errors,
        IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _roleClaimRepository = UnitOfWork.RepositoryAsync<RoleClaim>();
        this._errors = _errors;
    }

    public bool AutoSaveChanges { get; set; } = true;
    public IQueryable<Role> Roles => Repository.Queryable();

    public void Dispose()
    {
        _disposed = true;
    }

    private Task SaveChanges(CancellationToken cancellationToken)
    {
        if (AutoSaveChanges)
        {
            var changes = Repository.Commit();
        }

        return Task.CompletedTask;
    }

    protected void ThrowIfDisposed()
    {
        if (_disposed) throw new ObjectDisposedException(GetType().Name);
    }

    public virtual string ConvertIdToString(int id)
    {
        if (id.Equals(default)) return null;
        return id.ToString();
    }

    public virtual int ConvertIdFromString(string id)
    {
        if (id == null) return default;
        return (int) TypeDescriptor.GetConverter(typeof(int)).ConvertFromInvariantString(id);
    }
}