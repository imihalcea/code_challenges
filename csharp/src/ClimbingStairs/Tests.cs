using NFluent;
using NUnit.Framework;

namespace CodeChallenges.ClimbingStairs;

[TestFixture]
public class Tests
{
    [TestCase(1,1)]
    [TestCase(2,2)]
    [TestCase(3,3)]
    public void examples(int stairs, int expected)
    {
        var sut = new Solution();
        Check.That(sut.ClimbStairs(stairs)).IsEqualTo(expected);
    }
}