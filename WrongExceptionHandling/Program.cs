using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WrongExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Thread(Go).Start();
            }
            catch(Exception)
            {
                Console.WriteLine("Exception !!");
            }
        }

        static void Go()
        {
            throw null;
        }
    }
}
