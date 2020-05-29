using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Pet
{
    /// <summary>
    /// Interaction logic for UserControl_MainMenu.xaml
    /// </summary>
    public partial class UserControl_MainMenu : UserControl, IDisposable
    {
        void IDisposable.Dispose() { }

        public UserControl_MainMenu()
        {
            InitializeComponent();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            tblc_version.Text = string.Format(" - Version {0}.{1}.{2}", version.Major, version.Minor, version.Build);
        }

        private void btn_Play_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Content = new UserControl_SelectPet();
        }

        private void btn_Options_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window_Options wo = new Window_Options();
            wo.ShowDialog();
        }

        private void btn_Creators_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (border_Creators.Visibility == Visibility.Visible)
            {
                border_Creators.Visibility = Visibility.Collapsed;
            }
            else border_Creators.Visibility = Visibility.Visible;
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Version_Click(object sender, RoutedEventArgs e)
        {
            if (tblc_version.Visibility == Visibility.Visible)
            {
                tblc_version.Visibility = Visibility.Collapsed;
            }
            else tblc_version.Visibility = Visibility.Visible;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
