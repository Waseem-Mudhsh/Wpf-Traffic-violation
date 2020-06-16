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
    /// Interaction logic for UserControl_Home.xaml
    /// </summary>
    public partial class UserControl_Home : UserControl
    {
        public UserControl_Home()
        {
            InitializeComponent();
            //Frame_home.Content = new UserControl1GridDataCommunications();
           
        }

        private void but_setting_Click(object sender, RoutedEventArgs e)
        {
            Color ColorforN = (Color)ColorConverter.ConvertFromString("#90a4ae");//color forground
            Button but = ((Button)sender);
            int index = int.Parse(((Button)e.Source).Uid);
            Rectangle_home.Margin = new Thickness(0, 0, (133 * index), 0);
            

            if (index == 0)
            {
                but.Foreground = Brushes.OrangeRed;
                but_Objections.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            }
            else
            {
                but.Foreground = Brushes.OrangeRed;
                but_Communications.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            }
        }
    }
}
