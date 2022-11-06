using NFluent;
using NUnit.Framework;

namespace CodeChallenges.RomanNumerals
{
    public class Tests
    {
        [TestCase(0,"")]
        [TestCase(-1,"")]
        [TestCase(4000,"")]
        [TestCase(1,"I")]
        [TestCase(2,"II")]
        [TestCase(4,"IV")]
        [TestCase(5,"V")]
        [TestCase(6,"VI")]
        [TestCase(9,"IX")]
        [TestCase(10,"X")]
        [TestCase(58,"LVIII")]
        [TestCase(1994,"MCMXCIV")]
        public void samples(int n, string expected)
        {
            Check.That(Solution.IntToRoman(n)).IsEqualTo(expected);
        }
    }
}