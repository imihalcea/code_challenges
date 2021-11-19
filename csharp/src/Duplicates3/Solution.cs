using System;
using System.Collections.Generic;

namespace CodeChallenges
{
    public static class Solution
    {
        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (k == 0) return false;

            var valuesIndex = new SortedList<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var candidate = nums[i];


                if (!valuesIndex.TryAdd(candidate, i))
                    return true;


                var v = valuesIndex.IndexOfKey(candidate);
                if (v > 0 && Math.Abs((long)valuesIndex.Keys[v - 1] - (long)candidate) <= t)
                    return true;

                if (v < valuesIndex.Count - 1 && Math.Abs((long)valuesIndex.Keys[v + 1] - (long)candidate) <= t)
                    return true;

                if (valuesIndex.Count > k) valuesIndex.Remove(nums[i - k]);
            }

            return false;
        }

        public static bool ContainsNearbyAlmostDuplicate2(int[] nums, int k, int t)
        {
            if (k == 0) return false;

            var valuesIndex = new SortedSet<long>();

            for (var i = 0; i < nums.Length; i++)
            {
                var candidate = nums[i];

                if (valuesIndex.GetViewBetween((long)candidate - t, (long)candidate + t).Count != 0)
                    return true;

                valuesIndex.Add(candidate);

                if (i >= k) valuesIndex.Remove(nums[i - k]);
            }

            return false;
        }
    }
}