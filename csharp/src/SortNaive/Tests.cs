using NUnit.Framework;
using NFluent;

namespace CodeChallenges.SortNaive;

public class Tests
{
    [TestCase(new []{1,3,2,4},new []{1,2,3,4})]
    public void SortNaiveTests(int[] src, int[] exp)
    {
        Solution.Sort(src);
        Check.That(src).IsEqualTo(exp);
    }
}