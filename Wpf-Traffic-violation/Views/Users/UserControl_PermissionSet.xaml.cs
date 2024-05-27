using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_PermissionSet.xaml
    /// </summary>
    public partial class UserControl_PermissionSet : UserControl
    {
        public UserControl_PermissionSet()
        {
            InitializeComponent();
        }

        private void But_Permission_Click(object sender, RoutedEventArgs e)
        {

            DockPanel_Permission.Visibility = Visibility.Visible;
        }

        private void But_Add_PermissionSet_Click(object sender, RoutedEventArgs e)
        {
            Window_AddPermissionSet win = new Window_AddPermissionSet();
            win.ShowDialog();
        }

        private void ComboBox_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void DataGrid_SelectionChanged(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
