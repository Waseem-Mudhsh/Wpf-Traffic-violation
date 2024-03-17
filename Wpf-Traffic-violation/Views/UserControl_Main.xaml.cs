using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation.Models;

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
            GetUserControlData();
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

        private void But_mins_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private List<UserControlData> GetUserControlData()
        {
            var userControlData = new List<UserControlData>();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is UserControl)
                {
                    var userControl = window;
                    var data = new UserControlData
                    {
                        Name = userControl.Name,
                        // Add additional properties here as needed
                    };
                    userControlData.Add(data);
                }
            }

            return userControlData;
        }
    }
}
