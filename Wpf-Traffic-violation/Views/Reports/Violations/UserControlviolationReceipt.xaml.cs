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

namespace Wpf_Traffic_violation.Views.Reports.Violations
{
    /// <summary>
    /// Interaction logic for UserControlviolationReceipt.xaml
    /// </summary>
    public partial class UserControlviolationReceipt : UserControl
    {
        public UserControlviolationReceipt()
        {

            InitializeComponent();
     
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var radioButtons = new RadioButton[] { RadioButton_main, RadioButton_sub, RadioButton_all };

            // Check if at least one RadioButton in the group is checked
            if (!radioButtons.Any(rb => rb.IsChecked == true))
            {
                // If none is checked, set the first one as checked
                RadioButton_main.IsChecked = true;
            }
            foreach(var item in radioButtons)
            {
                if(item.IsChecked == true)
                {
                    item.IsChecked = true; break;

                }
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton =  (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                radioButton.IsChecked = true;
            }
        }






    }
}
