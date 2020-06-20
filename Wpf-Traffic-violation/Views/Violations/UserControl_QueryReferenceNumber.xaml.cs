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
    /// Interaction logic for UserControl_QueryReferenceNumber.xaml
    /// </summary>
    public partial class UserControl_QueryReferenceNumber : UserControl
    {
        public UserControl_QueryReferenceNumber()
        {
            InitializeComponent();
        }

        private void but_PayViolation_Click(object sender, RoutedEventArgs e)
        {
            Window_PayViolation win = new Window_PayViolation();
            win.ShowDialog();
        }
    }
}
