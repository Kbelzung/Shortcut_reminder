using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace shortcut_reminder
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private bool ctrlPressed;

        public MainWindow()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                ctrlPressed = true;
                timer.Start();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                ctrlPressed = false;
                timer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (ctrlPressed)
            {
                ShowImage();
            }
        }

        private void ShowImage()
        {
            img.Visibility = img.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }
    }
}