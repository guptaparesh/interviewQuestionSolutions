using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Misc
{
    public class MaxSubsetSum
    {
        public static int maxSubsetSum(int[] arr)
        {
            //int maxSum = int.MinValue;

            //for (int i = 0; i <= arr.Length - 2; i++)
            //{
            //    for (int step = 2; step < arr.Length; step++)
            //    {
            //        int sum = arr[i];
            //        for (int j = i + step; j < arr.Length; j = j + step)
            //        {
            //            sum += arr[j];
            //        }
            //        maxSum = Math.Max(sum, maxSum);
            //    }
            //}

            //return maxSum;

            //int[] ngw = new int[arr.Length + 1];

            //ngw[0] = arr[0];
            //ngw[1] = Math.Max(arr[0], arr[1]);

            //for(int i = 2; i <= arr.Length; i++)
            //{
            //    ngw[i] = Math.Max(arr[i - 1], arr[i - 2] + arr[i]);
            //}
            if (arr.Length == 0) return 0;

            arr[0] = Math.Max(0, arr[0]);
            if (arr.Length == 1) return arr[0];
            arr[1] = Math.Max(arr[0], arr[1]);
            for(int i = 2; i < arr.Length; i++)
            {
                arr[i] = Math.Max(arr[i - 1], arr[i] + arr[i - 2]);
            }
            return arr[arr.Length - 1];
        }

        public static void Test()
        {
            var result = maxSubsetSum(new int[] { 3, 7, 4, 6, 5 });
            Debug.Assert(result == 13);
        }
    }
}
