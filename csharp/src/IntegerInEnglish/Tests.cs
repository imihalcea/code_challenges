using NFluent;
using NUnit.Framework;

namespace CodeChallenges.IntegerInEnglish
{
    public class Tests
    {
        [TestCase(0, "Zero")]
        [TestCase(5, "Five")]
        [TestCase(10, "Ten")]
        [TestCase(15, "Fifteen")]
        [TestCase(20, "Twenty")]
        [TestCase(23, "Twenty Three")]
        [TestCase(100, "One Hundred")]
        [TestCase(101, "One Hundred One")]
        [TestCase(123, "One Hundred Twenty Three")]
        [TestCase(1234, "One Thousand Two Hundred Thirty Four")]
        [TestCase(1000, "One Thousand")]
        [TestCase(1001, "One Thousand One")]
        [TestCase(12345, "Twelve Thousand Three Hundred Forty Five")]
        [TestCase(10000, "Ten Thousand")]
        [TestCase(10001, "Ten Thousand One")]
        [TestCase(100000, "One Hundred Thousand")]
        [TestCase(1000000, "One Million")]
        [TestCase(1000010, "One Million Ten")]
        [TestCase(1234567, "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven")]
        [TestCase(1234567891, "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One")]
        public void examples(int n, string expected)
        {
            var s = new Solution();
            Check.That(s.NumberToWords(n)).IsEqualTo(expected);
        }

        [Test]
        public void test()
        {
            var p = new Solution.Packet(new[] { 1, 0, 0 }, 0);
            Check.That(p.ToString()).IsEqualTo("One");
        }
    }
}