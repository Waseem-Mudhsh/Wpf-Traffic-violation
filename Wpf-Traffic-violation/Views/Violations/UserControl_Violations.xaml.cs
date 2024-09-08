using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wpf_Traffic_violation.Views
{
    /// <summary>
    /// Interaction logic for UserControl_Violations.xaml
    /// </summary>
    public partial class UserControl_Violations : UserControl
    {
        public UserControl_Violations()
        {
            InitializeComponent();
        }

        private void but_sub_ButtonClick(object sender, RoutedEventArgs e)
        {
            Button but = ((Button)sender);
            Changed_Background(but);
            int index = int.Parse(((Button)e.Source).Uid);
            var permation = Properties.Settings.Default.permissionUser.FormPrevlg.Where(o => o.FormId == index).ToList();

            foreach (var rol in permation)

            {
                if (index == 1007)
                {
                    UserControl_OperationViolation userControl_OperationViolation = new UserControl_OperationViolation();
                    userControl_OperationViolation.But_Add_Violation.IsEnabled = rol.PrivilegeAdd;
                    userControl_OperationViolation.But_Edit_Violation.IsEnabled = rol.PrivilegeUpdate;
                    userControl_OperationViolation.But_Delete_Violation.IsEnabled = rol.PrivilegeDelete;
                    userControl_OperationViolation.but1.IsEnabled = rol.PrivilegeAdd;
                    Frame_Violation.Content = userControl_OperationViolation;
                    break;
                }
                if (index == 1008)
                {
                    UserControl_QureyIdNumber userControl_QureyIdNumber = new UserControl_QureyIdNumber();
                    userControl_QureyIdNumber.butn_Query.IsEnabled = rol.PrivilegeUpdate;
                    userControl_QureyIdNumber.AmntDisconr.IsEnabled = rol.PrivilegeUpdate;
                    userControl_QureyIdNumber.searchBT1.IsEnabled = rol.PrivilegeSelect;
                    userControl_QureyIdNumber.but_PayViolation.IsEnabled = rol.PrivilegeAdd;
                    Frame_Violation.Content = userControl_QureyIdNumber;

                    break;

                    //AllPermissions AllPermissions = new AllPermissions();
                    //PermissionUser PermissionUser;
                    //PermissionUser = new PermissionUser();
                    //AllPermissions.getPermission(PermissionUser);
                    //if (PermissionUser.Form == false)
                    //{
                    //    UserControl_QureyViolation.butn1.IsEnabled = false;
                    //}
                    //PermissionUser = new PermissionUser();
                    //PermissionUser.Form_id = 4;
                    //AllPermissions.getPermission(PermissionUser);
                    //if (PermissionUser.Form == false)
                    //{
                    //    UserControl_QureyViolation.butn2.IsEnabled = false;
                    //}
                    //PermissionUser = new PermissionUser();
                    //PermissionUser.Form_id = 5;
                    //AllPermissions.getPermission(PermissionUser);
                    //if (PermissionUser.Form == false)
                    //{
                    //    UserControl_QureyViolation.butn3.IsEnabled = false;
                    //}

                    //Frame_Violation.Content = UserControl_QureyViolation;


                }


            }
        }

        private void Changed_Background(Button but)
        {

            Color ColorforN = (Color)ColorConverter.ConvertFromString("#B29FA8DA");//color forground
            Color ColorforF = (Color)ColorConverter.ConvertFromString("#03719C");//color Cureent

            but1.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));
            but2.Foreground = new SolidColorBrush(Color.FromArgb(ColorforN.A, ColorforN.R, ColorforN.G, ColorforN.B));




            but1.BorderBrush = Brushes.White;
            but2.BorderBrush = Brushes.White;
            //but.Foreground = Brushes.DarkOrange;
            but.Foreground = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
            //but.BorderBrush = Brushes.DarkOrange;
            but.BorderBrush = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
        }
    }
}
