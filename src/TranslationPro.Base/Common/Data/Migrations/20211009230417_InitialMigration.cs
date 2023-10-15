using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TranslationPro.Base.Common.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "IdentityServer");

            migrationBuilder.CreateTable(
                name: "ApiResource",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AllowedAccessTokenSigningAlgorithms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiScope",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Emphasize = table.Column<bool>(type: "bit", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(type: "bit", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(type: "bit", nullable: false),
                    AllowRememberConsent = table.Column<bool>(type: "bit", nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(type: "bit", nullable: false),
                    RequirePkce = table.Column<bool>(type: "bit", nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(type: "bit", nullable: false),
                    RequireRequestObject = table.Column<bool>(type: "bit", nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(type: "bit", nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(type: "bit", nullable: false),
                    BackChannelLogoutUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(type: "bit", nullable: false),
                    AllowOfflineAccess = table.Column<bool>(type: "bit", nullable: false),
                    IdentityTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    AllowedIdentityTokenSigningAlgorithms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccessTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(type: "int", nullable: false),
                    ConsentLifetime = table.Column<int>(type: "int", nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(type: "int", nullable: false),
                    RefreshTokenUsage = table.Column<int>(type: "int", nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(type: "bit", nullable: false),
                    RefreshTokenExpiration = table.Column<int>(type: "int", nullable: false),
                    AccessTokenType = table.Column<int>(type: "int", nullable: false),
                    EnableLocalLogin = table.Column<bool>(type: "bit", nullable: false),
                    IncludeJwtId = table.Column<bool>(type: "bit", nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(type: "bit", nullable: false),
                    ClientClaimsPrefix = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserSsoLifetime = table.Column<int>(type: "int", nullable: true),
                    UserCodeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(type: "int", nullable: false),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Iso2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CapsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    NumberCode = table.Column<int>(type: "int", nullable: true),
                    PhoneCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Iso2);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Decimals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DeviceFlowCodes",
                schema: "IdentityServer",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceFlowCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResource",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Emphasize = table.Column<bool>(type: "bit", nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Code3 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Code3);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                schema: "IdentityServer",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timezone",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timezone", x => new { x.Name, x.Code });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceClaim",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceClaim_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceProperty",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceProperty_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceScope",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceScope", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceScope_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiResourceSecret",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiResourceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResourceSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiResourceSecret_ApiResource_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeClaim",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScopeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiScopeClaim_ApiScope_ScopeId",
                        column: x => x.ScopeId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiScopeProperty",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScopeId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiScopeProperty_ApiScope_ScopeId",
                        column: x => x.ScopeId,
                        principalSchema: "IdentityServer",
                        principalTable: "ApiScope",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientClaim",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientClaim_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCorsOrigin",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCorsOrigin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCorsOrigin_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientGrantType",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrantType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGrantType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientGrantType_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientIdPRestriction",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdPRestriction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientIdPRestriction_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPostLogoutRedirectUri",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostLogoutRedirectUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPostLogoutRedirectUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPostLogoutRedirectUri_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientProperty",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientProperty_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientRedirectUri",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRedirectUri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientRedirectUri_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientScopes",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientScopes_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSecret",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecret", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSecret_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "IdentityServer",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnabledCountry",
                columns: table => new
                {
                    Iso2 = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnabledCountry", x => x.Iso2);
                    table.ForeignKey(
                        name: "FK_EnabledCountry_Country_Iso2",
                        column: x => x.Iso2,
                        principalTable: "Country",
                        principalColumn: "Iso2",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iso2 = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbrev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateProvince_Country_Iso2",
                        column: x => x.Iso2,
                        principalTable: "Country",
                        principalColumn: "Iso2",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceClaim",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityResourceId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResourceClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResourceClaim_IdentityResource_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "IdentityResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityResourceProperty",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityResourceId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResourceProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityResourceProperty_IdentityResource_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalSchema: "IdentityServer",
                        principalTable: "IdentityResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageCountry",
                columns: table => new
                {
                    Iso2 = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    Code3 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageCountry", x => new { x.Iso2, x.Code3 });
                    table.ForeignKey(
                        name: "FK_LanguageCountry_Country_Iso2",
                        column: x => x.Iso2,
                        principalTable: "Country",
                        principalColumn: "Iso2",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageCountry_Language_Code3",
                        column: x => x.Code3,
                        principalTable: "Language",
                        principalColumn: "Code3",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.UserId, x.ProviderKey, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "LB", "LEBANON", "LBN", "Lebanon", 422, 961 },
                    { "IT", "ITALY", "ITA", "Italy", 380, 39 },
                    { "IL", "ISRAEL", "ISR", "Israel", 376, 972 },
                    { "IE", "IRELAND", "IRL", "Ireland", 372, 353 },
                    { "IQ", "IRAQ", "IRQ", "Iraq", 368, 964 },
                    { "IR", "IRAN, ISLAMIC REPUBLIC OF", "IRN", "Iran, Islamic Republic of", 364, 98 },
                    { "ID", "INDONESIA", "IDN", "Indonesia", 360, 62 },
                    { "IN", "INDIA", "IND", "India", 356, 91 },
                    { "IS", "ICELAND", "ISL", "Iceland", 352, 354 },
                    { "HU", "HUNGARY", "HUN", "Hungary", 348, 36 },
                    { "HK", "HONG KONG", "HKG", "Hong Kong", 344, 852 },
                    { "JM", "JAMAICA", "JAM", "Jamaica", 388, 1876 },
                    { "HN", "HONDURAS", "HND", "Honduras", 340, 504 },
                    { "HM", "HEARD ISLAND AND MCDONALD ISLANDS", "", "Heard Island and Mcdonald Islands", null, 0 },
                    { "HT", "HAITI", "HTI", "Haiti", 332, 509 },
                    { "GY", "GUYANA", "GUY", "Guyana", 328, 592 },
                    { "GW", "GUINEA-BISSAU", "GNB", "Guinea-Bissau", 624, 245 },
                    { "GN", "GUINEA", "GIN", "Guinea", 324, 224 },
                    { "GT", "GUATEMALA", "GTM", "Guatemala", 320, 502 },
                    { "GU", "GUAM", "GUM", "Guam", 316, 1671 },
                    { "GP", "GUADELOUPE", "GLP", "Guadeloupe", 312, 590 },
                    { "GD", "GRENADA", "GRD", "Grenada", 308, 1473 },
                    { "GL", "GREENLAND", "GRL", "Greenland", 304, 299 },
                    { "VA", "HOLY SEE (VATICAN CITY STATE)", "VAT", "Holy See (Vatican City State)", 336, 39 },
                    { "JP", "JAPAN", "JPN", "Japan", 392, 81 },
                    { "JO", "JORDAN", "JOR", "Jordan", 400, 962 },
                    { "KZ", "KAZAKHSTAN", "KAZ", "Kazakhstan", 398, 7 },
                    { "MH", "MARSHALL ISLANDS", "MHL", "Marshall Islands", 584, 692 },
                    { "MT", "MALTA", "MLT", "Malta", 470, 356 },
                    { "ML", "MALI", "MLI", "Mali", 466, 223 },
                    { "MV", "MALDIVES", "MDV", "Maldives", 462, 960 },
                    { "MY", "MALAYSIA", "MYS", "Malaysia", 458, 60 },
                    { "MW", "MALAWI", "MWI", "Malawi", 454, 265 },
                    { "MG", "MADAGASCAR", "MDG", "Madagascar", 450, 261 },
                    { "MK", "MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF", "MKD", "Macedonia, the Former Yugoslav Republic of", 807, 389 },
                    { "MO", "MACAO", "MAC", "Macao", 446, 853 },
                    { "LU", "LUXEMBOURG", "LUX", "Luxembourg", 442, 352 },
                    { "LT", "LITHUANIA", "LTU", "Lithuania", 440, 370 },
                    { "LI", "LIECHTENSTEIN", "LIE", "Liechtenstein", 438, 423 },
                    { "LY", "LIBYAN ARAB JAMAHIRIYA", "LBY", "Libyan Arab Jamahiriya", 434, 218 },
                    { "LR", "LIBERIA", "LBR", "Liberia", 430, 231 },
                    { "LS", "LESOTHO", "LSO", "Lesotho", 426, 266 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "LV", "LATVIA", "LVA", "Latvia", 428, 371 },
                    { "LA", "LAO PEOPLE'S DEMOCRATIC REPUBLIC", "LAO", "Lao People's Democratic Republic", 418, 856 },
                    { "KG", "KYRGYZSTAN", "KGZ", "Kyrgyzstan", 417, 996 },
                    { "KW", "KUWAIT", "KWT", "Kuwait", 414, 965 },
                    { "KR", "KOREA, REPUBLIC OF", "KOR", "Korea, Republic of", 410, 82 },
                    { "KP", "KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF", "PRK", "Korea, Democratic People's Republic of", 408, 850 },
                    { "KI", "KIRIBATI", "KIR", "Kiribati", 296, 686 },
                    { "KE", "KENYA", "KEN", "Kenya", 404, 254 },
                    { "GR", "GREECE", "GRC", "Greece", 300, 30 },
                    { "MQ", "MARTINIQUE", "MTQ", "Martinique", 474, 596 },
                    { "GI", "GIBRALTAR", "GIB", "Gibraltar", 292, 350 },
                    { "DE", "GERMANY", "DEU", "Germany", 276, 49 },
                    { "CK", "COOK ISLANDS", "COK", "Cook Islands", 184, 682 },
                    { "CD", "CONGO, THE DEMOCRATIC REPUBLIC OF THE", "COD", "Congo, the Democratic Republic of the", 180, 242 },
                    { "CG", "CONGO", "COG", "Congo", 178, 242 },
                    { "KM", "COMOROS", "COM", "Comoros", 174, 269 },
                    { "CO", "COLOMBIA", "COL", "Colombia", 170, 57 },
                    { "CC", "COCOS (KEELING) ISLANDS", "", "Cocos (Keeling) Islands", null, 672 },
                    { "CX", "CHRISTMAS ISLAND", "", "Christmas Island", null, 61 },
                    { "CN", "CHINA", "CHN", "China", 156, 86 },
                    { "CL", "CHILE", "CHL", "Chile", 152, 56 },
                    { "TD", "CHAD", "TCD", "Chad", 148, 235 },
                    { "CR", "COSTA RICA", "CRI", "Costa Rica", 188, 506 },
                    { "CF", "CENTRAL AFRICAN REPUBLIC", "CAF", "Central African Republic", 140, 236 },
                    { "CV", "CAPE VERDE", "CPV", "Cape Verde", 132, 238 },
                    { "CA", "CANADA", "CAN", "Canada", 124, 1 },
                    { "CM", "CAMEROON", "CMR", "Cameroon", 120, 237 },
                    { "KH", "CAMBODIA", "KHM", "Cambodia", 116, 855 },
                    { "BI", "BURUNDI", "BDI", "Burundi", 108, 257 },
                    { "BF", "BURKINA FASO", "BFA", "Burkina Faso", 854, 226 },
                    { "BG", "BULGARIA", "BGR", "Bulgaria", 100, 359 },
                    { "BN", "BRUNEI DARUSSALAM", "BRN", "Brunei Darussalam", 96, 673 },
                    { "IO", "BRITISH INDIAN OCEAN TERRITORY", "", "British Indian Ocean Territory", null, 246 },
                    { "BR", "BRAZIL", "BRA", "Brazil", 76, 55 },
                    { "KY", "CAYMAN ISLANDS", "CYM", "Cayman Islands", 136, 1345 },
                    { "CI", "COTE D'IVOIRE", "CIV", "Cote D'Ivoire", 384, 225 },
                    { "HR", "CROATIA", "HRV", "Croatia", 191, 385 },
                    { "CU", "CUBA", "CUB", "Cuba", 192, 53 },
                    { "GE", "GEORGIA", "GEO", "Georgia", 268, 995 },
                    { "GM", "GAMBIA", "GMB", "Gambia", 270, 220 },
                    { "GA", "GABON", "GAB", "Gabon", 266, 241 },
                    { "TF", "FRENCH SOUTHERN TERRITORIES", "", "French Southern Territories", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "PF", "FRENCH POLYNESIA", "PYF", "French Polynesia", 258, 689 },
                    { "GF", "FRENCH GUIANA", "GUF", "French Guiana", 254, 594 },
                    { "FR", "FRANCE", "FRA", "France", 250, 33 },
                    { "FI", "FINLAND", "FIN", "Finland", 246, 358 },
                    { "FJ", "FIJI", "FJI", "Fiji", 242, 679 },
                    { "FK", "FALKLAND ISLANDS (MALVINAS)", "FLK", "Falkland Islands (Malvinas)", 238, 500 },
                    { "ET", "ETHIOPIA", "ETH", "Ethiopia", 231, 251 },
                    { "EE", "ESTONIA", "EST", "Estonia", 233, 372 },
                    { "ER", "ERITREA", "ERI", "Eritrea", 232, 291 },
                    { "GQ", "EQUATORIAL GUINEA", "GNQ", "Equatorial Guinea", 226, 240 },
                    { "SV", "EL SALVADOR", "SLV", "El Salvador", 222, 503 },
                    { "EG", "EGYPT", "EGY", "Egypt", 818, 20 },
                    { "EC", "ECUADOR", "ECU", "Ecuador", 218, 593 },
                    { "DO", "DOMINICAN REPUBLIC", "DOM", "Dominican Republic", 214, 1809 },
                    { "DM", "DOMINICA", "DMA", "Dominica", 212, 1767 },
                    { "DJ", "DJIBOUTI", "DJI", "Djibouti", 262, 253 },
                    { "DK", "DENMARK", "DNK", "Denmark", 208, 45 },
                    { "CZ", "CZECH REPUBLIC", "CZE", "Czech Republic", 203, 420 },
                    { "CY", "CYPRUS", "CYP", "Cyprus", 196, 357 },
                    { "GH", "GHANA", "GHA", "Ghana", 288, 233 },
                    { "BV", "BOUVET ISLAND", "", "Bouvet Island", null, 0 },
                    { "MR", "MAURITANIA", "MRT", "Mauritania", 478, 222 },
                    { "YT", "MAYOTTE", "", "Mayotte", null, 269 },
                    { "TL", "TIMOR-LESTE", "", "Timor-Leste", null, 670 },
                    { "TH", "THAILAND", "THA", "Thailand", 764, 66 },
                    { "TZ", "TANZANIA, UNITED REPUBLIC OF", "TZA", "Tanzania, United Republic of", 834, 255 },
                    { "TJ", "TAJIKISTAN", "TJK", "Tajikistan", 762, 992 },
                    { "TW", "TAIWAN, PROVINCE OF CHINA", "TWN", "Taiwan, Province of China", 158, 886 },
                    { "SY", "SYRIAN ARAB REPUBLIC", "SYR", "Syrian Arab Republic", 760, 963 },
                    { "CH", "SWITZERLAND", "CHE", "Switzerland", 756, 41 },
                    { "SE", "SWEDEN", "SWE", "Sweden", 752, 46 },
                    { "SZ", "SWAZILAND", "SWZ", "Swaziland", 748, 268 },
                    { "SJ", "SVALBARD AND JAN MAYEN", "SJM", "Svalbard and Jan Mayen", 744, 47 },
                    { "TG", "TOGO", "TGO", "Togo", 768, 228 },
                    { "SR", "SURINAME", "SUR", "Suriname", 740, 597 },
                    { "LK", "SRI LANKA", "LKA", "Sri Lanka", 144, 94 },
                    { "ES", "SPAIN", "ESP", "Spain", 724, 34 },
                    { "GS", "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS", "", "South Georgia and the South Sandwich Islands", null, 0 },
                    { "ZA", "SOUTH AFRICA", "ZAF", "South Africa", 710, 27 },
                    { "SO", "SOMALIA", "SOM", "Somalia", 706, 252 },
                    { "SB", "SOLOMON ISLANDS", "SLB", "Solomon Islands", 90, 677 },
                    { "SI", "SLOVENIA", "SVN", "Slovenia", 705, 386 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "SK", "SLOVAKIA", "SVK", "Slovakia", 703, 421 },
                    { "SG", "SINGAPORE", "SGP", "Singapore", 702, 65 },
                    { "SL", "SIERRA LEONE", "SLE", "Sierra Leone", 694, 232 },
                    { "SD", "SUDAN", "SDN", "Sudan", 736, 249 },
                    { "TK", "TOKELAU", "TKL", "Tokelau", 772, 690 },
                    { "TO", "TONGA", "TON", "Tonga", 776, 676 },
                    { "TT", "TRINIDAD AND TOBAGO", "TTO", "Trinidad and Tobago", 780, 1868 },
                    { "ZW", "ZIMBABWE", "ZWE", "Zimbabwe", 716, 263 },
                    { "ZM", "ZAMBIA", "ZMB", "Zambia", 894, 260 },
                    { "YE", "YEMEN", "YEM", "Yemen", 887, 967 },
                    { "EH", "WESTERN SAHARA", "ESH", "Western Sahara", 732, 212 },
                    { "WF", "WALLIS AND FUTUNA", "WLF", "Wallis and Futuna", 876, 681 },
                    { "VI", "VIRGIN ISLANDS, U.S.", "VIR", "Virgin Islands, U.s.", 850, 1340 },
                    { "VG", "VIRGIN ISLANDS, BRITISH", "VGB", "Virgin Islands, British", 92, 1284 },
                    { "VN", "VIET NAM", "VNM", "Viet Nam", 704, 84 },
                    { "VE", "VENEZUELA", "VEN", "Venezuela", 862, 58 },
                    { "VU", "VANUATU", "VUT", "Vanuatu", 548, 678 },
                    { "UZ", "UZBEKISTAN", "UZB", "Uzbekistan", 860, 998 },
                    { "UY", "URUGUAY", "URY", "Uruguay", 858, 598 },
                    { "UM", "UNITED STATES MINOR OUTLYING ISLANDS", "", "United States Minor Outlying Islands", null, 1 },
                    { "US", "UNITED STATES", "USA", "United States", 840, 1 },
                    { "GB", "UNITED KINGDOM", "GBR", "United Kingdom", 826, 44 },
                    { "AE", "UNITED ARAB EMIRATES", "ARE", "United Arab Emirates", 784, 971 },
                    { "UA", "UKRAINE", "UKR", "Ukraine", 804, 380 },
                    { "UG", "UGANDA", "UGA", "Uganda", 800, 256 },
                    { "TV", "TUVALU", "TUV", "Tuvalu", 798, 688 },
                    { "TC", "TURKS AND CAICOS ISLANDS", "TCA", "Turks and Caicos Islands", 796, 1649 },
                    { "TM", "TURKMENISTAN", "TKM", "Turkmenistan", 795, 7370 },
                    { "TR", "TURKEY", "TUR", "Turkey", 792, 90 },
                    { "TN", "TUNISIA", "TUN", "Tunisia", 788, 216 },
                    { "SC", "SEYCHELLES", "SYC", "Seychelles", 690, 248 },
                    { "MU", "MAURITIUS", "MUS", "Mauritius", 480, 230 },
                    { "CS", "SERBIA AND MONTENEGRO", "", "Serbia and Montenegro", null, 381 },
                    { "SA", "SAUDI ARABIA", "SAU", "Saudi Arabia", 682, 966 },
                    { "MP", "NORTHERN MARIANA ISLANDS", "MNP", "Northern Mariana Islands", 580, 1670 },
                    { "NF", "NORFOLK ISLAND", "NFK", "Norfolk Island", 574, 672 },
                    { "NU", "NIUE", "NIU", "Niue", 570, 683 },
                    { "NG", "NIGERIA", "NGA", "Nigeria", 566, 234 },
                    { "NE", "NIGER", "NER", "Niger", 562, 227 },
                    { "NI", "NICARAGUA", "NIC", "Nicaragua", 558, 505 },
                    { "NZ", "NEW ZEALAND", "NZL", "New Zealand", 554, 64 },
                    { "NC", "NEW CALEDONIA", "NCL", "New Caledonia", 540, 687 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "AN", "NETHERLANDS ANTILLES", "ANT", "Netherlands Antilles", 530, 599 },
                    { "NL", "NETHERLANDS", "NLD", "Netherlands", 528, 31 },
                    { "NO", "NORWAY", "NOR", "Norway", 578, 47 },
                    { "NP", "NEPAL", "NPL", "Nepal", 524, 977 },
                    { "NA", "NAMIBIA", "NAM", "Namibia", 516, 264 },
                    { "MM", "MYANMAR", "MMR", "Myanmar", 104, 95 },
                    { "MZ", "MOZAMBIQUE", "MOZ", "Mozambique", 508, 258 },
                    { "MA", "MOROCCO", "MAR", "Morocco", 504, 212 },
                    { "MS", "MONTSERRAT", "MSR", "Montserrat", 500, 1664 },
                    { "MN", "MONGOLIA", "MNG", "Mongolia", 496, 976 },
                    { "MC", "MONACO", "MCO", "Monaco", 492, 377 },
                    { "MD", "MOLDOVA, REPUBLIC OF", "MDA", "Moldova, Republic of", 498, 373 },
                    { "FM", "MICRONESIA, FEDERATED STATES OF", "FSM", "Micronesia, Federated States of", 583, 691 },
                    { "MX", "MEXICO", "MEX", "Mexico", 484, 52 },
                    { "NR", "NAURU", "NRU", "Nauru", 520, 674 },
                    { "OM", "OMAN", "OMN", "Oman", 512, 968 },
                    { "PK", "PAKISTAN", "PAK", "Pakistan", 586, 92 },
                    { "PW", "PALAU", "PLW", "Palau", 585, 680 },
                    { "ST", "SAO TOME AND PRINCIPE", "STP", "Sao Tome and Principe", 678, 239 },
                    { "SM", "SAN MARINO", "SMR", "San Marino", 674, 378 },
                    { "WS", "SAMOA", "WSM", "Samoa", 882, 684 },
                    { "VC", "SAINT VINCENT AND THE GRENADINES", "VCT", "Saint Vincent and the Grenadines", 670, 1784 },
                    { "PM", "SAINT PIERRE AND MIQUELON", "SPM", "Saint Pierre and Miquelon", 666, 508 },
                    { "LC", "SAINT LUCIA", "LCA", "Saint Lucia", 662, 1758 },
                    { "KN", "SAINT KITTS AND NEVIS", "KNA", "Saint Kitts and Nevis", 659, 1869 },
                    { "SH", "SAINT HELENA", "SHN", "Saint Helena", 654, 290 },
                    { "RW", "RWANDA", "RWA", "Rwanda", 646, 250 },
                    { "RU", "RUSSIAN FEDERATION", "RUS", "Russian Federation", 643, 70 },
                    { "RO", "ROMANIA", "ROM", "Romania", 642, 40 },
                    { "RE", "REUNION", "REU", "Reunion", 638, 262 },
                    { "QA", "QATAR", "QAT", "Qatar", 634, 974 },
                    { "PR", "PUERTO RICO", "PRI", "Puerto Rico", 630, 1787 },
                    { "PT", "PORTUGAL", "PRT", "Portugal", 620, 351 },
                    { "PL", "POLAND", "POL", "Poland", 616, 48 },
                    { "PN", "PITCAIRN", "PCN", "Pitcairn", 612, 0 },
                    { "PH", "PHILIPPINES", "PHL", "Philippines", 608, 63 },
                    { "PE", "PERU", "PER", "Peru", 604, 51 },
                    { "PY", "PARAGUAY", "PRY", "Paraguay", 600, 595 },
                    { "PG", "PAPUA NEW GUINEA", "PNG", "Papua New Guinea", 598, 675 },
                    { "PA", "PANAMA", "PAN", "Panama", 591, 507 },
                    { "PS", "PALESTINIAN TERRITORY, OCCUPIED", "", "Palestinian Territory, Occupied", null, 970 },
                    { "SN", "SENEGAL", "SEN", "Senegal", 686, 221 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Iso2", "CapsName", "Iso3", "Name", "NumberCode", "PhoneCode" },
                values: new object[,]
                {
                    { "BW", "BOTSWANA", "BWA", "Botswana", 72, 267 },
                    { "FO", "FAROE ISLANDS", "FRO", "Faroe Islands", 234, 298 },
                    { "BO", "BOLIVIA", "BOL", "Bolivia", 68, 591 },
                    { "BA", "BOSNIA AND HERZEGOVINA", "BIH", "Bosnia and Herzegovina", 70, 387 },
                    { "AF", "AFGHANISTAN", "AFG", "Afghanistan", 4, 93 },
                    { "AL", "ALBANIA", "ALB", "Albania", 8, 355 },
                    { "AS", "AMERICAN SAMOA", "ASM", "American Samoa", 16, 1684 },
                    { "AD", "ANDORRA", "AND", "Andorra", 20, 376 },
                    { "AO", "ANGOLA", "AGO", "Angola", 24, 244 },
                    { "AI", "ANGUILLA", "AIA", "Anguilla", 660, 1264 },
                    { "AQ", "ANTARCTICA", "", "Antarctica", null, 0 },
                    { "AG", "ANTIGUA AND BARBUDA", "ATG", "Antigua and Barbuda", 28, 1268 },
                    { "AR", "ARGENTINA", "ARG", "Argentina", 32, 54 },
                    { "AM", "ARMENIA", "ARM", "Armenia", 51, 374 },
                    { "AW", "ARUBA", "ABW", "Aruba", 533, 297 },
                    { "DZ", "ALGERIA", "DZA", "Algeria", 12, 213 },
                    { "AT", "AUSTRIA", "AUT", "Austria", 40, 43 },
                    { "AU", "AUSTRALIA", "AUS", "Australia", 36, 61 },
                    { "BM", "BERMUDA", "BMU", "Bermuda", 60, 1441 },
                    { "BT", "BHUTAN", "BTN", "Bhutan", 64, 975 },
                    { "BZ", "BELIZE", "BLZ", "Belize", 84, 501 },
                    { "BE", "BELGIUM", "BEL", "Belgium", 56, 32 },
                    { "BJ", "BENIN", "BEN", "Benin", 204, 229 },
                    { "BB", "BARBADOS", "BRB", "Barbados", 52, 1246 },
                    { "BD", "BANGLADESH", "BGD", "Bangladesh", 50, 880 },
                    { "BH", "BAHRAIN", "BHR", "Bahrain", 48, 973 },
                    { "BS", "BAHAMAS", "BHS", "Bahamas", 44, 1242 },
                    { "AZ", "AZERBAIJAN", "AZE", "Azerbaijan", 31, 994 },
                    { "BY", "BELARUS", "BLR", "Belarus", 112, 375 }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Code", "Decimals", "Name", "Number" },
                values: new object[,]
                {
                    { "IDR", "2", "Indonesian rupiah", "360" },
                    { "HUF", "2", "Hungarian forint", "348" },
                    { "HTG", "2", "Haitian gourde", "332" },
                    { "HRK", "2", "Croatian kuna", "191" },
                    { "HNL", "2", "Honduran lempira", "340" },
                    { "HKD", "2", "Hong Kong dollar", "344" },
                    { "GYD", "2", "Guyanese dollar", "328" },
                    { "GNF", "0", "Guinean franc", "324" },
                    { "FKP", "2", "Falkland Islands pound", "238" },
                    { "GIP", "2", "Gibraltar pound", "292" },
                    { "GHS", "2", "Ghanaian cedi", "936" },
                    { "GEL", "2", "Georgian lari", "981" },
                    { "GBP", "2", "Pound sterling", "826" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Code", "Decimals", "Name", "Number" },
                values: new object[,]
                {
                    { "FJD", "2", "Fiji dollar", "242" },
                    { "EUR", "2", "Euro", "978" },
                    { "ETB", "2", "Ethiopian birr", "230" },
                    { "ERN", "2", "Eritrean nakfa", "232" },
                    { "ILS", "2", "Israeli new shekel", "376" },
                    { "GMD", "2", "Gambian dalasi", "270" },
                    { "INR", "2", "Indian rupee", "356" },
                    { "KWD", "3", "Kuwaiti dinar", "414" },
                    { "IRR", "0", "Iranian rial", "364" },
                    { "LTL", "2", "Lithuanian litas", "440" },
                    { "LSL", "2", "Lesotho loti", "426" },
                    { "LRD", "2", "Liberian dollar", "430" },
                    { "LKR", "2", "Sri Lankan rupee", "144" },
                    { "LBP", "0", "Lebanese pound", "422" },
                    { "LAK", "0", "Lao kip", "418" },
                    { "KZT", "2", "Kazakhstani tenge", "398" },
                    { "KYD", "2", "Cayman Islands dollar", "136" },
                    { "EGP", "2", "Egyptian pound", "818" },
                    { "KRW", "0", "South Korean won", "410" },
                    { "KPW", "0", "North Korean won", "408" },
                    { "KMF", "0", "Comoro franc", "174" },
                    { "KHR", "2", "Cambodian riel", "116" },
                    { "KGS", "2", "Kyrgyzstani som", "417" },
                    { "KES", "2", "Kenyan shilling", "404" },
                    { "JPY", "0", "Japanese yen", "392" },
                    { "JOD", "3", "Jordanian dinar", "400" },
                    { "JMD", "2", "Jamaican dollar", "388" },
                    { "ISK", "0", "Icelandic króna", "352" },
                    { "IQD", "3", "Iraqi dinar", "368" },
                    { "DZD", "2", "Algerian dinar", "12" },
                    { "CLF", "0", "Unidad de Fomento (funds code)", "990" },
                    { "DKK", "2", "Danish krone", "208" },
                    { "BOB", "2", "Boliviano", "68" },
                    { "BND", "2", "Brunei dollar", "96" },
                    { "BMD", "2", "Bermudian dollar (customarily known as Bermuda dollar)", "60" },
                    { "BIF", "0", "Burundian franc", "108" },
                    { "BHD", "3", "Bahraini dinar", "48" },
                    { "BGN", "2", "Bulgarian lev", "975" },
                    { "BDT", "2", "Bangladeshi taka", "50" },
                    { "BBD", "2", "Barbados dollar", "52" },
                    { "BAM", "2", "Bosnia and Herzegovina convertible mark", "977" },
                    { "AZN", "2", "Azerbaijani manat", "944" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Code", "Decimals", "Name", "Number" },
                values: new object[,]
                {
                    { "AWG", "2", "Aruban florin", "533" },
                    { "AUD", "2", "Australian dollar", "36" },
                    { "ARS", "2", "Argentine peso", "32" },
                    { "AOA", "2", "Angolan kwanza", "973" },
                    { "ANG", "2", "Netherlands Antillean guilder", "532" },
                    { "AMD", "2", "Armenian dram", "51" },
                    { "ALL", "2", "Albanian lek", "8" },
                    { "AFN", "2", "Afghan afghani", "971" },
                    { "AED", "2", "United Arab Emirates dirham", "784" },
                    { "BOV", "2", "Bolivian Mvdol (funds code)", "984" },
                    { "DOP", "2", "Dominican peso", "214" },
                    { "BRL", "2", "Brazilian real", "986" },
                    { "BTN", "2", "Bhutanese ngultrum", "64" },
                    { "DJF", "0", "Djiboutian franc", "262" },
                    { "CZK", "2", "Czech koruna", "203" },
                    { "CVE", "0", "Cape Verde escudo", "132" },
                    { "CUP", "2", "Cuban peso", "192" },
                    { "CUC", "2", "Cuban convertible peso", "931" },
                    { "CRC", "2", "Costa Rican colon", "188" },
                    { "COU", "2", "Unidad de Valor Real", "970" },
                    { "COP", "2", "Colombian peso", "170" },
                    { "CNY", "2", "Chinese yuan", "156" },
                    { "CLP", "0", "Chilean peso", "152" },
                    { "LVL", "2", "Latvian lats", "428" },
                    { "CHW", "2", "WIR Franc (complementary currency)", "948" },
                    { "CHF", "2", "Swiss franc", "756" },
                    { "CHE", "2", "WIR Euro (complementary currency)", "947" },
                    { "CDF", "2", "Congolese franc", "976" },
                    { "CAD", "2", "Canadian dollar", "124" },
                    { "BZD", "2", "Belize dollar", "84" },
                    { "BYR", "0", "Belarusian ruble", "974" },
                    { "BWP", "2", "Botswana pula", "72" },
                    { "BSD", "2", "Bahamian dollar", "44" },
                    { "LYD", "3", "Libyan dinar", "434" },
                    { "GTQ", "2", "Guatemalan quetzal", "320" },
                    { "MDL", "2", "Moldovan leu", "498" },
                    { "UZS", "2", "Uzbekistan som", "860" },
                    { "UYU", "2", "Uruguayan peso", "858" },
                    { "UYI", "0", "Uruguay Peso en Unidades Indexadas (URUIURUI) (funds code)", "940" },
                    { "USS", "2", "United States dollar (same day) (funds code) (one source[who?] claims it is no longer used, but it is still on the ISO 4217-MA list)", "998" },
                    { "USN", "2", "United States dollar (next day) (funds code)", "997" },
                    { "USD", "2", "United States dollar", "840" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Code", "Decimals", "Name", "Number" },
                values: new object[,]
                {
                    { "UGX", "2", "Ugandan shilling", "800" },
                    { "UAH", "2", "Ukrainian hryvnia", "980" },
                    { "VEF", "2", "Venezuelan bolívar fuerte", "937" },
                    { "TZS", "2", "Tanzanian shilling", "834" },
                    { "TTD", "2", "Trinidad and Tobago dollar", "780" },
                    { "TRY", "2", "Turkish lira", "949" },
                    { "TOP", "2", "Tongan paʻanga", "776" },
                    { "TND", "3", "Tunisian dinar", "788" },
                    { "TMT", "2", "Turkmenistani manat", "934" },
                    { "TJS", "2", "Tajikistani somoni", "972" },
                    { "THB", "2", "Thai baht", "764" },
                    { "SZL", "2", "Swazi lilangeni", "748" },
                    { "TWD", "2", "New Taiwan dollar", "901" },
                    { "VUV", "0", "Vanuatu vatu", "548" },
                    { "WST", "2", "Samoan tala", "882" },
                    { "XAF", "0", "CFA franc BEAC", "950" },
                    { "MAD", "2", "Moroccan dirham", "504" },
                    { "ZMW", "2", "Zambian kwacha", "967" },
                    { "ZAR", "2", "South African rand", "710" },
                    { "YER", "2", "Yemeni rial", "886" },
                    { "XXX", ".", "No currency", "999" },
                    { "XTS", ".", "Code reserved for testing purposes", "963" },
                    { "XPT", ".", "Platinum (one troy ounce)", "962" },
                    { "XPF", "0", "CFP franc", "953" },
                    { "XPD", ".", "Palladium (one troy ounce)", "964" },
                    { "XOF", "0", "CFA franc BCEAO", "952" },
                    { "XFU", ".", "UIC franc (special settlement currency)", "Nil" },
                    { "XDR", ".", "Special drawing rights", "960" },
                    { "XCD", "2", "East Caribbean dollar", "951" },
                    { "XBD", ".", "European Unit of Account 17 (E.U.A.-17) (bond market unit)", "958" },
                    { "XBC", ".", "European Unit of Account 9 (E.U.A.-9) (bond market unit)", "957" },
                    { "XBB", ".", "European Monetary Unit (E.M.U.-6) (bond market unit)", "956" },
                    { "XBA", ".", "European Composite Unit (EURCO) (bond market unit)", "955" },
                    { "XAU", ".", "Gold (one troy ounce)", "959" },
                    { "XAG", ".", "Silver (one troy ounce)", "961" },
                    { "SYP", "2", "Syrian pound", "760" },
                    { "STD", "0", "São Tomé and Príncipe dobra", "678" },
                    { "VND", "0", "Vietnamese dong", "704" },
                    { "SRD", "2", "Surinamese dollar", "968" },
                    { "NZD", "2", "New Zealand dollar", "554" },
                    { "NPR", "2", "Nepalese rupee", "524" },
                    { "NOK", "2", "Norwegian krone", "578" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Code", "Decimals", "Name", "Number" },
                values: new object[,]
                {
                    { "NIO", "2", "Nicaraguan córdoba", "558" },
                    { "NGN", "2", "Nigerian naira", "566" },
                    { "NAD", "2", "Namibian dollar", "516" },
                    { "MZN", "2", "Mozambican metical", "943" },
                    { "MYR", "2", "Malaysian ringgit", "458" },
                    { "MXV", "2", "Mexican Unidad de Inversion (UDI) (funds code)", "979" },
                    { "MXN", "2", "Mexican peso", "484" },
                    { "MWK", "2", "Malawian kwacha", "454" },
                    { "MVR", "2", "Maldivian rufiyaa", "462" },
                    { "MUR", "2", "Mauritian rupee", "480" },
                    { "MRO", "0.7[8]", "Mauritanian ouguiya", "478" },
                    { "MOP", "2", "Macanese pataca", "446" },
                    { "MNT", "2", "Mongolian tugrik", "496" },
                    { "MMK", "0", "Myanma kyat", "104" },
                    { "SSP", "2", "South Sudanese pound", "728" },
                    { "MGA", "0.7[8]", "Malagasy ariary", "969" },
                    { "OMR", "3", "Omani rial", "512" },
                    { "PAB", "2", "Panamanian balboa", "590" },
                    { "MKD", "0", "Macedonian denar", "807" },
                    { "SLL", "0", "Sierra Leonean leone", "694" },
                    { "PEN", "2", "Peruvian nuevo sol", "604" },
                    { "SOS", "2", "Somali shilling", "706" },
                    { "SHP", "2", "Saint Helena pound", "654" },
                    { "SGD", "2", "Singapore dollar", "702" },
                    { "SEK", "2", "Swedish krona/kronor", "752" },
                    { "SDG", "2", "Sudanese pound", "938" },
                    { "SCR", "2", "Seychelles rupee", "690" },
                    { "SAR", "2", "Saudi riyal", "682" },
                    { "RWF", "0", "Rwandan franc", "646" },
                    { "RUB", "2", "Russian rouble", "643" },
                    { "SBD", "2", "Solomon Islands dollar", "90" },
                    { "RON", "2", "Romanian new leu", "946" },
                    { "QAR", "2", "Qatari riyal", "634" },
                    { "PGK", "2", "Papua New Guinean kina", "598" },
                    { "PYG", "0", "Paraguayan guaraní", "600" },
                    { "PLN", "2", "Polish złoty", "985" },
                    { "PKR", "2", "Pakistani rupee", "586" },
                    { "PHP", "2", "Philippine peso", "608" },
                    { "RSD", "2", "Serbian dinar", "941" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "iii", "ii", "Nuosu", "ꆈꌠ꒿ Nuosuhxop" },
                    { "ido", "io", "Ido", "Ido" },
                    { "ibo", "ig", "Igbo", "Asụsụ Igbo" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "hun", "hu", "Hungarian", "magyar" },
                    { "hye", "hy", "Armenian", "Հայերեն" },
                    { "hrv", "hr", "Croatian", "hrvatski jezik" },
                    { "iku", "iu", "Inuktitut", "ᐃᓄᒃᑎᑐᑦ" },
                    { "hmo", "ho", "Hiri Motu", "Hiri Motu" },
                    { "ile", "ie", "Interlingue", "Originally called Occidental; then Interlingue after WWII" },
                    { "kat", "ka", "Georgian", "ქართული" },
                    { "ind", "id", "Indonesian", "Bahasa Indonesia" },
                    { "ipk", "ik", "Inupiaq", "Iñupiaq, Iñupiatun" },
                    { "isl", "is", "Icelandic", "Íslenska" },
                    { "ita", "it", "Italian", "italiano" },
                    { "jav", "jv", "Javanese", "basa Jawa" },
                    { "jpn", "ja", "Japanese", "日本語 (にほんご)" },
                    { "kal", "kl", "Kalaallisut, Greenlandic", "kalaallisut, kalaallit oqaasii" },
                    { "hin", "hi", "Hindi", "हिन्दी, हिंदी" },
                    { "kan", "kn", "Kannada", "ಕನ್ನಡ" },
                    { "kas", "ks", "Kashmiri", "कश्मीरी, كشميري‎" },
                    { "ina", "ia", "Interlingua", "Interlingua" },
                    { "her", "hz", "Herero", "Otjiherero" },
                    { "ful", "ff", "Fula; Fulah; Pulaar; Pular", "Fulfulde, Pulaar, Pular" },
                    { "hau", "ha", "Hausa", "Hausa, هَوُسَ" },
                    { "ell", "el", "Greek, Modern", "ελληνικά" },
                    { "eng", "en", "English", "English" },
                    { "epo", "eo", "Esperanto", "Esperanto" },
                    { "est", "et", "Estonian", "eesti, eesti keel" },
                    { "eus", "eu", "Basque", "euskara, euskera" },
                    { "ewe", "ee", "Ewe", "Eʋegbe" },
                    { "fao", "fo", "Faroese", "føroyskt" },
                    { "fas", "fa", "Persian (Farsi)", "فارسی" },
                    { "fij", "fj", "Fijian", "vosa Vakaviti" },
                    { "fin", "fi", "Finnish", "suomi, suomen kieli" },
                    { "fra", "fr", "French", "français, langue française" },
                    { "fry", "fy", "Western Frisian", "Frysk" },
                    { "gla", "gd", "Scottish Gaelic; Gaelic", "Gàidhlig" },
                    { "gle", "ga", "Irish", "Gaeilge" },
                    { "glg", "gl", "Galician", "galego" },
                    { "glv", "gv", "Manx", "Gaelg, Gailck" },
                    { "grn", "gn", "Guaraní", "Avañe'ẽ" },
                    { "guj", "gu", "Gujarati", "ગુજરાતી" },
                    { "hat", "ht", "Haitian; Haitian Creole", "Kreyòl ayisyen" },
                    { "heb", "he", "Hebrew (modern)", "עברית" },
                    { "kau", "kr", "Kanuri", "Kanuri" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "oji", "oj", "Ojibwe, Ojibwa", "ᐊᓂᔑᓈᐯᒧᐎᓐ" },
                    { "khm", "km", "Khmer", "ខ្មែរ, ខេមរភាសា, ភាសាខ្មែរ" },
                    { "mri", "mi", "Māori", "te reo Māori" },
                    { "msa", "ms", "Malay", "bahasa Melayu, بهاس ملايو‎" },
                    { "mya", "my", "Burmese", "ဗမာစာ" },
                    { "nau", "na", "Nauru", "Ekakairũ Naoero" },
                    { "nav", "nv", "Navajo, Navaho", "Diné bizaad, Dinékʼehǰí" },
                    { "nbl", "nr", "South Ndebele", "isiNdebele" },
                    { "nde", "nd", "North Ndebele", "isiNdebele" },
                    { "ndo", "ng", "Ndonga", "Owambo" },
                    { "nep", "ne", "Nepali", "नेपाली" },
                    { "mon", "mn", "Mongolian", "монгол" },
                    { "nld", "nl", "Dutch", "Nederlands, Vlaams" },
                    { "nob", "nb", "Norwegian Bokmål", "Norsk bokmål" },
                    { "nor", "no", "Norwegian", "Norsk" },
                    { "pan", "pa", "Panjabi, Punjabi", "ਪੰਜਾਬੀ, پنجابی‎" },
                    { "oss", "os", "Ossetian, Ossetic", "ирон æвзаг" },
                    { "orm", "om", "Oromo", "Afaan Oromoo" },
                    { "ori", "or", "Oriya", "ଓଡ଼ିଆ" },
                    { "oci", "oc", "Occitan", "occitan, lenga d'òc" },
                    { "dzo", "dz", "Dzongkha", "རྫོང་ཁ" },
                    { "nya", "ny", "Chichewa; Chewa; Nyanja", "chiCheŵa, chinyanja" },
                    { "nno", "nn", "Norwegian Nynorsk", "Norsk nynorsk" },
                    { "kaz", "kk", "Kazakh", "қазақ тілі" },
                    { "mlt", "mt", "Maltese", "Malti" },
                    { "mkd", "mk", "Macedonian", "македонски јазик" },
                    { "kik", "ki", "Kikuyu, Gikuyu", "Gĩkũyũ" },
                    { "kin", "rw", "Kinyarwanda", "Ikinyarwanda" },
                    { "kir", "ky", "Kyrgyz", "Кыргызча, Кыргыз тили" },
                    { "kom", "kv", "Komi", "коми кыв" },
                    { "kon", "kg", "Kongo", "KiKongo" },
                    { "kor", "ko", "Korean", "한국어 (韓國語), 조선어 (朝鮮語)" },
                    { "kua", "kj", "Kwanyama, Kuanyama", "Kuanyama" },
                    { "kur", "ku", "Kurdish", "Kurdî, كوردی‎" },
                    { "lao", "lo", "Lao", "ພາສາລາວ" },
                    { "mlg", "mg", "Malagasy", "fiteny malagasy" },
                    { "lat", "la", "Latin", "latine, lingua latina" },
                    { "lim", "li", "Limburgish, Limburgan, Limburger", "Limburgs" },
                    { "lin", "ln", "Lingala", "Lingála" },
                    { "lit", "lt", "Lithuanian", "lietuvių kalba" },
                    { "ltz", "lb", "Luxembourgish, Letzeburgesch", "Lëtzebuergesch" },
                    { "lub", "lu", "Luba-Katanga", "Tshiluba" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "lug", "lg", "Ganda", "Luganda" },
                    { "mah", "mh", "Marshallese", "Kajin M̧ajeļ" },
                    { "mal", "ml", "Malayalam", "മലയാളം" },
                    { "mar", "mr", "Marathi (Marāṭhī)", "मराठी" },
                    { "lav", "lv", "Latvian", "latviešu valoda" },
                    { "div", "dv", "Divehi; Dhivehi; Maldivian;", "ދިވެހި" },
                    { "pol", "pl", "Polish", "język polski, polszczyzna" },
                    { "dan", "da", "Danish", "dansk" },
                    { "tha", "th", "Thai", "ไทย" },
                    { "tgl", "tl", "Tagalog", "Wikang Tagalog, ᜏᜒᜃᜅ᜔ ᜆᜄᜎᜓᜄ᜔" },
                    { "tgk", "tg", "Tajik", "тоҷикӣ, toğikī, تاجیکی‎" },
                    { "tel", "te", "Telugu", "తెలుగు" },
                    { "tat", "tt", "Tatar", "татар теле, tatar tele" },
                    { "tam", "ta", "Tamil", "தமிழ்" },
                    { "tah", "ty", "Tahitian", "Reo Tahiti" },
                    { "swe", "sv", "Swedish", "Svenska" },
                    { "swa", "sw", "Swahili", "Kiswahili" },
                    { "sun", "su", "Sundanese", "Basa Sunda" },
                    { "ssw", "ss", "Swati", "SiSwati" },
                    { "srp", "sr", "Serbian", "српски језик" },
                    { "srd", "sc", "Sardinian", "sardu" },
                    { "sqi", "sq", "Albanian", "gjuha shqipe" },
                    { "spa", "es", "Spanish; Castilian", "español, castellano" },
                    { "sot", "st", "Southern Sotho", "Sesotho" },
                    { "som", "so", "Somali", "Soomaaliga, af Soomaali" },
                    { "snd", "sd", "Sindhi", "सिन्धी, سنڌي، سندھی‎" },
                    { "sna", "sn", "Shona", "chiShona" },
                    { "tir", "ti", "Tigrinya", "ትግርኛ" },
                    { "smo", "sm", "Samoan", "gagana fa'a Samoa" },
                    { "ton", "to", "Tonga (Tonga Islands)", "faka Tonga" },
                    { "tso", "ts", "Tsonga", "Xitsonga" },
                    { "zul", "zu", "Zulu", "isiZulu" },
                    { "zho", "zh", "Chinese", "中文 (Zhōngwén), 汉语, 漢語" },
                    { "zha", "za", "Zhuang, Chuang", "Saɯ cueŋƅ, Saw cuengh" },
                    { "yor", "yo", "Yoruba", "Yorùbá" },
                    { "yid", "yi", "Yiddish", "ייִדיש" },
                    { "pli", "pi", "Pāli", "पाऴि" },
                    { "xho", "xh", "Xhosa", "isiXhosa" },
                    { "wol", "wo", "Wolof", "Wollof" },
                    { "wln", "wa", "Walloon", "walon" },
                    { "vol", "vo", "Volapük", "Volapük" },
                    { "vie", "vi", "Vietnamese", "Tiếng Việt" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "ven", "ve", "Venda", "Tshivenḓa" },
                    { "uzb", "uz", "Uzbek", "O‘zbek, Ўзбек, أۇزبېك‎" },
                    { "urd", "ur", "Urdu", "اردو" },
                    { "ukr", "uk", "Ukrainian", "українська мова" },
                    { "uig", "ug", "Uyghur, Uighur", "Uyƣurqə, ئۇيغۇرچە‎" },
                    { "twi", "tw", "Twi", "Twi" },
                    { "tur", "tr", "Turkish", "Türkçe" },
                    { "tuk", "tk", "Turkmen", "Türkmen, Түркмен" },
                    { "tsn", "tn", "Tswana", "Setswana" },
                    { "deu", "de", "German", "Deutsch" },
                    { "sme", "se", "Northern Sami", "Davvisámegiella" },
                    { "slk", "sk", "Slovak", "slovenčina, slovenský jazyk" },
                    { "bam", "bm", "Bambara", "bamanankan" },
                    { "bel", "be", "Belarusian", "беларуская мова" },
                    { "ben", "bn", "Bengali; Bangla", "বাংলা" },
                    { "bih", "bh", "Bihari", "भोजपुरी" },
                    { "bis", "bi", "Bislama", "Bislama" },
                    { "bod", "bo", "Tibetan Standard, Tibetan, Central", "བོད་ཡིག" },
                    { "bos", "bs", "Bosnian", "bosanski jezik" },
                    { "bre", "br", "Breton", "brezhoneg" },
                    { "bul", "bg", "Bulgarian", "български език" },
                    { "cat", "ca", "Catalan; Valencian", "català, valencià" },
                    { "ces", "cs", "Czech", "čeština, český jazyk" },
                    { "cha", "ch", "Chamorro", "Chamoru" },
                    { "che", "ce", "Chechen", "нохчийн мотт" },
                    { "chu", "cu", "Old Church Slavonic, Church Slavonic, Old Bulgarian", "ѩзыкъ словѣньскъ" },
                    { "chv", "cv", "Chuvash", "чӑваш чӗлхи" },
                    { "cor", "kw", "Cornish", "Kernewek" },
                    { "cos", "co", "Corsican", "corsu, lingua corsa" },
                    { "cre", "cr", "Cree", "ᓀᐦᐃᔭᐍᐏᐣ" },
                    { "cym", "cy", "Welsh", "Cymraeg" },
                    { "bak", "ba", "Bashkir", "башҡорт теле" },
                    { "slv", "sl", "Slovene", "slovenski jezik, slovenščina" },
                    { "aze", "az", "Azerbaijani", "azərbaycan dili" },
                    { "aym", "ay", "Aymara", "aymar aru" },
                    { "sin", "si", "Sinhala, Sinhalese", "සිංහල" },
                    { "san", "sa", "Sanskrit (Saṁskṛta)", "संस्कृतम्" },
                    { "sag", "sg", "Sango", "yângâ tî sängö" },
                    { "rus", "ru", "Russian", "русский язык" },
                    { "run", "rn", "Kirundi", "Ikirundi" },
                    { "ron", "ro", "Romanian", "limba română" },
                    { "roh", "rm", "Romansh", "rumantsch grischun" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code3", "Code2", "Name", "NativeName" },
                values: new object[,]
                {
                    { "que", "qu", "Quechua", "Runa Simi, Kichwa" },
                    { "pus", "ps", "Pashto, Pushto", "پښتو" },
                    { "azb", "az", "South Azerbaijani", "تورکجه‎" },
                    { "por", "pt", "Portuguese", "português" },
                    { "abk", "ab", "Abkhaz", "аҧсуа бызшәа, аҧсшәа" },
                    { "afr", "af", "Afrikaans", "Afrikaans" },
                    { "aka", "ak", "Akan", "Akan" },
                    { "amh", "am", "Amharic", "አማርኛ" },
                    { "ara", "ar", "Arabic", "العربية" },
                    { "arg", "an", "Aragonese", "aragonés" },
                    { "asm", "as", "Assamese", "অসমীয়া" },
                    { "ava", "av", "Avaric", "авар мацӀ, магӀарул мацӀ" },
                    { "ave", "ae", "Avestan", "avesta" },
                    { "aar", "aa", "Afar", "Afaraf" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "20f1b6e7-64b7-4658-9f5a-ca9b73da374e", "member", "MEMBER" },
                    { 1, "20f1b6e7-64b7-4658-9f5a-ca9b73da374e", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "StateProvince",
                columns: new[] { "Id", "Abbrev", "Code", "Iso2", "Name" },
                values: new object[,]
                {
                    { 8, "Del.", "DE", null, "Delaware" },
                    { 4, "Ark.", "AR", null, "Arkansas" },
                    { 50, "Wis.", "WI", null, "Wisconsin" },
                    { 23, "Mich.", "MI", null, "Michigan" },
                    { 22, "Mass.", "MA", null, "Massachusetts" },
                    { 21, "Md.", "MD", null, "Maryland" },
                    { 20, "Maine", "ME", null, "Maine" },
                    { 19, "La.", "LA", null, "Louisiana" },
                    { 18, "Ky.", "KY", null, "Kentucky" },
                    { 17, "Kans.", "KS", null, "Kansas" },
                    { 16, "Iowa", "IA", null, "Iowa" },
                    { 15, "Ind.", "IN", null, "Indiana" },
                    { 14, "Ill.", "IL", null, "Illinois" },
                    { 13, "Idaho", "ID", null, "Idaho" },
                    { 12, "Hawaii", "HI", null, "Hawaii" },
                    { 11, "Ga.", "GA", null, "Georgia" },
                    { 10, "Fla.", "FL", null, "Florida" },
                    { 9, "D.C.", "DC", null, "District of Columbia" },
                    { 7, "Conn.", "CT", null, "Connecticut" },
                    { 6, "Colo.", "CO", null, "Colorado" },
                    { 5, "Calif.", "CA", null, "California" },
                    { 3, "Ariz.", "AZ", null, "Arizona" },
                    { 2, "Alaska", "AK", null, "Alaska" },
                    { 51, "Wyo.", "WY", null, "Wyoming" },
                    { 24, "Minn.", "MN", null, "Minnesota" },
                    { 25, "Miss.", "MS", null, "Mississippi" }
                });

            migrationBuilder.InsertData(
                table: "StateProvince",
                columns: new[] { "Id", "Abbrev", "Code", "Iso2", "Name" },
                values: new object[,]
                {
                    { 1, "Ala.", "AL", null, "Alabama" },
                    { 27, "Mont.", "MT", null, "Montana" },
                    { 48, "Wash.", "WA", null, "Washington" },
                    { 47, "Va.", "VA", null, "Virginia" },
                    { 49, "W.Va.", "WV", null, "West Virginia" },
                    { 46, "Vt.", "VT", null, "Vermont" },
                    { 45, "Utah", "UT", null, "Utah" },
                    { 44, "Tex.", "TX", null, "Texas" },
                    { 26, "Mo.", "MO", null, "Missouri" },
                    { 42, "S.D.", "SD", null, "South Dakota" },
                    { 41, "S.C.", "SC", null, "South Carolina" },
                    { 40, "R.I.", "RI", null, "Rhode Island" },
                    { 39, "Pa.", "PA", null, "Pennsylvania" },
                    { 43, "Tenn.", "TN", null, "Tennessee" },
                    { 37, "Okla.", "OK", null, "Oklahoma" },
                    { 38, "Ore.", "OR", null, "Oregon" },
                    { 29, "Nev.", "NV", null, "Nevada" },
                    { 30, "N.H.", "NH", null, "New Hampshire" },
                    { 31, "N.J.", "NJ", null, "New Jersey" },
                    { 28, "Nebr.", "NE", null, "Nebraska" },
                    { 33, "N.Y.", "NY", null, "New York" },
                    { 34, "N.C.", "NC", null, "North Carolina" },
                    { 35, "N.D.", "ND", null, "North Dakota" },
                    { 36, "Ohio", "OH", null, "Ohio" },
                    { 32, "N.M.", "NM", null, "New Mexico" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "MIST", "Macquarie Island Station Time", "+11" },
                    { "MIT", "Marquesas Islands Time", "-09:30" },
                    { "MMT", "Myanmar Standard Time", "+06:30" },
                    { "MSK", "Moscow Time", "+03" },
                    { "MST", "Malaysia Standard Time", "+08" },
                    { "MST", "Mountain Standard Time (North America)", "-07" },
                    { "MUT", "Mauritius Time", "+04" },
                    { "MVT", "Maldives Time", "+05" },
                    { "MYT", "Malaysia Time", "+08" },
                    { "ORAT", "Oral Time", "+05" },
                    { "NDT", "Newfoundland Daylight Time", "-02:30" },
                    { "NFT", "Norfolk Time", "+11" },
                    { "NPT", "Nepal Time", "+05:45" },
                    { "NST", "Newfoundland Standard Time", "-03:30" },
                    { "NT", "Newfoundland Time", "-03:30" },
                    { "NUT", "Niue Time", "-11" },
                    { "NZDT", "New Zealand Daylight Time", "+13" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "NZST", "New Zealand Standard Time", "+12" },
                    { "OMST", "Omsk Time", "+06" },
                    { "MHT", "Marshall Islands", "+12" },
                    { "PDT", "Pacific Daylight Time (North America)", "-07" },
                    { "NCT", "New Caledonia Time", "+11" },
                    { "MEST", "Middle European Summer Time Same zone as CEST", "+02" },
                    { "KOST", "Kosrae Time", "+11" },
                    { "MDT", "Mountain Daylight Time (North America)", "-06" },
                    { "HOVT", "Khovd Standard Time", "+07" },
                    { "PET", "Peru Time", "-05" },
                    { "ICT", "Indochina Time", "+07" },
                    { "IDT", "Israel Daylight Time", "+03" },
                    { "IOT", "Indian Ocean Time", "+03" },
                    { "IRDT", "Iran Daylight Time", "+04:30" },
                    { "IRKT", "Irkutsk Time", "+08" },
                    { "IRST", "Iran Standard Time", "+03:30" },
                    { "IST", "Indian Standard Time", "+05:30" },
                    { "IST", "Irish Standard Time[6]", "+01" },
                    { "IST", "Israel Standard Time", "+02" },
                    { "JST", "Japan Standard Time", "+09" },
                    { "KGT", "Kyrgyzstan time", "+06" },
                    { "KRAT", "Krasnoyarsk Time", "+07" },
                    { "KST", "Korea Standard Time", "+09" },
                    { "LHST", "Lord Howe Standard Time", "+10:30" },
                    { "LHST", "Lord Howe Summer Time", "+11" },
                    { "LINT", "Line Islands Time", "+14" },
                    { "MAGT", "Magadan Time", "+12" },
                    { "MART", "Marquesas Islands Time", "-09:30" },
                    { "MAWT", "Mawson Station Time", "+05" },
                    { "MET", "Middle European Time Same zone as CET", "+01" },
                    { "PETT", "Kamchatka Time", "+12" },
                    { "SST", "Singapore Standard Time", "+08" },
                    { "PHOT", "Phoenix Island Time", "+13" },
                    { "TJT", "Tajikistan Time", "+05" },
                    { "TKT", "Tokelau Time", "+13" },
                    { "TLT", "Timor Leste Time", "+09" },
                    { "TMT", "Turkmenistan Time", "+05" },
                    { "TRT", "Turkey Time", "+03" },
                    { "TOT", "Tonga Time", "+13" },
                    { "TVT", "Tuvalu Time", "+12" },
                    { "ULAST", "Ulaanbaatar Summer Time", "+09" },
                    { "ULAT", "Ulaanbaatar Standard Time", "+08" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "USZ1", "Kaliningrad Time", "+02" },
                    { "", "Coordinated Universal Time", "±00" },
                    { "UYST", "Uruguay Summer Time", "-02" },
                    { "UYT", "Uruguay Standard Time", "-03" },
                    { "UZT", "Uzbekistan Time", "+05" },
                    { "VET", "Venezuelan Standard Time", "-04" },
                    { "VLAT", "Vladivostok Time", "+10" },
                    { "VOLT", "Volgograd Time", "+04" },
                    { "VOST", "Vostok Station Time", "+06" },
                    { "VUT", "Vanuatu Time", "+11" },
                    { "WAKT", "Wake Island Time", "+12" },
                    { "WAST", "West Africa Summer Time", "+02" },
                    { "TFT", "Indian/Kerguelen", "+05" },
                    { "THA", "Thailand Standard Time", "+07" },
                    { "TAHT", "Tahiti Time", "-10" },
                    { "SYOT", "Showa Station Time", "+03" },
                    { "PHT", "Philippine Time", "+08" },
                    { "PKT", "Pakistan Standard Time", "+05" },
                    { "PMDT", "Saint Pierre and Miquelon Daylight time", "-02" },
                    { "PMST", "Saint Pierre and Miquelon Standard Time", "-03" },
                    { "PONT", "Pohnpei Standard Time", "+11" },
                    { "PST", "Pacific Standard Time (North America)", "-08" },
                    { "PST", "Philippine Standard Time", "+08" },
                    { "PYST", "Paraguay Summer Time (South America)[7]", "-03" },
                    { "PYT", "Paraguay Time (South America)[8]", "-04" },
                    { "RET", "Réunion Time", "+04" },
                    { "PGT", "Papua New Guinea Time", "+10" },
                    { "ROTT", "Rothera Research Station Time", "-03" },
                    { "SAMT", "Samara Time", "+04" },
                    { "SAST", "South African Standard Time", "+02" },
                    { "SBT", "Solomon Islands Time", "+11" },
                    { "SCT", "Seychelles Time", "+04" },
                    { "SGT", "Singapore Time", "+08" },
                    { "SLST", "Sri Lanka Standard Time", "+05:30" },
                    { "SRET", "Srednekolymsk Time", "+11" },
                    { "SRT", "Suriname Time", "-03" },
                    { "SST", "Samoa Standard Time", "-11" },
                    { "HOVST", "Khovd Summer Time", "+08" },
                    { "SAKT", "Sakhalin Island time", "+11" },
                    { "HMT", "Heard and McDonald Islands Time", "+05" },
                    { "EGST", "Eastern Greenland Summer Time", "±00" },
                    { "HAST", "Hawaii-Aleutian Standard Time", "-10" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "AZT", "Azerbaijan Time", "+04" },
                    { "BDT", "Brunei Time", "+08" },
                    { "BIOT", "British Indian Ocean Time", "+06" },
                    { "BIT", "Baker Island Time", "-12" },
                    { "BOT", "Bolivia Time", "-04" },
                    { "BRST", "Brasilia Summer Time", "-02" },
                    { "BRT", "Brasilia Time", "-03" },
                    { "BST", "Bangladesh Standard Time", "+06" },
                    { "BST", "Bougainville Standard Time[3]", "+11" },
                    { "BST", "British Summer Time (British Standard Time from Feb 1968 to Oct 1971)", "+01" },
                    { "BTT", "Bhutan Time", "+06" },
                    { "CAT", "Central Africa Time", "+02" },
                    { "CCT", "Cocos Islands Time", "+06:30" },
                    { "CDT", "Central Daylight Time (North America)", "-05" },
                    { "CDT", "Cuba Daylight Time[4]", "-04" },
                    { "CEST", "Central European Summer Time (Cf. HAEC)", "+02" },
                    { "CET", "Central European Time", "+01" },
                    { "CHADT", "Chatham Daylight Time", "+13:45" },
                    { "CHAST", "Chatham Standard Time", "+12:45" },
                    { "CHOT", "Choibalsan Standard Time", "+08" },
                    { "CHOST", "Choibalsan Summer Time", "+09" },
                    { "AZOT", "Azores Standard Time", "-01" },
                    { "CHST", "Chamorro Standard Time", "+10" },
                    { "AZOST", "Azores Summer Time", "±00" },
                    { "AST", "Atlantic Standard Time", "-04" },
                    { "WAT", "West Africa Time", "+01" },
                    { "WET", "Western European Time", "±00" },
                    { "WIT", "Western Indonesian Time", "+07" },
                    { "WST", "Western Standard Time", "+08" },
                    { "YAKT", "Yakutsk Time", "+09" },
                    { "YEKT", "Yekaterinburg Time", "+05" },
                    { "ACDT", "Australian Central Daylight Savings Time", "+10:30" },
                    { "ACST", "Australian Central Standard Time", "+09:30" },
                    { "ACT", "Acre Time", "-05" },
                    { "ACT", "ASEAN Common Time", "+06:30 - +09" },
                    { "ADT", "Atlantic Daylight Time", "-03" },
                    { "AEDT", "Australian Eastern Daylight Savings Time", "+11" },
                    { "AEST", "Australian Eastern Standard Time", "+10" },
                    { "AFT", "Afghanistan Time", "+04:30" },
                    { "AKDT", "Alaska Daylight Time", "-08" },
                    { "AKST", "Alaska Standard Time", "-09" },
                    { "AMST", "Amazon Summer Time (Brazil)[1]", "-03" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "AMT", "Amazon Time (Brazil)[2]", "-04" },
                    { "AMT", "Armenia Time", "+04" },
                    { "ART", "Argentina Time", "-03" },
                    { "AST", "Arabia Standard Time", "+03" },
                    { "AWST", "Australian Western Standard Time", "+08" },
                    { "CHUT", "Chuuk Time", "+10" },
                    { "CIST", "Clipperton Island Standard Time", "-08" },
                    { "CIT", "Central Indonesia Time", "+08" },
                    { "EGT", "Eastern Greenland Time", "-01" },
                    { "EIT", "Eastern Indonesian Time", "+09" },
                    { "EST", "Eastern Standard Time (North America)", "-05" },
                    { "AEST", "Eastern Standard Time (Australia)", "+10" },
                    { "FET", "Further-eastern European Time", "+03" },
                    { "FJT", "Fiji Time", "+12" },
                    { "FKST", "Falkland Islands Summer Time", "-03" },
                    { "FKT", "Falkland Islands Time", "-04" },
                    { "FNT", "Fernando de Noronha Time", "-02" },
                    { "GALT", "Galapagos Time", "-06" },
                    { "GAMT", "Gambier Islands", "-09" },
                    { "GET", "Georgia Standard Time", "+04" },
                    { "GFT", "French Guiana Time", "-03" },
                    { "GILT", "Gilbert Island Time", "+12" },
                    { "GIT", "Gambier Island Time", "-09" },
                    { "GMT", "Greenwich Mean Time", "±00" },
                    { "GST", "South Georgia and the South Sandwich Islands", "-02" },
                    { "GST", "Gulf Standard Time", "+04" },
                    { "GYT", "Guyana Time", "-04" },
                    { "HADT", "Hawaii-Aleutian Daylight Time", "-09" },
                    { "HAEC", "Heure Avancée d'Europe Centrale francised name for CEST", "+02" },
                    { "EET", "Eastern European Time", "+02" },
                    { "EEST", "Eastern European Summer Time", "+03" },
                    { "AEDT", "Eastern Summer Time (Australia)", "+11" },
                    { "EDT", "Eastern Daylight Time (North America)", "-04" },
                    { "CKT", "Cook Island Time", "-10" },
                    { "CLST", "Chile Summer Time", "-03" },
                    { "CLT", "Chile Standard Time", "-04" },
                    { "COST", "Colombia Summer Time", "-04" },
                    { "COT", "Colombia Time", "-05" },
                    { "CST", "Central Standard Time (North America)", "-06" },
                    { "CST", "China Standard Time", "+08" },
                    { "ACST", "Central Standard Time (Australia)", "+09:30" },
                    { "ACDT", "Central Summer Time (Australia)", "+10:30" }
                });

            migrationBuilder.InsertData(
                table: "Timezone",
                columns: new[] { "Code", "Name", "Value" },
                values: new object[,]
                {
                    { "CST", "Cuba Standard Time", "-05" },
                    { "HKT", "Hong Kong Time", "+08" },
                    { "CT", "China time", "+08" },
                    { "CWST", "Central Western Standard Time (Australia) unofficial", "+08:45" },
                    { "CXT", "Christmas Island Time", "+07" },
                    { "DAVT", "Davis Time", "+07" },
                    { "DDUT", "Dumont d'Urville Time", "+10" },
                    { "DFT", "AIX specific equivalent of Central European Time[5]", "+01" },
                    { "EASST", "Easter Island Summer Time", "-05" },
                    { "EAST", "Easter Island Standard Time", "-06" },
                    { "EAT", "East Africa Time", "+03" },
                    { "ECT", "Eastern Caribbean Time (does not recognise DST)", "-04" },
                    { "ECT", "Ecuador Time", "-05" },
                    { "CVT", "Cape Verde Time", "-01" },
                    { "WEST", "Western European Summer Time", "+01" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "20f1b6e7-64b7-4658-9f5a-ca9b73da374e", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEIVVeEi6VZ2YB3JUwyExMUFOL9E6rS4Px8AHXK0osa6ncEsGkS0mFtBesBmGurNFuA==", "", false, "", false, "admin" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ApiScope",
                columns: new[] { "Id", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "Required", "ShowInDiscoveryDocument" },
                values: new object[] { 1, null, "My API", false, true, "api1", false, true });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "Client",
                columns: new[] { "Id", "AbsoluteRefreshTokenLifetime", "AccessTokenLifetime", "AccessTokenType", "AllowAccessTokensViaBrowser", "AllowOfflineAccess", "AllowPlainTextPkce", "AllowRememberConsent", "AllowedIdentityTokenSigningAlgorithms", "AlwaysIncludeUserClaimsInIdToken", "AlwaysSendClientClaims", "AuthorizationCodeLifetime", "BackChannelLogoutSessionRequired", "BackChannelLogoutUri", "ClientClaimsPrefix", "ClientId", "ClientName", "ClientUri", "ConsentLifetime", "Created", "Description", "DeviceCodeLifetime", "EnableLocalLogin", "Enabled", "FrontChannelLogoutSessionRequired", "FrontChannelLogoutUri", "IdentityTokenLifetime", "IncludeJwtId", "LastAccessed", "LogoUri", "NonEditable", "PairWiseSubjectSalt", "ProtocolType", "RefreshTokenExpiration", "RefreshTokenUsage", "RequireClientSecret", "RequireConsent", "RequirePkce", "RequireRequestObject", "SlidingRefreshTokenLifetime", "UpdateAccessTokenClaimsOnRefresh", "Updated", "UserCodeType", "UserSsoLifetime" },
                values: new object[,]
                {
                    { 4, 2592000, 3600, 0, false, false, false, true, null, true, false, 300, true, null, "client_", "js", "JavaScript Client", null, null, new DateTime(2021, 9, 18, 13, 12, 13, 653, DateTimeKind.Unspecified).AddTicks(7956), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, false, false, true, false, 1296000, false, null, null, null },
                    { 3, 2592000, 3600, 0, false, false, false, true, null, true, true, 300, true, null, "client_", "mvc", null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 645, DateTimeKind.Unspecified).AddTicks(5968), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null },
                    { 2, 2592000, 3600, 0, false, false, false, true, null, true, true, 300, true, null, "client_", "client", null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 642, DateTimeKind.Unspecified).AddTicks(7421), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null },
                    { 1, 2592000, 400000, 0, false, false, false, true, null, true, true, 300, true, null, "", "postman", null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 532, DateTimeKind.Unspecified).AddTicks(8105), null, 300, true, true, true, null, 300, true, null, null, false, null, "oidc", 1, 1, true, false, true, false, 1296000, false, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "IdentityResource",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "Name", "NonEditable", "Required", "ShowInDiscoveryDocument", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 17, 3, 58, 20, 206, DateTimeKind.Unspecified).AddTicks(3232), "Your user profile information (first name, last name, etc.)", "User profile", true, true, "profile", false, false, true, null },
                    { 2, new DateTime(2021, 9, 17, 3, 58, 20, 185, DateTimeKind.Unspecified).AddTicks(7082), null, "Your user identifier", false, true, "openid", false, true, true, null }
                });

            migrationBuilder.InsertData(
                table: "EnabledCountry",
                column: "Iso2",
                value: "US");

            migrationBuilder.InsertData(
                table: "LanguageCountry",
                columns: new[] { "Code3", "Iso2", "Default" },
                values: new object[] { "eng", "US", true });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                columns: new[] { "Id", "ClientId", "Origin" },
                values: new object[] { 1, 4, "https://localhost:5003" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientGrantType",
                columns: new[] { "Id", "ClientId", "GrantType" },
                values: new object[,]
                {
                    { 2, 4, "authorization_code" },
                    { 4, 3, "authorization_code" },
                    { 1, 1, "password" },
                    { 3, 2, "client_credentials" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                columns: new[] { "Id", "ClientId", "PostLogoutRedirectUri" },
                values: new object[,]
                {
                    { 1, 3, "https://localhost:5002/signout-callback-oidc" },
                    { 2, 4, "https://localhost:5003/index.html" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                columns: new[] { "Id", "ClientId", "RedirectUri" },
                values: new object[,]
                {
                    { 1, 3, "https://localhost:5002/signin-oidc" },
                    { 2, 4, "https://localhost:5003/callback.html" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientScopes",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 2, 2, "api1" },
                    { 4, 1, "api1" },
                    { 5, 1, "profile" },
                    { 9, 4, "api1" },
                    { 6, 1, "openid" },
                    { 7, 4, "openid" },
                    { 8, 4, "profile" },
                    { 10, 3, "profile" },
                    { 1, 3, "openid" },
                    { 3, 3, "api1" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientSecret",
                columns: new[] { "Id", "ClientId", "Created", "Description", "Expiration", "Type", "Value" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2021, 9, 17, 13, 19, 6, 568, DateTimeKind.Unspecified).AddTicks(1345), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" },
                    { 2, 2, new DateTime(2021, 9, 17, 13, 19, 6, 564, DateTimeKind.Unspecified).AddTicks(8731), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" },
                    { 1, 1, new DateTime(2021, 9, 17, 13, 19, 6, 414, DateTimeKind.Unspecified).AddTicks(3771), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                columns: new[] { "Id", "IdentityResourceId", "Type" },
                values: new object[,]
                {
                    { 15, 2, "sub" },
                    { 14, 1, "updated_at" },
                    { 13, 1, "locale" },
                    { 12, 1, "zoneinfo" },
                    { 11, 1, "birthdate" },
                    { 9, 1, "name" },
                    { 8, 1, "family_name" },
                    { 7, 1, "given_name" },
                    { 6, 1, "middle_name" },
                    { 5, 1, "nickname" },
                    { 4, 1, "preferred_username" },
                    { 2, 1, "picture" },
                    { 1, 1, "website" },
                    { 10, 1, "gender" },
                    { 3, 1, "profile" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiResource_Name",
                schema: "IdentityServer",
                table: "ApiResource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceClaim_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceClaim",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceProperty_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceProperty",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScope_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceScope",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceSecret_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceSecret",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScope_Name",
                schema: "IdentityServer",
                table: "ApiScope",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeClaim_ScopeId",
                schema: "IdentityServer",
                table: "ApiScopeClaim",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeProperty_ScopeId",
                schema: "IdentityServer",
                table: "ApiScopeProperty",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientId",
                schema: "IdentityServer",
                table: "Client",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientClaim_ClientId",
                schema: "IdentityServer",
                table: "ClientClaim",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCorsOrigin_ClientId",
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGrantType_ClientId",
                schema: "IdentityServer",
                table: "ClientGrantType",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdPRestriction_ClientId",
                schema: "IdentityServer",
                table: "ClientIdPRestriction",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPostLogoutRedirectUri_ClientId",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProperty_ClientId",
                schema: "IdentityServer",
                table: "ClientProperty",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRedirectUri_ClientId",
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientScopes_ClientId",
                schema: "IdentityServer",
                table: "ClientScopes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSecret_ClientId",
                schema: "IdentityServer",
                table: "ClientSecret",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Iso2",
                table: "Country",
                column: "Iso2");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Iso3",
                table: "Country",
                column: "Iso3");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceFlowCodes_DeviceCode",
                schema: "IdentityServer",
                table: "DeviceFlowCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceFlowCodes_Expiration",
                schema: "IdentityServer",
                table: "DeviceFlowCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResource_Name",
                schema: "IdentityServer",
                table: "IdentityResource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceClaim_IdentityResourceId",
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceProperty_IdentityResourceId",
                schema: "IdentityServer",
                table: "IdentityResourceProperty",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageCountry_Code3",
                table: "LanguageCountry",
                column: "Code3");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                schema: "IdentityServer",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                schema: "IdentityServer",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_Iso2",
                table: "StateProvince",
                column: "Iso2");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiResourceClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiResourceProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiResourceScope",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiResourceSecret",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiScopeClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiScopeProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientCorsOrigin",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientGrantType",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientIdPRestriction",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientPostLogoutRedirectUri",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientRedirectUri",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientScopes",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientSecret",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DeviceFlowCodes",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "EnabledCountry");

            migrationBuilder.DropTable(
                name: "IdentityResourceClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "IdentityResourceProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "LanguageCountry");

            migrationBuilder.DropTable(
                name: "PersistedGrants",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "StateProvince");

            migrationBuilder.DropTable(
                name: "Timezone");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "ApiResource",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ApiScope",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "IdentityResource",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
