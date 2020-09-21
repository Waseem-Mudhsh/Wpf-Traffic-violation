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
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Views.Reports.Objections
{
    /// <summary>
    /// Interaction logic for UserControl_Report_Objections.xaml
    /// </summary>
    public partial class UserControl_Report_Objections : UserControl
    {
        public UserControl_Report_Objections()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReportUser_ViewModel View_ReportUser = new ReportUser_ViewModel();
            Button but = ((Button)sender);

            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {

                case 1:
                    {

                      Frame_Search_objections.Content = new UserControl_Report_allObjections { DataContext = View_ReportUser };
                        break;
                    }
               
                case 2:
                    {

                          Frame_Search_objections.Content = new UserControl_Report_RightObjection { DataContext = View_ReportUser };
                        break;
                    }
                case 3:
                    {

                        Frame_Search_objections.Content = new UserControl_Report_Falseobjection { DataContext = View_ReportUser };
                        break;
                    }
                case 4:
                    {

                    Frame_Search_objections.Content = new UserControl_Report_Unchecked { DataContext = View_ReportUser };
                        break;
                    }
                case 5:
                    {

                       Frame_Search_objections.Content = new UserControl_Report_Compareobjection { DataContext = View_ReportUser };
                        break;
                    }
            }


        }
    }
}
