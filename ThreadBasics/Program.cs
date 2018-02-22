using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating new Thread directly");
            Console.WriteLine($"Main thread number: {Thread.CurrentThread.GetHashCode()}");
            Thread aThread = new Thread(ThreadMethod);
            aThread.Start();
            
        }

        static void ThreadMethod()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} number: {Thread.CurrentThread.GetHashCode()}");
        }
    }
}
