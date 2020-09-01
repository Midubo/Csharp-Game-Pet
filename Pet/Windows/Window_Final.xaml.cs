using Pet.Properties;
using System.Windows;
using System.Windows.Media;

namespace Pet
{
    /// <summary>
    /// Interaction logic for Window_Final.xaml
    /// </summary>
    public partial class Window_Final : Window
    {
        public Window_Final(int happiness)
        {
            InitializeComponent();

            tblc_Final.Text = happiness.ToString();

            if (happiness >= 100)
            {
                Settings.Default["wins"] = (int)Settings.Default["wins"] + 1;
                Settings.Default.Save();

                tblc_result.Text = "You won!";
                tblc_comment.Text = "Excellent!";
            }
            else
            {
                header.Background = Brushes.Coral;

                tblc_result.Text = "You lost";
                tblc_comment.Text = "Your pet is sad.";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
