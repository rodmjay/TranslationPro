using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.common.data.migrations
{
    /// <inheritdoc />
    public partial class UpdatedIdentityServerTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientScopes_Client_ClientId",
                schema: "IdentityServer",
                table: "ClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServerSideSessions",
                schema: "IdentityServer",
                table: "ServerSideSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersistedGrants",
                schema: "IdentityServer",
                table: "PersistedGrants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keys",
                schema: "IdentityServer",
                table: "Keys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientScopes",
                schema: "IdentityServer",
                table: "ClientScopes");

            migrationBuilder.RenameTable(
                name: "ServerSideSessions",
                schema: "IdentityServer",
                newName: "ServerSideSession",
                newSchema: "IdentityServer");

            migrationBuilder.RenameTable(
                name: "PersistedGrants",
                schema: "IdentityServer",
                newName: "PersistedGrant",
                newSchema: "IdentityServer");

            migrationBuilder.RenameTable(
                name: "Keys",
                schema: "IdentityServer",
                newName: "Key",
                newSchema: "IdentityServer");

            migrationBuilder.RenameTable(
                name: "ClientScopes",
                schema: "IdentityServer",
                newName: "ClientScope",
                newSchema: "IdentityServer");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSessions_SubjectId",
                schema: "IdentityServer",
                table: "ServerSideSession",
                newName: "IX_ServerSideSession_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSessions_SessionId",
                schema: "IdentityServer",
                table: "ServerSideSession",
                newName: "IX_ServerSideSession_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSessions_Key",
                schema: "IdentityServer",
                table: "ServerSideSession",
                newName: "IX_ServerSideSession_Key");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSessions_Expires",
                schema: "IdentityServer",
                table: "ServerSideSession",
                newName: "IX_ServerSideSession_Expires");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSessions_DisplayName",
                schema: "IdentityServer",
                table: "ServerSideSession",
                newName: "IX_ServerSideSession_DisplayName");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                schema: "IdentityServer",
                table: "PersistedGrant",
                newName: "IX_PersistedGrant_SubjectId_SessionId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                schema: "IdentityServer",
                table: "PersistedGrant",
                newName: "IX_PersistedGrant_SubjectId_ClientId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrants_Key",
                schema: "IdentityServer",
                table: "PersistedGrant",
                newName: "IX_PersistedGrant_Key");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrants_Expiration",
                schema: "IdentityServer",
                table: "PersistedGrant",
                newName: "IX_PersistedGrant_Expiration");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                schema: "IdentityServer",
                table: "PersistedGrant",
                newName: "IX_PersistedGrant_ConsumedTime");

            migrationBuilder.RenameIndex(
                name: "IX_Keys_Use",
                schema: "IdentityServer",
                table: "Key",
                newName: "IX_Key_Use");

            migrationBuilder.RenameIndex(
                name: "IX_ClientScopes_ClientId_Scope",
                schema: "IdentityServer",
                table: "ClientScope",
                newName: "IX_ClientScope_ClientId_Scope");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServerSideSession",
                schema: "IdentityServer",
                table: "ServerSideSession",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersistedGrant",
                schema: "IdentityServer",
                table: "PersistedGrant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Key",
                schema: "IdentityServer",
                table: "Key",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientScope",
                schema: "IdentityServer",
                table: "ClientScope",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 10, 30, 21, 22, 52, 759, DateTimeKind.Utc).AddTicks(504));

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScope_Client_ClientId",
                schema: "IdentityServer",
                table: "ClientScope",
                column: "ClientId",
                principalSchema: "IdentityServer",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientScope_Client_ClientId",
                schema: "IdentityServer",
                table: "ClientScope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServerSideSession",
                schema: "IdentityServer",
                table: "ServerSideSession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersistedGrant",
                schema: "IdentityServer",
                table: "PersistedGrant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Key",
                schema: "IdentityServer",
                table: "Key");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientScope",
                schema: "IdentityServer",
                table: "ClientScope");

            migrationBuilder.RenameTable(
                name: "ServerSideSession",
                schema: "IdentityServer",
                newName: "ServerSideSessions",
                newSchema: "IdentityServer");

            migrationBuilder.RenameTable(
                name: "PersistedGrant",
                schema: "IdentityServer",
                newName: "PersistedGrants",
                newSchema: "IdentityServer");

            migrationBuilder.RenameTable(
                name: "Key",
                schema: "IdentityServer",
                newName: "Keys",
                newSchema: "IdentityServer");

            migrationBuilder.RenameTable(
                name: "ClientScope",
                schema: "IdentityServer",
                newName: "ClientScopes",
                newSchema: "IdentityServer");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSession_SubjectId",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                newName: "IX_ServerSideSessions_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSession_SessionId",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                newName: "IX_ServerSideSessions_SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSession_Key",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                newName: "IX_ServerSideSessions_Key");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSession_Expires",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                newName: "IX_ServerSideSessions_Expires");

            migrationBuilder.RenameIndex(
                name: "IX_ServerSideSession_DisplayName",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                newName: "IX_ServerSideSessions_DisplayName");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrant_SubjectId_SessionId_Type",
                schema: "IdentityServer",
                table: "PersistedGrants",
                newName: "IX_PersistedGrants_SubjectId_SessionId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrant_SubjectId_ClientId_Type",
                schema: "IdentityServer",
                table: "PersistedGrants",
                newName: "IX_PersistedGrants_SubjectId_ClientId_Type");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrant_Key",
                schema: "IdentityServer",
                table: "PersistedGrants",
                newName: "IX_PersistedGrants_Key");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrant_Expiration",
                schema: "IdentityServer",
                table: "PersistedGrants",
                newName: "IX_PersistedGrants_Expiration");

            migrationBuilder.RenameIndex(
                name: "IX_PersistedGrant_ConsumedTime",
                schema: "IdentityServer",
                table: "PersistedGrants",
                newName: "IX_PersistedGrants_ConsumedTime");

            migrationBuilder.RenameIndex(
                name: "IX_Key_Use",
                schema: "IdentityServer",
                table: "Keys",
                newName: "IX_Keys_Use");

            migrationBuilder.RenameIndex(
                name: "IX_ClientScope_ClientId_Scope",
                schema: "IdentityServer",
                table: "ClientScopes",
                newName: "IX_ClientScopes_ClientId_Scope");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServerSideSessions",
                schema: "IdentityServer",
                table: "ServerSideSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersistedGrants",
                schema: "IdentityServer",
                table: "PersistedGrants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keys",
                schema: "IdentityServer",
                table: "Keys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientScopes",
                schema: "IdentityServer",
                table: "ClientScopes",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 10, 29, 3, 44, 28, 680, DateTimeKind.Utc).AddTicks(2838));

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScopes_Client_ClientId",
                schema: "IdentityServer",
                table: "ClientScopes",
                column: "ClientId",
                principalSchema: "IdentityServer",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
