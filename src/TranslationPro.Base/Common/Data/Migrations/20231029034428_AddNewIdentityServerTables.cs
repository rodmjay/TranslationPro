using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.common.data.migrations
{
    /// <inheritdoc />
    public partial class AddNewIdentityServerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersistedGrants",
                schema: "IdentityServer",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_IdentityResourceProperty_IdentityResourceId",
                schema: "IdentityServer",
                table: "IdentityResourceProperty");

            migrationBuilder.DropIndex(
                name: "IX_IdentityResourceClaim_IdentityResourceId",
                schema: "IdentityServer",
                table: "IdentityResourceClaim");

            migrationBuilder.DropIndex(
                name: "IX_ClientScopes_ClientId",
                schema: "IdentityServer",
                table: "ClientScopes");

            migrationBuilder.DropIndex(
                name: "IX_ClientRedirectUri_ClientId",
                schema: "IdentityServer",
                table: "ClientRedirectUri");

            migrationBuilder.DropIndex(
                name: "IX_ClientProperty_ClientId",
                schema: "IdentityServer",
                table: "ClientProperty");

            migrationBuilder.DropIndex(
                name: "IX_ClientPostLogoutRedirectUri_ClientId",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri");

            migrationBuilder.DropIndex(
                name: "IX_ClientIdPRestriction_ClientId",
                schema: "IdentityServer",
                table: "ClientIdPRestriction");

            migrationBuilder.DropIndex(
                name: "IX_ClientGrantType_ClientId",
                schema: "IdentityServer",
                table: "ClientGrantType");

            migrationBuilder.DropIndex(
                name: "IX_ClientCorsOrigin_ClientId",
                schema: "IdentityServer",
                table: "ClientCorsOrigin");

            migrationBuilder.DropIndex(
                name: "IX_ClientClaim_ClientId",
                schema: "IdentityServer",
                table: "ClientClaim");

            migrationBuilder.DropIndex(
                name: "IX_ApiScopeProperty_ScopeId",
                schema: "IdentityServer",
                table: "ApiScopeProperty");

            migrationBuilder.DropIndex(
                name: "IX_ApiScopeClaim_ScopeId",
                schema: "IdentityServer",
                table: "ApiScopeClaim");

            migrationBuilder.DropIndex(
                name: "IX_ApiResourceScope_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceScope");

            migrationBuilder.DropIndex(
                name: "IX_ApiResourceProperty_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceProperty");

            migrationBuilder.DropIndex(
                name: "IX_ApiResourceClaim_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceClaim");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                schema: "IdentityServer",
                table: "PersistedGrants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                schema: "IdentityServer",
                table: "PersistedGrants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "RedirectUri",
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "PostLogoutRedirectUri",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddColumn<int>(
                name: "CibaLifetime",
                schema: "IdentityServer",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CoordinateLifetimeWithUserSession",
                schema: "IdentityServer",
                table: "Client",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DPoPClockSkew",
                schema: "IdentityServer",
                table: "Client",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "DPoPValidationMode",
                schema: "IdentityServer",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InitiateLoginUri",
                schema: "IdentityServer",
                table: "Client",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PollingInterval",
                schema: "IdentityServer",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireDPoP",
                schema: "IdentityServer",
                table: "Client",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "IdentityServer",
                table: "ApiScope",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccessed",
                schema: "IdentityServer",
                table: "ApiScope",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NonEditable",
                schema: "IdentityServer",
                table: "ApiScope",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "IdentityServer",
                table: "ApiScope",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireResourceIndicator",
                schema: "IdentityServer",
                table: "ApiResource",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersistedGrants",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "Id");

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
                name: "Keys",
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
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServerSideSessions",
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
                    table.PrimaryKey("PK_ServerSideSessions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastAccessed", "NonEditable", "Updated" },
                values: new object[] { new DateTime(2023, 10, 29, 3, 44, 28, 680, DateTimeKind.Utc).AddTicks(2838), null, false, null });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "Client",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CibaLifetime", "CoordinateLifetimeWithUserSession", "DPoPClockSkew", "DPoPValidationMode", "InitiateLoginUri", "PollingInterval", "RequireDPoP" },
                values: new object[] { null, null, new TimeSpan(0, 0, 5, 0, 0), 0, null, null, false });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "Client",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CibaLifetime", "CoordinateLifetimeWithUserSession", "DPoPClockSkew", "DPoPValidationMode", "InitiateLoginUri", "PollingInterval", "RequireDPoP" },
                values: new object[] { null, null, new TimeSpan(0, 0, 5, 0, 0), 0, null, null, false });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "Client",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CibaLifetime", "CoordinateLifetimeWithUserSession", "DPoPClockSkew", "DPoPValidationMode", "InitiateLoginUri", "PollingInterval", "RequireDPoP" },
                values: new object[] { null, null, new TimeSpan(0, 0, 5, 0, 0), 0, null, null, false });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "Client",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CibaLifetime", "CoordinateLifetimeWithUserSession", "DPoPClockSkew", "DPoPValidationMode", "InitiateLoginUri", "PollingInterval", "RequireDPoP" },
                values: new object[] { null, null, new TimeSpan(0, 0, 5, 0, 0), 0, null, null, false });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Key",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "Key",
                unique: true,
                filter: "[Key] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceProperty_IdentityResourceId_Key",
                schema: "IdentityServer",
                table: "IdentityResourceProperty",
                columns: new[] { "IdentityResourceId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceClaim_IdentityResourceId_Type",
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                columns: new[] { "IdentityResourceId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientScopes_ClientId_Scope",
                schema: "IdentityServer",
                table: "ClientScopes",
                columns: new[] { "ClientId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRedirectUri_ClientId_RedirectUri",
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                columns: new[] { "ClientId", "RedirectUri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientProperty_ClientId_Key",
                schema: "IdentityServer",
                table: "ClientProperty",
                columns: new[] { "ClientId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientPostLogoutRedirectUri_ClientId_PostLogoutRedirectUri",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                columns: new[] { "ClientId", "PostLogoutRedirectUri" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdPRestriction_ClientId_Provider",
                schema: "IdentityServer",
                table: "ClientIdPRestriction",
                columns: new[] { "ClientId", "Provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientGrantType_ClientId_GrantType",
                schema: "IdentityServer",
                table: "ClientGrantType",
                columns: new[] { "ClientId", "GrantType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCorsOrigin_ClientId_Origin",
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                columns: new[] { "ClientId", "Origin" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientClaim_ClientId_Type_Value",
                schema: "IdentityServer",
                table: "ClientClaim",
                columns: new[] { "ClientId", "Type", "Value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeProperty_ScopeId_Key",
                schema: "IdentityServer",
                table: "ApiScopeProperty",
                columns: new[] { "ScopeId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeClaim_ScopeId_Type",
                schema: "IdentityServer",
                table: "ApiScopeClaim",
                columns: new[] { "ScopeId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScope_ApiResourceId_Scope",
                schema: "IdentityServer",
                table: "ApiResourceScope",
                columns: new[] { "ApiResourceId", "Scope" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceProperty_ApiResourceId_Key",
                schema: "IdentityServer",
                table: "ApiResourceProperty",
                columns: new[] { "ApiResourceId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceClaim_ApiResourceId_Type",
                schema: "IdentityServer",
                table: "ApiResourceClaim",
                columns: new[] { "ApiResourceId", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                schema: "IdentityServer",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_DisplayName",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                column: "DisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_Expires",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                column: "Expires");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_Key",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_SessionId",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSideSessions_SubjectId",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityProviders");

            migrationBuilder.DropTable(
                name: "Keys",
                schema: "IdentityServer");

            migrationBuilder.DropTable(
                name: "ServerSideSessions",
                schema: "IdentityServer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersistedGrants",
                schema: "IdentityServer",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                schema: "IdentityServer",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_Key",
                schema: "IdentityServer",
                table: "PersistedGrants");

            migrationBuilder.DropIndex(
                name: "IX_IdentityResourceProperty_IdentityResourceId_Key",
                schema: "IdentityServer",
                table: "IdentityResourceProperty");

            migrationBuilder.DropIndex(
                name: "IX_IdentityResourceClaim_IdentityResourceId_Type",
                schema: "IdentityServer",
                table: "IdentityResourceClaim");

            migrationBuilder.DropIndex(
                name: "IX_ClientScopes_ClientId_Scope",
                schema: "IdentityServer",
                table: "ClientScopes");

            migrationBuilder.DropIndex(
                name: "IX_ClientRedirectUri_ClientId_RedirectUri",
                schema: "IdentityServer",
                table: "ClientRedirectUri");

            migrationBuilder.DropIndex(
                name: "IX_ClientProperty_ClientId_Key",
                schema: "IdentityServer",
                table: "ClientProperty");

            migrationBuilder.DropIndex(
                name: "IX_ClientPostLogoutRedirectUri_ClientId_PostLogoutRedirectUri",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri");

            migrationBuilder.DropIndex(
                name: "IX_ClientIdPRestriction_ClientId_Provider",
                schema: "IdentityServer",
                table: "ClientIdPRestriction");

            migrationBuilder.DropIndex(
                name: "IX_ClientGrantType_ClientId_GrantType",
                schema: "IdentityServer",
                table: "ClientGrantType");

            migrationBuilder.DropIndex(
                name: "IX_ClientCorsOrigin_ClientId_Origin",
                schema: "IdentityServer",
                table: "ClientCorsOrigin");

            migrationBuilder.DropIndex(
                name: "IX_ClientClaim_ClientId_Type_Value",
                schema: "IdentityServer",
                table: "ClientClaim");

            migrationBuilder.DropIndex(
                name: "IX_ApiScopeProperty_ScopeId_Key",
                schema: "IdentityServer",
                table: "ApiScopeProperty");

            migrationBuilder.DropIndex(
                name: "IX_ApiScopeClaim_ScopeId_Type",
                schema: "IdentityServer",
                table: "ApiScopeClaim");

            migrationBuilder.DropIndex(
                name: "IX_ApiResourceScope_ApiResourceId_Scope",
                schema: "IdentityServer",
                table: "ApiResourceScope");

            migrationBuilder.DropIndex(
                name: "IX_ApiResourceProperty_ApiResourceId_Key",
                schema: "IdentityServer",
                table: "ApiResourceProperty");

            migrationBuilder.DropIndex(
                name: "IX_ApiResourceClaim_ApiResourceId_Type",
                schema: "IdentityServer",
                table: "ApiResourceClaim");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "IdentityServer",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "CibaLifetime",
                schema: "IdentityServer",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "CoordinateLifetimeWithUserSession",
                schema: "IdentityServer",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "DPoPClockSkew",
                schema: "IdentityServer",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "DPoPValidationMode",
                schema: "IdentityServer",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "InitiateLoginUri",
                schema: "IdentityServer",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "PollingInterval",
                schema: "IdentityServer",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "RequireDPoP",
                schema: "IdentityServer",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "IdentityServer",
                table: "ApiScope");

            migrationBuilder.DropColumn(
                name: "LastAccessed",
                schema: "IdentityServer",
                table: "ApiScope");

            migrationBuilder.DropColumn(
                name: "NonEditable",
                schema: "IdentityServer",
                table: "ApiScope");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "IdentityServer",
                table: "ApiScope");

            migrationBuilder.DropColumn(
                name: "RequireResourceIndicator",
                schema: "IdentityServer",
                table: "ApiResource");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                schema: "IdentityServer",
                table: "PersistedGrants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RedirectUri",
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "PostLogoutRedirectUri",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersistedGrants",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceProperty_IdentityResourceId",
                schema: "IdentityServer",
                table: "IdentityResourceProperty",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityResourceClaim_IdentityResourceId",
                schema: "IdentityServer",
                table: "IdentityResourceClaim",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientScopes_ClientId",
                schema: "IdentityServer",
                table: "ClientScopes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRedirectUri_ClientId",
                schema: "IdentityServer",
                table: "ClientRedirectUri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProperty_ClientId",
                schema: "IdentityServer",
                table: "ClientProperty",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPostLogoutRedirectUri_ClientId",
                schema: "IdentityServer",
                table: "ClientPostLogoutRedirectUri",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdPRestriction_ClientId",
                schema: "IdentityServer",
                table: "ClientIdPRestriction",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGrantType_ClientId",
                schema: "IdentityServer",
                table: "ClientGrantType",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCorsOrigin_ClientId",
                schema: "IdentityServer",
                table: "ClientCorsOrigin",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientClaim_ClientId",
                schema: "IdentityServer",
                table: "ClientClaim",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeProperty_ScopeId",
                schema: "IdentityServer",
                table: "ApiScopeProperty",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiScopeClaim_ScopeId",
                schema: "IdentityServer",
                table: "ApiScopeClaim",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceScope_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceScope",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceProperty_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceProperty",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiResourceClaim_ApiResourceId",
                schema: "IdentityServer",
                table: "ApiResourceClaim",
                column: "ApiResourceId");
        }
    }
}
