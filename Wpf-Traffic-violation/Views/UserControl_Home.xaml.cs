using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation.Models;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_Home.xaml
    /// </summary>
    public partial class UserControl_Home : UserControl
    {
        StatisticViolation_Model s = new StatisticViolation_Model();
        StatisticCommunication_Model sa = new StatisticCommunication_Model();
        StatisticOpjection_Model O = new StatisticOpjection_Model();
        public UserControl_Home()
        {
            InitializeComponent();


            //violationtotal.Text = (s.GetStatisticViolation(fromviolation.Text.ToString(), toviolation.Text.ToString(), 1).ToString())=="" ? violationtotal.Text:null;
            //violationPayment.Text = s.GetStatisticViolation(fromviolation.Text.ToString(), toviolation.Text.ToString(), 2).ToString();


            //commtotal.Text = sa.GetStatisticCommunication(commfrom.Text.ToString(), commto.Text.ToString(), 1).ToString();
            //commtotal1.Text = sa.GetStatisticCommunication(commfrom1.Text.ToString(), commto1.Text.ToString(), 2).ToString();


            //Opjtotal.Text = O.GetStatisticOpjection(Opjfrom.Text.ToString(), Opjto.Text.ToString(), 1).ToString();
            //opjtotal1.Text = O.GetStatisticOpjection(Opjfrom1.Text.ToString(), Opjto1.Text.ToString(), 2).ToString();
            //Frame_home.Content = new UserControl1GridDataCommunications();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StatisticViolation_Model s = new StatisticViolation_Model();
            violationtotal.Text = s.GetStatisticViolation(fromviolation.Text.ToString(), toviolation.Text.ToString(), 1).ToString();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StatisticViolation_Model s = new StatisticViolation_Model();
            violationPayment.Text = s.GetStatisticViolation(violationPayfrom.Text.ToString(), violationPayto.Text.ToString(), 2).ToString();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StatisticCommunication_Model s = new StatisticCommunication_Model();
            commtotal.Text = s.GetStatisticCommunication(commfrom.Text.ToString(), commto.Text.ToString(), 1).ToString();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            StatisticCommunication_Model s = new StatisticCommunication_Model();
            commtotal1.Text = s.GetStatisticCommunication(commfrom1.Text.ToString(), commto1.Text.ToString(), 2).ToString();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            StatisticOpjection_Model O = new StatisticOpjection_Model();
            Opjtotal.Text = O.GetStatisticOpjection(Opjfrom.Text.ToString(), Opjto.Text.ToString(), 1).ToString();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            StatisticOpjection_Model O = new StatisticOpjection_Model();
            opjtotal1.Text = O.GetStatisticOpjection(Opjfrom1.Text.ToString(), Opjto1.Text.ToString(), 2).ToString();

        }
    }
}
