﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;

namespace TranslationPro.Shared.Interfaces;

public interface ITranslation
{
    string Text { get; set; }
    public string LanguageId { get; set; }
    DateTime? TranslationDate { get; set; }
}