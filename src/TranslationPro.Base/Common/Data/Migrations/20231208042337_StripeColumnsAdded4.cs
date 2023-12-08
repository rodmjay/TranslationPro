﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class StripeColumnsAdded4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterPrice",
                schema: "Stripe",
                table: "Subscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CharacterPrice",
                schema: "Stripe",
                table: "Subscription",
                type: "money",
                precision: 19,
                scale: 4,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
