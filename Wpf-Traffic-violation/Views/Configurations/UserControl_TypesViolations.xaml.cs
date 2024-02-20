using System.Windows;
using System.Windows.Controls;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_TypesViolations.xaml
    /// </summary>
    public partial class UserControl_TypesViolations : UserControl
    {
        public UserControl_TypesViolations()
        {

            InitializeComponent();
            //But_Delete_TypeViolation.IsEnabled = true;
            //But_Add_TypeViolation.IsEnabled = true;
            //But_Edit_TypeViolation.IsEnabled = true;

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
