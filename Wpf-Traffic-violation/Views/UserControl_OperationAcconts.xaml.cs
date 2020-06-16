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
    /// Interaction logic for UserControl_OperationAcconts.xaml
    /// </summary>
    public partial class UserControl_OperationAcconts : UserControl
    {
        public UserControl_OperationAcconts()
        {
            InitializeComponent();
        }

        private void But_Add_Accont_Click(object sender, RoutedEventArgs e)
        {
           
            Window_AddAccont win = new Window_AddAccont();
            win.ShowDialog();
        }
    }
}
