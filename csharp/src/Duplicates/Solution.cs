using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Duplicates;

public class Solution
{
    public static string CommonDuplicates(string[] strArray)
    {
        var parts = strArray.Select(s => s.Split(":")).ToArray();
        var shortest = parts.Min(p => p.Length);
        var common = new List<string>();
        for (var i = 0; i < shortest; i++)
        {
            var s = parts.Select(p => p[i]).ToHashSet();
            if (s.Count == 1)
                common.Add(s.First());
        }
        return string.Join(":", common);
    }
}