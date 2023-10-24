#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System.Diagnostics.CodeAnalysis;

namespace TranslationPro.Base.Common.Data;

[ExcludeFromCodeCoverage]
public class DatabaseSettings
{
    public int Timeout { get; set; }
    public string ConnectionStringName { get; set; }
}