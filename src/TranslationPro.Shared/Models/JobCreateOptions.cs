#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;

namespace TranslationPro.Base.Services;

public class JobCreateOptions
{
    public int[] Phrases { get; set; }
    public string[] Languages { get; set; }
}