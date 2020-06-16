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
    /// Interaction logic for UserControl_Deportation.xaml
    /// </summary>
    public partial class UserControl_Deportation : UserControl
    {
        public UserControl_Deportation()
        {
            InitializeComponent();
        }

        private void RadioButton_day_Click(object sender, RoutedEventArgs e)
        {
            Panel_day.Visibility = Visibility.Visible;
            panel_date.Visibility = Visibility.Hidden;
            panel_Decument.Visibility = Visibility.Hidden;
        }

        private void RadioButton_Date_Click(object sender, RoutedEventArgs e)
        {
            panel_date.Visibility = Visibility.Visible;
            panel_Decument.Visibility = Visibility.Hidden;
            Panel_day.Visibility = Visibility.Hidden;
        }

        private void RadioButton_Document_Click(object sender, RoutedEventArgs e)
        {
            panel_Decument.Visibility = Visibility.Visible;
            panel_date.Visibility = Visibility.Hidden;  
            Panel_day.Visibility = Visibility.Hidden;
        }
    }
}
