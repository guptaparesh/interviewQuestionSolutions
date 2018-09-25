using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problems.Misc
{
    public static class CountTriplets
    {
        static long Ngw(List<long> arr, long r)
        {
            long count = 0;
            var numToIndices = new Dictionary<long, HashSet<int>>();

            for (int i = 0; i < arr.Count; i++)
            {
                HashSet<int> indices;
                if(!numToIndices.TryGetValue(arr[i], out indices))
                {
                    indices = new HashSet<int>();
                    numToIndices.Add(arr[i], indices);
                }
                indices.Add(i);
            }

            for (int i = 0; i <= arr.Count-3; i++)
            {
                var firstNum = arr[i];
                HashSet<int> secondNumberIndices;
                if(numToIndices.TryGetValue(firstNum * r, out secondNumberIndices))
                {
                    foreach (var sec in secondNumberIndices)
                    {
                        if (sec == i)
                            continue;
                        var second = arr[sec];
                        HashSet<int> thirdNumberIndices;
                        if (numToIndices.TryGetValue(second * r, out thirdNumberIndices))
                        {
                            //count += thirdNumberIndices.Count;
                            foreach(var thirdIdx in thirdNumberIndices)
                            {
                                if (thirdIdx == i || thirdIdx == sec)
                                    continue;
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }

        public static void Test()
        {
            var numTriplets = Ngw(new List<long>() { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}, 1);
            Debug.Assert(numTriplets == 2);

            numTriplets = Ngw(new List<long>() { 1, 1, 1, 1, 1}, 1);
            Debug.Assert(numTriplets == 2);
            numTriplets = Ngw(new List<long>() { 1, 3, 9, 9, 27, 81 }, 3); 
            Debug.Assert(numTriplets == 6);
        }
    }
}
