using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Search
{
    public class SearchInsert
    {
        public static int searchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return 0;
            if(nums.Length == 1)
            {
                if (nums[0] == target) return 0;
                return (nums[0] > target) ? 0 : 1;
            }

            if (target <= nums[0]) return 0;

            return BsInsert(nums, target, 0, nums.Length - 1);
        }

        //public static int BinarySearchInsert(int[] nums, int target, int low, int high)
        //{
        //    if (low > high)
        //    {
        //        int result = (target > nums[low]) ? low + 1 : low - 1;
        //        if (result < 0) return 0;
        //        return result;
        //    }

        //    int mid = (low + high) / 2;

        //    if(low == high)
        //    {
        //        if (nums[low] == target)
        //            return low;
        //        int result = (target > nums[low]) ? low + 1 : low-1;
        //        if (result < 0) return 0;
        //        return result;
        //    }

        //    if (nums[mid] < target)
        //    {
        //        return BinarySearchInsert(nums, target, mid+1, high);
        //    }
        //    else if (nums[mid] > target)
        //    {
        //        return BinarySearchInsert(nums, target, low, mid-1);
        //    }
        //    else
        //    {
        //        if (nums[mid] == target)
        //            return mid;
        //        var result = (target > nums[mid]) ? mid + 1 : mid - 1;
        //        if (result < 0) return 0;
        //        return result;
        //    }
        //}

        public static int BsInsert(int[] nums, int target, int low, int high)
        {
            //if (target <= nums[low]) return low;
            if(low >= high)
            {
                if (target <= nums[low]) return low;
                return low + 1;
            }

            int mid = (low + high) / 2;
            if(target < nums[mid])
            {
                return BsInsert(nums, target, low, mid - 1);
            }
            else if( target > nums[mid])
            {
                return BsInsert(nums, target, mid + 1, high);
            }
            else
            {
                return mid;
            }
        }

        public static void Test()
        {
            var result = searchInsert(new int[] { 1, 3 }, 0);
            Debug.Assert(result == 0);

            result = searchInsert(new int[] { 1, 3 }, 1);
            Debug.Assert(result == 0);

            result = searchInsert(new int[] { 1, 3 }, 2);
            Debug.Assert(result == 1);

            result = searchInsert(new int[] { 1, 3 }, 4);
            Debug.Assert(result == 2);

            result = searchInsert(new int[] { 1, 3, 5, 6 }, 7);
            Debug.Assert(result == 4);
        }
    }
}
