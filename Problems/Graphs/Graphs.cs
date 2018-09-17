using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Graphs
{
    public class Graph
    {
        public Node[] Nodes;

        public void PrintDfs()
        {
            Console.WriteLine("DFS");
            if (Nodes == null || Nodes.Length == 0) return;

            var visited = new HashSet<int>();
            DfsSearch(Nodes[0], visited);
        }

        public void DfsSearch(Node n, HashSet<int> visited)
        {
            if (n == null) return;

            // mark visited
            visited.Add(n.data);

            Console.Write($" {n.data} ");

            foreach(var adj in n.AdjacentNodes)
            {
                if (!visited.Contains(adj.data))
                {
                    DfsSearch(adj, visited);
                }
            }
        }

        public void BfsSearch(Node n, HashSet<int> visited)
        {
            Console.WriteLine("BFS");

            if (n == null)
                return;

            var q = new Queue<Node>();

            q.Enqueue(n);
            visited.Add(n.data);

            Console.Write($" {n.data} ");

            while(q.Count != 0)
            {
                var node = q.Dequeue();
                if (node.AdjacentNodes == null) continue;
                foreach (var adj in node.AdjacentNodes)
                {
                    if (!visited.Contains(adj.data))
                    {
                        Console.Write($" {adj.data} ");
                        visited.Add(adj.data);
                        q.Enqueue(adj);
                    }
                }
            }
            
        }

        public static void Test()
        {
            var g = new Graph();
            g.Nodes = new Node[4];

            var root = new Node(5);
            var n10 = new Node(10, new Node[] { new Node(1) });
            root.SetAdj(new Node[] { n10, new Node(3) });
            g.BfsSearch(root, new HashSet<int>());

            g.Nodes[0] = root;
            g.Nodes[1] = n10;

            g.PrintDfs();
        }
    }

    public class Node
    {
        public int data;
        public Node[] AdjacentNodes
        {
            get;
            private set;
        }

        public Node(int data)
        {
            this.data = data;
            this.AdjacentNodes = new Node[0];
        }

        public Node(int data, Node[] adj)
        {
            this.data = data;
            this.AdjacentNodes = adj;
        }

        public void SetAdj(Node[] adj)
        {
            this.AdjacentNodes = adj;
        }
    }
}
