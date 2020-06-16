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
    /// Interaction logic for UserControl_Objections.xaml
    /// </summary>
    public partial class UserControl_Objections : UserControl
    {
        public UserControl_Objections()
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
                        Frame_Objection.Content = new UserControl_AddObjection();
                        break;
                    }
                case 2:
                    {

                        Frame_Objection.Content = new UserControl_ScanObjection();
                        break;
                    }
            }
        }
        private void Changed_Background(Button but)
        {

            Color ColorforN = (Color)ColorConverter.ConvertFromString("#B29FA8DA");//color forground


            but1.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but2.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
          


            but1.BorderBrush = Brushes.White;
            but2.BorderBrush = Brushes.White;
           



            but.Foreground = Brushes.DarkOrange;

            but.BorderBrush = Brushes.DarkOrange;
        }
    }
}
