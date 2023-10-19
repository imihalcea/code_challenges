/*using System;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace CodeChallenges.Benchmark
{
    [SimpleJob(RuntimeMoniker.Net60)]
    public class TwoSumBench
    {
        private int[] _nums;
        private int _target;

        [GlobalSetup]
        public void Setup()
        {
            _nums = File.ReadLines("TwoSumChallenge/10_000.txt")
                .Select(int.Parse)
                .ToArray();
            _target = _nums[^2] + _nums[^1];
            Console.WriteLine($"Loaded {_nums.Length} data set");
        }

        [Benchmark]
        public int[] TwoSumOptimized() => TwoSumChallenge.TwoSum.Optimized(_nums, _target);
        
        [Benchmark]
        public int[] TwoSumBruteForce() => TwoSumChallenge.TwoSum.BruteForce(_nums, _target);

    }
}*/