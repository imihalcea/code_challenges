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
        
        private static IEnumerable<byte> EnumerateDigitsOf(int n)
        {
            while (n >= 10)
            {
                var d = n % 10;
                n = n / 10;
                yield return (byte)d;
            }
            yield return (byte)n;
        }

        public record Packet(byte[] digits, int startIndex)
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

            private string One(byte[] digits)
            {
                return units[digits[0]];
            }

            private string Two(byte[] digits)
            {
                var (tensDigit, unitDigit) = (digits[0],digits[1]);
                return (tensDigit, unitDigit) switch
                {
                    (0, 0) => String.Empty,
                    (1, _) => teens[unitDigit],
                    (0, _) => units[unitDigit],
                    (_, 0) => tens[tensDigit],
                    (_, _) => $"{tens[tensDigit]} {units[unitDigit]}",
                };
            }

            private string Three(byte[] digits)
            {
                return $"{units[digits[0]]} Hundred {Two(digits[1..])}".Trim();
            }

            private byte[] SignificantDigits()
            {
                IEnumerable<byte> EnumerateSignificantDigits()
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
            
            private static Dictionary<byte, string> units = new()
            {
                [0] = "Zero",
                [1] = "One", [2] = "Two", [3] = "Three",
                [4] = "Four", [5] = "Five", [6] = "Six",
                [7] = "Seven", [8] = "Eight", [9] = "Nine"
            };

            private static Dictionary<byte, string> teens = new()
            {
                [0] = "Ten",
                [1] = "Eleven", [2] = "Twelve", [3] = "Thirteen",
                [4] = "Fourteen", [5] = "Fifteen", [6] = "Sixteen",
                [7] = "Seventeen", [8] = "Eighteen", [9] = "Nineteen"
            };

            private static Dictionary<byte, string> tens = new()
            {
            
                [2] = "Twenty", [3] = "Thirty", [4] = "Forty",
                [5] = "Fifty", [6] = "Sixty", [7] = "Seventy",
                [8] = "Eighty", [9] = "Ninety"
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