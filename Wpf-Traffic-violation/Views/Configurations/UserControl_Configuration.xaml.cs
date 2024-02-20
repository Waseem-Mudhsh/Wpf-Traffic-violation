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
using Wpf_Traffic_violation.Views.Configurations;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_Configuration.xaml
    /// </summary>
    public partial class UserControl_Configuration : UserControl
    {
        public UserControl_Configuration()
        {
            InitializeComponent();
        }

        private void but_sub_ButtonClick(object sender, RoutedEventArgs e)
        {
            Button but = ((Button)sender);
            Changed_Background(but);
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {

                case 1:
                    {
                        Frame_Configuration.Content = new UserControl_DataTrafficMan();
                        break;
                    }
                case 2:
                    {

                        Frame_Configuration.Content = new UserControl_DataCitizen();
                        break;
                    }
                case 3:
                    {
                        Frame_Configuration.Content = new UserControl_DataVehicle();
                        break;
                    }
                case 4:
                    {
                        Frame_Configuration.Content = new UserControl_CategoriesOfLicenses();
                        break;
                    }
                case 5:
                    {
                        Frame_Configuration.Content = new UserControl_DataDrivingLicense();
                        break;
                    }
                case 6:
                    {
                        Frame_Configuration.Content = new UserControl_TypesOfPlates();
                        break;
                    }
                case 7:
                    {
                        Frame_Configuration.Content = new UserControl_DataPlate();
                        break;
                    }
                case 8:
                    {
                        UserControl_TypesViolations userControl_TypesViolations = new UserControl_TypesViolations();
                        userControl_TypesViolations.but1.IsEnabled = true;
                        userControl_TypesViolations.    But_Add_TypeViolation.IsEnabled = true;
                        userControl_TypesViolations.    But_Edit_TypeViolation.IsEnabled = true;
                        userControl_TypesViolations.    But_Delete_TypeViolation.IsEnabled = true;
                        Frame_Configuration.Content = new UserControl_TypesViolations();


                        break;
                    }
                case 9:
                    {
                        UserControl_Directorate userControl_Directorate = new UserControl_Directorate();
                        userControl_Directorate.But_Add_Citizen.IsEnabled = true;
                        userControl_Directorate.But_Delete_Citizen.IsEnabled = true;
                        userControl_Directorate.But_Edit_Citizen.IsEnabled = true;
                        Frame_Configuration.Content = userControl_Directorate;

                        break;
                    }
                case 10:
                    {
                        UserControl_Streets userControl_Streets = new UserControl_Streets();
                        userControl_Streets.But_Add_Citizen.IsEnabled = true;
                        userControl_Streets.But_Delete_Citizen.IsEnabled = true;
                        userControl_Streets.But_Edit_Citizen.IsEnabled = true;
                        Frame_Configuration.Content = new UserControl_Streets();

                        break;
                    }
                case 11:
                    {
                        Frame_Configuration.Content = new UserControl_ReasonsToObject();
                        break;
                    }



            }
        }
        private void Changed_Background(Button but)
        {

            Color ColorforN = (Color)ColorConverter.ConvertFromString("#B29FA8DA");//color forground
            Color ColorforF = (Color)ColorConverter.ConvertFromString("#03719C");//color Cureent

            but1.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but2.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but3.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but4.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but5.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but6.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but7.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but8.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but9.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but10.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but11.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
           


            but1.BorderBrush = Brushes.White;
            but2.BorderBrush = Brushes.White;
            but3.BorderBrush = Brushes.White;
            but4.BorderBrush = Brushes.White;
            but5.BorderBrush = Brushes.White;
            but6.BorderBrush = Brushes.White;
            but7.BorderBrush = Brushes.White;
            but8.BorderBrush = Brushes.White;
            but9.BorderBrush = Brushes.White;
            but10.BorderBrush = Brushes.White;
            but11.BorderBrush = Brushes.White;


            //but.Foreground = Brushes.DarkOrange;
            but.Foreground = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
            //but.BorderBrush = Brushes.DarkOrange;
            but.BorderBrush = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
        }
    }
}
