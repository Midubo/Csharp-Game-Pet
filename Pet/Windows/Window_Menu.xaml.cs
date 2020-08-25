using Pet.Properties;
using System.Windows;

namespace Pet
{

    public partial class Window_Menu : Window
    {
        public string command;

        public Window_Menu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            checkBox_Music.IsChecked = (bool)Settings.Default["music"];
        }

        private void Button_Continue(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_Restart_Click(object sender, RoutedEventArgs e)
        {
            command = "restart";
            Close();
        }

        private void btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            command = "mainmenu";
            Close();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Settings.Default["music"] = checkBox_Music.IsChecked;

            Settings.Default.Save();
        }
    }
}
