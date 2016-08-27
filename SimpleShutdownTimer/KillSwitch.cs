using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShutdownTimer
{
    class KillSwitch
    {
        //this object holds the time (in secononds) until the program initates the killswitch
        private TimeSpan countdown;
        private TimeSpan One = new TimeSpan(0, 0, 1); //1 Second
        private TimeSpan ZeroHour = new TimeSpan(0, 0, 0); //End Time

        public TimeSpan Countdown {
            get
            {
                return countdown;
            }
            set
            {
                countdown = value;
            }

        }

        public bool Tick()
        {
            try
            {
                countdown = countdown.Subtract(One);
            }
            catch(Exception e)
            {
                var dialog = new Windows.UI.Popups.MessageDialog(e.Message);
                var res = dialog.ShowAsync();
            }

            if (countdown <= ZeroHour)
            {
                return true; //Countdown is completed, return true
            }
            else return false;


        }

        public void Engage()
        {
            //pipe shutdown command to console here
            
        }


        }

    }

