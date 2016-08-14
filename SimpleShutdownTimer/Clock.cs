using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShutdownTimer
{
    class Clock
    {

        public string Time
        {
            get
            {
                return DateTime.Now.ToString("HH:mm:ss tt");
            }


        }

    }
}
