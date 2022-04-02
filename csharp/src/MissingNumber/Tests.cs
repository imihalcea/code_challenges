using NFluent;
using NUnit.Framework;

namespace CodeChallenges.MissingNumber;

public class Tests
{
    [TestCase(new []{0},1,1)]
    [TestCase(new []{0},1,1)]
    [TestCase(new []{1,2,4},3,6)]
    [TestCase(new []{4,7,9,10},1,5)]
    [TestCase(new []{4,7,9,10},3,8)]
    [TestCase(new []{1,2,20,21},3,5)]
    [TestCase(new []{1,3,20,21},3,5)]
    [TestCase(new []{1,2,10},3,5)]

    public void examples(int[] nums, int k, int expected)
    {
        var sol = new Solution();
        Check.That(sol.MissingElement(nums, k)).IsEqualTo(expected);
    }
}