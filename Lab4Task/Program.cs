using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(P);
            t.Start();
            Thread.Sleep(200);
            t.Abort();
            Console.WriteLine("done");
            t.Join();
            Console.WriteLine("done");
            Console.ReadLine();
        }

        static void P()
        {
            try
            {
                try
                {
                    try
                    {
                        while (true)
                        {
                            Thread.Sleep(1);
                            Console.WriteLine("run");
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        Console.WriteLine("---- inner aborted");
                    }
                }
                catch (ThreadAbortException)
                {
                    Console.WriteLine("---- outer Aborted");
                    Console.WriteLine($"Thread state: {Thread.CurrentThread.ThreadState}");
                    Thread.ResetAbort();
                    Console.WriteLine($"Thread state: {Thread.CurrentThread.ThreadState}");
                    Thread.Sleep(200);
                }
            }
            catch(ThreadAbortException)
            {
                Console.WriteLine("-- last catch");
            }
        }
    }
}
