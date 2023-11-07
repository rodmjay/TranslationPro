using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestingEndpointsAddedToIdentityServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientScope",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientScope",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientScope",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "Client",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 7, 4, 41, 25, 772, DateTimeKind.Utc).AddTicks(7644));

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                columns: new[] { "Id", "ClientId", "Origin" },
                values: new object[] { 3, 5, "https://translationpro-app-test.azurewebsites.net" });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostLogoutRedirectUri",
                value: "https://localhost:44330/authentication/logout-callback");

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                columns: new[] { "Id", "ClientId", "PostLogoutRedirectUri" },
                values: new object[] { 4, 5, "https://translationpro-app-test.azurewebsites.net/authentication/logout-callback" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                columns: new[] { "Id", "ClientId", "RedirectUri" },
                values: new object[] { 4, 5, "https://translationpro-app-test.azurewebsites.net/authentication/login-callback" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 6, 1, 45, 36, 939, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "Client",
                columns: new[] { "Id", "AbsoluteRefreshTokenLifetime", "AccessTokenLifetime", "AccessTokenType", "AllowAccessTokensViaBrowser", "AllowOfflineAccess", "AllowPlainTextPkce", "AllowRememberConsent", "AllowedIdentityTokenSigningAlgorithms", "AlwaysIncludeUserClaimsInIdToken", "AlwaysSendClientClaims", "AuthorizationCodeLifetime", "BackChannelLogoutSessionRequired", "BackChannelLogoutUri", "CibaLifetime", "ClientClaimsPrefix", "ClientId", "ClientName", "ClientUri", "ConsentLifetime", "CoordinateLifetimeWithUserSession", "Created", "DPoPClockSkew", "DPoPValidationMode", "Description", "DeviceCodeLifetime", "EnableLocalLogin", "Enabled", "FrontChannelLogoutSessionRequired", "FrontChannelLogoutUri", "IdentityTokenLifetime", "IncludeJwtId", "InitiateLoginUri", "LastAccessed", "LogoUri", "NonEditable", "PairWiseSubjectSalt", "PollingInterval", "ProtocolType", "RefreshTokenExpiration", "RefreshTokenUsage", "RequireClientSecret", "RequireConsent", "RequireDPoP", "RequirePkce", "RequireRequestObject", "SlidingRefreshTokenLifetime", "UpdateAccessTokenClaimsOnRefresh", "Updated", "UserCodeType", "UserSsoLifetime" },
                values: new object[] { 4, 2592000, 3600, 0, false, false, false, true, null, true, false, 300, true, null, null, "client_", "js", "JavaScript Client", null, null, null, new DateTime(2021, 9, 18, 13, 12, 13, 653, DateTimeKind.Unspecified).AddTicks(7956), new TimeSpan(0, 0, 5, 0, 0), 0, null, 300, true, true, true, null, 300, true, null, null, null, false, null, null, "oidc", 1, 1, false, false, false, true, false, 1296000, false, null, null, null });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostLogoutRedirectUri",
                value: "https://localhost:44330/index.html");

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                columns: new[] { "Id", "ClientId", "Origin" },
                values: new object[] { 1, 4, "https://localhost:5003" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                columns: new[] { "Id", "ClientId", "PostLogoutRedirectUri" },
                values: new object[] { 2, 4, "https://localhost:5003/index.html" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                columns: new[] { "Id", "ClientId", "RedirectUri" },
                values: new object[] { 2, 4, "https://localhost:5003/callback.html" });

            migrationBuilder.InsertData(
                schema: "IdentityServer",
                table: "ClientScope",
                columns: new[] { "Id", "ClientId", "Scope" },
                values: new object[,]
                {
                    { 7, 4, "openid" },
                    { 8, 4, "profile" },
                    { 9, 4, "api1" }
                });
        }
    }
}
