using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValheimManaPotion
{
    public static class Utils
    {
        public static string RemoveSpaces(string text)
        {
            return new Regex(@"\s+").Replace(text, "");
        }
        public static string RemoveSpacesToLower(string text)
        {
            return new Regex(@"\s+").Replace(text, "").ToLower();
        }
        public static string RemoveDollarSign(string text)
        {
            return text.Substring(1);
        }
        public static string GenerateItemId(string itemName)
        {
            return $"$item_{itemName}";
        }
        public static string GenerateItemDescId(string itemName)
        {
            return $"$item_{itemName}_desc";
        }
    }
}
