using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class RemoveElementTest
    {
        public static void TestRemoveElement()
        {
            var input = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var result = RemoveElement(input, 2);
            Debug.Assert(result == 5);

            input = new int[] { 3, 2, 2, 3 };
            result = RemoveElement(input, 2);
            Debug.Assert(result == 2);
            Debug.Assert(input[0] == 3);
            Debug.Assert(input[1] == 3);

        }

        public static int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 1 && nums[0] == val)
            {
                nums[0] = -1;
                return 0;
            }

            int len = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == val)
                {
                    int j = i + 1;
                    while(j < nums.Length && nums[j] == val)
                    {
                        j++;
                    }
                    if(j < nums.Length)
                    {
                        nums[i] = nums[j];
                        nums[j] = val;
                        len++;
                    }
                }
                else
                {
                    len++;
                }
            }

            return len;
        }
    }
}
