using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.IO;

namespace Genshin_Impact_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string genshinImpactLocation = @"GenshinImpact.exe";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void toolbarPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //If the mouse button is held, drag the window.
            switch (e.ButtonState)
            {
                case MouseButtonState.Pressed:
                    this.DragMove();
                    break;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            //Exit the application.
            Environment.Exit(0);
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            //Minimizes the window.
            this.WindowState = WindowState.Minimized;
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void launchButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(genshinImpactLocation))
            {
                //Start Genshin Impact.
                Process.Start(genshinImpactLocation);

                //Close the application.
                Environment.Exit(0);
            }
            else if (!File.Exists(genshinImpactLocation))
            {
                MessageBox.Show("Genshin Impact could not be found. If the game is installed on your computer, please move the launcher to the game's install directory.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
