#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TemplateBase.Common.Data.Contexts;
using TemplateBase.Common.Data.Interfaces;

namespace TemplateBase.Common.Data.Factories
{
    public class OperationalContextFactory : IApplicationContextFactory
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            // Used only for EF .NET Core CLI tools (update database/migrations etc.)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("sharedSettings.json", false, true);

            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>()
                .EnableSensitiveDataLogging()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}