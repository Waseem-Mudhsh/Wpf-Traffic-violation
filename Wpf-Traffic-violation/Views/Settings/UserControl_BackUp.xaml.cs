using System.Windows;
using System.Windows.Controls;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_BackUp.xaml
    /// </summary>
    public partial class UserControl_BackUp : UserControl
    {
        public UserControl_BackUp()
        {
            InitializeComponent();
        }
        private void But_OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            // Use FolderBrowserDialog or SaveFileDialog
            using (System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog())
            {
                folderBrowser.Description = "Select the folder to save the backup";
                folderBrowser.ShowNewFolderButton = true;

                // Show the FolderBrowserDialog
                System.Windows.Forms.DialogResult result = folderBrowser.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // Set the selected path to the TextBox
                    //text_OpenFolder.Text = folderBrowser.SelectedPath;
                }
            }
        }

    }
}
