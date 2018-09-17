using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DynamicAndRecurive
{
    class DeletionDistance
    {
        public static int StringDeletionDistance(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1)) return str2.Length;
            if (string.IsNullOrEmpty(str2)) return str1.Length;
            if (str1.Equals(str2, StringComparison.OrdinalIgnoreCase)) return 0;

            int count = 0;
            var charToCountMap1 = new Dictionary<char, int>();
            var charToCountMap2 = new Dictionary<char, int>();

            CalculateCharCounts(charToCountMap1, str1);
            CalculateCharCounts(charToCountMap2, str2);

            var charToCount = charToCountMap1.ToArray();
            foreach(var kvp in charToCount)
            {
                if(!charToCountMap2.ContainsKey(kvp.Key))
                {
                    count += kvp.Value;
                }
                else
                {
                    if(charToCountMap2[kvp.Key] != kvp.Value)
                    {
                        count += Math.Abs(charToCountMap2[kvp.Key] - kvp.Value);
                    }

                    charToCountMap2.Remove(kvp.Key);
                }
            }

            foreach(var kvp in charToCountMap2)
            {
                count += kvp.Value;
            }
            return count;
        }

        private static void CalculateCharCounts(Dictionary<char, int> charToCountMap1, string str)
        {
            foreach (var c in str)
            {
                if (charToCountMap1.TryGetValue(c, out int charCount))
                {
                    charCount++;
                    charToCountMap1[c] = charCount;
                }
                else
                {
                    charToCountMap1.Add(c, 1);
                }
            }
        }

        public static void Test()
        {
            var result = StringDeletionDistance("dog", "from");
            Debug.Assert(result == 5);
        }
    }
}
