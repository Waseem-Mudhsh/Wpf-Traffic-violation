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
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Services;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_Login.xaml
    /// </summary>
    public partial class UserControl_Login : UserControl
    {
        //readonly ViolationInterface _userServices;

        LoginModel LoginModel;
        //ViolationInterface _userServices;
        public UserControl_Login()
        {
       
            InitializeComponent();
            LoginModel = new LoginModel();

            username.Focus();
            username.SelectionStart = 0;
            username.SelectionLength = username.Text.Length;

        }

        private void But_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void but_Login_Click(object sender, RoutedEventArgs e)
        {

            //LoginModel = new LoginModel();
            if (username.Text != "" && password.Password.ToString() != "")
            {
                //var check = _userServices.checkforuser();
                //var checkofUser = _userServices.Login(username.Text, password.Password.ToString());
                //var checkofUsers = userServices.Login(username.Text, password.Password.ToString());
               var checkofUser = LoginModel.Login(username.Text, password.Password.ToString());
                if (checkofUser)
                {
                    UserControl_Main UserControl_Main = new UserControl_Main { DataContext = this };
                    Grid_Login.Children.Clear();
                    UserControl_Main.TextBlockUserName.Text = username.Text;
                   new AllPermissions().getAllPermissions();
                    Grid_Login.Children.Add(UserControl_Main);


                }
                else
                    MessageBox.Show("تاكد من صحة البيانات المدخلة");

            }
            else
                MessageBox.Show("يجب إدخال اسم المستخدم وكلمة السر الخاصة بك");
        }

       
    }
    }

