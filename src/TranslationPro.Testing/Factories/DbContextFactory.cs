﻿#region Header

// /*
// Copyright (c) 2022 Rational Alliance. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TranslationPro.Base.Common.Data.Contexts;

namespace TranslationPro.Testing.Factories;

[ExcludeFromCodeCoverage]
public static class DbContextFactory
{
    public static DbContextOptions<ApplicationContext> CreateContextOptions(IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("DefaultConnection");
        var opts = new DbContextOptionsBuilder<ApplicationContext>();
        opts.UseSqlServer(connString,
            provider => provider.EnableRetryOnFailure());
        opts.EnableSensitiveDataLogging();

        return opts.Options;
    }
}