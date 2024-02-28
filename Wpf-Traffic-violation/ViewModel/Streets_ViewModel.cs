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
    class Streets_ViewModel : BindableBase
    {
        Window_AddStreet win;
        #region Objects And Variables
        Directorate_Model Directorate_Model = new Directorate_Model();
        Street_Model Streets_Model = new Street_Model();
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

        ObservableCollection<Streets> grid_Streets;
        public ObservableCollection<Streets> Grid_Streets
        {
            get
            {
                return grid_Streets;
            }
            set
            {
                if (grid_Streets != value)
                {
                    grid_Streets = value;
                    RaisePropertyChanged("Grid_Streets");
                }
            }
        }
        ObservableCollection<Directorate> grid_Ditectorate;
        public ObservableCollection<Directorate> Grid_Ditectorate
        {
            get
            {
                return grid_Ditectorate;
            }
            set
            {
                if (grid_Ditectorate != value)
                {
                    grid_Ditectorate = value;
                    RaisePropertyChanged("Grid_Ditectorate");
                }
            }
        }
        Streets current_Street;
        public Streets Current_Street
        {
            get
            {
                return current_Street;
            }
            set
            {
                if (current_Street != value)
                {
                    current_Street = value;
                    RaisePropertyChanged("Current_Street");
                }
            }
        }
        Directorate selected_Dirctorate;
        public Directorate Selected_Dirctorate
        {
            get
            {
                return selected_Dirctorate;
            }
            set
            {
                if (selected_Dirctorate != value)
                {
                    selected_Dirctorate = value;
                    RaisePropertyChanged("Selected_Dirctorate");
                }
            }
        }

        #endregion
        #region Construcor
        public Streets_ViewModel()
        {
            asyncStreets();


            Addcommand = new RelayCommand(Par => Add());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit());
            Deletecommand = new RelayCommand(par => Delet());
            Savecommand = new RelayCommand(par => Save());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 27;


            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events
        async Task asyncStreets()
        {
            Grid_Streets = new ObservableCollection<Streets>();
            Grid_Streets = await Task.Run(() => Streets_Model.GetStreets());
            Grid_Ditectorate = new ObservableCollection<Directorate>();
            Grid_Ditectorate = await Task.Run(() => Directorate_Model.GetDirectorate());
        }
        public void Add()
        {
            int maxid = new Class_SqlConnection().Get_Max("Street", "Street_id");

            Current_Street = new Streets { Street_id = maxid + 1, Province_name = "" };
            Selected_Dirctorate = new Directorate();
            win = new Window_AddStreet { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            foreach (Directorate a in Grid_Ditectorate)
            {
                if (a.Directorate_id == Current_Street.Directerate_id)
                    Selected_Dirctorate = a;


            }
            IsEditing = true;

            win = new Window_AddStreet { DataContext = this };
            //Selected_Provinces = new Provinces();

            //Selected_Provinces.Province_name = Current_Street.Province_name;
            win.ShowDialog();

        }
        bool CanEdit() => Current_Street != null && PermissionUser.Update_opretion == true;
        void Delet()
        {

            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                //////////////////////////////////////////////////////////////
                Current_Activity = new Activity();
                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 27;
                Current_Activity.Activity_record_num = Current_Street.Street_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
                if (Streets_Model.OperarionStreets(Current_Street, "Delete"))
                {
                    Grid_Streets.Remove(Current_Street);
                    asyncStreets();
                    string message1 = "تمت عملية الحذف بنجاح";
                    string caption1 = "عملية الحذف";
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxButton buttons1 = MessageBoxButton.OK;
                    MessageBox.Show(message1, caption1, buttons1, icon1);
                }
                else
                {
                    string message1 = "يوجد سجلات مرتبطة بهذا الشارع";
                    string caption1 = "تأكيد";
                    MessageBoxButton buttons1 = MessageBoxButton.OK;

                    MessageBoxImage icon1 = MessageBoxImage.Error;


                    MessageBox.Show(message1, caption1, buttons1, icon1);
                }


            }
            else
            {
                return;
            }


        }
        bool CanDelet() => Current_Street != null && PermissionUser.Delete_opretion == true;
        void Save()
        {
            //////////////////////////////////////////////////////////////

            //Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 27;
            Current_Activity.Activity_record_num = Current_Street.Street_id;

            //////////////////////////////////////////////////////////


            //Current_Street.Province_name = "تعز";
            Current_Street.Directerate_id = Selected_Dirctorate.Directorate_id;
            if (IsEditing && Streets_Model.Check_Exsit(Current_Street.Street_id))
            {
                Streets_Model.OperarionStreets(Current_Street, "Update");
                IsEditing = false;
                close();
                string message = "تمت عملية التعديل بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                ////////////////////////////////////////////////////////////
                //Current_Activity.Activity_operation_num = 2;
                //ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }
            else if (Streets_Model.Check_Exsit(Current_Street.Street_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
            }

            else
            {
                Streets_Model.OperarionStreets(Current_Street, "Insert");
                //Current_Street.Province_name = Selected_Provinces.Province_name;
                Grid_Streets = new ObservableCollection<Streets>();
                Grid_Streets = Streets_Model.GetStreets();
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                ////////////////////////////////////////////////////////////
                //Current_Activity.Activity_operation_num = 1;
                //ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }

        }
        bool CanSave() => Current_Street != null && !Current_Street.HasErrors;
        void close()
        {
            Current_Street = null;
            win.Close();
        }
        void GetExcel()
        {

            Streets_Model.GetExcel(Grid_Streets);
            Grid_Streets = new ObservableCollection<Streets>();
            Grid_Streets = Streets_Model.GetStreets();
        }
        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; set; }
        public RelayCommand Excelcommand { get; private set; }
        #endregion





        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
