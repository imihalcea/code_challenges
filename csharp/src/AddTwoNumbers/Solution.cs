using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.AddTwoNumbers;


public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}


public class Solution
{
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        return null;
    }
    
    public static ListNode ArrayToListNode(int[] arr)
    {
        ListNode head = null;
        ListNode current = null;
        foreach (var i in arr)
        {
            if (head == null)
            {
                head = new ListNode(i);
                current = head;
            }
            else
            {
                current.next = new ListNode(i);
                current = current.next;
            }
        }
        return head;
    }
    
    public static int[] ListNodeToArray(ListNode head)
    {
        var current = head;
        var arr = new List<int>();
        while (current != null)
        {
            arr.Add(current.val);
            current = current.next;
        }
        return arr.ToArray();
    }

    public static int ArrayToDecimal(int[] arr) => 
        (int)arr.Select((n,i)=>Math.Pow(10,i)*n).Sum();

    public static int[] DecimalToArray(int n)
    {
        var arr = new List<int>();
        while (n < 10)
        {
            (n, int r) = Math.DivRem(n, 10);
            arr.Add(r);
        }
        arr.Add(n);
        return arr.ToArray();
    }
        
}