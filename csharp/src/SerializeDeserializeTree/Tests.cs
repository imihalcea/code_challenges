using NFluent;
using NUnit.Framework;

namespace CodeChallenges.SerializeDeserializeTree;

public class Tests
{
    [Test]
    public void serialize_tests()
    {
        var root = new TreeNode(1);
        var tn2 = new TreeNode(2);
        var tn3 = new TreeNode(3);
        var tn4 = new TreeNode(4);
        var tn5 = new TreeNode(5);

        tn3.left = tn4;
        tn3.right = tn5;
        root.left = tn2;
        root.right = tn3;

        var c = new Codec();
        var s = c.serialize(root);
        Check.That(s).IsEqualTo("1;2;3;null;null;4;5;null;null;null;null");
    }
    
    [Test]
    public void deserialize_tests()
    {
        var c = new Codec();
        var root = c.deserialize("1;2;3;null;null;4;5;null;null;null;null");
        Check.That(root.val).IsEqualTo(1);
        Check.That(root.left.val).IsEqualTo(2);
        Check.That(root.left.left).IsNull();
        Check.That(root.left.right).IsNull();
        Check.That(root.right.val).IsEqualTo(3);
        Check.That(root.right.left.val).IsEqualTo(4);
        Check.That(root.right.right.val).IsEqualTo(5);
        Check.That(root.right.left.left).IsNull();
        Check.That(root.right.left.right).IsNull();
        Check.That(root.right.right.left).IsNull();
        Check.That(root.right.right.right).IsNull();

    }
    
    
}