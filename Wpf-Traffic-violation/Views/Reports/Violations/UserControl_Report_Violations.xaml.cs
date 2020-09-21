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

namespace Wpf_Traffic_violation.Views.Reports.Violations
{
    /// <summary>
    /// Interaction logic for UserControl_Report_Violations.xaml
    /// </summary>
    public partial class UserControl_Report_Violations : UserControl
    {
        public UserControl_Report_Violations()
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

                        Frame_Search_violations.Content = new UserControl_ReportAllViolations { DataContext = View_ReportUser };
                        break;
                    }
                case 2:
                    {

                        Frame_Search_violations.Content = new UserControl_Report_Statistics { DataContext = View_ReportUser };
                        break;
                    }
                case 3:
                    {

                        //  Frame_Search_violations.Content = new UserControl_Report_Bonds { DataContext = View_ReportUser };
                        break;
                    }
                case 4:
                    {

                        //  Frame_Search_accounts.Content = new UserControl_ReportPermissions { DataContext = View_ReportUser };
                        break;
                    }
                case 5:
                    {

                        // Frame_Search_accounts.Content = new UserControl_ReportUsertraffic { DataContext = View_ReportUser };
                        break;
                    }
            }


        }
    }
}
