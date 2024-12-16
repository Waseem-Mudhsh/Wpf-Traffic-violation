using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_OperationViolation.xaml
    /// </summary>
    public partial class UserControl_OperationViolation : UserControl
    {
        public UserControl_OperationViolation()
        {
            InitializeComponent();
            Window MainWindow = System.Windows.Application.Current.MainWindow;
            PresentationSource MainWindowPresentationSource = PresentationSource.FromVisual(MainWindow);
            Matrix m = MainWindowPresentationSource.CompositionTarget.TransformToDevice;
            var DpiWidthFactor = m.M11;
            var DpiHeightFactor = m.M22;
            double ScreenHeight = SystemParameters.PrimaryScreenHeight * DpiHeightFactor;
            double ScreenWidth = SystemParameters.PrimaryScreenWidth * DpiWidthFactor;
            this.trkSetWidthAdjust.Width = ScreenWidth - 240;//assigning the width for the panel
            this.TrkAnalysisDataGrid.Height = ScreenHeight - 160;//assigning the Height for the DataGrid

        }

        private void But_Add_Violation_Click(object sender, RoutedEventArgs e)
        {
            Window_AddViolation win = new Window_AddViolation();
            win.ShowDialog();
        }


        private void DataGridCell_Selected(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                var item = checkBox.DataContext; // This gives you the item bound to the row
                                                 // Do something with the item...
            }

        }

        private void filterSearchbytypplate_TextChanged(object sender, RoutedEventArgs e)
        {
            if (sender is AutoCompleteBox autoCompleteBox)
            {
                string pattern = @"[^a-zA-Z0-9\u0621-\u064A]"; // Match invalid characters

                // Get the original text
                string originalText = autoCompleteBox.Text;

                // Clean invalid characters
                string cleanedText = Regex.Replace(originalText, pattern, "");

                if (originalText != cleanedText)
                {
                    // Show the warning only if there was invalid input
                    MessageBox.Show("غير صحيح: يُسمح فقط بالحروف الإنجليزية، الحروف العربية، والأرقام.",
                                    "تنبيه", MessageBoxButton.OK, MessageBoxImage.Warning);

                    // Update the text and reset the caret position
                    autoCompleteBox.Text = cleanedText;
                    //autoCompleteBox.SelectionStart = cleanedText.Length; // Move caret to end
                }

            }

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Regular Expression: Allow Arabic letters, English letters, and numbers (no spaces or special characters)
                string pattern = @"[^a-zA-Z0-9\u0621-\u064A]"; // Match invalid characters

                // Get the original text
                string originalText = textBox.Text;

                // Clean invalid characters
                string cleanedText = Regex.Replace(originalText, pattern, "");

                if (originalText != cleanedText)
                {
                    // Show the warning only if there was invalid input
                    MessageBox.Show("غير صحيح: يُسمح فقط بالحروف الإنجليزية، الحروف العربية، والأرقام.",
                                    "تنبيه", MessageBoxButton.OK, MessageBoxImage.Warning);

                    // Update the text and reset the caret position
                    textBox.Text = cleanedText;
                    textBox.SelectionStart = cleanedText.Length; // Move caret to end
                }
            }

        }


    }
}
