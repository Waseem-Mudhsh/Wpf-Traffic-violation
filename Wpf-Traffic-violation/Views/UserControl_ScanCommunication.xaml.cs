using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_ScanCommunication.xaml
    /// </summary>
    public partial class UserControl_ScanCommunication : UserControl
    {
        public UserControl_ScanCommunication()
        {
            InitializeComponent();
        }

        private void But_Scan_Commnication_Click(object sender, RoutedEventArgs e)
        {
            Window_ScanCommunication win = new Window_ScanCommunication();
            win.ShowDialog();
        }
    }
}
