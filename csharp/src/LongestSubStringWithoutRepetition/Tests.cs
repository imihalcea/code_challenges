using NUnit.Framework;

namespace CodeChallenges.LongestSubStringWithoutRepetition;

public class Tests
{
    [TestCaseSource(nameof(Cases))] 
    public void examples(string s, int exp)
    {
        Assert.That(Solution.LengthOfLongestSubstring(s), Is.EqualTo(exp));
    }
    public static object[] Cases = new[]
    {
        new object[] { "abcdb", 4 },
        new object[] { "bbbbb", 1 },
        new object[] { "pwwkew", 3 },
        new object[] { "svsg", 3 },
        new object[] { " ", 1 },
        new object[] { "", 0 },
    };
}