using NUnit.Framework;
using static CodeChallenges.AddTwoNumbers.Solution;

namespace CodeChallenges.AddTwoNumbers;

public class Tests
{
    [TestCaseSource(nameof(Examples))]
    public void examples(int[] l1, int[] l2, int[] exp)
    {
        var l1Node = ArrayToListNode(l1);
        var l2Node = ArrayToListNode(l2);
        var actual = ListNodeToArray(Solution.AddTwoNumbers(l1Node, l2Node));
        Assert.That(actual, Is.EquivalentTo(exp));
    }
    
    [TestCaseSource(nameof(DecimalToArrayCases))]
    public void DecimalToArrayTests(int n, int[] exp)
    {
        Assert.That(DecimalToArray(n), Is.EquivalentTo(exp));
    }

    
    public static object[] Examples = new object[]
    {
        new[] { new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 } }
    };
    
    public static object[] DecimalToArrayCases = new object[]
    {
        new object[] { 342, new[] { 2, 4, 3 } },
        new object[] { 0, new[] { 0 } },
        new object[] { 1, new[] { 1 } },
        new object[] { 10, new[] { 0, 1 } },
        new object[] { 100, new[] { 0, 0, 1 } },
        new object[] { 1000, new[] { 0, 0, 0, 1 } },
        new object[] { 10000, new[] { 0, 0, 0, 0, 1 } },
        new object[] { 100000, new[] { 0, 0, 0, 0, 0, 1 } },
        new object[] { 1000000, new[] { 0, 0, 0, 0, 0, 0, 1 } },
        new object[] { 10000000, new[] { 0, 0, 0, 0, 0, 0, 0, 1 } },
        new object[] { 100000000, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 1 } },
        new object[] { 1000000000, new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 } },
    };

}