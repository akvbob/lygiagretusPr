using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_GG
{
    class Changer
    {
        CustomMonitor monitor;

        public Changer(CustomMonitor monitor)
        {
            this.monitor = monitor;
        }
        public void ChangeA()
        {
            while (monitor.End())
            {
                monitor.ChangeA();
            }
        }
        public void ChangeB()
        {
            while (monitor.End())
            {
                monitor.ChangeB();
            }
        }
    }
}
