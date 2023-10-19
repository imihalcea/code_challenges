using System;

namespace CodeChallenges.NextPrime;

public class Solution
{
    public static long NextPrime(long l)
    {
        Console.WriteLine("try to find next prime after {0}", l);
        var candidate = l;
        while (!IsPrime(candidate)) candidate += 2;

        return candidate;
    }
    
    public static bool IsPrime(long n){
        Console.WriteLine("check is prime {0}",n);
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