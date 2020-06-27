using Pet.Properties;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Pet
{
    /// <summary>
    /// Interaction logic for UserControl_MainMenu.xaml
    /// </summary>
    public partial class UserControl_MainMenu : UserControl, IDisposable
    {
        void IDisposable.Dispose() { }

        private MediaPlayer mediaPlayer = new MediaPlayer();

        public UserControl_MainMenu()
        {
            InitializeComponent();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            tblc_version.Text += string.Format(" - Version {0}.{1}.{2}", version.Major, version.Minor, version.Build);

            mediaPlayer.Open(new Uri(string.Format("{0}\\Robot_Boogie.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mediaPlayer.MediaEnded += new EventHandler(Media_Ended);

            if ((bool)Settings.Default["music"] == true)
            {
                mediaPlayer.Play();
            }
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            if ((bool)Settings.Default["music"] == true)
            {
                mediaPlayer.Position = TimeSpan.Zero;
                mediaPlayer.Play();
            }
        }

        private void btn_Play_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            (Parent as Window).Content = new UserControl_SelectPet();
        }

        private void btn_Options_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Opacity = 0.4;
            this.Effect = new BlurEffect();

            Window_Options wo = new Window_Options()
            {
                Owner = this.Parent as Window,
                ShowInTaskbar = false
            };
            wo.ShowDialog();

            this.Opacity = 1;
            this.Effect = null;
            (Parent as Window).ShowInTaskbar = true;

            if ((bool)Settings.Default["music"] == false)
            {
                mediaPlayer.Stop();
            }
            else
            {
                mediaPlayer.Position = TimeSpan.Zero;
                mediaPlayer.Play();
            }

            if ((bool)Settings.Default["windowed"] == false)
            {
                (Parent as Window).WindowStyle = WindowStyle.None;
                (Parent as Window).WindowState = WindowState.Maximized;
            }
            else
            {
                (Parent as Window).WindowStyle = WindowStyle.ToolWindow;
                (Parent as Window).WindowState = WindowState.Maximized;
            }
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void btn_Website_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(link.NavigateUri.AbsoluteUri));
        }
    }
}
