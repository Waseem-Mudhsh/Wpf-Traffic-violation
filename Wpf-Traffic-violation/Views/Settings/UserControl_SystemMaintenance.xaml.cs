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
    /// Interaction logic for UserControl_SystemMaintenance.xaml
    /// </summary>
    public partial class UserControl_SystemMaintenance : UserControl
    {
       
        public UserControl_SystemMaintenance()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton but = ((RadioButton)sender);

            int index = int.Parse(((RadioButton)e.Source).Uid);

            
            //GridCursor.Margin = new Thickness(3 + (115 * index), 0, 0, 0);


            switch (index)
            {

                case 1:
                    {
                        GridPageFrom1.Content = new UserControl_ConnectDatabase ();

                        break;
                    }
                case 2:
                    {
                        GridPageFrom1.Content = new UserControl_BackUp();
                       
                        break;
                    }
                case 3:
                    {

                        GridPageFrom1.Content = new UserControl_RestoreTheBackup();
                        break;
                    }
                
            }
        }

       
    }
}
