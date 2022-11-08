namespace CodeChallenges.ClimbingStairs;

public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n <= 2)
            return n;
        var modes = new int[n+1];
        modes[0] = 0;
        modes[1] = 1;
        modes[2] = 2;
        for (var i = 3; i <= n; i++)
        {
            modes[i] = modes[i - 1] + modes[i - 2];
        }
        return modes[^1];
    }
}