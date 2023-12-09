#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using System.Collections.Generic;

namespace TranslationPro.Shared.Models;

public class SubscriptionOutput
{
    public SubscriptionOutput()
    {
        Items = new List<SubscriptionItemOutput>();
        Invoices = new List<InvoiceOutput>();
    }

    public string Id { get; set; }

    public List<SubscriptionItemOutput> Items { get; set; }
    public List<InvoiceOutput> Invoices { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndedAt { get; set; }
    public long? DaysUntilDue { get; set; }
    public DateTime CurrentPeriodStart { get; set; }
    public DateTime CurrentPeriodEnd { get; set; }
    public DateTime Created { get; set; }
    public string CollectionMethod { get; set; }
    public DateTime? CanceledAt { get; set; }
    public bool CancelAtPeriodEnd { get; set; }
    public DateTime? CancelAt { get; set; }
}