using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationPro.Base.Common.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStripe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "CouponProduct",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Dispute",
                schema: "Stripe");

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
                name: "LineItem",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Payout",
                schema: "Stripe");

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
                name: "Session",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "SetupIntent",
                schema: "Stripe");

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
                name: "SubscriptionItem",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "Price",
                schema: "Stripe");

            migrationBuilder.DropTable(
                name: "StripeProduct",
                schema: "Stripe");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Stripe");

            migrationBuilder.CreateTable(
                name: "Coupon",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AmountOff = table.Column<long>(type: "bigint", nullable: true),
                    Created = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationInMonths = table.Column<long>(type: "bigint", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    MaxRedemptions = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentOff = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RedeemBy = table.Column<long>(type: "bigint", nullable: true),
                    TimesRedeemed = table.Column<long>(type: "bigint", nullable: false),
                    Valid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Delinquent = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoicePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextInvoiceSequence = table.Column<long>(type: "bigint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxExempt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Card",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1Check = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressZipCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CvcCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultForCurrency = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DynamicLast4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpMonth = table.Column<long>(type: "bigint", nullable: false),
                    ExpYear = table.Column<long>(type: "bigint", nullable: false),
                    Fingerprint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    ReleasedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleasedSubscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    BillingScheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    LookupKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxBehavior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiersMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitAmount = table.Column<long>(type: "bigint", nullable: true),
                    UnitAmountDecimal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Recurring_AggregateUsage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recurring_Interval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recurring_IntervalCount = table.Column<long>(type: "bigint", nullable: true),
                    Recurring_TrialPeriodDays = table.Column<long>(type: "bigint", nullable: true),
                    Recurring_UsageType = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "PaymentMethod",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "LineItem",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentLinkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PriceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AmountDiscount = table.Column<long>(type: "bigint", nullable: false),
                    AmountSubtotal = table.Column<long>(type: "bigint", nullable: false),
                    AmountTax = table.Column<long>(type: "bigint", nullable: false),
                    AmountTotal = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: true),
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
                name: "Subscription",
                schema: "Stripe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentMethodId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    NextPendingInvoiceItemInvoice = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrialEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrialStart = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    PriceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubscriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
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
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refunded = table.Column<bool>(type: "bit", nullable: false),
                    StatementDescriptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementDescriptorSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_NetworkStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_RiskLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_RiskScore = table.Column<long>(type: "bigint", nullable: true),
                    Outcome_SellerMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome_Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ChargeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubscriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountCaptured = table.Column<int>(type: "int", nullable: false),
                    AmountDue = table.Column<long>(type: "bigint", nullable: false),
                    AmountPaid = table.Column<long>(type: "bigint", nullable: false),
                    AmountRemaining = table.Column<long>(type: "bigint", nullable: false),
                    AmountShipping = table.Column<long>(type: "bigint", nullable: false),
                    ApplicationFeeAmount = table.Column<long>(type: "bigint", nullable: true),
                    AttemptCount = table.Column<long>(type: "bigint", nullable: false),
                    Attempted = table.Column<bool>(type: "bit", nullable: false),
                    AutoAdvance = table.Column<bool>(type: "bit", nullable: false),
                    BillingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Captured = table.Column<bool>(type: "bit", nullable: false),
                    CollectionMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    NextPaymentAttempt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidOutOfBand = table.Column<bool>(type: "bit", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostPaymentCreditNotesAmount = table.Column<long>(type: "bigint", nullable: false),
                    PrePaymentCreditNotesAmount = table.Column<long>(type: "bigint", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refunded = table.Column<bool>(type: "bit", nullable: false),
                    StartingBalance = table.Column<long>(type: "bigint", nullable: false),
                    StatementDescriptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<long>(type: "bigint", nullable: false),
                    SubtotalExcludingTax = table.Column<long>(type: "bigint", nullable: true),
                    Tax = table.Column<long>(type: "bigint", nullable: true),
                    Total = table.Column<long>(type: "bigint", nullable: false),
                    TotalExcludingTax = table.Column<long>(type: "bigint", nullable: true),
                    WebhooksDeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress_State = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PriceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubscriptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubscriptionItemId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    AmountExcludingTax = table.Column<long>(type: "bigint", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discountable = table.Column<bool>(type: "bit", nullable: false),
                    LiveMode = table.Column<bool>(type: "bit", nullable: false),
                    Proration = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitAmountExcludingTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    CaptureMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    InvoiceLineItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "IX_Discount_CouponId",
                schema: "Stripe",
                table: "Discount",
                column: "CouponId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Charge_Invoice_InvoiceId",
                schema: "Stripe",
                table: "Charge",
                column: "InvoiceId",
                principalSchema: "Stripe",
                principalTable: "Invoice",
                principalColumn: "Id");
        }
    }
}
