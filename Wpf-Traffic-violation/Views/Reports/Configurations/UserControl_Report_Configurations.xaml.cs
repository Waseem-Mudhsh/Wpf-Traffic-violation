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

namespace Wpf_Traffic_violation.Views.Reports.Configurations
{
    /// <summary>
    /// Interaction logic for UserControl_Report_Configurations.xaml
    /// </summary>
    public partial class UserControl_Report_Configurations : UserControl
    {
        public UserControl_Report_Configurations()
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

                        Frame_Search_configurations.Content = new UserControl_Report_DataTrafficMan { DataContext = View_ReportUser };
                        break;
                    }
                case 2:
                    {

                         Frame_Search_configurations.Content = new UserControl_Report_DataCitizen { DataContext = View_ReportUser };
                        break;
                    }
                case 3:
                    {

                        Frame_Search_configurations.Content = new UserControl_Report_DataVehicle { DataContext = View_ReportUser };
                        break;
                    }
                case 4:
                    {

                         Frame_Search_configurations.Content = new UserControl_Report_DataDrivingLicense { DataContext = View_ReportUser };
                        break;
                    }
                case 5:
                    {

                        Frame_Search_configurations.Content = new UserControl_Report_DataPlate { DataContext = View_ReportUser };
                        break;
                    }
                case 11:
                    {

                        Frame_Search_configurations.Content = new UserControl_Report_Streets { DataContext = View_ReportUser };
                        break;
                    }
            }


        }
    }
}
