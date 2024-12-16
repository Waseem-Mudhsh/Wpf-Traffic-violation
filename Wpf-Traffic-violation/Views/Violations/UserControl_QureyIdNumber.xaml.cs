using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_QureyIdNumber.xaml
    /// </summary>
    public partial class UserControl_QureyIdNumber : UserControl
    {
        public UserControl_QureyIdNumber()
        {

            InitializeComponent();
            gridselected();


        }
        private void gridselected()
        {
            var permation = Properties.Settings.Default.permissionUser.FormPrevlg.Where(o => o.FormId == 1008).FirstOrDefault();

            dataGrid.IsReadOnly = !permation.PrivilegeUpdate;// = permation.PrivilegeUpdate;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            panal_query.Visibility = Visibility.Visible;
        }


        private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    int value = 0;

        //    var data = dataGrid.ItemsSource;
        //    SelectedAmount.Text = "";
        //    foreach (Violation item in data)
        //    {
        //        if (item.Isselected)
        //        {
        //            //value = Convert.ToInt32(SelectedAmount.Text);
        //            value += item.Violation_penalty;
        //            SelectedAmount.Text = value.ToString();

        //        }
        //    }
        //    // Handle the Checked event here
        //    // You can access the DataContext of the CheckBox to get the corresponding item in your ItemsSource
        //    // For example:
        //    //var checkBox = sender as DataGridCell;

        //    //if (checkBox != null)
        //    //{
        //    //    Violation model = checkBox.DataContext as Violation;

        //    //    if (model.Isselected == true)
        //    //    {
        //    //        value = Convert.ToInt32(SelectedAmount.Text);
        //    //        value += model.Violation_penalty;
        //    //        SelectedAmount.Text = value.ToString();
        //    //    }
        //    //}
        //}
        //private void CheckBox_UNChecked(object sender, RoutedEventArgs e)
        //{
        //    int value = 0;

        //    var data = dataGrid.ItemsSource;
        //    SelectedAmount.Text = "";
        //    foreach (Violation item in data)
        //    {
        //        if (item.Isselected)
        //        {
        //            //value = Convert.ToInt32(SelectedAmount.Text);
        //            value += item.Violation_penalty;
        //            SelectedAmount.Text = value.ToString();

        //        }
        //    }
        //}

        private void DataGridCell_Selected(object sender, RoutedEventArgs e)
        {
            //var checkBox = sender as CheckBox;
            //if (checkBox != null)
            //{
            //    var item = checkBox.DataContext; // This gives you the item bound to the row
            //                                     // Do something with the item...
            //}

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
