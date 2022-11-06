namespace CodeChallenges.SortNaive;

public static class Solution
{
    public static void Sort(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        for (var j = 0; j < array.Length; j++)
            if (array[i] < array[j])
                Swap(array, i, j);
    }

    private static void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }
}