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

namespace Wpf_Traffic_violation.Views.Reports.Violations
{
    /// <summary>
    /// Interaction logic for ShowReciptReports.xaml
    /// </summary>
    public partial class ShowReciptReports : Window
    {
        public ShowReciptReports()
        {
            InitializeComponent();
        }
        private void But_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
