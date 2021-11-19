using NFluent;
using NUnit.Framework;

namespace CodeChallenges.IntegerInEnglish
{
    public class Tests
    {
        [TestCase(0, "Zero")]
        [TestCase(5, "Five")]
        [TestCase(15, "Fifteen")]
        [TestCase(20, "Twenty")]
        [TestCase(23, "Twenty Three")]
        [TestCase(123, "One Hundred Twenty Three")]
        public void examples(int n, string expected)
        {
            var s = new Solution();
            Check.That(s.NumberToWords(n)).IsEqualTo(expected);
        }
    }
}