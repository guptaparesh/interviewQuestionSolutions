using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problems.DynamicAndRecurive
{
    class PerfectSquares
    {
        public int NumSquares(int n)
        {
            if (n >0 && n < 4)
                return n;
            int[] memo = new int[n + 1];
            memo[0] = 0;
            memo[1] = 1;
            memo[2] = 2;
            memo[3] = 3;
            memo[4] = 1;

            return Ngw(n, memo);
        }

        public int Ngw(int n, int[] memo)
        {
            var sqrt = (int)Math.Sqrt(n);
            if ((sqrt * sqrt) == n)
            {
                memo[n] = 1;
                return 1;
            }
            else if (memo[n] != 0)
            {
                return memo[n];
            }

            if (n <= 4) return memo[n];

            int i = 1, j = n-1;
            var minSNgw = 0;
            int min = int.MaxValue;
            while(i <= j)
            {
                minSNgw = Ngw(i, memo) + Ngw(j, memo);
                if(minSNgw < min)
                {
                    min = minSNgw;
                }
                i++;
                j--;                   
            }
            memo[n] = min;
            return memo[n];
        }

        public static void Test()
        {
            var ps = new PerfectSquares();
            var ns = ps.NumSquares(8);
            Debug.Assert(ns == 2);

            ns = ps.NumSquares(12);
            Debug.Assert(ns == 3);

            ns = ps.NumSquares(100);
            Debug.Assert(ns == 1);

            ns = ps.NumSquares(27);
            Debug.Assert(ns == 3);

            ns = ps.NumSquares(13);
            Debug.Assert(ns == 2);

            ns = ps.NumSquares(50);
            Debug.Assert(ns == 2);

            ns = ps.NumSquares(5156);
            Debug.Assert(ns == 2);
        }
    }
}
