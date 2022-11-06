using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.SubstringWithConcatenationOfAllWords;

public class Solution
{
    private record WordIndex(string word, int count);
    public IList<int> FindSubstring(string s, string[] words)
    {
        var wordsIndex = WordsIndex(words);
        var wordLen = words[0].Length;
        var concatLen = words.Length * wordLen;
        var slices = Slice(s, 1, concatLen);
        var result = new List<int>();
        foreach (var (slice, index) in slices)
        {
            if (wordsIndex.SetEquals(ToWords(slice, wordLen)))
            {
                result.Add(index);
            }
        }
        return result;
    }


    private IEnumerable<(string slice, int index)> Slice(string s, int slide, int take)
    {
        var head = 0;
        while (head+take<=s.Length)
        {
            yield return (s.Substring(head, take), head);
            head += slide;
        }
    }

    private static HashSet<WordIndex> WordsIndex(string[] words) => 
        words.GroupBy(w => w).Select(grp=> new WordIndex(grp.Key, grp.Count())).ToHashSet();

    
    private HashSet<WordIndex> ToWords(string s, int wordLen) => 
        WordsIndex(Slice(s, wordLen, wordLen).Select(it => it.slice).ToArray());
}