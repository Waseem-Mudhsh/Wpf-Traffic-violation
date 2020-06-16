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

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControlForm1.xaml
    /// </summary>
    public partial class UserControlForm1 : UserControl
    {
        public UserControlForm1()
        {
            InitializeComponent();
            GridPageFrom1.Content = new UserControl_Home();


        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            Button but = ((Button)sender);
            Changed_Backgroung(but);
            int index = int.Parse(((Button)e.Source).Uid);
            
            
            //GridCursor.Margin = new Thickness(3 + (115 * index), 0, 0, 0);


            switch (index)
            {
               
                case 1:
                    {
                        GridPageFrom1.Content = new UserControlsubSetting();
                        break;
                    }
                case 2:
                    {

                        GridPageFrom1.Content = new UserControl_Configuration();
                        break;
                    }
                case 3:
                    {
                        GridPageFrom1.Content = new UserControl_Accounts();
                        
                        break;
                    }
                case 4:
                    {
                        GridPageFrom1.Content = new UserControl_Communications();
                        break;
                    }
                case 5:
                    {
                        GridPageFrom1.Content = new UserControl_Objections();
                        break;
                    }
                case 6:
                    {
                        GridPageFrom1.Content = new UserControl_Violations();
                        break;
                    }
                case 7:
                    {
                        GridPageFrom1.Content = new UserControl_Users();
                        break;
                    }
                case 8:
                    {
                        GridPageFrom1.Content = new UserControlsubSetting();
                        break;
                    }



            }
        }

        private void Changed_Backgroung(Button but)
        {
            Color ColorgroN = (Color)ColorConverter.ConvertFromString("#FF00008B");//color background
            Color ColorforN = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");//color forground

            but1.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but2.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but3.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but4.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but5.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but6.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but7.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but8.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));

            but1.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            but2.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            but3.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            but4.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            but5.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            but6.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            but7.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            but8.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));



            but.Background = Brushes.White;
            but.Foreground = Brushes.DarkBlue;
        }

        private void But_Home_Click(object sender, RoutedEventArgs e)
        {
            GridPageFrom1.Content = new UserControl_Home();
        }
    }
    }

