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
    /// Interaction logic for UserControlsubSetting.xaml
    /// </summary>
    public partial class UserControlsubSetting : UserControl
    {
        public UserControlsubSetting()
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

               
                case 2:
                    {

                        Frame_Setting.Content = new UserControl_DataCitizen();
                        break;
                    }
                case 3:
                    {
                        Frame_Setting.Content = new UserControl_CancelTheDeportation();
                        break;
                    }
                case 4:
                    {
                        Frame_Setting.Content = new UserControl_SystemMaintenance();
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                case 7:
                    {
                        Frame_Setting.Content = new UserControl_NotificationSystem();
                        break;
                    }




            }
        }
        private void Changed_Background(Button but)
        {
            
            Color ColorforN = (Color)ColorConverter.ConvertFromString("#B29FA8DA");//color forground
            

            
            but2.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but3.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but4.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but5.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but6.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but7.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));


           
            but2.BorderBrush = Brushes.White;
            but3.BorderBrush = Brushes.White;
            but4.BorderBrush = Brushes.White;
            but5.BorderBrush = Brushes.White;
            but6.BorderBrush = Brushes.White;
            but7.BorderBrush = Brushes.White;


            but.Foreground = Brushes.DarkOrange;
            
            but.BorderBrush = Brushes.DarkOrange;
        }
    }
    }
