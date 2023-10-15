#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TranslationPro.Base.Common.Data.Contexts;
using TranslationPro.Base.Common.Data.Interfaces;

namespace TranslationPro.Base.Common.Data.Factories
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