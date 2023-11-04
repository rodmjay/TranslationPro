using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStripeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StripeCoupon",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeCoupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripeCustomer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripePaymentLink",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePaymentLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripePayout",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePayout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripeProduct",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripeSession",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripePromotionCode",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePromotionCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripePromotionCode_StripeCoupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "StripeCoupon",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeCard",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Last4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvcCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpMonth = table.Column<int>(type: "int", nullable: false),
                    ExpYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeCard_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeInvoice",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<int>(type: "int", nullable: false),
                    Captured = table.Column<bool>(type: "bit", nullable: false),
                    AmountCaptured = table.Column<int>(type: "int", nullable: false),
                    Refunded = table.Column<bool>(type: "bit", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeInvoice_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeSchedule",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeSchedule_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeSubscription",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeSubscription_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripePrice",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripePrice_StripeProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "StripeProduct",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripePaymentMethod",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CardId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePaymentMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripePaymentMethod_StripeCard_CardId",
                        column: x => x.CardId,
                        principalTable: "StripeCard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StripePaymentMethod_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeCharge",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeCharge_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StripeCharge_StripeInvoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "StripeInvoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeInvoiceLine",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeInvoiceLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeInvoiceLine_StripeInvoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "StripeInvoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripePaymentIntent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CaptureMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripePaymentIntent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripePaymentIntent_StripeCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "StripeCustomer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StripePaymentIntent_StripeInvoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "StripeInvoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeSubscriptionItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubscriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeSubscriptionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeSubscriptionItem_StripeSubscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "StripeSubscription",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeRefund",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChargeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeRefund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeRefund_StripeCharge_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "StripeCharge",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 4, 20, 56, 52, 518, DateTimeKind.Utc).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_User_CustomerId",
                table: "User",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeCard_CustomerId",
                table: "StripeCard",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeCharge_CustomerId",
                table: "StripeCharge",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeCharge_InvoiceId",
                table: "StripeCharge",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeInvoice_CustomerId",
                table: "StripeInvoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeInvoiceLine_InvoiceId",
                table: "StripeInvoiceLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StripePaymentIntent_CustomerId",
                table: "StripePaymentIntent",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripePaymentIntent_InvoiceId",
                table: "StripePaymentIntent",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StripePaymentMethod_CardId",
                table: "StripePaymentMethod",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_StripePaymentMethod_CustomerId",
                table: "StripePaymentMethod",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripePrice_ProductId",
                table: "StripePrice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StripePromotionCode_CouponId",
                table: "StripePromotionCode",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeRefund_ChargeId",
                table: "StripeRefund",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeSchedule_CustomerId",
                table: "StripeSchedule",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeSubscription_CustomerId",
                table: "StripeSubscription",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeSubscriptionItem_SubscriptionId",
                table: "StripeSubscriptionItem",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_StripeCustomer_CustomerId",
                table: "User",
                column: "CustomerId",
                principalTable: "StripeCustomer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_StripeCustomer_CustomerId",
                table: "User");

            migrationBuilder.DropTable(
                name: "StripeInvoiceLine");

            migrationBuilder.DropTable(
                name: "StripePaymentIntent");

            migrationBuilder.DropTable(
                name: "StripePaymentLink");

            migrationBuilder.DropTable(
                name: "StripePaymentMethod");

            migrationBuilder.DropTable(
                name: "StripePayout");

            migrationBuilder.DropTable(
                name: "StripePrice");

            migrationBuilder.DropTable(
                name: "StripePromotionCode");

            migrationBuilder.DropTable(
                name: "StripeRefund");

            migrationBuilder.DropTable(
                name: "StripeSchedule");

            migrationBuilder.DropTable(
                name: "StripeSession");

            migrationBuilder.DropTable(
                name: "StripeSubscriptionItem");

            migrationBuilder.DropTable(
                name: "StripeCard");

            migrationBuilder.DropTable(
                name: "StripeProduct");

            migrationBuilder.DropTable(
                name: "StripeCoupon");

            migrationBuilder.DropTable(
                name: "StripeCharge");

            migrationBuilder.DropTable(
                name: "StripeSubscription");

            migrationBuilder.DropTable(
                name: "StripeInvoice");

            migrationBuilder.DropTable(
                name: "StripeCustomer");

            migrationBuilder.DropIndex(
                name: "IX_User_CustomerId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "User");

            migrationBuilder.UpdateData(
                schema: "IdentityServer",
                table: "ApiScope",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 2, 3, 28, 0, 977, DateTimeKind.Utc).AddTicks(4014));
        }
    }
}
