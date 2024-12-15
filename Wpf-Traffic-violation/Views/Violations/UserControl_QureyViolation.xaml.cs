using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_QureyViolation.xaml
    /// </summary>
    public partial class UserControl_QureyViolation : UserControl
    {
        public UserControl_QureyViolation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            panal_query.Visibility = Visibility.Visible;
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
                // Define a regex to allow only letters and digits
                string regexPattern = @"[^a-zA-Z0-9\u0621-\u064A]+"; // This includes Arabic letters
                string originalText = autoCompleteBox.Text;

                // Remove spaces and special characters
                string cleanedText = Regex.Replace(originalText, regexPattern, "");

            }

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox autoCompleteBox)
            {
                // Define a regex to allow only letters and digits
                string regexPattern = @"[^a-zA-Z0-9\u0621-\u064A]+"; // This includes Arabic letters
                string originalText = autoCompleteBox.Text;

                // Remove spaces and special characters
                string cleanedText = Regex.Replace(originalText, regexPattern, "");

            }

        }
    }
}
