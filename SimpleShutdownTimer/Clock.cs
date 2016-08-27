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

        public TimeSpan SpanSeconds(TimeSpan start, TimeSpan end)
        {
            //returns a timespan containing total seconds between start and end timespans
            TimeSpan span = new TimeSpan(0,0, (int)start.Subtract(end).TotalSeconds);
            return span;

        }

    }
}
