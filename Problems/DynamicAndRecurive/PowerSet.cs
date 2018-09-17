using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.DynamicAndRecurive
{
    public class PowerSet
    {
        static IList<List<char>> GetAllSubsets(List<char> orig)
        {
            if(orig.Count == 0)
            {
                var result = new List<List<char>>
                {
                    new List<char>(0)  // empty list set
                };
                return result;
            }
            else if (orig.Count == 1)
            {
                var result = new List<List<char>>
                {
                    new List<char>(0),  // empty list set
                    orig                // single element set
                };
                return result;
            }

            var subsets = GetAllSubsets(orig.GetRange(0, orig.Count - 1));
            var ngw = new List<List<char>>();
            // empty list set
            char toAdd = orig.ElementAt(orig.Count - 1);

            foreach(var s in subsets)
            {
                ngw.Add(new List<char>(s.ToArray()));
                var newSet = new List<char>(s.ToArray());
                newSet.Add(toAdd);
                ngw.Add(newSet);
            }

            return ngw;
        }


        public static void Test()
        {
            var input = new List<char>() { 'a', 'b', 'c' };
            var powerSets = GetAllSubsets(input);

            Debug.Assert(powerSets.Count == 8);
        }
    }
}
