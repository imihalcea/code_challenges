using NFluent;
using NUnit.Framework;

namespace CodeChallenges.RobHouse;

public class Tests
{
    [TestCase(new int[]{}, 0)]
    [TestCase(new []{1,2,3,1}, 4)]
    [TestCase(new []{2,7,9,3,1}, 12)]
    public void examples(int[] nums, int expected)
    {
        var sut = new Solution();
        Check.That(sut.Rob(nums)).IsEqualTo(expected);
    }
}