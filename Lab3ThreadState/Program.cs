using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3ThreadState
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(delegate () { while (true) ; });
            Console.WriteLine($"name={t.Name}, priority={t.Priority}, state={t.ThreadState}");
            t.Name = "Worker";
            t.Priority = ThreadPriority.BelowNormal;
            t.Start();
            Thread.Sleep(1000);
            Console.WriteLine($"name={t.Name}, priority={t.Priority}, state={t.ThreadState}");
            t.Suspend();
            Thread.Sleep(1000);
            Console.WriteLine($"state={t.ThreadState}");
            t.Resume();
            Console.WriteLine($"state={t.ThreadState}");
            t.Abort();
            Thread.Sleep(1000);
            Console.WriteLine($"state={t.ThreadState}");
        }
    }
}
