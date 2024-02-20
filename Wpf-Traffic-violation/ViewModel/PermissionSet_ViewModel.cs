using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
    public class PermissionSet_ViewModel : BindableBase
    {

        #region Objects And Variables
        Window_AddPermissionSet win;

        Models.Users_Model.PermissionSet_Model PermissionSet_Model = new Models.Users_Model.PermissionSet_Model();
        Models.Users_Model.PermissionGroupModel PermissionGroupModel = new PermissionGroupModel();
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

        ObservableCollection<PermissionSet> grid_PermissionSet;
        public ObservableCollection<PermissionSet> Grid_PermissionSets //يربط مع الجرد فيو 
        {
            get
            {
                return grid_PermissionSet;
            }
            set
            {
                if (grid_PermissionSet != value)
                {
                    grid_PermissionSet = value;
                    RaisePropertyChanged("Grid_PermissionSets");
                }
            }
        }

        PermissionSet currunt_PermissionSet; //selectedItemيربط مع 

        public PermissionSet Currunt_PermissionSet
        {
            get
            {
                return currunt_PermissionSet;
            }
            set
            {
                if (currunt_PermissionSet != value)
                {
                    currunt_PermissionSet = value;
                    RaisePropertyChanged("Currunt_PermissionSet");
                }
            }
        }

        ObservableCollection<PermissionGroup> grid_PermissionGroup;
        public ObservableCollection<PermissionGroup> Grid_PermissionGroup //يربط مع الجرد فيو 
        {
            get
            {
                return grid_PermissionGroup;
            }
            set
            {
                if (grid_PermissionGroup != value)
                {
                    grid_PermissionGroup = value;
                    RaisePropertyChanged("grid_PermissionGroup");
                }
            }
        }
        PermissionGroup currunt_PermissionGroup; //selectedItemيربط مع 

        public PermissionGroup Currunt_PermissionGroup
        {
            get
            {
                return currunt_PermissionGroup;
            }
            set
            {
                if (currunt_PermissionGroup != value)
                {
                    currunt_PermissionGroup = value;
                    RaisePropertyChanged("Currunt_PermissionGroup");
                }
            }
        }


        #endregion
        #region Construcor
        public PermissionSet_ViewModel()
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

           
            Grid_PermissionSets = new ObservableCollection<PermissionSet>();
            Grid_PermissionSets =PermissionSet_Model.GetPermissionSet();

            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());
            Permissioncommand = new RelayCommand(par => SetPermission(), par => CanSetPermission());
            SavePermissioncommand = new RelayCommand(par => SavePermission(), par => CanSavePermission());
            Changecommad = new RelayCommand(par => Change());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 30;
           

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events
        
        public void Add()
        {

            int maxid = new Class_SqlConnection().Get_Max("Group");


            Currunt_PermissionSet = new PermissionSet { Group_id = maxid };
            win = new Window_AddPermissionSet { DataContext = this };
            win.ShowDialog();

        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;

        void Edit()
        {


            IsEditing = true;
            win = new Window_AddPermissionSet { DataContext = this };
            if (Currunt_PermissionSet.String_Status == "نشط")
            {
                win.Radiobutton_state.IsChecked = true;

            }
            else
            {
                win.Radiobutton_state.IsChecked = false;
            }
            win.ShowDialog();


        }
        bool CanEdit() => Currunt_PermissionSet != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                PermissionSet_Model.OperarionPermissionSet(Currunt_PermissionSet, "Delete");
                Grid_PermissionSets.Remove(Currunt_PermissionSet);
                //////////////////////////////////////////////////////////////

                //Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                //Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                //Current_Activity.User_id = Properties.Settings.Default.Userid;
                //Current_Activity.Form_id = 11;
                //Current_Activity.Activity_record_num = Current_Communication.Communication_id;

                ////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////
                //Current_Activity.Activity_operation_num = 4;
                //ActivityModel.OperarionActivity(current_Activity, "Insert");
                //////////////////////////////////////////////////////////////

            }
            else
            {
                return;
            }
        }
        bool CanDelet() => Currunt_PermissionSet != null && PermissionUser.Delete_opretion == true;

        void Save()
        {
            if (win.Radiobutton_state.IsChecked != true)
            {
                Currunt_PermissionSet.Group_status = 1;
            }
            else
            {
                Currunt_PermissionSet.Group_status = 0;
            }
            try
            {
                if (win.Radiobutton_state.IsChecked == true)
                {
                    Currunt_PermissionSet.Group_status = 1;
                }
                else if (win.Radiobutton_state.IsChecked == false)
                {
                    Currunt_PermissionSet.Group_status = 0;
                }

                if (IsEditing && PermissionSet_Model.Check_Exsit(Currunt_PermissionSet.Group_id))
                {
                    PermissionSet_Model.OperarionPermissionSet(Currunt_PermissionSet, "Update");
                    IsEditing = false;

                    string message = "تمت عملية التعديل بنجاح";
                    string caption = "عملية التعديل";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                    close();
                }
                else if (PermissionSet_Model.Check_Exsit(Currunt_PermissionSet.Group_id))
                {
                    string message = "رقم المستخدم موجود مسبقا";
                    string caption = "رسالة خطا";
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);

                }
                else
                {
                    PermissionSet_Model.OperarionPermissionSet(Currunt_PermissionSet, "Insert");

                    Grid_PermissionSets.Add(Currunt_PermissionSet);
                    close();
                    string message = "تمت عملية الإضافة بنجاح";
                    string caption = "عملية التعديل";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);

                }

            }// end try
            catch (Exception e)
            {
                MessageBox.Show("Error reading from " + e.Message);

                close();

            }

            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_PermissionSet != null && !Currunt_PermissionSet.HasErrors;

        void close()
        {
            Currunt_PermissionSet = null;
            win.Close();
        }
        void GetExcel()
        {

            PermissionSet_Model.GetExcel(Grid_PermissionSets);
            Grid_PermissionSets = new ObservableCollection<PermissionSet>();
            Grid_PermissionSets= PermissionSet_Model.GetPermissionSet();
        }

        void SetPermission()
        {

            Grid_PermissionGroup = new ObservableCollection<PermissionGroup>();
            Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup( "setting", Currunt_PermissionSet.Group_id);

        }
        bool CanSetPermission() => Currunt_PermissionSet != null;

        void SavePermission()
        {
            foreach (PermissionGroup a in Grid_PermissionGroup)
            {
                PermissionGroupModel.OperarionPermissionGroup(a, "Update");
                // MessageBox.Show(a.Add_opretion.ToString());
            }
            // MessageBox.Show(selected_value);
        }
        bool CanSavePermission() => Grid_PermissionGroup != null;
        void Change()
        {
            SavePermission();
            Grid_PermissionGroup = new ObservableCollection<PermissionGroup>();

            if (selected_value == "الإعدادات")
            {

                Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup( "setting", Currunt_PermissionSet.Group_id);
            }
            else if (selected_value == "المستخدمين")
            {
                Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup( "user", Currunt_PermissionSet.Group_id);
            }
            else if (selected_value == "المخالفات")
            {

                Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup( "violation", Currunt_PermissionSet.Group_id);
            }
            else if (selected_value == "الإعتراضات")
            {

                Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup( "interception", Currunt_PermissionSet.Group_id);
            }
            else if (selected_value == "البلاغات")
            {

                Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup( "communication", Currunt_PermissionSet.Group_id);
            }
            else if (selected_value == "الحسابات")
            {

                Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup( "account", Currunt_PermissionSet.Group_id);
            }
            else if (selected_value == "التهيئة")
            {

                Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup("format", Currunt_PermissionSet.Group_id);
            }
            else if (selected_value == "التقارير")
            {

                Grid_PermissionGroup= PermissionGroupModel.GetPermisstionGroup( "report", Currunt_PermissionSet.Group_id);
            }






        }


        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; private set; }
        public RelayCommand Excelcommand { get; private set; }
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
