using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwoThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting 2 threads");
            var t1 = new Thread(ThreadMethod1);
            var t2 = new Thread(ThreadMethod2);
            t1.Start();
            t2.Start();
        }

        static void ThreadMethod1()
        {
            while (true)
            {
                Console.WriteLine("*********");
                Thread.Sleep(300);
            }
        }

        static void ThreadMethod2()
        {
            while (true)
            {
                Console.WriteLine("sdjkkdlsfjlék");
                Thread.Sleep(300);
            }
        }
    }
}
