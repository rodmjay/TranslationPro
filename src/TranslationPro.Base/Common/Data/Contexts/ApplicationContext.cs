#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranslationPro.Base.Common.Data.Bases;
using TranslationPro.Base.Languages.Entities;
using TranslationPro.Base.Seeding.Extensions;
using TranslationPro.Base.Users.Entities;
namespace TranslationPro.Base.Common.Data.Contexts;

public class ApplicationContext : BaseContext<ApplicationContext>, IConfigurationDbContext, IPersistedGrantDbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public ApplicationContext(
        DbContextOptions<ApplicationContext> options, ILoggerFactory loggerFactory) :
        base(options)
    {
        _loggerFactory = loggerFactory;
    }


    public ApplicationContext(
        DbContextOptions<ApplicationContext> options) : this(options, null)
    {
    }

    public DbSet<Client> Clients { get; set; }

    public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }

    public DbSet<IdentityResource> IdentityResources { get; set; }

    public DbSet<ApiResource> ApiResources { get; set; }

    public DbSet<ApiScope> ApiScopes { get; set; }
    public DbSet<IdentityProvider> IdentityProviders { get; set; }

    public DbSet<PersistedGrant> PersistedGrants { get; set; }

    public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
    public DbSet<Key> Keys { get; set; }
    public DbSet<ServerSideSession> ServerSideSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_loggerFactory != null) optionsBuilder.UseLoggerFactory(_loggerFactory);
    }

    protected override void ConfigureDatabase(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        var configurationOptions = new ConfigurationStoreOptions
        {
            Client = new TableConfiguration(nameof(Client), "IdentityServer"),
            ApiResource = new TableConfiguration(nameof(ApiResource), "IdentityServer"),
            ApiResourceClaim = new TableConfiguration(nameof(ApiResourceClaim), "IdentityServer"),
            ApiResourceProperty = new TableConfiguration(nameof(ApiResourceProperty), "IdentityServer"),
            ApiResourceScope = new TableConfiguration(nameof(ApiResourceScope), "IdentityServer"),
            ApiResourceSecret = new TableConfiguration(nameof(ApiResourceSecret), "IdentityServer"),
            ApiScope = new TableConfiguration(nameof(ApiScope), "IdentityServer"),
            ApiScopeClaim = new TableConfiguration(nameof(ApiScopeClaim), "IdentityServer"),
            ApiScopeProperty = new TableConfiguration(nameof(ApiScopeProperty), "IdentityServer"),
            IdentityResource = new TableConfiguration(nameof(IdentityResource), "IdentityServer"),
            ClientClaim = new TableConfiguration(nameof(ClientClaim), "IdentityServer"),
            ClientCorsOrigin = new TableConfiguration(nameof(ClientCorsOrigin), "IdentityServer"),
            ClientGrantType = new TableConfiguration(nameof(ClientGrantType), "IdentityServer"),
            ClientIdPRestriction = new TableConfiguration(nameof(ClientIdPRestriction), "IdentityServer"),
            ClientPostLogoutRedirectUri =
                new TableConfiguration(nameof(ClientPostLogoutRedirectUri), "IdentityServer"),
            ClientProperty = new TableConfiguration(nameof(ClientProperty), "IdentityServer"),
            ClientRedirectUri = new TableConfiguration(nameof(ClientRedirectUri), "IdentityServer"),
            ClientScopes = new TableConfiguration("ClientScopes", "IdentityServer"),
            ClientSecret = new TableConfiguration(nameof(ClientSecret), "IdentityServer"),
            IdentityResourceClaim = new TableConfiguration(nameof(IdentityResourceClaim), "IdentityServer"),
            IdentityResourceProperty = new TableConfiguration(nameof(IdentityResourceProperty), "IdentityServer")
        };
        var operationalStoreOptions = new OperationalStoreOptions
        {
            DeviceFlowCodes = new TableConfiguration(nameof(DeviceFlowCodes), "IdentityServer"),
            PersistedGrants = new TableConfiguration(nameof(PersistedGrants), "IdentityServer")
        };

        builder.ConfigureClientContext(configurationOptions);
        builder.ConfigureResourcesContext(configurationOptions);
        builder.ConfigurePersistedGrantContext(operationalStoreOptions);
    }

    private void SeedIdentityServer(ModelBuilder builder)
    {
        builder.Entity<Client>()
            .Seed("clients.csv");
        builder.Entity<ApiScope>()
            .Seed("apiScopes.csv");
        builder.Entity<ClientGrantType>()
            .Seed("clientGrantTypes.csv");
        builder.Entity<ClientPostLogoutRedirectUri>()
            .Seed("clientPostLogoutRedirectUris.csv");
        builder.Entity<ClientRedirectUri>()
            .Seed("clientRedirectUris.csv");
        builder.Entity<ClientScope>()
            .Seed("clientScopes.csv");
        builder.Entity<ClientSecret>()
            .Seed("clientSecrets.csv");
        builder.Entity<ClientCorsOrigin>()
            .Seed("clientCorsOrigins.csv");
        builder.Entity<IdentityResource>()
            .Seed("identityResources.csv");
        builder.Entity<IdentityResourceClaim>()
            .Seed("identityResourceClaims.csv");
    }

    private void SeedUsersAndRoles(ModelBuilder builder)
    {
        builder.Entity<User>().Seed("users.csv");
        builder.Entity<Role>().Seed("roles.csv");
        builder.Entity<UserRole>().Seed("userRoles.csv");
    }


    private void SeedLanguages(ModelBuilder builder)
    {
        builder.Entity<Language>().Seed("languages.csv");
    }

    protected override void SeedDatabase(ModelBuilder builder)
    {
        // these should be placed in the Seeding/csv folder for it to work
        // make sure files are marked as "EmbeddedResource => Copy if newer"

        SeedIdentityServer(builder);
        SeedLanguages(builder);
        SeedUsersAndRoles(builder);
    }
}