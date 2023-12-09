#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;

namespace TranslationPro.Shared.Models;

public class InvoiceLineOutput
{
    public string Id { get; set; }
    public long Amount { get; set; }
    public long? AmountExcludingTax { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public DateTime PeriodEnd { get; set; }
    public DateTime PeriodStart { get; set; }
    public string Type { get; set; }
    public long? Quantity { get; set; }
    public decimal? UnitAmountExcludingTax { get; set; }
}