using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationPro.Testing.Helpers
{
    public static class RandomValueHelper
    {
        public static string GenerateRandomCompanyName()
        {
            string[] adjectives = { "Dynamic", "Innovative", "Global", "Tech", "Creative", "Alpha", "Omega", "Pioneer", "Vivid", "Epic" };
            string[] nouns = { "Solutions", "Systems", "Enterprises", "Tech", "Labs", "Innovations", "Ventures", "Corp", "Industries", "Group" };

            Random random = new Random();
            string adjective = adjectives[random.Next(adjectives.Length)];
            string noun = nouns[random.Next(nouns.Length)];

            return $"{adjective} {noun}";
        }
    }
}
