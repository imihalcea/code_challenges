using NFluent;
using NUnit.Framework;

namespace CodeChallenges.MaxPointOnALine;

public class Tests
{
    [Test]
    public void test1()
    {
        var input = new[] { new []{ 1, 1 }, new []{ 3, 2 }, new []{ 5, 3 }, new []{ 4, 1 }, new []{ 2, 3 }, new []{ 1, 4 } };
        Check.That(Solution.MaxPoints(input)).IsEqualTo(4);
    }
    
    [Test]
    public void test2()
    {
        var input = new[] { new []{ 1, 1 }, new []{ 2, 2 }, new []{ 3, 3 } };
        Check.That(Solution.MaxPoints(input)).IsEqualTo(3);
    }
    
    [Test]
    public void test3()
    {
        //[[0,0],[4,5],[7,8],[8,9],[5,6],[3,4],[1,1]]
        var input = new[] { new []{ 0, 0 }, new []{ 4, 5 }, new []{ 7, 8 }, new []{ 8,9 }, new []{5,6}, new []{3,4}, new []{1,1} };
        Check.That(Solution.MaxPoints(input)).IsEqualTo(5);
    }
}