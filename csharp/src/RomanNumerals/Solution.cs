using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.RomanNumerals
{
    public static class Solution
    {
        private static readonly Dictionary<int, (string, string, string)> RULES_BY_POWER_OF_TEN = new()
        {
            [0] = ("I", "V", "X"),
            [1] = ("X", "L", "C"),
            [2] = ("C", "D", "M"),
            [3] = ("M", "M", "M")
        };
        public static string IntToRoman(int n)
        {
            if (n is <= 0 or > 3999) return string.Empty;
            
            var parts = EnumerateDigitsOf(n)
                        .Select((digit, powerOfTen) => EncodeDigit(digit, RULES_BY_POWER_OF_TEN[powerOfTen]))
                        .Reverse();
            
            return string.Concat(parts);
        }
        
        private static string EncodeDigit(int digit, (string, string, string) encodingSymbols)
        {
            var (first, middle, end) = encodingSymbols;
            return digit switch
            {
                1 => $"{first}",
                2 => $"{first}{first}",
                3 => $"{first}{first}{first}",
                4 => $"{first}{middle}",
                5 => $"{middle}",
                6 => $"{middle}{first}",
                7 => $"{middle}{first}{first}",
                8 => $"{middle}{first}{first}{first}",
                9 => $"{first}{end}",
                _ => string.Empty
            };
        }

        private static IEnumerable<int> EnumerateDigitsOf(int n)
        {
            while (n>=10)
            {
                var d = n % 10;
                n = n / 10;
                yield return d;
            }
            yield return n;
        }

    }
}