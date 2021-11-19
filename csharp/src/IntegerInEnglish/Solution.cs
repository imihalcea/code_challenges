using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.IntegerInEnglish
{
    public class Solution
    {
        
        public string NumberToWords(int num)
        {
            var digits = EnumerateDigitsOf(num).ToArray();
            return digits.Length switch
            {
                1 => SayUnit(digits[0]),
                2 => SayTens(digits[0], digits[1]),
                _ => string.Empty
            };
        }

        private string SayTens(int tensDigit, int unitDigit)
        {
            var n = tensDigit * 10 + unitDigit;
            return (tensDigit, unitDigit) switch
            {
                (1,_) => teens[n],
                (_,0) => tens[n],
                (_,_) => $"{tens[tensDigit*10]} {units[unitDigit]}",
            };
        }

        private string SayUnit(int digit) => units[digit];
        
        private static IEnumerable<int> EnumerateDigitsOf(int n)
        {
            IEnumerable<int> ToDigits(int i)
            {
                while (i >= 10)
                {
                    var d = i % 10;
                    i = i / 10;
                    yield return d;
                }

                yield return i;
            }

            return ToDigits(n).Reverse();
        }
        
        private static Dictionary<int, string> units = new()
        {
            [0] = "Zero",
            [1] = "One", [2]= "Two", [3]= "Three", 
            [4] = "Four", [5] = "Five", [6] = "Six", 
            [7]= "Seven", [8]= "Eight", [9] = "Nine"
        };
        
        private static Dictionary<int, string> teens = new()
        {
            [11] = "Eleven", [12]= "Twelve", [13]= "Thirteen", 
            [14] = "Fourteen", [15] = "Fifteen", [16] = "Sixteen", 
            [17]= "Seventeen", [18]= "Eighteen", [19] = "Nineteen"
        };

        private static Dictionary<int, string> tens = new()
        {
            [20] = "Twenty", [30] = "Thirty", [40] = "Forty",
            [50] = "Fifty", [60] = "Sixty", [70] = "Seventy",
            [80] = "Eighty", [90] = "Ninety"
        };

        private static Dictionary<int, string> toto = new()
        {
            [2] = "Hundred",
            [4] = "Thousand",
            [6] = "Million",
            [9] = "Billion"
        };

    }
}