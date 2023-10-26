#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Microsoft.EntityFrameworkCore.Design;
using TranslationPro.Base.Common.Data.Contexts;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface IApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
}