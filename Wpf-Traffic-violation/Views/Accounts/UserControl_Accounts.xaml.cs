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
    /// Interaction logic for UserControl_Accounts.xaml
    /// </summary>
    public partial class UserControl_Accounts : UserControl
    {
        public UserControl_Accounts()
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
                        
                        Frame_Accounts.Content = new UserControl_OperationAcconts();
                        break;
                    }
                //case 2:
                //    {

                        
                //        break;
                //    }
                case 3:
                    {
                        Frame_Accounts.Content = new UserControl_BondOfExchange();

                        break;
                    }
                case 4:
                    {
                        Frame_Accounts.Content = new UserControl_Receipt();

                        break;
                    }
                case 5:
                    {
                        Properties.Settings.Default.Deportationtype = 0;
                        Properties.Settings.Default.Save();
                        Frame_Accounts.Content = new UserControl_Deportation();

                        break;
                    }
                case 6:
                    {
                        Properties.Settings.Default.Deportationtype = 1;
                        Properties.Settings.Default.Save();
                        Frame_Accounts.Content = new UserControl_CancelTheDeportation();

                        break;
                    }
            }
        }
        private void Changed_Background(Button but)
        {

            Color ColorforN = (Color)ColorConverter.ConvertFromString("#B29FA8DA");//color forground
            Color ColorforF = (Color)ColorConverter.ConvertFromString("#03719C");//color Cureent

            but1.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            //but2.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but3.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but4.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but5.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but6.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));



            but1.BorderBrush = Brushes.White;
            //but2.BorderBrush = Brushes.White;
            but3.BorderBrush = Brushes.White;
            but4.BorderBrush = Brushes.White;
            but5.BorderBrush = Brushes.White;
            but6.BorderBrush = Brushes.White;


            //but.Foreground = Brushes.DarkOrange;
            but.Foreground= new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
            //but.BorderBrush = Brushes.DarkOrange;
            but.BorderBrush= new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
        }
    }
}
