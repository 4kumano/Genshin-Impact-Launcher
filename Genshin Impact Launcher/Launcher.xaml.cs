using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Genshin_Impact_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string genshinImpactLocation = Properties.Resources.genshinImpactLocation;

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
            ShowChangeGenshinLocationDialogueBox();
        }

        private void ShowChangeGenshinLocationDialogueBox()
        {
            //Opens a file dialog that will allow the user to select the location of their Genshin Impact.
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Genshin Impact Location:";
                ofd.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    genshinImpactLocation = ofd.FileName;
                }
            }
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
                System.Windows.Forms.MessageBox.Show("Genshin Impact could not be found. If the game is installed on your computer, please select its location in the prompt that will appear after closing this message. The game's location can be changed any time from the settings menu.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ShowChangeGenshinLocationDialogueBox();
            }
        }
    }
}
