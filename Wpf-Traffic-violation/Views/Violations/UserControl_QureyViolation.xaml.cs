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
    /// Interaction logic for UserControl_QureyViolation.xaml
    /// </summary>
    public partial class UserControl_QureyViolation : UserControl
    {
        public UserControl_QureyViolation()
        {
            InitializeComponent();
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            RadioButton but = ((RadioButton)sender);

            int index = int.Parse(((RadioButton)e.Source).Uid);


            //GridCursor.Margin = new Thickness(3 + (115 * index), 0, 0, 0);


            switch (index)
            {

                case 1:
                    {
                        UserControl_QureyIdNumber userControl_QureyIdNumber = new UserControl_QureyIdNumber();
                        //userControl_QureyIdNumber.searchBT1.IsEnabled = false;
                        //userControl_QureyIdNumber.searchBT1.IsEnabled = false;
                        GridPageFrom1.Content = userControl_QureyIdNumber;
                        
                        break;
                    }
                case 2:
                    {

                        GridPageFrom1.Content= new UserControl_QueryPersonalNumber();
                        break;
                    }
                
                case 3:
                    {
                        GridPageFrom1.Content = new UserControl_QueryReferenceNumber();

                        break;
                    }
            }
        }





    }
}
