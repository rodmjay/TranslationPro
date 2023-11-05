#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.ComponentModel.DataAnnotations;

namespace TranslationPro.Shared.Models;

public class ApplicationOptions
{
    [Required][MinLength(3)] public string Name { get; set; }

}