#region Header

// /*
// Copyright (c) 2022 Rational Alliance. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TranslationPro.Testing.Extensions;

public static class ObjectExtensions
{
    public static StringContent SerializeToUTF8Json(this object model)
    {
        var str = JsonConvert.SerializeObject(model);

        return new StringContent(str,
            Encoding.UTF8, "application/json");
    }
}