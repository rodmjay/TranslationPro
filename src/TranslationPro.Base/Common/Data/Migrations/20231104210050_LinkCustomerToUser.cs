using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinkCustomerToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_StripeCustomer_CustomerId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CustomerId",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StripeCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 4, 21, 0, 50, 579, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.CreateIndex(
                name: "IX_StripeCustomer_UserId",
                table: "StripeCustomer",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StripeCustomer_User_UserId",
                table: "StripeCustomer",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripeCustomer_User_UserId",
                table: "StripeCustomer");

            migrationBuilder.DropIndex(
                name: "IX_StripeCustomer_UserId",
                table: "StripeCustomer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StripeCustomer");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "User",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 4, 20, 56, 52, 518, DateTimeKind.Utc).AddTicks(1238));

            migrationBuilder.CreateIndex(
                name: "IX_User_CustomerId",
                table: "User",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_StripeCustomer_CustomerId",
                table: "User",
                column: "CustomerId",
                principalTable: "StripeCustomer",
                principalColumn: "Id");
        }
    }
}
