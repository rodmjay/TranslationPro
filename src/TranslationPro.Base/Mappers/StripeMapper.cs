#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using AutoMapper;
using TranslationPro.Base.Entities;
using TranslationPro.Shared.Models;

namespace TranslationPro.Base.Mappers;

public class StripeMapper : Profile
{
    public StripeMapper()
    {
        CreateMap<Subscription, SubscriptionOutput>()
            .ForMember(x=>x.Id, opt=>opt.MapFrom(x=>x.SubscriptionId))
            .ForMember(x=>x.Invoices, opt=>opt.MapFrom(x=>x.Invoices))
            .ForMember(x=>x.Items, opt=>opt.MapFrom(x=>x.Items));

        CreateMap<Invoice, InvoiceOutput>()
            .ForMember(x=>x.Id, opt=>opt.MapFrom(x=>x.Id))
            .ForMember(x=>x.Items, opt=>opt.MapFrom(x=>x.Items))
            .ForMember(x=>x.Lines, opt=>opt.MapFrom(x=>x.Lines));

        CreateMap<InvoiceItem, InvoiceItemOutput>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));

        CreateMap<UsageRecordSummary, UsageRecordSummaryOutput>();

        CreateMap<InvoiceLine, InvoiceLineOutput>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id));

        CreateMap<SubscriptionItem, SubscriptionItemOutput>()
            .ForMember(x=>x.Id, opt=>opt.MapFrom(x=>x.StripeItemId))
            .ForMember(x=>x.Product, opt=>opt.MapFrom(x=>x.Product))
            .ForMember(x=>x.UsageRecords, opt=>opt.MapFrom(x=>x.UsageRecordSummaries))
            .ForMember(x=>x.Plan, opt=>opt.MapFrom(x=>x.Plan));

        CreateMap<Plan, PlanOutput>()
            .ForMember(x=>x.Active, opt=>opt.MapFrom(x=>x.Active))
            .ForMember(x=>x.Amount, opt=>opt.MapFrom(x=>x.Amount))
            .ForMember(x=>x.Interval, opt=>opt.MapFrom(x=>x.Interval))
            .ForMember(x=>x.IntervalCount, opt=>opt.MapFrom(x=>x.IntervalCount))
            .ForMember(x=>x.AmountDecimal, opt=>opt.MapFrom(x=>x.AmountDecimal));

        CreateMap<Product, ProductOutput>()
            .ForMember(x=>x.Name, opt=>opt.MapFrom(x=>x.Name))
            .ForMember(x=>x.Type, opt=>opt.MapFrom(x=>x.Type))
            .ForMember(x=>x.Id, opt=>opt.MapFrom(x=>x.Id));
    }
}