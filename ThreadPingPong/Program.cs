using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            var pingPong = new PingPong();
            var pingThread = new Thread(pingPong.Ping);
            var pongThread = new Thread(pingPong.Pong);
            pingThread.Start();
            pongThread.Start();

            pingThread.Join();
            pongThread.Join();
        }
    }

    public class PingPong
    {
        private static object ball = new object();

        public void Ping()
        {
            lock (ball)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Ping");
                    Monitor.Pulse(ball);
                    Monitor.Wait(ball);
                }
                Monitor.Pulse(ball);
            }

        }

        public void Pong()
        {
            lock (ball)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Pong");
                    Monitor.Pulse(ball);
                    Monitor.Wait(ball);
                }
            }
        }
    }
}
