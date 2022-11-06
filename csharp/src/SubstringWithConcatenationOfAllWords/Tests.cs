using NFluent;
using NUnit.Framework;

namespace CodeChallenges.SubstringWithConcatenationOfAllWords;

[TestFixture]
public class Tests
{
    [TestCase("barfoothefoobarman", new []{"foo", "bar"}, new []{0,9})]
    [TestCase("wordgoodgoodgoodbestword", new []{"word","good","best","word"}, new int[]{})]
    [TestCase("lingmindraboofooowingdingbarrwingmonkeypoundcake", new []{"fooo","barr","wing","ding","wing"}, new int[]{13})]
    public void Test(string s, string[] words, int[] expected)
    {
        var sut = new Solution();
        Check.That(sut.FindSubstring(s, words)).ContainsExactly(expected);
    }
}