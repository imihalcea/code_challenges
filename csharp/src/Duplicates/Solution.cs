using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Duplicates;

public class Solution
{
    public static string CommonDuplicates(string[] strArray)
    {
        var parts = strArray.Select(s => s.Split(":")).ToArray();
        var counters = new Dictionary<(string,int), int>();
        foreach (var part in parts)
        {
            for (var index = 0; index < part.Length; index++)
            {
                var p = (part[index], index);
                if (counters.ContainsKey(p))
                    counters[p]++;
                else
                    counters.Add(p, 1);
            }
        }
        var commons = counters.Where(c => c.Value == parts.Length).Select(c => c.Key.Item1).ToArray();
        return string.Join(":", commons);
    }
}