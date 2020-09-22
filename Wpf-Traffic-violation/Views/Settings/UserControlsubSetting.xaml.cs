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
using Wpf_Traffic_violation.Models.Users_Model;

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

               
                case 1:
                    {

                        Frame_Setting.Content = new UserControl_NotificationSystem();
                        break;
                    }
                case 2:
                    {
                        //AllPermissions AllPermissions = new AllPermissions();
                        //PermissionUser PermissionUser;
                        UserControl_ConnectDatabase UserControl_ConnectDatabase = new UserControl_ConnectDatabase();

                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 34;
                        //AllPermissions.getPermission(PermissionUser);
                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_ConnectDatabase.but1.IsEnabled = false;
                        //}
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 35;
                        //AllPermissions.getPermission(PermissionUser);
                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_ConnectDatabase.but2.IsEnabled = false;
                        //}
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 36;
                        //AllPermissions.getPermission(PermissionUser);
                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_ConnectDatabase.but3.IsEnabled = false;
                        //}
                        Frame_Setting.Content = UserControl_ConnectDatabase;

                        break;
                    }
                case 3:
                    {
                        Frame_Setting.Content = new UserControl_BackUp();
                        break;
                    }
                case 4:
                    {
                        Frame_Setting.Content = new UserControl_RestoreTheBackup();
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




            but1.BorderBrush = Brushes.White;
            but2.BorderBrush = Brushes.White;
            but3.BorderBrush = Brushes.White;
            but4.BorderBrush = Brushes.White;



            //but.Foreground = Brushes.DarkOrange;
            but.Foreground = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
            //but.BorderBrush = Brushes.DarkOrange;
            but.BorderBrush = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
        }
    }
    }
