using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Misc
{
    class FindBusiest
    {
        public static int FindBusiestPeriod(int[,] data)
        {
            var dayToNetVisitorsMap = new Dictionary<int, int>();
            
            // build the map
            for (int i = 0; i < data.GetLength(0); i++)
            {
                int ts = data[i, 0];
                int visitors = data[i, 1];
                int opType = data[i, 2];

                int currNetVisitors;
                // dayToNetVisitorsMAp 
                // 1487799425 8
                // 1487800378 10
                // 1487801478 0
                // 1487901013 -1
                // 1487901211 0

                // maxVisitors 
                // 1487800378 10

                if (dayToNetVisitorsMap.TryGetValue(ts, out currNetVisitors))
                {
                    if (opType == 0)
                    {
                        currNetVisitors -= visitors;
                    }
                    else
                        currNetVisitors += visitors;

                    dayToNetVisitorsMap[ts] = currNetVisitors;
                }
                else
                {
                    if (opType == 0)
                        dayToNetVisitorsMap.Add(ts, -visitors);
                    else
                        dayToNetVisitorsMap.Add(ts, visitors);
                }
            }

            int[] maxVisitors = new int[2] { -1, Int32.MinValue };

            foreach (var dayToNetVisitorKvp in dayToNetVisitorsMap)
            {
                if (dayToNetVisitorKvp.Value > maxVisitors[1])
                {
                    // found a busy day so far
                    maxVisitors[0] = dayToNetVisitorKvp.Key;
                    maxVisitors[1] = dayToNetVisitorKvp.Value;
                }
            }

            return maxVisitors[0];
        }

        public static void Test()
        {
            int[,] data = new int[,] {
        {1487799425, 14, 1},
                 {1487799425, 4,  0},
                 {1487799425, 2,  0},
                 {1487800378, 10, 1},
                 {1487801478, 18, 0},
                 {1487801478, 18, 1},
                 {1487901013, 1,  0},
                 {1487901211, 7,  1},
                 {1487901211, 7,  0} };

            var result = FindBusiestPeriod(data);

            data = new int[,]{ { 1487799425,14,1},
                                { 1487799425,4,1},
                                { 1487799425,2,1},
                                { 1487800378,10,1},
                                { 1487801478,18,1},
                                { 1487901013,1,1},
                                { 1487901211,7,1},
                                { 1487901211,7,1} };

            result = FindBusiestPeriod(data);
        }
    }
}
