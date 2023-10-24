#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.EntityFrameworkCore.Design;
using TranslationPro.Base.Common.Data.Contexts;

namespace TranslationPro.Base.Common.Data.Interfaces;

public interface IApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
}