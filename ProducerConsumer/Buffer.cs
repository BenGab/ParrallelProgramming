using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    public class Buffer
    {
        const int size = 16;
        char[] buff = new char[size];
        int head = 0, tail = 0, n = 0;
        object mutext = new object();

        public void Put(char ch)
        {
            lock (mutext)
            {
                while (n == size)
                    Monitor.Wait(mutext);

                buff[tail] = ch;
                tail = (tail + 1) % size;
                ++n;
                Monitor.Pulse(mutext);

            }
        }

        public char Get()
        {
            lock (mutext)
            {
                while (n == 0)
                    Monitor.Wait(mutext);

                char ch = buff[head];
                head = (head + 1) % size;
                --n;
                Monitor.Pulse(mutext);
                return ch;
            }
        }
    }
}
