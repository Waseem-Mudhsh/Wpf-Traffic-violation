using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
    class Directorate_ViewModel : BindableBase
    {
        Window_ِAddDirectorate win;
        #region Objects And Variables
        Directorate_Model Directorate_Model = new Directorate_Model();
        Provinces_Model provinces_Model = new Provinces_Model();
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

        ObservableCollection<Provinces> grid_Provinces;
        public ObservableCollection<Provinces> Grid_Provinces
        {
            get
            {
                return grid_Provinces;
            }
            set
            {
                if (grid_Provinces != value)
                {
                    grid_Provinces = value;
                    RaisePropertyChanged("Grid_Provinces");
                }
            }
        }
        ObservableCollection<Directorate> grid_Directorate;
        public ObservableCollection<Directorate> Grid_Directorate
        {
            get
            {
                return grid_Directorate;
            }
            set
            {
                if (grid_Directorate != value)
                {
                    grid_Directorate = value;
                    RaisePropertyChanged("Grid_Directorate");
                }
            }
        }

        Directorate current_Directorate;
        public Directorate Current_Directorate
        {
            get
            {
                return current_Directorate;
            }
            set
            {
                if (current_Directorate != value)
                {
                    current_Directorate = value;
                    RaisePropertyChanged("Current_Directorate");
                }
            }
        }

        Provinces selected_Provinces;
        public Provinces Selected_Provinces
        {
            get
            {
                return selected_Provinces;
            }
            set
            {
                if (selected_Provinces != value)
                {
                    selected_Provinces = value;
                    RaisePropertyChanged("Selected_Provinces");
                }
            }
        }



        #endregion
        #region Construcor
        public Directorate_ViewModel()
        {
            Grid_Directorate = new ObservableCollection<Directorate>();
            Directorate_Model.GetDirectorate(Grid_Directorate);
            Grid_Provinces = new ObservableCollection<Provinces>();
            provinces_Model.GetProvinces(Grid_Provinces);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 26;
            new AllPermissions().getPermission(PermissionUser);

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events



        public void Add()
        {
            int maxid = new Class_SqlConnection().Get_Max("Directorate");

            Current_Directorate = new Directorate { Directorate_id = maxid, Province_name = "تعز" };
            Selected_Provinces = new Provinces();
            win = new Window_ِAddDirectorate { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;

            win = new Window_ِAddDirectorate { DataContext = this };
            //Selected_Provinces = new Provinces();

            //Selected_Provinces.Province_name = Current_Directorate.Province_name;
            win.ShowDialog();

        }
        bool CanEdit() => Current_Directorate != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {

                Directorate_Model.OperarionDirectorate(Current_Directorate, "Delete");
                Grid_Directorate.Remove(Current_Directorate);

                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 26;

                Current_Activity.Activity_record_num = Current_Directorate.Directorate_id;

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
        bool CanDelet() => Current_Directorate != null && PermissionUser.Delete_opretion == true;
        void Save()
        {
            Current_Directorate.Province_id = 4;

            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 26;

            Current_Activity.Activity_record_num = Current_Directorate.Directorate_id;

            //////////////////////////////////////////////////////////
            
            if (IsEditing && Directorate_Model.Check_Exsit(Current_Directorate.Directorate_id))
            {
                Directorate_Model.OperarionDirectorate(Current_Directorate, "Update");
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
            else if (Directorate_Model.Check_Exsit(Current_Directorate.Directorate_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);


            }



            else
            {
                Directorate_Model.OperarionDirectorate(Current_Directorate, "Insert");
                //Current_Directorate.Province_name = Selected_Provinces.Province_name;
                Grid_Directorate = new ObservableCollection<Directorate>();
                Directorate_Model.GetDirectorate(Grid_Directorate);
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية التعديل";
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
        bool CanSave() => Current_Directorate != null && !Current_Directorate.HasErrors;
        void close()
        {
            Current_Directorate = null;
            win.Close();
        }

        void GetExcel()
        {

            Directorate_Model.GetExcel(Grid_Directorate);
            Grid_Directorate = new ObservableCollection<Directorate>();
            Directorate_Model.GetDirectorate(Grid_Directorate);
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
