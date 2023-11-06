#region Header Info

// Copyright 2023 Rod Johnson.  All rights reserved

#endregion

using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TranslationPro.Shared.Extensions;

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