using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Users_Model;

namespace Wpf_Traffic_violation.ViewModel
{
    public class PermissionUser_ViewModel : BindableBase
    {

        #region Objects And Variables
        //Models.UserModel userModel = new UserModel();
        //public ICommand IsCheckCommand { get; set; }

        Models.Users_Model.PermissionUserModel PermissionUserModel = new Models.Users_Model.PermissionUserModel();
        UserModel UserModel = new UserModel();
        PermissionUser PermissionUser;

        #endregion
        #region Proprties
        ObservableCollection<String> comb;
        ObservableCollection<User_type> grid_Usertype;
        ObservableCollection<MenuDto> grid_Menu;
        ObservableCollection<MenuDetail> grid_MenuDetl;
        ObservableCollection<FormModel> grid_formMenu;
        ObservableCollection<PrivilegemenuUser> gridmenuUser;
        ObservableCollection<PrivilegemenuUser> GridmenuForUser
        {
            get
            {
                return gridmenuUser;

            }
            set
            {
                if (gridmenuUser != value)
                {
                    gridmenuUser = value;
                    RaisePropertyChanged("GridmenuForUser");
                }
            }

        }
        public ObservableCollection<MenuDto> Grid_menu
        {
            get
            {
                return grid_Menu;

            }
            set
            {
                if (grid_Menu != value)
                {
                    grid_Menu = value;
                    RaisePropertyChanged("Grid_menu");
                }
            }
        }
        public ObservableCollection<MenuDetail> Grid_MenuDetl
        {
            get
            {
                return grid_MenuDetl;

            }
            set
            {
                if (grid_MenuDetl != value)
                {
                    grid_MenuDetl = value;
                    RaisePropertyChanged("Grid_menuDetl");
                }
            }
        }
        public ObservableCollection<FormModel> Grid_formMenu
        {
            get
            {
                return grid_formMenu;

            }
            set
            {
                if (grid_formMenu != value)
                {
                    grid_formMenu = value;
                    RaisePropertyChanged("Grid_formMenu");
                }
            }
        }
        FormModel currunt_PermissionForm;
        public FormModel Currunt_PermissionForm
        {
            get
            {
                return currunt_PermissionForm;

            }
            set
            {
                if (currunt_PermissionForm != value)
                {
                    currunt_PermissionForm = value;
                    RaisePropertyChanged("Currunt_PermissionForm");
                }
            }
        }
        MenuDetail seletedMenuDetl;

        public MenuDetail SeletedMenuDetl
        {
            get
            {
                return seletedMenuDetl;

            }
            set
            {
                if (seletedMenuDetl != value)
                {
                    seletedMenuDetl = value;
                    RaisePropertyChanged("SeletedMenuDetl");
                }
            }
        }
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
        MenuDto selected_Menu;
        public MenuDto Selected_Menu
        {
            get
            {
                return selected_Menu;
            }
            set
            {
                if (selected_Menu != value)
                {
                    checkedMenu(value);
                    selected_Menu = value;
                    RaisePropertyChanged("Selected_Menu");
                }
            }
        }


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

