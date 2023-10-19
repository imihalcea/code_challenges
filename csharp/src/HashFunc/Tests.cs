using System;
using NUnit.Framework;

namespace CodeChallenges.HashFunc;

public class Tests
{
    [Test]
    public void test()
    {
        Console.WriteLine(DateTime.Now.AddMonths(30 * 12).Ticks);
        Assert.True(long.MaxValue == TimeSpan.MaxValue.Ticks);
    }
}