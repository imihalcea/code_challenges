namespace CodeChallenges.MissingElement;

public class Solution
{
  public int MissingElement(int[] nums, int k)
  {
    int missingAtIndex(int i) => nums[i] - nums[0] - i;

    int finish(int idx) =>
      missingAtIndex(idx) >= k
        ? nums[idx - 1] + k - missingAtIndex(idx - 1)
        : nums[idx] + k - missingAtIndex(idx);

    int search(int low, int high)
    {
      var mid = (high + low)/ 2;
      return (high - low) switch
      {
        0 => finish(low),
        1 => missingAtIndex(high) < k? finish(high):finish(low),
        _ => missingAtIndex(mid) >= k ? search(low, mid) : search(mid+1, high)
      };
    }
    return search(0, nums.Length-1);
  }
    
}