﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion


namespace TranslationPro.Shared.Models;

public class ApplicationCreateOptions : ApplicationOptions
{
    public string[] Languages { get; set; }
}