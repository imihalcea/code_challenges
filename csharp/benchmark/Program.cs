using BenchmarkDotNet.Running;
using CodeChallenges.Benchmark;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<TwoSumBench>();
    }
}