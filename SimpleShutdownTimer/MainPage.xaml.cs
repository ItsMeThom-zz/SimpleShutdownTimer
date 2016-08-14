using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


using System.Threading;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimpleShutdownTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        DispatcherTimer _t;
        private Clock _clock;
        private KillTime _shutdownTime;

        private bool KillswitchEngaged = false;
        public MainPage()
        {
            this.InitializeComponent();
            
            //activate the clock here
            this._clock = new Clock();
            this._shutdownTime = new KillTime();
            _t = new DispatcherTimer();
            _t.Interval = new TimeSpan(0,0,1);
            _t.Tick += timer_SetTime;
            _t.Start();
            

        }


        private void timer_SetTime(Object sender, object e)
        {
            currentTimeDisplay.Text = _clock.Time;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan remaining = shutdown_AT.Time - DateTime.Now.TimeOfDay;
            this._shutdownTime.Seconds = (int)remaining.TotalSeconds;

            //killswitchCountdownText.Visibility = Visibility.Visible;
            killswitchCountdownText.Text = remaining.Minutes.ToString() + ":" + remaining.Seconds.ToString().Split('.')[0]; // this._shutdownTime.Seconds.ToString();
        }
    }
}
