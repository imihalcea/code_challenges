using System;

namespace CodeChallenges.NextPrime;

public class Solution
{
    public static long NextPrime(long candidate)
    {
        do candidate = NextCandidate(candidate);
        while (!IsPrime(candidate));
        return candidate;
    }

    private static long NextCandidate(long candidate)
    {
        return (candidate % 2) switch
        {
            0 => candidate + 1,
            _ => candidate + 2
        };
    }

    public static bool IsPrime(long n){
        if(n < 2) return false;
        if(n == 2) return true;
        for(var d = 3; d * d <= n; d += 2){
            if(n % d == 0){
                return false;
            }
        }
        return true; 
    }
}