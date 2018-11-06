using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_GG
{
    class Printer
    {
        CustomMonitor monitor;

        public Printer(CustomMonitor monitor)
        {
            this.monitor = monitor;
        }
        public void PrintToConsole()
        {
            while (monitor.End())
            {
                monitor.PrintValues();
            }
        }
    }
}
