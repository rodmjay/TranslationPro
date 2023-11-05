using Newtonsoft.Json;
using Stripe;
using TranslationPro.Base.Common.Extensions;

namespace TranslationPro.Base.Stripe.Extensions;

public static class EventExtensions
{
    public static T Deserialize<T>(this Event input)
    {
        return JsonConvert.DeserializeObject<T>(input.Data.Object.ToJson());
    }
}