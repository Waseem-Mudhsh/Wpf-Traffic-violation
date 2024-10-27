using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Views.Reports;
using Wpf_Traffic_violation.Views.Reservation;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControlForm1.xaml
    /// </summary>
    public partial class UserControlForm1 : UserControl
    {
        AllPermissions AllPermissions = new AllPermissions();
        UserControl userControl;

        public UserControlForm1()
        {
            InitializeComponent();
            GetpermationForMenu();

            GridPageFrom1.Content = new UserControl_Home();

        }
        private void GetpermationForMenu()
        {
            try
            {
                var permation = Properties.Settings.Default.permissionUser;

                foreach (var menue in permation.MenuPrevlg)
                {
                    if (menue.name == "Violations" && !menue.is_active)
                        Violations.IsEnabled = false;
                    if (menue.name == "Reports" && !menue.is_active)
                        Reports.IsEnabled = false;
                    if (menue.name == "Settings" && !menue.is_active)
                        Settings.IsEnabled = false;
                    if (menue.name == "Incidents" && !menue.is_active)
                        Incidents.IsEnabled = false;
                    if (menue.name == "Users" && !menue.is_active)
                        Users.IsEnabled = false;
                }

            }
            catch
            {

            }


        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {

            Button but = ((Button)sender);
            Changed_Backgroung(but);
            int index = int.Parse(((Button)e.Source).Uid);

            //var permation = Properties.Settings.Default.permissionUser;
            //foreach (var form in permation.FormPrevlg)
            //{
            //    //if (index =)
            //    //    form.FormId =

            //}
            var permation = Properties.Settings.Default.permissionUser;

            var result = permation.MenuPrevlg.Where(o => o.menu_id == index).ToList();
            //var result = permation.MenuPrevlg.Where(o => o.menu_id == index).ToList();
            foreach (var perMenu in result)
            {
                var per = permation.FormPrevlg.FirstOrDefault(o => o.MenuId == index);

                if (perMenu.menu_id == 1009)
                {

                    UserControl_Violations UserControl_Violations = new UserControl_Violations();
                    if (per.FormName == "عمليات المخالفات")
                        UserControl_Violations.but1.IsEnabled = per.PrivilegeForm;
                    if (per.FormName == "الاستعلام عن مخالفات")
                        UserControl_Violations.but2.IsEnabled = per.PrivilegeForm;

                    userControl = UserControl_Violations;
                }
                if (perMenu.menu_id == 2)
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

                }
                if (perMenu.menu_id == 1004)
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
                    userControl = UserControl_Configuration;
                }
                if (perMenu.menu_id == 1002)
                {

                    UserControl_Reports userControl_Reports = new UserControl_Reports();

                    userControl_Reports.but1.IsEnabled = true;
                    userControl_Reports.but2.IsEnabled = true;
                    userControl_Reports.but3.IsEnabled = false;
                    userControl_Reports.but4.IsEnabled = false;
                    userControl_Reports.but5.IsEnabled = true;
                    userControl_Reports.but6.IsEnabled = true;

                    userControl = userControl_Reports;

                }
                if (perMenu.menu_id == 1007)
                {
                    Main_reservation main_Reservation = new Main_reservation();
                    if (per.FormName == "عمليات الحجز")
                        main_Reservation.but2_op.IsEnabled = per.PrivilegeForm;
                    if (per.FormName == "خروج")
                        main_Reservation.but2.IsEnabled = per.PrivilegeForm;
                    if (per.FormName == "دخول")
                        main_Reservation.but1.IsEnabled = per.PrivilegeForm;
                    if (per.FormName == "تحصيل")
                        main_Reservation.but2_pid.IsEnabled = per.PrivilegeForm;
                    userControl = main_Reservation;

                }
                if (perMenu.menu_id == 1005)
                {
                    UserControl_Users userControl_Users = new UserControl_Users();


                    if (per.FormName == "منح الصلاحيات")
                        userControl_Users.but3.IsEnabled = per.PrivilegeForm;
                    if (per.FormName == "حركة المستخدمين")
                        userControl_Users.but4.IsEnabled = per.PrivilegeForm;
                    if (per.FormName == "عمليات المستخدمين")
                        userControl_Users.but1.IsEnabled = per.PrivilegeForm;

                    userControl = userControl_Users;
                    break;
                }
                if (perMenu.menu_id == 1003)

                {
                    UserControl_SystemMaintenance userControl_SystemMaintenance = new UserControl_SystemMaintenance();
                    userControl = userControl_SystemMaintenance;

                }



            }


            GridPageFrom1.Content = userControl;


        }



        //public bool HasPermission(string permission)
        //{
        //    // Check if the current user has the required permission
        //    return false;
        //}
        private void Changed_Backgroung(Button but)
        {
            Color ColorgroN = (Color)ColorConverter.ConvertFromString("#FF00008B");//color background
            Color ColorforN = (Color)ColorConverter.ConvertFromString("#FFFFFFFF");//color forground

            //but1.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but2.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            Violations.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            Objections.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            Users.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            Incidents.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            Reports.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            Settings.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));

            //but1.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            but2.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            Settings.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            Violations.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            Users.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            Objections.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            //Reports.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            Reports.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));
            Incidents.Background = new SolidColorBrush(Color.FromArgb(ColorgroN.A, ColorgroN.R, ColorgroN.G, ColorgroN.B));



            but.Background = Brushes.White;
            but.Foreground = Brushes.DarkBlue;
        }

        private void But_Home_Click(object sender, RoutedEventArgs e)
        {
            GridPageFrom1.Content = new UserControl_Home();
        }
    }
}

