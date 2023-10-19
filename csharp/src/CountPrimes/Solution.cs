using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace CodeChallenges.CountPrimes;

public class Solution {
    
    public int CountPrimes(int n) {
        if(n < 2) return 0;
        var notPrimes = new BitArray(n, false);
        var notPrimesCnt = 2; // 0 and 1
        for (var i = 2; i < Math.Sqrt(n); i++)
        {
            if (notPrimes[i]) continue;
            for(var j = i * i; j < n; j += i){
                //if(!notPrimes[j]) notPrimesCnt++;
                notPrimes[j] = true;
                notPrimesCnt++;
            }
        }
        return n - notPrimesCnt;
    }
    
    public static IEnumerable<int> NotPrimes(int multiple, int n) {
        for(var i = multiple; i < n; i += multiple){
            yield return i;
        }
    }
    
    public static int[] ListPrimes(int n) {
        return Enumerable.Range(0,n).Where(IsPrime).ToArray();
    }

    public static bool IsPrime(int n){
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