﻿#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using TranslationPro.Shared.Enums;

namespace TranslationPro.Shared.Interfaces;

public interface IEngine
{
    TranslationEngine Id { get; set; }
    string Name { get; set; }
    bool Enabled { get; set; }
}