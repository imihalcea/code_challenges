using System;
using System.IO;
using System.Linq;
using NFluent;
using NUnit.Framework;
using static System.Int32;

namespace CodeChallenges.MissingElement;

public class Tests
{
    [TestCase(new []{0},1,1)]
    [TestCase(new []{0},4,4)]
    public void tests(int[] array, int k, int expected)
    {
        var solution = new Solution();
        Check.That(solution.MissingElement(array, k)).IsEqualTo(expected);
    }
    
    
    [TestCase(new []{4,7,9,10},1,5)]
    [TestCase(new []{4,7,9,10},3,8)]
    [TestCase(new []{1,2,4},3,6)]
    [TestCase(new []{746421,1033196,1647541,4775111,7769817,8030384},10,746431)]
    public void examples(int[] array, int k, int expected)
    {
        var solution = new Solution();
        Check.That(solution.MissingElement(array, k)).IsEqualTo(expected);
    }

    [TestCase("input.txt", 100_000, 100_651)]
    [TestCase("input2.txt", 100_000_000, 100_012_242)]
    public void huge_data_set(string filename, int k, int expected)
    {
        var input = File.ReadAllText($"MissingElement/{filename}")
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(Parse)
            .ToArray();
            
        var solution = new Solution();
        Check.That(solution.MissingElement(input, k)).IsEqualTo(expected);
    }
}