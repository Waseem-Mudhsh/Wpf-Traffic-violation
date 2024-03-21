using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation.Core;

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
            //GetUserControlData();
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
                System.Windows.Application.Current.Shutdown();
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
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private List<UserControl> GetUserControlData()
        {

            var userControls = new List<UserControl>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    UserControlInfoAttribute attribute = type.GetCustomAttribute<UserControlInfoAttribute>();
                    if (attribute != null)
                    {
                        //dataAccess.AddUserControlRegistration(attribute.XamlFilePath); // Store in database
                    }
                }
            }

            return userControls;

        }
    }
}
