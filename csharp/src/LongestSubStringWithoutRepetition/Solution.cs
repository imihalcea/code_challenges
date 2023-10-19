using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace CodeChallenges.LongestSubStringWithoutRepetition;

public class Solution
{
        
    public static int LengthOfLongestSubstring(string s)
    {
        var index = new Dictionary<char,int>();
        int count = 0, i = 0;
        for (var j = 0; j < s.Length; j++)
        {
            if (index.ContainsKey(s[j])) 
                i = Math.Max(i, index[s[j]]);
            count = Math.Max(count, j - i + 1);
            index[s[j]] = j + 1;
        }
        return count;
    }
}