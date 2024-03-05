using System.Windows;
using System.Windows.Controls;

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

        }

        private void But_Add_Violation_Click(object sender, RoutedEventArgs e)
        {
            Window_AddViolation win = new Window_AddViolation();
            win.ShowDialog();
        }

        private void filterSearchbycode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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



    }
}
