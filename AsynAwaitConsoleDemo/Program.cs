using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynAwaitConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("first");
            Task.Run(async () =>
            {
                Console.WriteLine(await ResultAsync());
            });          
            Console.WriteLine("last");
            Console.ReadLine();
        }

        static string Result()
        {
            Thread.Sleep(3000);
            return "Hello World";
        }

        static async Task<string> ResultAsync()
        {
            await Task.Delay(3000);
            return "Hello World";
        }
    }
}
