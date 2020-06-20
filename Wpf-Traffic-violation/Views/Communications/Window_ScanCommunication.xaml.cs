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
using System.Windows.Shapes;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for Window_ScanCommunication.xaml
    /// </summary>
    public partial class Window_ScanCommunication : Window
    {
        public Window_ScanCommunication()
        {
            InitializeComponent();
        }

        private void But_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

       

        private void RadioButton_True_Click(object sender, RoutedEventArgs e)
        {
            but_AddViolation.Visibility = Visibility.Visible;
        }

        private void RadioButton_False_Click(object sender, RoutedEventArgs e)
        {
            but_AddViolation.Visibility = Visibility.Hidden;
        }
    }
}
