#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace TemplateBase.Common.Caching
{
    [ExcludeFromCodeCoverage]
    public class CacheSettings
    {
        public TimeSpan? DefaultExpiration { get; set; }
    }
}