namespace CodeChallenges.MissingNumber;

public class Solution
{
    public int MissingElement(int[] nums, int k)
    {
        for(int i=1;i<nums.Length;i++)
        {
            var diff=nums[i]-nums[i-1]-1;
            if(diff>=k) return nums[i-1]+k;
            k-=diff;
        }

        return nums[^1] + k;

    }
}