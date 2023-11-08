#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Languages.Services;
using TranslationPro.Base.Permissions.Interfaces;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Permissions.Services;

public class PermissionService : BaseService, IPermissionService
{
    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(PermissionService)}.{callerName}] - {message}";
    }
    private readonly IRepositoryAsync<User> _userRepository;

    public PermissionService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _userRepository = UnitOfWork.RepositoryAsync<User>();
    }

    private IQueryable<User> Users => _userRepository.Queryable().Include(x => x.Applications);

    public async Task<bool> UserCanAccessApplication(int userId, Guid applicationId)
    {
        var user = await Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

        return user != null && user.Applications.Any(x => x.ApplicationId == applicationId);
    }
}