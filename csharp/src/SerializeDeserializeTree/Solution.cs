using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeChallenges.SerializeDeserializeTree;

public class Codec
{
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrWhiteSpace(data)) return null;
        var strNodes = data.Split(';');
        var queue = new Queue<TreeNode>();
        var root = new TreeNode(int.Parse(strNodes[0]));
        queue.Enqueue(root);

        for (int i = 0; i < strNodes.Length; i += 2)
        {
            if(queue.Count==0) break;
            var currentNode = queue.Dequeue();
            if (strNodes[i + 1] != "null")
            {
                currentNode.left = new TreeNode(Int32.Parse(strNodes[i+1]));
                queue.Enqueue(currentNode.left);
            }

            if (strNodes[i + 2] != "null")
            {
                currentNode.right = new TreeNode(Int32.Parse(strNodes[i+2]));
                queue.Enqueue(currentNode.right);
            }
        }
        return root;
    }
    public string serialize(TreeNode root)
    {
        if (root == null) return null;
        var queue = new Queue<TreeNode>();
        var ser = new List<string>();
        queue.Enqueue(root);
        while (queue.Count>0)
        {
            var node = queue.Dequeue();
            if (node != null)
            {
                ser.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            else
            {
                ser.Add("null");
            }
            
        }
        return string.Join(";",ser);
    }
}