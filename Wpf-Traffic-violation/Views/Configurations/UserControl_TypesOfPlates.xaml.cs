using System.Windows;
using System.Windows.Controls;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_TypesOfPlates.xaml
    /// </summary>
    public partial class UserControl_TypesOfPlates : UserControl
    {
        public UserControl_TypesOfPlates()
        {
            InitializeComponent();
        }

        private void But_Add_TypesOfPlates_Click(object sender, RoutedEventArgs e)
        {
            Window_AddTypeOfplates win = new Window_AddTypeOfplates();
            win.ShowDialog();
        }
        private void DataGridCell_Selected(object sender, RoutedEventArgs e)
        {
            // Your custom logic here
            DataGridCell cell = sender as DataGridCell;
            if (cell != null)
            {

            }
        }
    }
}
