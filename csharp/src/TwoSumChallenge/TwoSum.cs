using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeChallenges.TwoSumChallenge
{
    /**
    //https://leetcode.com/problems/two-sum/

    Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    You may assume that each input would have exactly one solution, and you may not use the same element twice.
    You can return the answer in any order.

    2 <= nums.length <= 10^4
    -10^9 <= nums[i] <= 10^9
    -10^9 <= target <= 10^9
     */
    public static class TwoSum
    {
        public static int[] Optimized(int[] nums, int target)
        {
            var complements = new Dictionary<int, int>(nums.Length);

            for(var i=0; i<nums.Length; i++){
                var n = nums[i];
                if(complements.TryGetValue(n, out var j))
                {
                    return new []{j,i};
                }
                complements.TryAdd(target - n, i);
            }
            return Array.Empty<int>();
        } 

        public static int[] BruteForce(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = 0; j < nums.Length; j++)
                {
                    if (i == j) continue;
                    
                    if (nums[i] + nums[j] == target)
                        return new[] { i, j };
                }
            }
            return Array.Empty<int>();
        } 
    }
}