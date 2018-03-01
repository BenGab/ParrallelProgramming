using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest3
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread tt = new Thread(new ParameterizedThreadStart(Go));
            tt.Start(true);
            Go(false);
        }

        static void Go(object upperCase)
        {
            bool upper = (bool)upperCase;
            Console.WriteLine(upper ? "HELLO" : "hello");
        }
    }
}
