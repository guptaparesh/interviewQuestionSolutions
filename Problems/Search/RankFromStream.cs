using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Search
{
    public class RankFromStream
    {
        Node root; // tree root

        void Insert(int k)
        {
            this.root = Insert(this.root, k);
        }

        Node Insert(Node n, int k)
        {
            if(n == null)
            {
                return new Node(k);
            }

            if(n.key == k)
            {
                n.count += 1;
                return n;
            }

            if(k < n.key)
            {
                n.left = Insert(n.left, k);
            }
            else if(k > n.key)
            {
                n.right = Insert(n.right, k);
            }

            return n;
        }

        void ProcessNumber(int num)
        {
            Insert(num);
            
            // preprocess to maintain ranks
            // inorder traversal of entire tree
            // index of the key is its rank (for duplicates find the last dup to find its rank)
        }

        public int GetRank(int num)
        {
            var rankings = RankAll();

            return BinarySearch(rankings.ToArray(), num);
        }

        int BinarySearch(int[] nums, int k)
        {
            int low = 0;
            int high = nums.Length - 1;

            while(low <= high)
            {
                int mid = (low + high) / 2;

                if(k < nums[mid])
                {
                    high = mid - 1;
                }
                else if(k > nums[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    
                    while (mid + 1 < nums.Length && nums[mid+1] == k)
                    {
                        mid++;
                    }
                    
                    return mid;
                }
            }

            return -1;
        }
        
        IList<int> RankAll()
        {
            var visited = new List<int>();
            InOrder(this.root, visited);
            return visited;
        }

        void InOrder(Node n, IList<int> visited)
        {
            if(n != null)
            {
                InOrder(n.left, visited);

                for (int i = 0; i < n.count; i++)
                {
                    visited.Add(n.key);
                }

                InOrder(n.right, visited);
            }
        }

        public static void Test()
        {
            var rs = new RankFromStream();
            int[] stream = new int[] { 5, 1, 4, 4, 5, 9, 7, 13, 3 };

            foreach(var num in stream)
            {
                rs.ProcessNumber(num);
            }

            var rank = rs.GetRank(1);
            Debug.Assert(rank == 0);

            rank = rs.GetRank(4);
            Debug.Assert(rank == 3);

            rank = rs.GetRank(5);
            Debug.Assert(rank == 5);

            rank = rs.GetRank(3);
            Debug.Assert(rank == 1);
        }
    }

    public class Node
    {
        public int key;
        public int count; // to handle dups.

        public Node left, right;

        public Node(int k)
        {
            this.key = k;
            this.count = 1;
        }        
    }
}
