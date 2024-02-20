using System.Windows;
using System.Windows.Controls;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_Streets.xaml
    /// </summary>
    public partial class UserControl_Streets : UserControl
    {
        public UserControl_Streets()
        {
            InitializeComponent();
        }

        private void But_Add_Street_Click(object sender, RoutedEventArgs e)
        {

            Window_AddStreet win = new Window_AddStreet();
            win.ShowDialog();
        }
        private void DataGridCell_Selected(object sender, RoutedEventArgs e)
        {
            // Your custom logic here
            DataGridCell cell = sender as DataGridCell;
            if (cell != null)
            {
                // Get the row and column indices of the selected cell
                //int rowIndex = cell.GetIndex();
                //int columnIndex = cell.Column.DisplayIndex;

                //// Get the DataGrid that contains the selected cell
                //DataGrid dataGrid = FindParent<DataGrid>(cell);

                //// Get the item that is bound to the selected cell's row
                //var item = dataGrid.Items[rowIndex];

                // Perform your custom actions here
            }
        }
    }
}
