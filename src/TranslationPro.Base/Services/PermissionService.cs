#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Interfaces;
using TranslationPro.Base.Common.Services.Bases;
using TranslationPro.Base.Interfaces;
using TranslationPro.Base.Users.Entities;

namespace TranslationPro.Base.Services;

public class PermissionService : BaseService, IPermissionService
{
    private readonly ILogger<PermissionService> _logger;

    private static string GetLogMessage(string message, [CallerMemberName] string callerName = null)
    {
        return $"[{nameof(PermissionService)}.{callerName}] - {message}";
    }
    private readonly IRepositoryAsync<User> _userRepository;

    public PermissionService(IServiceProvider serviceProvider, ILogger<PermissionService> logger) : base(serviceProvider)
    {
        _logger = logger;
        _userRepository = UnitOfWork.RepositoryAsync<User>();
    }

    private IQueryable<User> Users => _userRepository.Queryable().Include(x => x.Applications);

    public async Task<bool> UserCanAccessApplication(int userId, Guid applicationId)
    {
        var retVal = false;
        var user = await Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
        retVal = user != null && user.Applications.Any(x => x.ApplicationId == applicationId);

        _logger.LogInformation(GetLogMessage("User: {0} Has Permissions: {1} For Application: {2}"), userId, retVal, applicationId);

        return retVal;
    }
}