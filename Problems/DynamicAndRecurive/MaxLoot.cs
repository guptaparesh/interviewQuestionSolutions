using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problems.Misc
{
    public class MaxLoot
    {
        /// <summary>
        ///  recursive solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        static int Ngw(int[] nums)
        {
            int n = nums.Length;
            int[] memo = new int[n + 1];
            return Rob(nums, n-1, memo);
        }

        /// <summary>
        /// recursive with memoization
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="len"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public static int Rob(int[] nums, int len, int[] memo)
        {
            if (len < 0)
                return 0;

            if (len == 0)
                return nums[0];

            if (memo[len] != 0)
                return memo[len];

            memo[len] = Math.Max(nums[len] + Rob(nums, len - 2, memo), Rob(nums, len - 1, memo));
            return memo[len];
        }

        // Iterative top-down with memoization
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int[] memo = new int[nums.Length + 1];
            memo[0] = 0;
            memo[1] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int val = nums[i];
                memo[i + 1] = Math.Max(memo[i], memo[i - 1] + val);
            }
            return memo[nums.Length];
        }

        public static void Test()
        {
            var loot = Ngw(new int[] { 2, 1, 1, 2 });
            Debug.Assert(loot == 4);
        }
    }
}
