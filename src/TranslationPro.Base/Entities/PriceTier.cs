#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

namespace TranslationPro.Base.Entities;

public class PriceTier
{
    public long? FlatAmount { get; set; }
    
    public decimal? FlatAmountDecimal { get; set; }
    
    public long? UnitAmount { get; set; }
    
    public decimal? UnitAmountDecimal { get; set; }
    public long? UpTo { get; set; }
}