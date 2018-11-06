using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L2_GG
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomMonitor monitor = new CustomMonitor();
            Changer changerA = new Changer(monitor);
            Changer changerB = new Changer(monitor);

            List<Printer> printers = new List<Printer>
            {
                new Printer(monitor),
                new Printer(monitor),
                new Printer(monitor)
            };
            List<Thread> threads = new List<Thread>
            {
                new Thread(changerA.ChangeA),
                new Thread(changerB.ChangeB)
            };
            foreach (var p in printers)
            {
                threads.Add(new Thread(p.PrintToConsole));
            }
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Name = "" + (i + 1);
            }
            foreach (var thread in threads) { thread.Start(); }
            foreach (var thread in threads) { thread.Join(); }
            Console.ReadKey();
        }
    }
}
