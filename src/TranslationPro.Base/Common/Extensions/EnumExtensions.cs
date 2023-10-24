#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.ComponentModel;

namespace TranslationPro.Base.Common.Extensions;

public static class EnumExtensions
    // ReSharper restore CheckNamespace
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        var attributes = (DescriptionAttribute[]) field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }

    public static string GetName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        return field.Name;
    }
}