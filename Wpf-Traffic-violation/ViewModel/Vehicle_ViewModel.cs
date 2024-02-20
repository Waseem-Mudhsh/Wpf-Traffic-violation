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
    public class Vehicle_ViewModel : BindableBase
    {



        #region Objects And Variables
        CitizenModel CitizenModel = new CitizenModel();
        Provinces_Model provinces_Model = new Provinces_Model();
        VehicleModel vehicle_Model = new VehicleModel();
        Window_AddDataVehicle win;
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
        ObservableCollection<Citizen> grid_Citizen;
        public ObservableCollection<Citizen> Grid_Citizen
        {
            get
            {
                return grid_Citizen;
            }
            set
            {
                if (grid_Citizen != value)
                {
                    grid_Citizen = value;
                    RaisePropertyChanged("Grid_Citizen");
                }
            }
        }
        Citizen selected_Citizen;
        public Citizen Selected_Citizen
        {
            get
            {
                return selected_Citizen;
            }
            set
            {
                if (selected_Citizen != value)
                {
                    selected_Citizen = value;
                    RaisePropertyChanged("Selected_Citizen");
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
        Provinces selected_Province;
        public Provinces Selected_Province
        {
            get
            {
                return selected_Province;
            }
            set
            {
                if (selected_Province != value)
                {
                    selected_Province = value;
                    RaisePropertyChanged("Selected_Province");
                }
            }
        }
        Provinces selected_Province_vc;
        public Provinces Selected_Provinc_vc
        {
            get
            {
                return selected_Province_vc;
            }
            set
            {
                if (selected_Province_vc != value)
                {
                    selected_Province_vc = value;
                    RaisePropertyChanged("Selected_Province_vc");
                }
            }
        }
        ObservableCollection<Vehicle> grid_Vehicle;
        public ObservableCollection<Vehicle> Grid_Vehicle
        {
            get
            {
                return grid_Vehicle;
            }
            set
            {
                if (grid_Vehicle != value)
                {
                    grid_Vehicle = value;
                    RaisePropertyChanged("Grid_Vehicle");
                }
            }
        }
        Vehicle current_Vehicle;
        public Vehicle Current_Vehicle
        {
            get
            {
                return current_Vehicle;
            }
            set
            {
                if (current_Vehicle != value)
                {
                    current_Vehicle = value;
                    RaisePropertyChanged("Current_Vehicle");
                }
            }
        }
        #endregion
        #region Construcor
        public Vehicle_ViewModel()
        {
            asyncVehicle();
            

            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 20;
           
            ActivityModel ActivityModel;
            Current_Activity = new Activity();
        }

        #endregion
        #region Methodes And Events
        async Task asyncVehicle()
        {
            Grid_Vehicle = new ObservableCollection<Vehicle>();
            Grid_Vehicle = await Task.Run(() => vehicle_Model.GetVehicles());
        }
        async Task asyncGrid()
        {
            Grid_Citizen = new ObservableCollection<Citizen>();
            Grid_Citizen = await Task.Run(() => CitizenModel.GetCitizens());
            Grid_Provinces = new ObservableCollection<Provinces>();
            Grid_Provinces = await Task.Run(() => provinces_Model.GetProvinces());
          
        }
        public void Add()
        {
            asyncGrid();
            Selected_Citizen = new Citizen();
            Selected_Provinc_vc = new Provinces();
            Selected_Province = new Provinces();
            //int maxid = new Class_SqlConnection().Get_Max("Vehicle");


            Current_Vehicle = new Vehicle ();

            win = new Window_AddDataVehicle { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            Grid_Citizen = new ObservableCollection<Citizen>();
            Grid_Citizen = CitizenModel.GetCitizens();
            Grid_Provinces = new ObservableCollection<Provinces>();
            Grid_Provinces = provinces_Model.GetProvinces();
           
            Selected_Citizen = new Citizen();
            Selected_Provinc_vc = new Provinces();
            Selected_Province = new Provinces();
            foreach (Citizen a in Grid_Citizen)
            {
                if (a.Citizen_id == Current_Vehicle.Citizen_id)
                    Selected_Citizen = a;
            }
            foreach (Provinces a in Grid_Provinces)
            {
                if (a.Province_id == Current_Vehicle.Release_plase)
                    Selected_Provinc_vc = a;
            }
            foreach (Provinces a in Grid_Provinces)
            {
                if (a.Province_id == Current_Vehicle.Release_palc_c)
                    Selected_Province = a;
            }
            if (Current_Vehicle.Status == 1)
                Current_Vehicle.String_Status = "نشطة";
            else if (Current_Vehicle.Status == 2)
                Current_Vehicle.String_Status = "مفقودة";
            else if (Current_Vehicle.Status == 3)
                Current_Vehicle.String_Status = "منتهية";

            if (Current_Vehicle.Status_v == 1)
                Current_Vehicle.String_Status_v = "نشطة";
            else if (Current_Vehicle.Status_v == 2)
                Current_Vehicle.String_Status_v = "غير نشط";
            win = new Window_AddDataVehicle { DataContext = this };
            win.id_Vlical.Text = Current_Vehicle.Vehicle_card_id.ToString();
            win.id_Vlical.IsEnabled = false;
            win.Potty_id.IsEnabled = false;
            win.Vehicle_customs_num.IsEnabled = false;
            
            IsEditing = true;
            win.id_Vlical.IsEnabled = false;
            
          
            
            win.ShowDialog();


        }
        bool CanEdit() => Current_Vehicle != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 20;
                Current_Activity.Activity_record_num = Current_Vehicle.Potty_id;

                //////////////////////////////////////////////////////////
              
               if( vehicle_Model.OperarionVehicle(Current_Vehicle, "Delete"))
                {
                    Grid_Vehicle.Remove(Current_Vehicle);
                    asyncVehicle();
                    string message1 = "تمت عملية الحذف بنجاح";
                    string caption1 = "عملية الحذف";
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxButton buttons1 = MessageBoxButton.OK;
                    MessageBox.Show(message1, caption1, buttons1, icon1);
                    ////////////////////////////////////////////////////////////
                    Current_Activity.Activity_operation_num = 3;
                    ActivityModel.OperarionActivity(current_Activity, "Insert");
                    ////////////////////////////////////////////////////////////
                }
                else
                {
                    string message1 = "يوجد سجلات مرتبطة بهذي المركبة";
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
        bool CanDelet() => Current_Vehicle != null && PermissionUser.Delete_opretion == true;
        void Save()
        {
            Current_Vehicle.Citizen_id = Selected_Citizen.Citizen_id;
            Current_Vehicle.Release_palc_c = Selected_Province.Province_id;
            Current_Vehicle.Release_plase = Selected_Provinc_vc.Province_id;
            if (string.IsNullOrWhiteSpace(Current_Vehicle.Noties))
            {
                Current_Vehicle.Noties = "لا شي";
            }
            if (Current_Vehicle.String_Status == "نشطة")
            {
                Current_Vehicle.Status = 1;
            }
            else if (Current_Vehicle.String_Status == "مفقودة")
            {
                Current_Vehicle.Status = 2;
            }
            else if (Current_Vehicle.String_Status == "منتهية")
            {
                Current_Vehicle.Status = 3;
            }
            else
            {
                MessageBox.Show(" يجب تحديد الحالة");
            }

            if (Current_Vehicle.String_Status_v == "نشطة")
            {
                Current_Vehicle.Status_v = 1;
            }
            else if (Current_Vehicle.String_Status_v == "غير نشط")
            {
                Current_Vehicle.Status_v = 2;
            }
            else
            {
                MessageBox.Show(" يجب تحديد الحالة");
            }

            //////////////////////////////////////////////////////////////
            Current_Activity = new Activity();
            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 20;
            Current_Activity.Activity_record_num = Current_Vehicle.Potty_id;

            //////////////////////////////////////////////////////////
           

            if (IsEditing && vehicle_Model.Check_Exsit(Current_Vehicle.Potty_id))
            {

                vehicle_Model.OperarionVehicle(Current_Vehicle, "Update");
                IsEditing = false;
                Grid_Vehicle = new ObservableCollection<Vehicle>();
                Grid_Vehicle=vehicle_Model.GetVehicles();
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
            else if (vehicle_Model.Check_Exsit(Current_Vehicle.Potty_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
            }

            else
            {
                vehicle_Model.OperarionVehicle(Current_Vehicle, "Insert");
                //Current_Plate.Province_name = Selected_Provinces.Province_name;
                Grid_Vehicle = new ObservableCollection<Vehicle>();
                Grid_Vehicle= vehicle_Model.GetVehicles();
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية اضافة";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 1;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }

        }
        bool CanSave() => Current_Vehicle != null && !Current_Vehicle.HasErrors;
        void close()
        {
            Current_Vehicle = null;
            win.Close();
        }
        void GetExcel()
        {

            vehicle_Model.GetExcel(Grid_Vehicle);
            Grid_Vehicle = new ObservableCollection<Vehicle>();
            Grid_Vehicle=vehicle_Model.GetVehicles();
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
