using System;
using NUnit.Framework;

namespace CodeChallenges.NextPrime;

public class Tests
{
    [TestCase(7, 11)]
    [TestCase(8, 11)]
    [TestCase(11, 13)]
    public void test(int n, int expected)
    {
        var actual = Solution.NextPrime(n);
        Assert.AreEqual(expected, actual);
    }
}