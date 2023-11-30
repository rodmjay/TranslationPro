using TranslationPro.Shared.Models;

namespace TranslationPro.Blazor.Extensions
{
    public static class ConsumptionExtensions
    {
        public static Dictionary<DateTime, ConsumptionInfo> NormalizeDates(
            this Dictionary<DateTime, ConsumptionInfo> dictionary)
        {
            if (dictionary.Keys.Count == 0)
            {
                return dictionary;
            }

            var minDate = dictionary.Keys.Min();
            var maxDate = dictionary.Keys.Max();
            
            TimeSpan span = maxDate - minDate;

            var currentDate = minDate;

            while (currentDate <= maxDate)
            {
                if (!dictionary.ContainsKey(currentDate))
                {
                    dictionary.Add(currentDate, new ConsumptionInfo());
                }

                currentDate = currentDate.AddDays(1);
            }

            return dictionary.OrderBy(x=>x.Key).ToDictionary(x=>x.Key, x=>x.Value);
        }
    }
}
