﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System;
using Newtonsoft.Json;
using TranslationPro.Shared.Interfaces;

namespace TranslationPro.Shared.Models;

public class MachineTranslationOutput : ITranslation
{
    public string Text { get; set; }
    public string Engine { get; set; }
    public string LanguageId { get; set; }

    public DateTime? TranslationDate { get; set; }
}