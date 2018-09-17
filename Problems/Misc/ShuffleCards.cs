using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Misc
{
    public class ShuffleCards
    {
        static Random random = new Random();

        static int PerfectRandom(int lower, int higher)
        {
            return random.Next(lower, higher + 1);
        }

        static void Shuffle(int[] cards)
        {
            for(int i = 0; i < cards.Length; i++)
            {
                int k = PerfectRandom(0, i);
                var temp = cards[k];
                cards[k] = cards[i];
                cards[i] = temp;
            }
        }

        public static void Test()
        {
            var inputCards = Enumerable.Range(0, 9).ToArray();
            Console.WriteLine(string.Join("|", inputCards));

            for(int i = 1; i <= 9; i++)
            {
                Shuffle(inputCards);
                Console.WriteLine($"{string.Join("|", inputCards)} shuffled [{i}]");
            }

            int a = 4;
            var result = Negate(a);
            Debug.Assert(result == -a);
        }

        static int Negate(int num)
        {
            int sign = (num >> 31) ^ 0x1;

            return num;
        }
    }
}
