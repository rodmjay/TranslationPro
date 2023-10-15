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
using TemplateBase.Common.Data.Interfaces;
using TemplateBase.Common.Services.Bases;
using TemplateBase.Users.Entities;
using TemplateBase.Users.Interfaces;

namespace TemplateBase.Users.Services
{
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
            if (id.Equals(default(int))) return null;
            return id.ToString();
        }

        public virtual int ConvertIdFromString(string id)
        {
            if (id == null) return default(int);
            return (int) TypeDescriptor.GetConverter(typeof(int)).ConvertFromInvariantString(id);
        }
    }
}