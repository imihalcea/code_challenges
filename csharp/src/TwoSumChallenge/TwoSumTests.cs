using NFluent;
using NUnit.Framework;

namespace CodeChallenges.TwoSumChallenge
{
    public class TwoSumTests
    {
        [TestCase(new int[]{2,7,11,15},9,new int[]{0,1})]
        [TestCase(new int[]{1,6,2,4},6,new int[]{2,3})]
        public void TwoSum(int[] nums, int target, int[] expected)
        {
            var output = TwoSumChallenge.TwoSum.Optimized(nums, target);
            Check.That(output).ContainsExactly(expected);
        }
    }
}