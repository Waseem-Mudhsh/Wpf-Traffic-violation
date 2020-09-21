using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Users_Model;

namespace Wpf_Traffic_violation.ViewModel
{
    public class PermissionUser_ViewModel : BindableBase
    {

        #region Objects And Variables


        Models.Users_Model.PermissionUserModel PermissionUserModel = new Models.Users_Model.PermissionUserModel();
        UserModel UserModel = new UserModel();
        PermissionUser PermissionUser;

        #endregion
        #region Proprties
        ObservableCollection<String> comb;
        public ObservableCollection<String> Comb //يربط مع الجرد فيو 
        {
            get
            {
                return comb;
            }
            set
            {
                if (comb != value)
                {
                    comb = value;
                    RaisePropertyChanged("Comb");
                }
            }
        }
        string _selected_value; //selectedItemيربط مع 

        public string selected_value
        {
            get
            {
                return _selected_value;
            }
            set
            {
                if (_selected_value != value)
                {
                    _selected_value = value;
                    RaisePropertyChanged("selected_value");
                    Change();
                }
            }
        }
        ObservableCollection<PermissionUser> grid_PermissionUser;
        public ObservableCollection<PermissionUser> Grid_PermissionUsers //يربط مع الجرد فيو 
        {
            get
            {
                return grid_PermissionUser;
            }
            set
            {
                if (grid_PermissionUser != value)
                {
                    grid_PermissionUser = value;
                    RaisePropertyChanged("Grid_PermissionUsers");
                }
            }
        }

        PermissionUser currunt_PermissionUser; //selectedItemيربط مع 

        public PermissionUser Currunt_PermissionUser
        {
            get
            {
                return currunt_PermissionUser;
            }
            set
            {
                if (currunt_PermissionUser != value)
                {
                    currunt_PermissionUser = value;
                    RaisePropertyChanged("Currunt_PermissionUser");
                }
            }
        }

        ObservableCollection<User> grid_User;
        public ObservableCollection<User> Grid_User //يربط مع الجرد فيو 
        {
            get
            {
                return grid_User;
            }
            set
            {
                if (grid_User != value)
                {
                    grid_User = value;
                    RaisePropertyChanged("grid_User");
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

        #endregion
        #region Construcor
        public PermissionUser_ViewModel()
        {
            Comb = new ObservableCollection<string>();
            Comb.Add("المخالفات");
            Comb.Add("الإعتراضات");
            Comb.Add("البلاغات");
            Comb.Add("الحسابات");
            Comb.Add("المستخدمين");
            Comb.Add("التهيئة");
            Comb.Add("الإعدادات");
            Comb.Add("التقارير");

            // PermissionGroupModel.GetPermisstionGroup(Grid_PermissionGroup, "setting", 1);
            Grid_User = new ObservableCollection<User>();
            Grid_User = UserModel.GetUsers();


            Permissioncommand = new RelayCommand(par => SetPermission(), par => CanSetPermission());
            SavePermissioncommand = new RelayCommand(par => SavePermission(), par => CanSavePermission());
            Changecommad = new RelayCommand(par => Change());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id =31;
            new AllPermissions().getPermission(PermissionUser);
        }
        #endregion
        #region Methodes And Events
        void SetPermission()
        {

            Grid_PermissionUsers = new ObservableCollection<PermissionUser>();
            PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "setting", Currunt_User.Userid);
            selected_value = "المخالفات";
        }
        bool CanSetPermission() => Currunt_User != null && PermissionUser.Add_opretion == true;
        void SavePermission()
        {
            foreach (PermissionUser a in Grid_PermissionUsers)
            {
                PermissionUserModel.OperarionPermissionUser(a, "Update");
                // MessageBox.Show(a.Add_opretion.ToString());
            }
            // MessageBox.Show(selected_value);
        }
        bool CanSavePermission() => Grid_PermissionUsers != null;
        void Change()
        {
            SavePermission();
            Grid_PermissionUsers = new ObservableCollection<PermissionUser>();

            if (selected_value == "المخالفات")
             {
                    PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "violation", Currunt_User.Userid);
                 
            }
            else if (selected_value == "المستخدمين")
            {
                PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "user", Currunt_User.Userid);
            }
            else if(selected_value == "الإعدادات")
            {
                PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "setting", Currunt_User.Userid);

            }
            else if (selected_value == "الإعتراضات")
            {

                PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "interception", Currunt_User.Userid);
            }
            else if (selected_value == "البلاغات")
            {

                PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "communication", Currunt_User.Userid);
            }
            else if (selected_value == "الحسابات")
            {

                PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "account", Currunt_User.Userid);
            }
            else if (selected_value == "التهيئة")
            {

                PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "format", Currunt_User.Userid);
            }
            else if (selected_value == "التقارير")
            {

                PermissionUserModel.GetPermissionUser(Grid_PermissionUsers, "report", Currunt_User.Userid);
            }



        }
        #endregion
        #region Commands

        public RelayCommand Permissioncommand { get; private set; }
        public RelayCommand SavePermissioncommand { get; private set; }
        public RelayCommand Changecommad { get; private set; }
        #endregion






        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
