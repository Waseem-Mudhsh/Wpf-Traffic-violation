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
            var permation = Properties.Settings.Default.Userpermission;
            switch (index)
            {

                case 1:
                    {


                        Frame_Violation.Content = new UserControl_OperationViolation();
                        break;
                    }
                case 2:
                    {
                        UserControl_QureyViolation UserControl_QureyViolation = new UserControl_QureyViolation();
                        UserControl_QureyViolation.butn1.IsEnabled = true;
                        UserControl_QureyViolation.butn2.IsEnabled = true;
                        UserControl_QureyViolation.butn3.IsEnabled = true;
                      
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

                        Frame_Violation.Content = UserControl_QureyViolation;
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
           
          


            but1.BorderBrush = Brushes.White;
            but2.BorderBrush = Brushes.White;
          




            //but.Foreground = Brushes.DarkOrange;
            but.Foreground = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
            //but.BorderBrush = Brushes.DarkOrange;
            but.BorderBrush = new SolidColorBrush(Color.FromArgb(ColorforF.A, ColorforF.R, ColorforF.G, ColorforF.B));
        }
    }
}
