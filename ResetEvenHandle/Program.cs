using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResetEvenHandle
{
    class Program
    {
        static EventWaitHandle wh = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            var thread = new Thread(new ThreadStart(Waiter));
            thread.Start();
            wh.Set();
        }

        static void Waiter()
        {
            Console.WriteLine("Waiting ...");
            wh.WaitOne();
            Console.WriteLine("Notified ...");
        }
    }
}
