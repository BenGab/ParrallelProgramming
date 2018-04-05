using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBasedPrimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int numthread = Environment.ProcessorCount;
            int max = 10000000;
            int slicenum = max / numthread;
            List<Task<int>> tasks = new List<Task<int>>();

            for (int i = 0; i < numthread; i++)
            {
                //outer variable trap
                int j = i;
                tasks.Add(new Task<int>(() =>
                {
                    return PrimeSearch((j * slicenum) + 1, ((j + 1) * slicenum));
                }));
            }

            Task.WhenAll(tasks).ContinueWith(t =>
            {
                sw.Stop();
                Console.WriteLine(t.Result.Sum());
                Console.WriteLine(sw.Elapsed);
            });

            foreach (var item in tasks)
            {
                item.Start();
            }

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
