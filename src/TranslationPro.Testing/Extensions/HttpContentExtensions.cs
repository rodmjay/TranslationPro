#region Header

// /*
// Copyright (c) 2022 Rational Alliance. All rights reserved.
// Author: Rod Johnson, Architect, Solution Stream
// */

#endregion

using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TranslationPro.Testing.Extensions;

public static class HttpContentExtensions
{
    public static T DeserializeObject<T>(this HttpContent content)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Include
            
        };

        var jsonContent = content.ReadAsStringAsync().Result;

        var obj = JsonConvert.DeserializeObject<T>(jsonContent);
        return obj;
    }
}