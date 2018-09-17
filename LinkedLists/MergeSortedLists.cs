using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LinkedLists
{
    public class MergeSortedLists
    {
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l2 == null) return l1;
            if (l1 == null) return l2;

            var c1 = l1;
            var c2 = l2;
            ListNode mergedList = null;
            ListNode cm = null;
            while (c1 != null && c2 != null)
            {
                while(c1 != null && c2 != null && c1.Data <= c2.Data)
                {
                    var n = new ListNode(c1.Data);
                    if (mergedList == null)
                    {
                        mergedList = n;
                        cm = mergedList;
                    }
                    else
                    {
                        cm.Next = n;
                        cm = cm.Next;
                    }

                    c1 = c1.Next;
                }

                while(c2 != null && c1 !=null && c2.Data < c1.Data)
                {
                    var n = new ListNode(c2.Data);
                    if (mergedList == null)
                    {
                        mergedList = n;
                        cm = mergedList;
                    }
                    else
                    {
                        cm.Next = n;
                        cm = cm.Next;
                    }
                    c2 = c2.Next;
                }
            }

            if(c1 == null)
            {
                cm.Next = c2;
            }
            else
            {
                cm.Next = c1;
            }

            return mergedList;
        }

        public static void TestMergeTwoLists()
        {
            ListNode l1 = new LinkedList(new int[] { 1, 2, 3, 4, 5 }).Head;
            ListNode l2 = new LinkedList(new int[] { 2, 4, 6, 8, 10 }).Head;

            var result = MergeSortedLists.MergeTwoLists(l1, l2);

            Debug.Assert(result.Data == 1);
            Debug.Assert(result.Next.Data == 2);
            Debug.Assert(result.Size == 10);
        }
    }
}
