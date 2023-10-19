using System;
using NUnit.Framework;

namespace CodeChallenges.NextPrime;

public class Tests
{
    [Test]
    public void test()
    {
        var n = Solution.NextPrime(647788874263035981);
        Console.WriteLine(n);
        Assert.That(n, Is.EqualTo(42L));
        
    }
}