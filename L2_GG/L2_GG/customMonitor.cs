using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L2_GG
{
    class CustomMonitor
    {
        private int a;
        private int b;
        private object _locker;
        private bool[] canCahnge;
        private int count;
        private List<string> visitors;

        public CustomMonitor()
        {
            a = 100;
            b = 0;
            _locker = new object();
            canCahnge = new bool[2];
            canCahnge[0] = true;
            canCahnge[1] = true;
            count = 0;
            visitors = new List<string>();
        }
        private bool CanPrint()
        {
            return !(canCahnge[0] && canCahnge[1]);
        }
        public bool End()
        {
            return (a - b) > 20;
        }
        public void ChangeA()
        {
            lock(_locker)
            {
                while (!canCahnge[0])
                {
                    Monitor.Wait(_locker);
                }
                a -= 10;
                canCahnge[0] = false;
                //Monitor.PulseAll(_locker);
                //Console.WriteLine("Values a: " + a + " b: " + b);
            }
        }
        public void ChangeB()
        {
            lock(_locker)
            {
                while (!canCahnge[1])
                {
                    Monitor.Wait(_locker);
                }
                b += 10;
                canCahnge[1] = false;
                //Monitor.PulseAll(_locker);
                //Console.WriteLine("Values a: " + a + " b: " + b);
            }
        }
        public void PrintValues()
        {
            lock(_locker)
            {
                while (!CanPrint())
                {
                    Monitor.Wait(_locker);
                }
                if (!visitors.Contains(Thread.CurrentThread.Name))
                {
                    if (End())
                    {
                        Console.WriteLine("Values a: " + a + " b: " + b + " Thread id " + Thread.CurrentThread.Name);
                        visitors.Add(Thread.CurrentThread.Name);
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("--------------------------------");
                            canCahnge[0] = true;
                            canCahnge[1] = true;
                            visitors.Clear();
                            count = 0;
                        }
                    }
                }
                Monitor.PulseAll(_locker);
            }            
        }
    }
}
