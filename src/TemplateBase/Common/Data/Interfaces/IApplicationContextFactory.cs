#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using Microsoft.EntityFrameworkCore.Design;
using TemplateBase.Common.Data.Contexts;

namespace TemplateBase.Common.Data.Interfaces
{
    public interface IApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
    }
}