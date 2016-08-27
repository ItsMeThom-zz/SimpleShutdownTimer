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

        private DispatcherTimer _t; //handles updating the current time

        private DispatcherTimer _countdown; //handles updating the countdown to killswtich

        private Clock _clock;
        private KillSwitch _killswitch;

        private bool _countdown_active = false;
        
        public MainPage()
        {
            this.InitializeComponent();

            //Set the button to the nice system color blue and hide the countdown
            timer_button.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            killswitchCountdownText.Visibility = Visibility.Collapsed;

            //activate the clock here
            this._clock = new Clock();
            this._killswitch = new KillSwitch();

            _t = new DispatcherTimer();
            _t.Interval = new TimeSpan(0,0,1);
            _t.Tick += timer_SetTime;
            _t.Start();
            

        }


        private void timer_SetTime(Object sender, object e)
        {
            currentTimeDisplay.Text = _clock.Time;
        }

        private void countdown_Count(Object sender, object e)
        {
            if(this._killswitch.Tick()) //returns true on Coundown <= 0
            {
                this._killswitch.Engage();
            }
            else
            {
                killswitchCountdownText.Text = _killswitch.Countdown.ToString() + " Remaining";
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(!_countdown_active)
            {
                _killswitch.Countdown = _clock.SpanSeconds(shutdown_AT.Time, DateTime.Now.TimeOfDay);
                _countdown = new DispatcherTimer();
                _countdown.Interval = new TimeSpan(0, 0, 1);
                _countdown.Tick += countdown_Count;
                _countdown.Start();

                _countdown_active = true;
                killswitchCountdownText.Visibility = Visibility.Visible;

                //set button to 'Abort' state functionality
                timer_button.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                timer_button.Content = "Abort";
            } 
            else
            {
                _countdown.Stop();
                timer_button.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
                timer_button.Content = "Start";
                _countdown_active = false;
                killswitchCountdownText.Visibility = Visibility.Collapsed;

            }

            

            
        }
    }
}
