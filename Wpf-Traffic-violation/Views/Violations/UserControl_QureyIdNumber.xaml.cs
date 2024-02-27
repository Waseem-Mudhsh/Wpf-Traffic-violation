using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation.Models.Violations_Model;

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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            panal_query.Visibility = Visibility.Visible;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            int value = 0;

            var data = dataGrid.ItemsSource;
            SelectedAmount.Text = "";
            foreach (Violation item in data)
            {
                if (item.Isselected)
                {
                    //value = Convert.ToInt32(SelectedAmount.Text);
                    value += item.Violation_penalty;
                    SelectedAmount.Text = value.ToString();

                }
            }
            // Handle the Checked event here
            // You can access the DataContext of the CheckBox to get the corresponding item in your ItemsSource
            // For example:
            //var checkBox = sender as DataGridCell;

            //if (checkBox != null)
            //{
            //    Violation model = checkBox.DataContext as Violation;

            //    if (model.Isselected == true)
            //    {
            //        value = Convert.ToInt32(SelectedAmount.Text);
            //        value += model.Violation_penalty;
            //        SelectedAmount.Text = value.ToString();
            //    }
            //}
        }
        private void CheckBox_UNChecked(object sender, RoutedEventArgs e)
        {
            int value = 0;

            var data = dataGrid.ItemsSource;
            SelectedAmount.Text = "";
            foreach (Violation item in data)
            {
                if (item.Isselected)
                {
                    //value = Convert.ToInt32(SelectedAmount.Text);
                    value += item.Violation_penalty;
                    SelectedAmount.Text = value.ToString();

                }
            }
        }

        private void DataGridCell_Selected(object sender, RoutedEventArgs e)
        {
            //var checkBox = sender as CheckBox;
            //if (checkBox != null)
            //{
            //    var item = checkBox.DataContext; // This gives you the item bound to the row
            //                                     // Do something with the item...
            //}

        }
    }
}