            Grid_Usertype = new ObservableCollection<User_type>();
            Grid_menu = new ObservableCollection<MenuDto>();
            Grid_Usertype = UserModel.GetUserType();
            Grid_menu = PermissionUserModel.GetMenu();
            grid_MenuDetl = PermissionUserModel.GetMenuDetl();
            // PermissionGroupModel.GetPermisstionGroup(Grid_PermissionGroup, "setting", 1);
            Grid_User = new ObservableCollection<User>();
            Grid_User = UserModel.GetUsers();
            Permissioncommand = new RelayCommand(par => SetPermission(), par => CanSetPermission());
            SavePermissioncommand = new RelayCommand(par => SavePermission(), par => CanSavePermission());
            Changecommad = new RelayCommand(par => Change());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 31;

        }
        #endregion
        #region Methodes And Events
        void SetPermission()
        {

            Grid_PermissionUsers = new ObservableCollection<PermissionUser>();
            Grid_PermissionUsers = PermissionUserModel.GetPermissionUser("setting", Currunt_User.Userid);
            selected_value = "المخالفات";
        }
        bool CanSetPermission() => Currunt_User != null && PermissionUser.Add_opretion == true;
        void SavePermission()
        {
            if (Grid_formMenu == null)
            {

            }
            //foreach (FormModel a in Currunt_PermissionForm)
            //{
            PermissionUserModel.OperarionPermissionUser(Grid_formMenu, Selected_UserType.userTypeid, "Op");
            //    // MessageBox.Show(a.Add_opretion.ToString());
            //}
            // MessageBox.Show(selected_value);
        }
        bool CanSavePermission() => Grid_formMenu != null;
        async Task Change()
        {
            SavePermission();
            Grid_PermissionUsers = new ObservableCollection<PermissionUser>();

            if (selected_value == "المخالفات")
            {
                Grid_PermissionUsers = await Task.Run(() => PermissionUserModel.GetPermissionUser("violation", Currunt_User.Userid));

            }
            else if (selected_value == "المستخدمين")
            {
                Grid_PermissionUsers = await Task.Run(() => PermissionUserModel.GetPermissionUser("user", Currunt_User.Userid));
            }
            else if (selected_value == "الإعدادات")
            {
                Grid_PermissionUsers = await Task.Run(() => PermissionUserModel.GetPermissionUser("setting", Currunt_User.Userid));

            }
            else if (selected_value == "الإعتراضات")
            {

                Grid_PermissionUsers = await Task.Run(() => PermissionUserModel.GetPermissionUser("interception", Currunt_User.Userid));
            }
            else if (selected_value == "البلاغات")
            {

                Grid_PermissionUsers = await Task.Run(() => PermissionUserModel.GetPermissionUser("communication", Currunt_User.Userid));
            }
            else if (selected_value == "الحسابات")
            {

                Grid_PermissionUsers = await Task.Run(() => PermissionUserModel.GetPermissionUser("account", Currunt_User.Userid));
            }
            else if (selected_value == "التهيئة")
            {

                Grid_PermissionUsers = await Task.Run(() => PermissionUserModel.GetPermissionUser("format", Currunt_User.Userid));
            }
            else if (selected_value == "التقارير")
            {

                Grid_PermissionUsers = await Task.Run(() => PermissionUserModel.GetPermissionUser("report", Currunt_User.Userid));
            }



        }
        void checkedMenu(MenuDto menuDto)
        {
            try
            {
                ObservableCollection<FormModel> formsmenu = new ObservableCollection<FormModel>();
                // get formmenu if the form have permation
                GridmenuForUser = PermissionUserModel.GetPrivilegeUser(menuDto.Menu_id, Selected_UserType.userTypeid);
                if (GridmenuForUser.Count > 0)
                {
                    foreach (PrivilegemenuUser privilegemenu in GridmenuForUser)
                    {

                        FormModel formModel = new FormModel
                        {
                            FormId = privilegemenu.FormId,
                            FormName = privilegemenu.FormName,
                            Add_opretion = privilegemenu.PrivilegeAdd,
                            Delete_opretion = privilegemenu.PrivilegeDelete,
                            Select_opretion = privilegemenu.PrivilegeSelect,
                            Update_opretion = privilegemenu.PrivilegeUpdate,
                            Is_active = privilegemenu.PrivilegeForm,


                        };
                        formsmenu.Add(formModel);

                    }
                    Grid_formMenu = formsmenu;

                }
                else
                {
                    Grid_formMenu = PermissionUserModel.GetFormBymenuid(menuDto.Menu_id);

                }

            }
            catch (Exception e)
            {

            }

        }

        #endregion
        #region Commands

        public RelayCommand Permissioncommand { get; private set; }
        public RelayCommand SavePermissioncommand { get; private set; }
        public RelayCommand Changecommad { get; private set; }
        public RelayCommand ValueSelectedMenu { get; private set; }
        //private ICommand _myCheckBoxCommand;
        //public ICommand IsCheckCommand
        //{
        //    get { return _myCheckBoxCommand ?? (_myCheckBoxCommand = new RelayCommand(HandleingCheckBox)); }
        //}
        #endregion






        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
