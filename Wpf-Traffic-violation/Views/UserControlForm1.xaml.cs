using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Views.Reports;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControlForm1.xaml
    /// </summary>
    public partial class UserControlForm1 : UserControl
    {
        AllPermissions AllPermissions = new AllPermissions();
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

            var permation = Properties.Settings.Default.Userpermission;
            //var getUserForms = AllPermissions.GetFormPermation(permation);




            switch (index)
            {


                case 1:
                    {

                        UserControl_Violations UserControl_Violations = new UserControl_Violations();
                        UserControl_Violations.but1.IsEnabled = false;
                        UserControl_Violations.but2.IsEnabled = false;
                        foreach (var row in permation)
                        {
                            if (row.Codeform == "11111")
                            {
                                UserControl_Violations.but1.IsEnabled = true;

                            }
                            if (row.Codeform == "11112")
                            {
                                UserControl_Violations.but2.IsEnabled = true;

                            }
                        }
                        GridPageFrom1.Content = UserControl_Violations;
                        break;
                    }
                case 2:
                    {

                        //UserControl_Objections UserControl_Objections = new UserControl_Objections();
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 8;
                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_Objections.but1.IsEnabled = false;
                        //}
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 9;
                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_Objections.but2.IsEnabled = false;
                        //}

                        //GridPageFrom1.Content = UserControl_Objections;
                        break;
                    }
                case 3:
                    {
                        UserControl_Configuration UserControl_Configuration = new UserControl_Configuration();
                        UserControl_Configuration.but1.IsEnabled = true;
                        //UserControl_Configuration.but2.IsEnabled = true;
                        UserControl_Configuration.but3.IsEnabled = true;
                        //UserControl_Configuration.but4.IsEnabled = true;
                        UserControl_Configuration.but5.IsEnabled = true;
                        UserControl_Configuration.but6.IsEnabled = true;
                        //UserControl_Configuration.but7.IsEnabled = true;
                        UserControl_Configuration.but8.IsEnabled = true;
                        UserControl_Configuration.but9.IsEnabled = true;
                        UserControl_Configuration.but10.IsEnabled = true;

                        GridPageFrom1.Content = UserControl_Configuration;
                        break;
                    }
                case 8:
                    {

                        UserControl_Reports UserControl_Reports = new UserControl_Reports();

                        UserControl_Reports.but1.IsEnabled = true;
                        UserControl_Reports.but2.IsEnabled = true;
                        UserControl_Reports.but3.IsEnabled = false;
                        UserControl_Reports.but4.IsEnabled = false;
                        UserControl_Reports.but5.IsEnabled = true;
                        UserControl_Reports.but6.IsEnabled = true;

                        GridPageFrom1.Content = UserControl_Reports;
                        break;
                    }
                case 4:
                    {
                        //UserControl_Accounts UserControl_Accounts = new UserControl_Accounts();
                        //PermissionUser = new PermissionUser();


                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_Accounts.but1.IsEnabled = false;
                        //}


                        ////PermissionUser = new PermissionUser();
                        ////PermissionUser.Form_id = 13;
                        ////
                        ////if (PermissionUser.Form == false)
                        ////{
                        ////    UserControl_Accounts.but2.IsEnabled = false;
                        ////}
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 14;

                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_Accounts.but3.IsEnabled = false;
                        //}
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 15;

                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_Accounts.but4.IsEnabled = false;
                        //}
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 16;

                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_Accounts.but5.IsEnabled = false;
                        //}
                        //PermissionUser = new PermissionUser();
                        //PermissionUser.Form_id = 17;

                        //if (PermissionUser.Form == false)
                        //{
                        //    UserControl_Accounts.but6.IsEnabled = false;
                        //}

                        //GridPageFrom1.Content = UserControl_Accounts;

                        break;
                    }
                case 7:
                    {
                        UserControl_SystemMaintenance userControl_SystemMaintenance = new UserControl_SystemMaintenance();
                        GridPageFrom1.Content = userControl_SystemMaintenance;
                        break;
                    }

            }


        }



        public bool HasPermission(string permission)
        {
            // Check if the current user has the required permission
            return false;
        }
        private void Changed_Backgroung(Button but)
        {
            Color ColorgroN = (Color)ColorConverter.ConvertFromString("#FF00008B");//color background
            Color ColorforN = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");//color forground

            //but1.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but2.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but3.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but4.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but5.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but6.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but7.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but8.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));

            //but1.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
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

