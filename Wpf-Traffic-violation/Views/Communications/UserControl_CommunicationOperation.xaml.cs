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
    /// Interaction logic for UserControl_CommunicationOperation.xaml
    /// </summary>
    public partial class UserControl_CommunicationOperation : UserControl
    {
        public UserControl_CommunicationOperation()
        {
            InitializeComponent();
        }

        private void But_Add_Communication_Click(object sender, RoutedEventArgs e)
        {
            Window_AddCommunication win = new Window_AddCommunication();
            win.ShowDialog();
              
        }
    }
}
