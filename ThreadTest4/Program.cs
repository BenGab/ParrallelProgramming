using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "before";
            Thread t = new Thread(() => WriteText(text));
            t.Start();
            text = "after";
        }

        static void WriteText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
