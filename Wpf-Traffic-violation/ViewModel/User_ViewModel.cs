using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{

    public class User_ViewModel : BindableBase
    {

        Window_AddUser win;

        #region Objects And Variables

        Models.UserModel userModel = new UserModel();
        Models.TrafficmanModel trafficMan = new TrafficmanModel();
        PermissionUser PermissionUser;
        ActivityModel ActivityModel = new ActivityModel();

        #endregion
        #region Proprties

        Activity current_Activity; //selectedItemيربط مع 
        public Activity Current_Activity
        {
            get
            {
                return current_Activity;
            }
            set
            {
                if (current_Activity != value)
                {
                    current_Activity = value;
                    RaisePropertyChanged("Current_Activity");
                }
            }
        }

        public ObservableCollection<User> grid_Users { get; set; }
        public ObservableCollection<TrafficMan> get_Trafficman { get; set; }
        User currunt_User; //selectedItemيربط مع 
        public User Currunt_User
        {
            get
            {
                return currunt_User;
            }
            set
            {
                if (currunt_User != value)
                {
                    currunt_User = value;
                    RaisePropertyChanged("Currunt_User");
                }
            }
        }


        TrafficMan selected_TrafficMan;
        public TrafficMan Selected_TrafficMan
        {
            get
            {
                return selected_TrafficMan;
            }
            set
            {
                if (selected_TrafficMan != value)
                {
                    selected_TrafficMan = value;
                    RaisePropertyChanged("Selected_TrafficMan");
                }
            }
        }





        #endregion
        #region Construcor
        public User_ViewModel()
        {
            grid_Users = new ObservableCollection<User>();
            grid_Users = userModel.GetUsers();
            get_Trafficman = new ObservableCollection<TrafficMan>();
            trafficMan.GetTrafficMans(get_Trafficman);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 29;
            new AllPermissions().getPermission(PermissionUser);

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events
        public void Add()
        {
            int maxid = new Class_SqlConnection().Get_Max("User");

            Currunt_User = new User { Userid = maxid, String_usertype = "النظام" };
            Selected_TrafficMan = new TrafficMan();
            win = new Window_AddUser { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {

            IsEditing = true;
            win = new Window_AddUser { DataContext = this };
            win.Combobox_userName.IsEnabled = false;
            win.ShowDialog();

        }
        bool CanEdit() => Currunt_User != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            selected_TrafficMan = new TrafficMan();
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            selected_TrafficMan.Traffic_man_id = Currunt_User.Userid;
            Selected_TrafficMan.User_id = Currunt_User.Userid;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                UserModel.OperarionUser(Currunt_User, "Delete");
                trafficMan.Update_Uesrid(Selected_TrafficMan, "Delete_User");
                grid_Users.Remove(Currunt_User);
                string message1 = "تمت عملية الحذف بنجاح";
                string caption1 = "عملية التعديل";
                MessageBoxImage icon1 = MessageBoxImage.Information;
                MessageBoxButton buttons1 = MessageBoxButton.OK;
                MessageBox.Show(message1, caption1, buttons1, icon1);

                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 29;
                Current_Activity.Activity_record_num = Currunt_User.Userid;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }
            else
            {
                return;
            }


        }
        bool CanDelet() => Currunt_User != null && PermissionUser.Delete_opretion == true;
        void Save()
        {
            Selected_TrafficMan.User_id = Currunt_User.Userid;
            Currunt_User.Username = Selected_TrafficMan.Traffic_man_name;
            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 29;
            Current_Activity.Activity_record_num = Currunt_User.Userid;

            //////////////////////////////////////////////////////////
           

            if (Currunt_User.String_usertype == "النظام")
            {
                Currunt_User.Usertype = 1;
            }
            else if (Currunt_User.String_usertype == "التطبيق")
            {
                Currunt_User.Usertype = 2;
            }
            //else
            //{
            //    Currunt_User.Usertype = 3;
            //}
            if (IsEditing && userModel.Check_Exsit(Currunt_User.Userid))
            {

                UserModel.OperarionUser(Currunt_User, "Update");
                IsEditing = false;
                close();
                string message = "تمت عملية التعديل بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 2;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }
            else if (userModel.Check_Exsit(Currunt_User.Userid))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                win.textBox_id.Focus();
                win.textBox_id.SelectionStart = 0;
                win.textBox_id.SelectionLength = win.textBox_id.Text.Length;
            }

            else
            {


                trafficMan.Update_Uesrid(Selected_TrafficMan, "Updete_User");
                UserModel.OperarionUser(Currunt_User, "Insert");
                grid_Users.Add(Currunt_User);
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية الإضافة";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 1;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

            }



            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_User != null && !Currunt_User.HasErrors;
        void close()
        {
            Currunt_User = null;
            win.Close();
        }
        void GetExcel()
        {
            grid_Users = new ObservableCollection<User>();
            grid_Users = userModel.GetExcel();
        }
        #endregion
        #region Commands

        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; private set; }
        public RelayCommand Excelcommand { get; private set; }
        #endregion









        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
