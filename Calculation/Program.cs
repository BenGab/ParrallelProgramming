using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Calculation
{
    class Program
    {
        private const int size = 40000000;
        private static int[] arr;
        private static int[] sumparts;
        private static int blockSize;

        static void Main(string[] args)
        {
            arr = new int[size];


            Random rnd = new Random(1000);

            int threadNum = 4;
            blockSize = size / threadNum;
            sumparts = new int[threadNum];

            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(1, 10);
            }


            for (int i = 0; i < threadNum; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Calculate));
                thread.Start(i);
            }

            Stopwatch wtch = new Stopwatch();
            wtch.Reset();
            wtch.Start();
            wtch.Stop();

            Console.WriteLine($"found number 3 in {sumparts.Sum()} in wtch {wtch.ElapsedMilliseconds} ms");
        }

        private static void Calculate(object id)
        {
            int local_num = 0;
            int start = (int)id * blockSize;

            for (int i = start; i < start + blockSize; i++)
            {
                if (arr[i] == 3)
                {
                    ++local_num;
                }
            }
            sumparts[(int)id] = local_num;
        }
    }
}
