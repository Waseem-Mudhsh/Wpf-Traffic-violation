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
using Wpf_Traffic_violation.ViewModel;
using Wpf_Traffic_violation.Views.Reports;

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
            PermissionUser PermissionUser;

            AllPermissions AllPermissions = new AllPermissions();

            switch (index)
            {
               
                case 1:
                    {
                        UserControl_Reports UserControl_Reports = new UserControl_Reports();

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 38;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Reports.but1.IsEnabled = false;
                        }

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 39;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Reports.but2.IsEnabled = false;
                        }

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 40;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Reports.but3.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 41;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Reports.but4.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 42;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Reports.but5.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 43;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Reports.but6.IsEnabled = false;
                        }


                        GridPageFrom1.Content = UserControl_Reports;
                        break;
                    }
                case 2:
                    {
                        UserControl_Configuration UserControl_Configuration = new UserControl_Configuration();

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 18;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but1.IsEnabled = false;
                        }

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 19;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but2.IsEnabled = false;
                        }

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 20;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but3.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 21;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but7.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 22;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but4.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 23;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but6.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 24;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but11.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 25;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but5.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 26;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but9.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 27;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but10.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 28;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Configuration.but8.IsEnabled = false;
                        }
                        GridPageFrom1.Content = UserControl_Configuration;
                        break;
                    }
                case 3:
                    {
                        UserControl_Accounts UserControl_Accounts = new UserControl_Accounts();
                           PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 12;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Accounts.but1.IsEnabled = false;
                        }
                       

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 13;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Accounts.but2.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 14;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Accounts.but3.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 15;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Accounts.but4.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 16;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Accounts.but5.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 17;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Accounts.but6.IsEnabled = false;
                        }

                        GridPageFrom1.Content = UserControl_Accounts;
                        
                        break;
                    }
                case 4:
                    {
                        UserControl_Communications UserControl_Communications = new UserControl_Communications();
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 10;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Communications.but1.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 11;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Communications.but2.IsEnabled = false;
                        }

                        GridPageFrom1.Content = UserControl_Communications;
                        break;
                    }
                case 5:
                    {
                        UserControl_Objections UserControl_Objections = new UserControl_Objections();
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 8;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Objections.but1.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 9;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Objections.but2.IsEnabled = false;
                        }

                        GridPageFrom1.Content = UserControl_Objections;
                        break;
                    }
                case 6:
                    {
                        UserControl_Violations UserControl_Violations = new UserControl_Violations();
                           PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 1;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Violations.but1.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 7;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Violations.but3.IsEnabled = false;
                        }
                        GridPageFrom1.Content = UserControl_Violations;
                        break;
                    }
                case 7:
                    {
                        UserControl_Users UserControl_Users = new UserControl_Users();
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 29;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Users.but1.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 30;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Users.but2.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 31;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Users.but3.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 32;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControl_Users.but4.IsEnabled = false;
                        }


                        GridPageFrom1.Content = UserControl_Users;
                        break;
                    }
                case 8:
                    {
                        UserControlsubSetting UserControlsubSetting = new UserControlsubSetting();
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 33;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControlsubSetting.but1.IsEnabled = false;
                        }
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 37;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                        {
                            UserControlsubSetting.but3.IsEnabled = false;
                        }
                        GridPageFrom1.Content = UserControlsubSetting;
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

