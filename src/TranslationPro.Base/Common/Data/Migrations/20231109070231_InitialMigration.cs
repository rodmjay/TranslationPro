using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "IdentityServer");

            migrationBuilder.EnsureSchema(
                name: "Stripe");

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
                    RequireResourceIndicator = table.Column<bool>(type: "bit", nullable: false),
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
                    ShowInDiscoveryDocument = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScope", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
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
                    RequireDPoP = table.Column<bool>(type: "bit", nullable: false),
                    DPoPValidationMode = table.Column<int>(type: "int", nullable: false),
                    DPoPClockSkew = table.Column<TimeSpan>(type: "time", nullable: false),
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
                    InitiateLoginUri = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UserSsoLifetime = table.Column<int>(type: "int", nullable: true),
                    UserCodeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(type: "int", nullable: false),
                    CibaLifetime = table.Column<int>(type: "int", nullable: true),
                    PollingInterval = table.Column<int>(type: "int", nullable: true),
                    CoordinateLifetimeWithUserSession = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AmountOff = table.Column<long>(type: "bigint", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationInMonths = table.Column<long>(type: "bigint", nullable: true),
                    MaxRedemptions = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentOff = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RedeemBy = table.Column<long>(type: "bigint", nullable: true),
                    TimesRedeemed = table.Column<long>(type: "bigint", nullable: false),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<int>(type: "int", nullable: false),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
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
                name: "Dispute",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastAccessed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityProviders", x => x.Id);
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
                name: "Key",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Key", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentLink",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AllowPromotionCodes = table.Column<bool>(type: "bit", nullable: false),
                    BillingAddressCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCreation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Livemode = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMethodCollection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmitType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payout",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_PersistedGrants", x => x.Id);
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
                name: "ServerSideSession",
                schema: "IdentityServer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Scheme = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Renewed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerSideSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripeProduct",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    StatementDescriptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentApplication = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Phrase",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrase", x => new { x.ApplicationId, x.Id });
                    table.ForeignKey(
                        name: "FK_Phrase_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
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
                    PostLogoutRedirectUri = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
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
                    RedirectUri = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
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
                name: "ClientScope",
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
                    table.PrimaryKey("PK_ClientScope", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientScope_Client_ClientId",
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
                name: "Discount",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalSchema: "Stripe",
                        principalTable: "Coupon",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PromotionCode",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionCode_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalSchema: "Stripe",
                        principalTable: "Coupon",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationEngine",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationEngine", x => new { x.ApplicationId, x.EngineId });
                    table.ForeignKey(
                        name: "FK_ApplicationEngine_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationEngine_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ApplicationLanguage",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLanguage", x => new { x.ApplicationId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ApplicationLanguage_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineLanguage",
                columns: table => new
                {
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineLanguage", x => new { x.LanguageId, x.EngineId });
                    table.ForeignKey(
                        name: "FK_EngineLanguage_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
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
                name: "CouponProduct",
                schema: "Stripe",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponProduct", x => new { x.ProductId, x.CouponId });
                    table.ForeignKey(
                        name: "FK_CouponProduct_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalSchema: "Stripe",
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponProduct_StripeProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Stripe",
                        principalTable: "StripeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Recurring_AggregateUsage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recurring_Interval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recurring_IntervalCount = table.Column<long>(type: "bigint", nullable: true),
                    Recurring_TrialPeriodDays = table.Column<long>(type: "bigint", nullable: true),
                    Recurring_UsageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingScheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    LookupKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxBehavior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiersMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitAmount = table.Column<long>(type: "bigint", nullable: true),
                    UnitAmountDecimal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_StripeProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Stripe",
                        principalTable: "StripeProduct",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                schema: "Stripe",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeature", x => new { x.ProductId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductFeature_StripeProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Stripe",
                        principalTable: "StripeProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    InvitationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvitationReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => new { x.ApplicationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Delinquent = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextInvoiceSequence = table.Column<long>(type: "bigint", nullable: false),
                    TaxExempt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhraseId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TranslationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_ApplicationEngine_ApplicationId_EngineId",
                        columns: x => new { x.ApplicationId, x.EngineId },
                        principalTable: "ApplicationEngine",
                        principalColumns: new[] { "ApplicationId", "EngineId" });
                    table.ForeignKey(
                        name: "FK_Translation_ApplicationLanguage_ApplicationId_LanguageId",
                        columns: x => new { x.ApplicationId, x.LanguageId },
                        principalTable: "ApplicationLanguage",
                        principalColumns: new[] { "ApplicationId", "LanguageId" });
                    table.ForeignKey(
                        name: "FK_Translation_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translation_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Translation_Phrase_ApplicationId_PhraseId",
                        columns: x => new { x.ApplicationId, x.PhraseId },
                        principalTable: "Phrase",
                        principalColumns: new[] { "ApplicationId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AmountDiscount = table.Column<long>(type: "bigint", nullable: false),
                    AmountSubtotal = table.Column<long>(type: "bigint", nullable: false),
                    AmountTax = table.Column<long>(type: "bigint", nullable: false),
                    AmountTotal = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: true),
                    PriceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentLinkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StripePaymentLinkLineItemId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_LineItem_StripePaymentLinkLineItemId",
                        column: x => x.StripePaymentLinkLineItemId,
                        principalSchema: "Stripe",
                        principalTable: "LineItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineItem_PaymentLink_PaymentLinkId",
                        column: x => x.PaymentLinkId,
                        principalSchema: "Stripe",
                        principalTable: "PaymentLink",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineItem_Price_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "Stripe",
                        principalTable: "Price",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Card",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Last4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvcCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpMonth = table.Column<long>(type: "bigint", nullable: false),
                    ExpYear = table.Column<long>(type: "bigint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    DefaultForCurrency = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressZipCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DynamicLast4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fingerprint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenizationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Stripe",
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SetupIntent",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupIntent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetupIntent_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Stripe",
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionSchedule",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CanceledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndBehavior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleasedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleasedSubscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionSchedule_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Stripe",
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CardId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_Card_CardId",
                        column: x => x.CardId,
                        principalSchema: "Stripe",
                        principalTable: "Card",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentMethod_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Stripe",
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationFeePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillingCycleAnchor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelAtPeriodEnd = table.Column<bool>(type: "bit", nullable: false),
                    CanceledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CollectionMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentPeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysUntilDue = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextPendingInvoiceItemInvoice = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrialEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrialStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethodId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Stripe",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subscription_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "Stripe",
                        principalTable: "Discount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subscription_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "Stripe",
                        principalTable: "PaymentMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subscription_SubscriptionSchedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "Stripe",
                        principalTable: "SubscriptionSchedule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionItem",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubscriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PriceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionItem_Price_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "Stripe",
                        principalTable: "Price",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubscriptionItem_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "Stripe",
                        principalTable: "Subscription",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Charge",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    AmountCaptured = table.Column<long>(type: "bigint", nullable: false),
                    AmountRefunded = table.Column<long>(type: "bigint", nullable: false),
                    AuthorizationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CalculatedStatementDescriptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Captured = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disputed = table.Column<bool>(type: "bit", nullable: false),
                    FailureCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FailureMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_NetworkStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_RiskLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_RiskScore = table.Column<long>(type: "bigint", nullable: true),
                    Outcome_SellerMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refunded = table.Column<bool>(type: "bit", nullable: false),
                    StatementDescriptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementDescriptorSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Stripe",
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<int>(type: "int", nullable: false),
                    Captured = table.Column<bool>(type: "bit", nullable: false),
                    AmountCaptured = table.Column<int>(type: "int", nullable: false),
                    Refunded = table.Column<bool>(type: "bit", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountDue = table.Column<long>(type: "bigint", nullable: false),
                    AmountPaid = table.Column<long>(type: "bigint", nullable: false),
                    AmountRemaining = table.Column<long>(type: "bigint", nullable: false),
                    AmountShipping = table.Column<long>(type: "bigint", nullable: false),
                    ApplicationFeeAmount = table.Column<long>(type: "bigint", nullable: true),
                    AttemptCount = table.Column<long>(type: "bigint", nullable: false),
                    Attempted = table.Column<bool>(type: "bit", nullable: false),
                    AutoAdvance = table.Column<bool>(type: "bit", nullable: false),
                    BillingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerTaxExempt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EffectiveAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndingBalance = table.Column<long>(type: "bigint", nullable: true),
                    Footer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HostedInvoiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicePdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextPaymentAttempt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidOutOfBand = table.Column<bool>(type: "bit", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostPaymentCreditNotesAmount = table.Column<long>(type: "bigint", nullable: false),
                    PrePaymentCreditNotesAmount = table.Column<long>(type: "bigint", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingBalance = table.Column<long>(type: "bigint", nullable: false),
                    StatementDescriptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<long>(type: "bigint", nullable: false),
                    SubtotalExcludingTax = table.Column<long>(type: "bigint", nullable: true),
                    Tax = table.Column<long>(type: "bigint", nullable: true),
                    Total = table.Column<long>(type: "bigint", nullable: false),
                    TotalExcludingTax = table.Column<long>(type: "bigint", nullable: true),
                    WebhooksDeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalSchema: "Stripe",
                        principalTable: "Charge",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Stripe",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoice_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "Stripe",
                        principalTable: "Subscription",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Refund",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChargeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refund_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalSchema: "Stripe",
                        principalTable: "Charge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDiscount",
                schema: "Stripe",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDiscount", x => new { x.InvoiceId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_InvoiceDiscount_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "Stripe",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDiscount_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Stripe",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineItem",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PriceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubscriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubscriptionItemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    AmountExcludingTax = table.Column<long>(type: "bigint", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discountable = table.Column<bool>(type: "bit", nullable: false),
                    Proration = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitAmountExcludingTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItem_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Stripe",
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceLineItem_Price_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "Stripe",
                        principalTable: "Price",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceLineItem_SubscriptionItem_SubscriptionItemId",
                        column: x => x.SubscriptionItemId,
                        principalSchema: "Stripe",
                        principalTable: "SubscriptionItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceLineItem_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "Stripe",
                        principalTable: "Subscription",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentIntent",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    CaptureMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    StripeInvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentIntent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentIntent_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Stripe",
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentIntent_Invoice_StripeInvoiceId",
                        column: x => x.StripeInvoiceId,
                        principalSchema: "Stripe",
                        principalTable: "Invoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItemDiscount",
                schema: "Stripe",
                columns: table => new
                {
                    DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceLineItemId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItemDiscount", x => new { x.InvoiceLineItemId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_InvoiceItemDiscount_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "Stripe",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItemDiscount_InvoiceLineItem_InvoiceLineItemId",
                        column: x => x.InvoiceLineItemId,
                        principalSchema: "Stripe",
                        principalTable: "InvoiceLineItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePaymentIntent",
                schema: "Stripe",
                columns: table => new
                {
                    PaymentIntentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePaymentIntent", x => new { x.InvoiceId, x.PaymentIntentId });
                    table.ForeignKey(
                        name: "FK_InvoicePaymentIntent_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Stripe",
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicePaymentIntent_PaymentIntent_PaymentIntentId",
                        column: x => x.PaymentIntentId,
                        principalSchema: "Stripe",
                        principalTable: "PaymentIntent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ApiScope",
                columns: new[] { "Id", "Created", "Description", "DisplayName", "Emphasize", "Enabled", "LastAccessed", "Name", "NonEditable", "Required", "ShowInDiscoveryDocument", "Updated" },
                values: new object[] { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "My API", false, true, null, "api1", false, false, true, null });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "Client",
                columns: new[] { "Id", "AbsoluteRefreshTokenLifetime", "AccessTokenLifetime", "AccessTokenType", "AllowAccessTokensViaBrowser", "AllowOfflineAccess", "AllowPlainTextPkce", "AllowRememberConsent", "AllowedIdentityTokenSigningAlgorithms", "AlwaysIncludeUserClaimsInIdToken", "AlwaysSendClientClaims", "AuthorizationCodeLifetime", "BackChannelLogoutSessionRequired", "BackChannelLogoutUri", "CibaLifetime", "ClientClaimsPrefix", "ClientId", "ClientName", "ClientUri", "ConsentLifetime", "CoordinateLifetimeWithUserSession", "Created", "DPoPClockSkew", "DPoPValidationMode", "Description", "DeviceCodeLifetime", "EnableLocalLogin", "Enabled", "FrontChannelLogoutSessionRequired", "FrontChannelLogoutUri", "IdentityTokenLifetime", "IncludeJwtId", "InitiateLoginUri", "LastAccessed", "LogoUri", "NonEditable", "PairWiseSubjectSalt", "PollingInterval", "ProtocolType", "RefreshTokenExpiration", "RefreshTokenUsage", "RequireClientSecret", "RequireConsent", "RequireDPoP", "RequirePkce", "RequireRequestObject", "SlidingRefreshTokenLifetime", "UpdateAccessTokenClaimsOnRefresh", "Updated", "UserCodeType", "UserSsoLifetime" },
                values: new object[,]
                {
                    { 1, 2592000, 400000, 0, false, false, false, true, null, true, true, 300, true, null, null, "", "postman", null, null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 532, DateTimeKind.Unspecified).AddTicks(8105), new TimeSpan(0, 0, 5, 0, 0), 0, null, 300, true, true, true, null, 300, true, null, null, null, false, null, null, "oidc", 1, 1, true, false, false, true, false, 1296000, false, null, null, null },
                    { 2, 2592000, 3600, 0, false, false, false, true, null, true, true, 300, true, null, null, "client_", "client", null, null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 642, DateTimeKind.Unspecified).AddTicks(7421), new TimeSpan(0, 0, 5, 0, 0), 0, null, 300, true, true, true, null, 300, true, null, null, null, false, null, null, "oidc", 1, 1, true, false, false, true, false, 1296000, false, null, null, null },
                    { 3, 2592000, 3600, 0, false, false, false, true, null, true, true, 300, true, null, null, "client_", "mvc", null, null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 645, DateTimeKind.Unspecified).AddTicks(5968), new TimeSpan(0, 0, 5, 0, 0), 0, null, 300, true, true, true, null, 300, true, null, null, null, false, null, null, "oidc", 1, 1, true, false, false, true, false, 1296000, false, null, null, null },
                    { 5, 2592000, 3600, 0, false, false, false, true, null, true, false, 300, true, null, null, "client_", "translationpro", "TranslationPro", null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 653, DateTimeKind.Unspecified).AddTicks(7956), new TimeSpan(0, 0, 5, 0, 0), 0, null, 300, true, true, true, null, 300, true, null, null, null, false, null, null, "oidc", 1, 1, false, false, false, true, false, 1296000, false, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Engine",
                columns: new[] { "Id", "Enabled", "Name" },
                values: new object[,]
                {
                    { 1, true, "Google Cloud Translate" },
                    { 2, false, "Azure Translator by Microsoft" },
                    { 3, false, "Amazon Translate" },
                    { 4, false, "DeepL" }
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
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "af", "Afrikaans" },
                    { "am", "Amharic" },
                    { "ar", "Arabic" },
                    { "as", "Assamese" },
                    { "az", "Azerbaijani (Latin)" },
                    { "ba", "Bashkir" },
                    { "bg", "Bulgarian" },
                    { "bho", "Bhojpuri" },
                    { "bn", "Bangla" },
                    { "bo", "Tibetan" },
                    { "brx", "Bodo" },
                    { "bs", "Bosnian (Latin)" },
                    { "ca", "Catalan" },
                    { "cs", "Czech" },
                    { "cy", "Welsh" },
                    { "da", "Danish" },
                    { "de", "German" },
                    { "doi", "Dogri" },
                    { "dsb", "Lower Sorbian" },
                    { "dv", "Divehi" },
                    { "el", "Greek" },
                    { "en", "English" },
                    { "es", "Spanish" },
                    { "es-MX", "Spanish (Mexico)" },
                    { "et", "Estonian" },
                    { "eu", "Basque" },
                    { "fa", "Persian" },
                    { "fi", "Finnish" },
                    { "fil", "Filipino" },
                    { "fj", "Fijian" },
                    { "fo", "Faroese" },
                    { "fr", "French" },
                    { "fr-ca", "French (Canada)" },
                    { "gl", "Galician" },
                    { "gom", "Konkani" },
                    { "gu", "Gujarati" },
                    { "ha", "Hausa" },
                    { "hi", "Hindi" },
                    { "hr", "Croatian" },
                    { "hsb", "Upper Sorbian" },
                    { "ht", "Haitian Creole" },
                    { "hu", "Hungarian" },
                    { "hy", "Armenian" },
                    { "id", "Indonesian" },
                    { "ig", "Igbo" },
                    { "ikt", "Inuinnaqtun" },
                    { "ir", "Irish" },
                    { "is", "Icelandic" },
                    { "it", "Italian" },
                    { "itu-Latin", "Inuktitut (Latin)" },
                    { "iu", "Inuktitut" },
                    { "iw", "Hebrew" },
                    { "ja", "Japanese" },
                    { "ka", "Georgian" },
                    { "kk", "Kazahk" },
                    { "km", "Kymer" },
                    { "kmr", "Kurdish (Northern)" },
                    { "kn", "Kannada" },
                    { "ko", "Korean" },
                    { "ks", "Kashmiri" },
                    { "ku", "Kurdish (Central)" },
                    { "ky", "Kyrgyz" },
                    { "ln", "Lingala" },
                    { "lo", "Lao" },
                    { "lt", "Lithuanian" },
                    { "lug", "Liganda" },
                    { "lv", "Latvian" },
                    { "mai", "Maithili" },
                    { "mg", "Malagasy" },
                    { "mi", "Maori" },
                    { "mk", "Macedonian" },
                    { "ml", "Malayalam" },
                    { "mn-Cyrl", "Mongolian (Cyrillic)" },
                    { "mn-Mong", "Mongilian (Traditional)" },
                    { "mr", "Marathi" },
                    { "ms", "Malay (Latin)" },
                    { "mt", "Maltese" },
                    { "mww", "Hmong Daw (Latin)" },
                    { "my", "Myanmar" },
                    { "mya", "Nyanja" },
                    { "ne", "Nepali" },
                    { "nl", "Dutch" },
                    { "no", "Norwegian" },
                    { "nso", "Sesotho sa Leboa" },
                    { "or", "Odia" },
                    { "otq", "Queretaro" },
                    { "pa", "Punjabi" },
                    { "pl", "Polish" },
                    { "prs", "Dari" },
                    { "ps", "Pashto" },
                    { "pt", "Portugese (Brazil)" },
                    { "pt-pt", "Portugese (Portugal)" },
                    { "ro", "Romanian" },
                    { "ru", "Russian" },
                    { "run", "Rundi" },
                    { "rw", "Kiyarwanda" },
                    { "sd", "Sindhi" },
                    { "si", "Sinhala" },
                    { "sk", "Slovak" },
                    { "sl", "Slovenian" },
                    { "sm", "Samoan (Latin)" },
                    { "so", "Somali (Arabic)" },
                    { "sq", "Albanian" },
                    { "sr-Cyrl", "Serbian (Cyrillic)" },
                    { "sr-Latn", "Serbian (Latin)" },
                    { "st", "Sesotho" },
                    { "sv", "Swedish" },
                    { "sw", "Swahili (Latin)" },
                    { "ta", "Tamil" },
                    { "te", "Telugu" },
                    { "th", "Thai" },
                    { "ti", "Tigrinya" },
                    { "tk", "Tirkmen (Latin)" },
                    { "tl", "Filipino (Tagalog)" },
                    { "tlh-Latn", "Klingon" },
                    { "tn", "Setswana" },
                    { "to", "Tongan" },
                    { "tr", "Turkish" },
                    { "tt", "Tatar (Latin)" },
                    { "ty", "Tahitian" },
                    { "ug", "Uyghur (Arabic)" },
                    { "uk", "Ukranian" },
                    { "ur", "Urdu" },
                    { "uz", "Uzbek (Latin)" },
                    { "vi", "Vietnamese" },
                    { "xh", "Zhosa" },
                    { "yo", "Yoruba" },
                    { "yua", "Yucatec Maya" },
                    { "zh-CN", "Chinese (Simplified)" },
                    { "zh-TW", "Chinese (Traditional)" },
                    { "zu", "Zulu" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "20f1b6e7-64b7-4658-9f5a-ca9b73da374e", "admin", "ADMIN" },
                    { 2, "20f1b6e7-64b7-4658-9f5a-ca9b73da374e", "member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrentApplication", "CustomerId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "4a1f1ee5-0ce2-4b5d-88be-4373574ef024", null, null, "admin@admin.com", true, "Rod", "Johnson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKWd/iQx36LYevmQZ7567wkLZT31FgSYJiEiNwdMi9oYappMoiWnbGCOZOsbO5325g==", "123-123-1234", false, "GHCMP3XRBQUGXXFNLNP4UCVZAHL73RZ6", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                columns: new[] { "Id", "ClientId", "Origin" },
                values: new object[,]
                {
                    { 2, 5, "https://localhost:44330" },
                    { 3, 5, "https://translationpro-app-test.azurewebsites.net" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientGrantType",
                columns: new[] { "Id", "ClientId", "GrantType" },
                values: new object[,]
                {
                    { 1, 1, "password" },
                    { 3, 2, "client_credentials" },
                    { 4, 3, "authorization_code" },
                    { 5, 5, "authorization_code" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                columns: new[] { "Id", "ClientId", "PostLogoutRedirectUri" },
                values: new object[,]
                {
                    { 1, 3, "https://localhost:5002/signout-callback-oidc" },
                    { 3, 5, "https://localhost:44330/authentication/logout-callback" },
                    { 4, 5, "https://translationpro-app-test.azurewebsites.net/authentication/logout-callback" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                columns: new[] { "Id", "ClientId", "RedirectUri" },
                values: new object[,]
                {
                    { 1, 3, "https://localhost:5002/signin-oidc" },
                    { 3, 5, "https://localhost:44330/authentication/login-callback" },
                    { 4, 5, "https://translationpro-app-test.azurewebsites.net/authentication/login-callback" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientScope",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 1, 3, "openid" },
                    { 2, 2, "api1" },
                    { 3, 3, "api1" },
                    { 4, 1, "api1" },
                    { 5, 1, "profile" },
                    { 6, 1, "openid" },
                    { 10, 3, "profile" },
                    { 11, 5, "api1" },
                    { 12, 5, "profile" },
                    { 13, 5, "openid" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientSecret",
                columns: new[] { "Id", "ClientId", "Created", "Description", "Expiration", "Type", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 9, 17, 13, 19, 6, 414, DateTimeKind.Unspecified).AddTicks(3771), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" },
                    { 2, 2, new DateTime(2021, 9, 17, 13, 19, 6, 564, DateTimeKind.Unspecified).AddTicks(8731), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" },
                    { 3, 3, new DateTime(2021, 9, 17, 13, 19, 6, 568, DateTimeKind.Unspecified).AddTicks(1345), null, null, "SharedSecret", "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=" }
                });

            migrationBuilder.InsertData(
                table: "EngineLanguage",
                columns: new[] { "EngineId", "LanguageId" },
                values: new object[,]
                {
                    { 3, "af" },
                    { 3, "am" },
                    { 1, "ar" },
                    { 3, "ar" },
                    { 3, "az" },
                    { 3, "bg" },
                    { 3, "bn" },
                    { 3, "bs" },
                    { 3, "ca" },
                    { 1, "cs" },
                    { 3, "cs" },
                    { 3, "cy" },
                    { 1, "da" },
                    { 3, "da" },
                    { 1, "de" },
                    { 3, "de" },
                    { 1, "el" },
                    { 3, "el" },
                    { 1, "en" },
                    { 3, "en" },
                    { 1, "es" },
                    { 3, "es" },
                    { 3, "et" },
                    { 3, "fa" },
                    { 1, "fi" },
                    { 3, "fi" },
                    { 1, "fr" },
                    { 3, "fr" },
                    { 3, "fr-CA" },
                    { 3, "gu" },
                    { 3, "ha" },
                    { 1, "hi" },
                    { 3, "hi" },
                    { 3, "hr" },
                    { 3, "ht" },
                    { 1, "hu" },
                    { 3, "hu" },
                    { 3, "hy" },
                    { 3, "id" },
                    { 3, "ir" },
                    { 3, "is" },
                    { 1, "it" },
                    { 3, "it" },
                    { 1, "iw" },
                    { 3, "iw" },
                    { 1, "ja" },
                    { 3, "ja" },
                    { 3, "ka" },
                    { 3, "kk" },
                    { 3, "kn" },
                    { 1, "ko" },
                    { 3, "ko" },
                    { 3, "lt" },
                    { 3, "lv" },
                    { 3, "mk" },
                    { 3, "ml" },
                    { 3, "mn-Cyrl" },
                    { 3, "mr" },
                    { 3, "ms" },
                    { 3, "mt" },
                    { 1, "nl" },
                    { 3, "nl" },
                    { 1, "no" },
                    { 3, "no" },
                    { 3, "pa" },
                    { 1, "pl" },
                    { 3, "pl" },
                    { 3, "ps" },
                    { 1, "pt" },
                    { 3, "pt" },
                    { 3, "pt-PT" },
                    { 3, "ro" },
                    { 1, "ru" },
                    { 3, "ru" },
                    { 3, "si" },
                    { 3, "sk" },
                    { 3, "sl" },
                    { 3, "so" },
                    { 3, "sq" },
                    { 1, "sv" },
                    { 3, "sv" },
                    { 3, "sw" },
                    { 3, "ta" },
                    { 3, "te" },
                    { 1, "th" },
                    { 3, "th" },
                    { 3, "tl" },
                    { 1, "tr" },
                    { 3, "tr" },
                    { 3, "uk" },
                    { 3, "ur" },
                    { 3, "uz" },
                    { 1, "vi" },
                    { 3, "vi" },
                    { 1, "zh-CN" },
                    { 3, "zh-CN" },
                    { 1, "zh-TW" },
                    { 3, "zh-TW" }
                });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                columns: new[] { "Id", "IdentityResourceId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "website" },
                    { 2, 1, "picture" },
                    { 3, 1, "profile" },
                    { 4, 1, "preferred_username" },
                    { 5, 1, "nickname" },
                    { 6, 1, "middle_name" },
                    { 7, 1, "given_name" },
                    { 8, 1, "family_name" },
                    { 9, 1, "name" },
                    { 10, 1, "gender" },
                    { 11, 1, "birthdate" },
                    { 12, 1, "zoneinfo" },
                    { 13, 1, "locale" },
                    { 14, 1, "updated_at" },
                    { 15, 2, "sub" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiResource_Name",
                schema: "IdentityServer",
                table: "ApiResource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceClaim_ApiResourceId_Type",
                schema: "IdentityServer",
                table: "ApiResourceClaim",
                columns: new[] { "ApiResourceId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceProperty_ApiResourceId_Key",
                schema: "IdentityServer",
                table: "ApiResourceProperty",
                columns: new[] { "ApiResourceId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScope_ApiResourceId_Scope",
                schema: "IdentityServer",
                table: "ApiResourceScope",
                columns: new[] { "ApiResourceId", "Scope" },
                unique: true);

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
                name: "IX_ApiScopeClaim_ScopeId_Type",
                schema: "IdentityServer",
                table: "ApiScopeClaim",
                columns: new[] { "ScopeId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeProperty_ScopeId_Key",
                schema: "IdentityServer",
                table: "ApiScopeProperty",
                columns: new[] { "ScopeId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationEngine_EngineId",
                table: "ApplicationEngine",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLanguage_LanguageId",
                table: "ApplicationLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_UserId",
                table: "ApplicationUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_CustomerId",
                schema: "Stripe",
                table: "Card",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_CustomerId",
                schema: "Stripe",
                table: "Charge",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_InvoiceId",
                schema: "Stripe",
                table: "Charge",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientId",
                schema: "IdentityServer",
                table: "Client",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientClaim_ClientId_Type_Value",
                schema: "IdentityServer",
                table: "ClientClaim",
                columns: new[] { "ClientId", "Type", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCorsOrigin_ClientId_Origin",
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                columns: new[] { "ClientId", "Origin" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientGrantType_ClientId_GrantType",
                schema: "IdentityServer",
                table: "ClientGrantType",
                columns: new[] { "ClientId", "GrantType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdPRestriction_ClientId_Provider",
                schema: "IdentityServer",
                table: "ClientIdPRestriction",
                columns: new[] { "ClientId", "Provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientPostLogoutRedirectUri_ClientId_PostLogoutRedirectUri",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                columns: new[] { "ClientId", "PostLogoutRedirectUri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientProperty_ClientId_Key",
                schema: "IdentityServer",
                table: "ClientProperty",
                columns: new[] { "ClientId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRedirectUri_ClientId_RedirectUri",
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                columns: new[] { "ClientId", "RedirectUri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientScope_ClientId_Scope",
                schema: "IdentityServer",
                table: "ClientScope",
                columns: new[] { "ClientId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientSecret_ClientId",
                schema: "IdentityServer",
                table: "ClientSecret",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponProduct_CouponId",
                schema: "Stripe",
                table: "CouponProduct",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                schema: "Stripe",
                table: "Customer",
                column: "UserId",
                unique: true);

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
                name: "IX_Discount_CouponId",
                schema: "Stripe",
                table: "Discount",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineLanguage_EngineId",
                table: "EngineLanguage",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResource_Name",
                schema: "IdentityServer",
                table: "IdentityResource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceClaim_IdentityResourceId_Type",
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                columns: new[] { "IdentityResourceId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceProperty_IdentityResourceId_Key",
                schema: "IdentityServer",
                table: "IdentityResourceProperty",
                columns: new[] { "IdentityResourceId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ChargeId",
                schema: "Stripe",
                table: "Invoice",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                schema: "Stripe",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SubscriptionId",
                schema: "Stripe",
                table: "Invoice",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDiscount_DiscountId",
                schema: "Stripe",
                table: "InvoiceDiscount",
                column: "DiscountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItemDiscount_DiscountId",
                schema: "Stripe",
                table: "InvoiceItemDiscount",
                column: "DiscountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_InvoiceId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_PriceId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_SubscriptionId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_SubscriptionItemId",
                schema: "Stripe",
                table: "InvoiceLineItem",
                column: "SubscriptionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePaymentIntent_InvoiceId",
                schema: "Stripe",
                table: "InvoicePaymentIntent",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePaymentIntent_PaymentIntentId",
                schema: "Stripe",
                table: "InvoicePaymentIntent",
                column: "PaymentIntentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Key_Use",
                schema: "IdentityServer",
                table: "Key",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_PaymentLinkId",
                schema: "Stripe",
                table: "LineItem",
                column: "PaymentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_PriceId",
                schema: "Stripe",
                table: "LineItem",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_StripePaymentLinkLineItemId",
                schema: "Stripe",
                table: "LineItem",
                column: "StripePaymentLinkLineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentIntent_CustomerId",
                schema: "Stripe",
                table: "PaymentIntent",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentIntent_StripeInvoiceId",
                schema: "Stripe",
                table: "PaymentIntent",
                column: "StripeInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_CardId",
                schema: "Stripe",
                table: "PaymentMethod",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_CustomerId",
                schema: "Stripe",
                table: "PaymentMethod",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Key",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "Key",
                unique: true,
                filter: "[Key] IS NOT NULL");

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
                name: "IX_Price_ProductId",
                schema: "Stripe",
                table: "Price",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionCode_CouponId",
                schema: "Stripe",
                table: "PromotionCode",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_ChargeId",
                schema: "Stripe",
                table: "Refund",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSession_DisplayName",
                schema: "IdentityServer",
                table: "ServerSideSession",
                column: "DisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSession_Expires",
                schema: "IdentityServer",
                table: "ServerSideSession",
                column: "Expires");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSession_Key",
                schema: "IdentityServer",
                table: "ServerSideSession",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSession_SessionId",
                schema: "IdentityServer",
                table: "ServerSideSession",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSession_SubjectId",
                schema: "IdentityServer",
                table: "ServerSideSession",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SetupIntent_CustomerId",
                schema: "Stripe",
                table: "SetupIntent",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_CustomerId",
                schema: "Stripe",
                table: "Subscription",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_DiscountId",
                schema: "Stripe",
                table: "Subscription",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_PaymentMethodId",
                schema: "Stripe",
                table: "Subscription",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_ScheduleId",
                schema: "Stripe",
                table: "Subscription",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItem_PriceId",
                schema: "Stripe",
                table: "SubscriptionItem",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionItem_SubscriptionId",
                schema: "Stripe",
                table: "SubscriptionItem",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionSchedule_CustomerId",
                schema: "Stripe",
                table: "SubscriptionSchedule",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_ApplicationId_EngineId",
                table: "Translation",
                columns: new[] { "ApplicationId", "EngineId" });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_ApplicationId_LanguageId",
                table: "Translation",
                columns: new[] { "ApplicationId", "LanguageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_ApplicationId_PhraseId",
                table: "Translation",
                columns: new[] { "ApplicationId", "PhraseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Translation_LanguageId",
                table: "Translation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charge_Invoice_InvoiceId",
                schema: "Stripe",
                table: "Charge",
                column: "InvoiceId",
                principalSchema: "Stripe",
                principalTable: "Invoice",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_User_UserId",
                schema: "Stripe",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Customer_CustomerId",
                schema: "Stripe",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Charge_Customer_CustomerId",
                schema: "Stripe",
                table: "Charge");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                schema: "Stripe",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_Customer_CustomerId",
                schema: "Stripe",
                table: "PaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Customer_CustomerId",
                schema: "Stripe",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionSchedule_Customer_CustomerId",
                schema: "Stripe",
                table: "SubscriptionSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Charge_Invoice_InvoiceId",
                schema: "Stripe",
                table: "Charge");

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
                name: "ApplicationUser");

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
                name: "ClientScope",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ClientSecret",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "CouponProduct",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "DeviceFlowCodes",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Dispute",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "EngineLanguage");

            migrationBuilder.DropTable(
                name: "IdentityProviders");

            migrationBuilder.DropTable(
                name: "IdentityResourceClaim",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "IdentityResourceProperty",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "InvoiceDiscount",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "InvoiceItemDiscount",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "InvoicePaymentIntent",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Key",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "LineItem",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Payout",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "PersistedGrants",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ProductFeature",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "PromotionCode",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Refund",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "ServerSideSession",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "Session",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "SetupIntent",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Translation");

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
                name: "InvoiceLineItem",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "PaymentIntent",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "PaymentLink",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "ApplicationEngine");

            migrationBuilder.DropTable(
                name: "ApplicationLanguage");

            migrationBuilder.DropTable(
                name: "Phrase");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "SubscriptionItem",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Price",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "StripeProduct",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Charge",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Discount",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "PaymentMethod",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "SubscriptionSchedule",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Coupon",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Card",
                schema: "Stripe");
        }
    }
}
