using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;

namespace Genshin_Impact_Launcher
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Background_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Allows the user to drag the window.
            switch (e.ButtonState)
            {
                case MouseButtonState.Pressed:
                    this.DragMove();
                    break;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            //Closes the settings window.
            this.Close();
        }

        private void changeLocationButton_Click(object sender, RoutedEventArgs e)
        {
            //Opens a file dialog that will allow the user to select the location of their Genshin Impact.
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Genshin Impact Location:";
                ofd.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MainWindow.genshinImpactLocation = ofd.FileName;

                    installationPathwayTextBlock.Text = ofd.FileName;
                }
            }
        }
    }
}
