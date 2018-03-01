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

            new Thread(Go).Start();
        }

        static void Go()
        {
            try
            {
                throw null;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception !!");
            }
        }
    }
}
