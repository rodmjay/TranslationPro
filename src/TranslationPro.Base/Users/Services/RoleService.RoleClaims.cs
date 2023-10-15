#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Users.Services
{
    public partial class RoleService
    {
        public IQueryable<RoleClaim> RoleClaims => _roleClaimRepository.Queryable();

        public async Task<IList<Claim>> GetClaimsAsync(Role role,
            CancellationToken cancellationToken = new())
        {
            ThrowIfDisposed();
            if (role == null) throw new ArgumentNullException(nameof(role));

            return await RoleClaims
                .Where(rc => rc.RoleId.Equals(role.Id)).Select(c => new Claim(c.ClaimType, c.ClaimValue))
                .ToListAsync(cancellationToken);
        }

        public Task AddClaimAsync(Role role, Claim claim, CancellationToken cancellationToken = new())
        {
            throw new NotImplementedException();
        }

        public async Task RemoveClaimAsync(Role role, Claim claim,
            CancellationToken cancellationToken = new())
        {
            ThrowIfDisposed();
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (claim == null) throw new ArgumentNullException(nameof(claim));
            var claims = await RoleClaims
                .Where(rc => rc.RoleId.Equals(role.Id) && rc.ClaimValue == claim.Value && rc.ClaimType == claim.Type)
                .ToListAsync(cancellationToken);
            foreach (var c in claims) _roleClaimRepository.Delete(c);
        }

        protected virtual RoleClaim CreateRoleClaim(Role role, Claim claim)
        {
            return new() {RoleId = role.Id, ClaimType = claim.Type, ClaimValue = claim.Value};
        }
    }
}