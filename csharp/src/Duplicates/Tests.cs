using NUnit.Framework;

namespace CodeChallenges.Duplicates;

public class Tests
{
    [TestCaseSource(nameof(testCases))]
    public void Test1(string[] strArray, string expected)
    {
        var actual = Solution.CommonDuplicates(strArray);
        Assert.AreEqual(expected, actual);
    }
    
    private static object[] testCases = new object[]
    {
        new object[] {new string[] {"foo:bar:baz", "foo:bar:qix", "foo:bar:pix"}, "foo:bar"},
        new object[] {new string[] {"foo:bar:baz", "foo:bar:qix", "foo:moo"}, "foo"},
        new object[] {new string[] {"foo:bar:baz", "foo:bar:qix", "foo:moo:bar"}, "foo"},
        new object[] {new string[] {"boom:bim", "pif:paf", "bim:bam"}, ""},
    };
}