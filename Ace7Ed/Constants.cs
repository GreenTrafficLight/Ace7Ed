using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ace7Ed
{
    internal static class Constants
    {
        public static Dictionary<char, string> DatLanguages = new Dictionary<char, string>
        {
            ['A'] = "English",
            ['B'] = "Traditional Chinese",
            ['C'] = "French",
            ['D'] = "German",
            ['E'] = "Italian",
            ['F'] = "Japanese",
            ['G'] = "Korean",
            ['H'] = "European Spanish",
            ['I'] = "Latin American Spanish",
            ['J'] = "Polish",
            ['K'] = "Brazilian Portugese",
            ['L'] = "Russian",
            ['M'] = "Simplified Chinese",
        };

        public static char[] DatLetters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M'];
    }
}
