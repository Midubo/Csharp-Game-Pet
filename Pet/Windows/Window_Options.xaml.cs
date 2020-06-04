using Pet.Properties;
using System;
using System.Windows;

namespace Pet
{
    /// <summary>
    /// Interaction logic for Window_Options.xaml
    /// </summary>
    public partial class Window_Options : Window
    {
        public Window_Options()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            checkBox_Windowed.IsChecked = (bool)Settings.Default["windowed"];
            checkBox_Music.IsChecked = (bool)Settings.Default["music"];
            checkBox_dailyComments.IsChecked = (bool)Settings.Default["dailyComments"];
            tb_Name.Text = (string)Settings.Default["defaultName"];
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Settings.Default["windowed"] = checkBox_Windowed.IsChecked;
            Settings.Default["music"] = checkBox_Music.IsChecked;
            Settings.Default["dailyComments"] = checkBox_dailyComments.IsChecked;
            Settings.Default["defaultName"] = tb_Name.Text;

            Settings.Default.Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
