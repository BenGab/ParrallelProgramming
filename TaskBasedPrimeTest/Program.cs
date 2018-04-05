using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskBasedPrimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task<int> t = new Task<int>(() => PrimeSearch(1, 10000000));
            t.ContinueWith(task =>
            {
                sw.Stop();
                Console.WriteLine(task.Result);
                Console.WriteLine(sw.Elapsed);
            });
            t.Start();

            Console.WriteLine("END");
            Console.ReadLine();
        }

        static int PrimeSearch(int from, int to)
        {
            int count = 0;

            for (int i = from; i <= to; i++)
            {
                if(IsPrime(i))
                {
                    ++count;
                }
            }
            return count;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;

            int limit = (int)Math.Sqrt(number);

            for (int i = 2; i < limit; i++)
            {
                if (number % i == 0)
                    return true;
            }

            return true;
        }
    }
}
