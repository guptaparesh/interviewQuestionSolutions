using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Misc
{
//    Given an array arr of unique nonnegative integers, implement a function getDifferentNumber that finds the smallest nonnegative integer that is NOT in the array.

//Even if your programming language of choice doesn’t have that restriction (like Python), assume that the maximum value an integer can have is MAX_INT = 2 ^ 31 - 1.So, for instance, the operation MAX_INT + 1 would be undefined in our case.

//Your algorithm should be efficient, both from a time and a space complexity perspectives.

//Solve first for the case when you’re NOT allowed to modify the input arr. If successful and still have time, see if you can come up with an algorithm with an improved space complexity when modifying arr is allowed.Do so without trading off the time complexity.

//Analyze the time and space complexities of your algorithm.
// e.g. 
// input:  arr = [0, 1, 2, 3]

//output: 4 
    public class SmallestNonNegativeNumber
    {
        public static int GetDifferentNumber(int[] arr)
        {
            if (arr.Length == 1) return arr[0] == 0 ? 1 : 0;

            Array.Sort(arr);
            var result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == result)
                    result++;
            }
            return result;
        }

        public static void Test()
        {
            var res = GetDifferentNumber(new int[] { 0, 1, 2, 3 });
            Debug.Assert(res == 4);

            res = GetDifferentNumber(new int[] { 1, 3, 0, 2 });
            Debug.Assert(res == 4);

            res = GetDifferentNumber(new int[] { 1, 0, 3, 4, 5 });
            Debug.Assert(res == 2);
            
        }
    }
}
