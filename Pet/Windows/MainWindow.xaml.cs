using Pet.Properties;
using System;
using System.Windows;

namespace Pet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        void IDisposable.Dispose() { }

        public MainWindow()
        {
            InitializeComponent();

            if ((bool)Settings.Default["windowed"] == true)
            {
                WindowStyle = WindowStyle.ToolWindow;
            }
            WindowState = WindowState.Maximized;

            Content = new UserControl_MainMenu();
        }

    }
}
