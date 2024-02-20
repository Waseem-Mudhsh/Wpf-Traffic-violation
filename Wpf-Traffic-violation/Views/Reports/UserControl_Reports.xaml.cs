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
using Wpf_Traffic_violation.Views.Reports.Accounts;
using Wpf_Traffic_violation.Views.Reports.Communications;
using Wpf_Traffic_violation.Views.Reports.Configurations;
using Wpf_Traffic_violation.Views.Reports.Objections;
using Wpf_Traffic_violation.Views.Reports.Users;
using Wpf_Traffic_violation.Views.Reports.Violations;

namespace Wpf_Traffic_violation.Views.Reports
{
    /// <summary>
    /// Interaction logic for UserControl_Reports.xaml
    /// </summary>
    public partial class UserControl_Reports : UserControl
    {
        public UserControl_Reports()
        {
            InitializeComponent();
        }

        private void but_sub_ButtonClick(object sender, RoutedEventArgs e)
        {
            Button but = ((Button)sender);
            Changed_Background(but);
            int index = int.Parse(((Button)e.Source).Uid);
            PermissionUser PermissionUser;
            AllPermissions AllPermissions = new AllPermissions();
            switch (index)
            {

                case 1:
                    {
                        UserControl_Report_Configurations UserControl_Report_Configurations = new UserControl_Report_Configurations();
                        

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 44;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but1.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 45;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but2.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 46;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but3.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 47;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but4.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 48;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but5.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 49;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but6.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 50;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but7.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 51;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but8.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 52;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but9.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 53;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but10.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 54;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Configurations.but11.IsEnabled = false;

                        Frame_Report.Content = UserControl_Report_Configurations;
                        break;
                    }
                case 2:
                    {
                        UserControl_Report_Users UserControl_Report_Users = new UserControl_Report_Users();
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 55;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Users.but1.IsEnabled = false;
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 56;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Users.but2.IsEnabled = false;
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 57;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Users.but3.IsEnabled = false;
                        
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 59;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Users.but5.IsEnabled = false;

                        Frame_Report.Content = UserControl_Report_Users;
                        break;
                    }
                case 3:
                    {
                        UserControl_Report_Accounts UserControl_Report_Accounts = new UserControl_Report_Accounts();

                           PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 60;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Accounts.but1.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 61;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Accounts.but2.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 62;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Accounts.but3.IsEnabled = false;

                        Frame_Report.Content = UserControl_Report_Accounts;
                        break;
                    }
                case 4:
                    {
                        UserControl_Report_Communications UserControl_Report_Communications = new UserControl_Report_Communications();

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 60;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Communications.but1.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 61;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Communications.but2.IsEnabled = false;

                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 62;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Communications.but3.IsEnabled = false;

                        Frame_Report.Content = UserControl_Report_Communications;
                        break;
                    }
                case 5:
                    {
                        UserControl_Report_Objections UserControl_Report_Objections = new UserControl_Report_Objections();
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 63;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Objections.but1.IsEnabled = false;
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 64;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Objections.but2.IsEnabled = false;
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 65;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Objections.but3.IsEnabled = false;
                        PermissionUser = new PermissionUser();
                        PermissionUser.Form_id = 66;
                        AllPermissions.getPermission(PermissionUser);
                        if (PermissionUser.Form == false)
                            UserControl_Report_Objections.but4.IsEnabled = false;
                       


                        Frame_Report.Content = UserControl_Report_Objections;
                        break;
                    }
                case 6:
                    {
                        UserControl_Report_Violations UserControl_Report_Violations = new UserControl_Report_Violations();
                        UserControl_Report_Violations.but1.IsEnabled = true;
                        UserControl_Report_Violations.but3.IsEnabled = true;
                        UserControl_Report_Violations.but2.IsEnabled = true;
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 68;
                        //AllPermissions.getPermission(PermissionUser);
                        //if (PermissionUser.Form == false
                        //    )
                        //    UserControl_Report_Violations.but1.IsEnabled = false;
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 69;
                        //AllPermissions.getPermission(PermissionUser);
                        //if (PermissionUser.Form == false)
                        //    UserControl_Report_Violations.but2.IsEnabled = false;
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 70;
                        //AllPermissions.getPermission(PermissionUser);
                        //if (PermissionUser.Form == false)
                        //    UserControl_Report_Violations.but3.IsEnabled = false;
                        Frame_Report.Content = UserControl_Report_Violations;
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
            but5.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but6.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));

            but1.BorderBrush = Brushes.White;
            but2.BorderBrush = Brushes.White;
            but3.BorderBrush = Brushes.White;
            but4.BorderBrush = Brushes.White;
            but5.BorderBrush = Brushes.White;
            but6.BorderBrush = Brushes.White;



            //but.Foreground = Brushes.DarkOrange;
            but.Foreground = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
            //but.BorderBrush = Brushes.DarkOrange;
            but.BorderBrush = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
        }

    }
}
