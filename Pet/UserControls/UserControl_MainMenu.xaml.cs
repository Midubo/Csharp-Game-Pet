using Pet.Properties;
using System;
using System.Diagnostics;
using System.IO;
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

        private readonly MediaPlayer mMediaPlayer = new MediaPlayer();

        public UserControl_MainMenu()
        {
            InitializeComponent();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            tblc_version.Text += string.Format(" - Version {0}.{1}.{2}", version.Major, version.Minor, version.Build);

            mMediaPlayer.Open(new Uri(string.Format("{0}\\Robot_Boogie.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            mMediaPlayer.MediaEnded += new EventHandler(Media_Ended);

            if ((bool)Settings.Default["music"] == true)
            {
                mMediaPlayer.Play();
            }

            if (File.Exists($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\save.sav"))
                btn_Load.IsEnabled = true;
        }

        private void Media_Ended(object sender, EventArgs e)
        {
            if ((bool)Settings.Default["music"] == true)
            {
                mMediaPlayer.Position = TimeSpan.Zero;
                mMediaPlayer.Play();
            }
        }

        private void btn_Play_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mMediaPlayer.Stop();
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
                mMediaPlayer.Stop();
            }
            else
            {
                mMediaPlayer.Position = TimeSpan.Zero;
                mMediaPlayer.Play();
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

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            SinglePet singlePet = new SinglePet();

            string[] lines = File.ReadAllLines($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\save.sav");

            singlePet.petName = lines[0];
            singlePet.totalDays = Convert.ToInt32(lines[1]);
            singlePet.happiness = Convert.ToInt32(lines[2]);
            singlePet.happinessBonus = Convert.ToInt32(lines[3]);
            singlePet.hunger = Convert.ToInt32(lines[4]);
            singlePet.hungerModifier = Convert.ToInt32(lines[5]);
            singlePet.pet = lines[6];
            singlePet.petDescription = lines[7];
            singlePet.age = lines[8];
            singlePet.ageDescription = lines[9];

            mMediaPlayer.Stop();

            (Parent as Window).Content = new UserControl_Game(singlePet,
                Convert.ToInt32(lines[10]),
                Convert.ToInt32(lines[11]),
                Convert.ToInt32(lines[12]),

                Convert.ToBoolean(lines[13]),
                Convert.ToBoolean(lines[14]),

                Convert.ToBoolean(lines[15])
                );
        }
    }
}
