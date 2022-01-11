using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Diagnostics.Runtime.ICorDebug;

namespace CodeChallenges.MaxPointOnALine;

public class Solution
{
    public static int MaxPoints(int[][] points)
    {
        if (points.Length == 1) return 1;
        var slopeIndex = new Dictionary<(float,float), HashSet<(int, int)>>();
        var verticalIndex = new Dictionary<int, HashSet<(int, int)>>();
        var horizontalIndex = new Dictionary<int, HashSet<(int, int)>>();
        var allPairs = 
            from p1 in points
            from p2 in points
            where !(p1[0] == p2[0] && p1[1] == p2[1])
            select (p1, p2);

        foreach (var (p1, p2) in allPairs)
        {
            var (x1, y1) = (p1[0],p1[1]);
            var (x2, y2) = (p2[0],p2[1]);
            var (dx, dy) = (Convert.ToSingle(x2-x1), Convert.ToSingle(y2 - y1));

            switch (dx, dy)
            {
                case (_,_) when dx !=0 && dy!=0:
                    //y = slope * x + p 
                    var slope = dy / dx;
                    var p = y2 - slope * x2;
                    slopeIndex.UpdateIndex((slope,p), ((x1,y1),(x2,y2)));
                    break;
                case (0, _):
                    verticalIndex.UpdateIndex(x1,((x1,y1),(x2,y2)));
                    break;
                case (_,0):
                    horizontalIndex.UpdateIndex(y1, ((x1,y1),(x2,y2)));
                    break;
            }
        }

        var sMx = slopeIndex.Any()? slopeIndex.Select(kvp => kvp.Value.Count).Max():0;
        var vMx = verticalIndex.Any()? verticalIndex.Select(kvp => kvp.Value.Count).Max():0;
        var hMx = horizontalIndex.Any()? horizontalIndex.Select(kvp => kvp.Value.Count).Max():0;
        return (new[]{sMx,vMx,hMx}).Max();
    }
}

public static class Ext
{
    public static void UpdateIndex<TKey>(this Dictionary<TKey, HashSet<(int, int)>> index, TKey key,
        ((int, int) p1, (int, int) p2) pair)
    {
        index.AddOrUpdate(key,
            new HashSet<(int, int)>(){pair.p1, pair.p2},
            set => { 
                set.Add(pair.p1);
                set.Add(pair.p2);
                return set;
            });
    }
    public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> @this, TKey key, TValue newValue,
        Func<TValue, TValue> update)
    {
        if (@this.TryGetValue(key, out var value))
        {
            @this[key] = update(value);
        }
        else
        {
            @this.Add(key, newValue);
        }
    }
}