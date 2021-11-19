using NFluent;
using NUnit.Framework;

namespace CodeChallenges
{
    
    public class Tests
    {

        [TestCase(new[] { 1, 2, 3, 1 }, 3, 0, true)]
        [TestCase(new[] { 1, 0, 1, 1 }, 1, 2, true)]
        [TestCase(new[] { 1, 5, 9, 1, 5, 9 }, 2, 3, false)]
        [TestCase( new [] { -2147483648,2147483647 }, 1, 1, false)]
        [TestCase( new [] { 4,1,6,3 }, 100, 1, true)]

        public void examples(int[] input, int k, int t, bool expected)
        {
            Check.That(Solution.ContainsNearbyAlmostDuplicate(input, k, t)).IsEqualTo(expected);
        }
        
        [TestCase(new[] { 1, 2, 3, 1 }, 3, 0, true)]
        [TestCase(new[] { 1, 0, 1, 1 }, 1, 2, true)]
        [TestCase(new[] { 1, 5, 9, 1, 5, 9 }, 2, 3, false)]
        [TestCase( new [] { -2147483648,2147483647 }, 1, 1, false)]
        [TestCase( new [] { 4,1,6,3 }, 100, 1, true)]

        public void examples2(int[] input, int k, int t, bool expected)
        {
            Check.That(Solution.ContainsNearbyAlmostDuplicate2(input, k, t)).IsEqualTo(expected);
        }
        
    }
}