using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DynamicAndRecurive
{
    public class TrianglePath
    {
        static int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1)
                return triangle[0][0];

            var result = new List<int>();
            result.Add(triangle[0][0]);
            int[] adj = new int[] { 0, 1 };
            for (int r = 1; r < triangle.Count; r++)
            {
                var min = int.MaxValue;
                int col = 0;
                for (int i = 0; i < adj.Length; i++)
                {
                    if(triangle[r][adj[i]] < min)
                    {
                        min = triangle[r][adj[i]];
                        col = adj[i];
                    }
                }

                result.Add(min);
                
                // update adj for the next row
                //if (col == 0)
                //    adj = new int[] { col, col+1 };
                //else
                    adj = new int[] { col, col + 1 };
            }

            return result.Sum(item => item);
        }

        public static void Test()
        {
            var input = new List<IList<int>>();
            input.Add(new List<int>() { 2 });
            input.Add(new List<int>() { 3, 4 });
            input.Add(new List<int>() { 6, 5, 7 });
            input.Add(new List<int>() { 3, 4, 1, 8, 3 });

            var result = MinimumTotal(input);
            Debug.Assert(result == 11);
        }
    }
}
