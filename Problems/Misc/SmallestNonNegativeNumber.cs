Random

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
