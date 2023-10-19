using NUnit.Framework;

namespace CodeChallenges.CountPrimes;

public class Tests
{
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, false)]
    [TestCase(5, true)]
    [TestCase(6, false)]
    [TestCase(7, true)]
    [TestCase(8, false)]
    [TestCase(9, false)]
    public void IsPrimeTests(int n, bool exp)
    {
        Assert.That(Solution.IsPrime(n), Is.EqualTo(exp));
    }

    [TestCase(10, new[] {2, 3, 5, 7})]
    public void ListPrimesTests(int n, int[] exp)
    {
        Assert.That(Solution.ListPrimes(n), Is.EquivalentTo(exp));
    }
}