using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest2
{
    class Program
    {
        static bool done;
        static void Main(string[] args)
        {
            new Thread(Go).Start();
            Go();
        }

        static void Go()
        {
            if(!done)
            {
                done = true;
                Console.WriteLine("Done");
            }
        }
    }
}
