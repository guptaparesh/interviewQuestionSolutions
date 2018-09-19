using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedLists;
using Problems.DynamicAndRecurive;
using Problems.Graphs;
using Problems.Misc;
using Problems.Search;

namespace Problems
{
    public class Tests
    {
        public static void Main(string[] args)
        {
            FindBusiest.Test();
            DeletionDistance.Test();
            ShuffleCards.Test();
            PowerSet.Test();
            SmallestNonNegativeNumber.Test();
            MaxSubsetSum.Test();
            Graph.Test();
            RankFromStream.Test();
            SearchInsert.Test();
            RemoveElementTest.TestRemoveElement();
            MergeSortedLists.TestMergeTwoLists();
        }
    }
}
