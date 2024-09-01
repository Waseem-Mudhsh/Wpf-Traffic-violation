using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
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
        ObservableCollection<User> grid_Users;
        public ObservableCollection<User> Grid_Users
        {
            get
            {
                return grid_Users;
            }
            set
            {
                if (grid_Users != value)
                {
                    grid_Users = value;
                    RaisePropertyChanged("Grid_Users");
                }
            }
        }

        ObservableCollection<User_type> grid_Usertype;
        public ObservableCollection<User_type> Grid_Usertype
        {
            get
            {
                return grid_Usertype;
            }
            set
            {
                if (grid_Usertype != value)
                {
                    grid_Usertype = value;
                    RaisePropertyChanged("Grid_Usertype");
                }
            }
        }


        ObservableCollection<TrafficMan> grid_Trafficman;
        public ObservableCollection<TrafficMan> Grid_Trafficman
        {
            get
            {
                return grid_Trafficman;
            }
            set
            {
                if (grid_Trafficman != value)
                {
                    grid_Trafficman = value;
                    RaisePropertyChanged("Grid_Trafficman");
                }
            }
        }
        ObservableCollection<TrafficMan> grid_CombboxTraffic;
        public ObservableCollection<TrafficMan> Grid_CombboxTraffic
        {
            get
            {
                return grid_CombboxTraffic;
            }
            set
            {
                if (grid_CombboxTraffic != value)
                {
                    grid_CombboxTraffic = value;
                    RaisePropertyChanged("Grid_CombboxTraffic");
                }
            }
        }

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
        User_type selected_UserType;
        public User_type Selected_UserType
        {
            get
            {
                return selected_UserType;
            }
            set
            {
                if (selected_UserType != value)
                {
                    selected_UserType = value;
                    RaisePropertyChanged("Selected_UserType");
                }
            }
        }






        #endregion
        #region Construcor
        public User_ViewModel()
        {
            //Grid_CombboxTraffic = new ObservableCollection<TrafficMan>();

            //Grid_Trafficman = new ObservableCollection<TrafficMan>();
            //Grid_Trafficman = trafficMan.Get_trafficmanNametoUser();

            //Grid_Trafficman = trafficMan.Get_trafficmanNametoUser();
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            Grid_Users = new ObservableCollection<User>();
            Grid_Usertype = new ObservableCollection<User_type>();
            Grid_Users = userModel.GetUsers();
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //MessageBox.Show($"Total execution time1:{ elapsedMs}");
            Addcommand = new RelayCommand(Par => AddAsync(), Par => CanAdd());
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 29;


            Current_Activity = new Activity();

        }
        #endregion
        #region Methodes And Events
        private async Task asyncUser()
        {
            Grid_Users = new ObservableCollection<User>();
            Grid_Users = await Task.Run(() => userModel.GetUsers());

            //Grid_Trafficman = await Task.Run(()=> trafficMan.Get_trafficmanNametoUser());
        }
        public async Task AddAsync()
        {
            //Grid_CombboxTraffic = trafficMan.Get_trafficmanNametoUser_Combbox();
            //int maxid = new Class_SqlConnection().Get_Max("User");
            Grid_Usertype = await Task.Run(() => userModel.GetUserType());

            Currunt_User = new User { Userid = 0, String_usertype = "" };
            Selected_TrafficMan = new TrafficMan();
            win = new Window_AddUser { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true;
        void Edit()
        {
            //Grid_Trafficman = trafficMan.Get_trafficmanNametoUser();
            IsEditing = true;
            Selected_TrafficMan = new TrafficMan();
            win = new Window_AddUser { DataContext = this };
            foreach (TrafficMan a in Grid_Trafficman)
            {
                if (a.User_id == Currunt_User.Userid)
                    Selected_TrafficMan = a;
            }

            //win.trafficman.SelectedItem = Selected_TrafficMan;
            //win.trafficman.IsEnabled = false;
            win.ShowDialog();

        }
        bool CanEdit() => Currunt_User != null;
        void Delet()
        {
            Selected_TrafficMan = new TrafficMan();
            foreach (TrafficMan a in Grid_Trafficman)
            {
                if (a.User_id == Currunt_User.Userid)
                    Selected_TrafficMan = a;
            }
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            //Selected_TrafficMan.Traffic_man_id = Currunt_User.Userid;
            //Selected_TrafficMan.User_id = Currunt_User.Userid;
            asyncUser();
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 29;
                Current_Activity.Activity_record_num = Currunt_User.Userid;



                trafficMan.Update_Uesrid(Selected_TrafficMan, "Delete_User");
                userModel.OperarionUser(Currunt_User, "Delete");
                Grid_Users.Remove(Currunt_User);

                string message1 = "تمت عملية الحذف بنجاح";
                string caption1 = "عملية التعديل";
                MessageBoxImage icon1 = MessageBoxImage.Information;
                MessageBoxButton buttons1 = MessageBoxButton.OK;
                MessageBox.Show(message1, caption1, buttons1, icon1);
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
        //bool CanDelet() => Currunt_User != null && PermissionUser.Delete_opretion == true;
        bool CanDelet() => true;
        void Save()
        {
            //Selected_TrafficMan.User_id = Currunt_User.Userid;
            //Currunt_User.Username = Selected_TrafficMan.Traffic_man_name;
            //////////////////////////////////////////////////////////////

            //Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            //Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            //Current_Activity.User_id = Properties.Settings.Default.Userid;
            //Current_Activity.Form_id = 29;
            //Current_Activity.Activity_record_num = /*selected_UserType*/.userTypeid;

            //////////////////////////////////////////////////////////

            Currunt_User.Usertype = selected_UserType.UserTypeid;
            //var IsExsit = userModel.Check_Exsit(Currunt_User.Userid);
            //if (IsExsit)
            //{

            //    string message = "رقم المستخدم موجود مسبقا";
            //    string caption = "رسالة خطا";
            //    MessageBoxImage icon = MessageBoxImage.Error;
            //    MessageBoxButton buttons = MessageBoxButton.OK;
            //    MessageBox.Show(message, caption, buttons, icon);

            //    win.textBox_id.Focus();
            //    win.textBox_id.SelectionStart = 0;
            //    win.textBox_id.SelectionLength = win.textBox_id.Text.Length;

            //}
            if (IsEditing)
            {

                userModel.OperarionUser(Currunt_User, "Update");

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
            /*else*/ //if (userModel.Check_Exsit(Currunt_User.Userid))
            else
            {
                try
                {
                    var result = userModel.OperarionUser(Currunt_User, "Insert");

                    //trafficMan.Update_Uesrid(Selected_TrafficMan, "Updete_User");
                    if (result)
                    {
                        Grid_Users.Add(Currunt_User);
                        close();
                        string message = "تمت عملية الإضافة بنجاح";
                        string caption = "عملية الإضافة";
                        MessageBoxImage icon = MessageBoxImage.Information;
                        MessageBoxButton buttons = MessageBoxButton.OK;
                        MessageBox.Show(message, caption, buttons, icon);

                        ////////////////////////////////////////////////////////////
                        Current_Activity.Activity_operation_num = 1;
                        ActivityModel.OperarionActivity(current_Activity, "Insert");
                    }
                    else
                    {

                    }
                }
                catch
                {

                }



                ////////////////////////////////////////////////////////////

            }



            //Enable_Grid = false;
        }
        //bool CanSave() => Currunt_User != null && !Currunt_User.HasErrors;
        bool CanSave() => true;
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
