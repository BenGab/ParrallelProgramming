using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer();

            for (int i = 0; i < 7; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart((object ch) =>
                {
                    buffer.Put(ch.ToString()[0]);
                }));
                thread.Start(i);
            }

            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(new ThreadStart(() =>
                {
                    Console.WriteLine(buffer.Get());
                }));
                thread.Start();
            }

        }


    }
}
