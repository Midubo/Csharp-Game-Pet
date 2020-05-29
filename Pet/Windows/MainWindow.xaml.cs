﻿using System;
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

            Content = new UserControl_MainMenu();
        }


    }
}