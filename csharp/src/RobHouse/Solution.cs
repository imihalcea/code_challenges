using System;

namespace CodeChallenges.RobHouse;

public class Solution
{
    public int Rob(int[] nums)
    {
        var n = nums.Length;
        if (n == 0)
            return 0;
        var maxRobbed = new int[n+1];
        maxRobbed[n] = 0;
        maxRobbed[n - 1] = nums[n - 1];
        for (var i = n - 2; i >= 0; i--)
        {
            maxRobbed[i] = Math.Max(maxRobbed[i + 1], maxRobbed[i + 2] + nums[i]);
        }
        return maxRobbed[0];
    }
}