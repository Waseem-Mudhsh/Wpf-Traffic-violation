using System.Windows;
using System.Windows.Controls;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_GiveThePermissions.xaml
    /// </summary>
    public partial class UserControl_GiveThePermissions : UserControl
    {
        public UserControl_GiveThePermissions()
        {
            InitializeComponent();
        }



        private void RadioButton_Click_Panel_group(object sender, RoutedEventArgs e)
        {
            Panel_group.Visibility = Visibility.Hidden;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            DockPanel_Permission.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Panel_group.Visibility = Visibility.Visible;
        }


    }
}
