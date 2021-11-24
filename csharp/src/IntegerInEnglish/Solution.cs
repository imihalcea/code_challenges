using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenges.IntegerInEnglish
{
    public class Solution
    {
        public string NumberToWords(int num)
        {
            return string.Join(" ", EnumerateDigitsOf(num)
                .Chunk(3)
                .Select((chunk, idx) => new Packet(chunk, idx * 3))
                .Reverse()
                .Select(p=>p.ToString())
                .Where(s=>!string.IsNullOrEmpty(s))
                ).Trim();
        }
        
        private static IEnumerable<int> EnumerateDigitsOf(int n)
        {
            while (n >= 10)
            {
                var d = n % 10;
                n = n / 10;
                yield return d;
            }
            yield return n;
        }

 

        public record Packet(int[] digits, int startIndex)
        {
            public override string ToString()
            {
                
                var significantDigits = digits.Length == 1 ? digits : SignificantDigits(); 
                var pstr = significantDigits.Length switch
                {
                    1 => One(significantDigits),
                    2 => Two(significantDigits),
                    3 => Three(significantDigits),
                    _ => string.Empty
                };
                return pstr != string.Empty ? $"{pstr} {powers_ten.GetValueOrDefault(startIndex, "")}".Trim():pstr;
            }

            private string One(int[] digits)
            {
                return units[digits[0]];
            }

            private string Two(int[] digits)
            {
                var (tensDigit, unitDigit) = (digits[0],digits[1]);
                var n = tensDigit * 10 + unitDigit;
                return (tensDigit, unitDigit) switch
                {
                    (0,0) => String.Empty,
                    (1, _) => teens[n],
                    (0, _) => units[unitDigit],
                    (_, 0) => tens[n],
                    (_, _) => $"{tens[tensDigit * 10]} {units[unitDigit]}",
                };
            }

            private string Three(int[] digits)
            {
                return $"{units[digits[0]]} Hundred {Two(digits[1..])}".Trim();
            }

            private int[] SignificantDigits()
            {
                IEnumerable<int> EnumerateSignificantDigits()
                {
                    var isSignificant = false;
                    for (int i = digits.Length-1; i >= 0; i--)
                    {
                        var digit = digits[i];
                        if (digit != 0)
                        {
                            isSignificant = true;
                        }

                        if (isSignificant)
                            yield return digit;

                    }
                }
                return EnumerateSignificantDigits().ToArray();
            }
            
            private static Dictionary<int, string> units = new()
            {
                [0] = "Zero",
                [1] = "One", [2] = "Two", [3] = "Three",
                [4] = "Four", [5] = "Five", [6] = "Six",
                [7] = "Seven", [8] = "Eight", [9] = "Nine"
            };

            private static Dictionary<int, string> teens = new()
            {
                [10] = "Ten",
                [11] = "Eleven", [12] = "Twelve", [13] = "Thirteen",
                [14] = "Fourteen", [15] = "Fifteen", [16] = "Sixteen",
                [17] = "Seventeen", [18] = "Eighteen", [19] = "Nineteen"
            };

            private static Dictionary<int, string> tens = new()
            {
            
                [20] = "Twenty", [30] = "Thirty", [40] = "Forty",
                [50] = "Fifty", [60] = "Sixty", [70] = "Seventy",
                [80] = "Eighty", [90] = "Ninety"
            };

            private static Dictionary<int, string> powers_ten = new()
            {
                [3] = "Thousand",
                [6] = "Million",
                [9] = "Billion"
            };
        }
    }
}