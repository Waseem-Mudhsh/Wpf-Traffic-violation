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
    /// Interaction logic for UserControl_Main.xaml
    /// </summary>
    public partial class UserControl_Main : UserControl
    {
        
        
        public UserControl_Main()
        {
            InitializeComponent();
            Frame_main.Content = new UserControlForm1();
            
        }

        private void But_close_Click(object sender, RoutedEventArgs e)
        {
            string message = "هل تريد الخروج من النظام ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                return;
            }
            
        }

        private void But_Home_Click(object sender, RoutedEventArgs e)
        {


            Frame_main.Content = new UserControlForm1();

        }

        private void But_Logout_Click(object sender, RoutedEventArgs e)
        {
            string message = "هل تريد تسجيل الخروج ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                GridMain.Children.Clear();
                GridMain.Children.Add(new UserControl_Login());
            }
            else
            {
                return;
            }


        }
    }
}
