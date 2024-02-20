using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Views.Configurations;
using Wpf_Traffic_violation.Commands;
using System.Windows;
using Wpf_Traffic_violation.Models.Users_Model;

namespace Wpf_Traffic_violation.ViewModel
{
    public class Plate_ViewModel : BindableBase
    {



        #region Objects And Variables
        PlateOfType_Model plateOfType_Model = new PlateOfType_Model();
        Provinces_Model Provinces_Model = new Provinces_Model();
        Plate_Model Plate_Model = new Plate_Model();
        VehicleModel Vehicle_Model = new VehicleModel();
        Window_AddDataPlate win;
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
        ObservableCollection<PlateOfType> grid_PlateType;
        public ObservableCollection<PlateOfType> Grid_PlateType
        {
            get
            {
                return grid_PlateType;
            }
            set
            {
                if (grid_PlateType != value)
                {
                    grid_PlateType = value;
                    RaisePropertyChanged("Grid_PlateType");
                }
            }
        }
        PlateOfType selected_PlateType;
        public PlateOfType Selected_PlateType
        {
            get
            {
                return selected_PlateType;
            }
            set
            {
                if (selected_PlateType != value)
                {
                    selected_PlateType = value;
                    RaisePropertyChanged("Selected_PlateType");
                }
            }
        }
        ObservableCollection<Provinces> grid_Provinces;// تربط بالايتم سورو
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
        Provinces selected_Provinces;
        public Provinces Selected_Provinces//تربط مع selected item
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
        ObservableCollection<Plate> grid_Plate;
        public ObservableCollection<Plate> Grid_Plate
        {
            get
            {
                return grid_Plate;
            }
            set
            {
                if (grid_Plate != value)
                {
                    grid_Plate = value;
                    RaisePropertyChanged("Grid_Plate");
                }
            }
        }
        Plate current_Plate;
        public Plate Current_Plate
        {
            get
            {
                return current_Plate;
            }
            set
            {
                if (current_Plate != value)
                {
                    current_Plate = value;
                    RaisePropertyChanged("Current_Plate");
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
        Vehicle selected_Vehicle;
        public Vehicle Selected_Vehicle
        {
            get
            {
                return selected_Vehicle;
            }
            set
            {
                if (selected_Vehicle != value)
                {
                    selected_Vehicle = value;
                    RaisePropertyChanged("Selected_Vehicle");
                }
            }
        }
        


        #endregion
        #region Construcor
        public Plate_ViewModel()
        {
            Grid_Provinces = new ObservableCollection<Provinces>();
            Grid_PlateType = new ObservableCollection<PlateOfType>();
           
            Grid_Vehicle = new ObservableCollection<Models.Vehicle>();

            asyncPlate();
            
            Addcommand = new RelayCommand(Par => Add());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit());
            Deletecommand = new RelayCommand(par => Delet());
            Savecommand = new RelayCommand(par => Save());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 24;
           

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events
        async Task asyncPlate()
        {
            Grid_Plate = new ObservableCollection<Plate>();
            Grid_Plate = await Task.Run(() => Plate_Model.GetPlates());
            
        }
        async Task asyncلGrid()
        {
           
           
            Grid_Provinces = await Task.Run(() => Provinces_Model.GetProvinces());
            
           
            Grid_PlateType = await Task.Run(() => plateOfType_Model.GetPlateOfType());
            
            Grid_Vehicle = await Task.Run(() => Vehicle_Model.GetVehicles());
        }



        public void Add()
        {
            //asyncلGrid();
            Grid_Provinces = Provinces_Model.GetProvinces();
            Grid_PlateType = plateOfType_Model.GetPlateOfType();

            Grid_Vehicle = Vehicle_Model.GetVehicles();
            Selected_PlateType = new PlateOfType();
            Selected_Provinces = new Provinces();
            Selected_Vehicle = new Vehicle();
            int maxid = new Class_SqlConnection().Get_Max("Plate");
            

            Current_Plate = new Plate { Plate_id = maxid };
           
            win = new Window_AddDataPlate { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            Grid_Provinces =  Provinces_Model.GetProvinces();


            Grid_PlateType =  plateOfType_Model.GetPlateOfType();

            Grid_Vehicle =  Vehicle_Model.GetVehicles();
            Selected_PlateType = new PlateOfType();
            Selected_Provinces = new Provinces();
            Selected_Vehicle = new Vehicle();
            foreach (Provinces a in Grid_Provinces)
            {
                if (a.Province_id == Current_Plate.Province_id)
                    Selected_Provinces = a;
            }
            foreach (PlateOfType a in Grid_PlateType)
            {
                if (a.Plate_type_id == Current_Plate.Plate_type)
                    Selected_PlateType = a;
            }
            foreach (Vehicle a in Grid_Vehicle)
            {
                if (a.Potty_id == Current_Plate.Vehicle_id)
                    Selected_Vehicle = a;
            }
            //Current_Plate.Vehicle_id = Selected_Vehicle.Potty_id;
            win = new Window_AddDataPlate { DataContext = this };
            win.vehicle_id.SelectedItem = Selected_Vehicle;
            win.vehicle_id.Text = Selected_Vehicle.Potty_id.ToString();
            win.vehicle_id.IsEnabled = false;
            IsEditing = true;
            win.ShowDialog();


        }
        bool CanEdit() => Current_Plate != null && PermissionUser.Update_opretion == true;
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
                Current_Activity.Form_id = 24;
                Current_Activity.Activity_record_num = Current_Plate.Plate_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

                if(Plate_Model.OperarionPlate(Current_Plate, "Delete"))
                {
                    Grid_Plate.Remove(Current_Plate);
                    asyncPlate();
                    string message1 = "تمت عملية الحذف بنجاح";
                    string caption1 = "عملية الحذف";
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxButton buttons1 = MessageBoxButton.OK;
                    MessageBox.Show(message1, caption1, buttons1, icon1);

                }
                else
                {
                    string message1 = "يوجد سجلات مرتبطة بهذا الرقم";
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
        bool CanDelet() => Current_Plate != null && PermissionUser.Delete_opretion == true;
        void Save()
        {//////////////////////////////////////////////////////////////

            //Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 24;
            Current_Activity.Activity_record_num = Current_Plate.Plate_id;

            //////////////////////////////////////////////////////////
            
            //Current_Plate.Province_name = "تعز";
            Current_Plate.Plate_type = Selected_PlateType.Plate_type_id;
            Current_Plate.Province_id = Selected_Provinces.Province_id;
            Current_Plate.Vehicle_id = Selected_Vehicle.Potty_id;
            if (Current_Plate.String_Status == "نشطة")
            {
                Current_Plate.Status = 1;
            }
            else if (Current_Plate.String_Status == "مفقودة")
            {
                Current_Plate.Status = 2;
            }
            else if (Current_Plate.String_Status == "منتهية")
            {
                Current_Plate.Status = 3;
            }
            else
            {
                MessageBox.Show(" يجب تحديد الحالة");
            }


            if (IsEditing && Plate_Model.Check_Exsit(Current_Plate.Plate_id))
            {
                Current_Plate.Account_id = Current_Plate.Plate_id;
                Plate_Model.OperarionPlate(Current_Plate, "Update");
                IsEditing = false;
                Grid_Plate = new ObservableCollection<Plate>();
                Grid_Plate= Plate_Model.GetPlates();
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
            else if (Plate_Model.Check_Exsit(Current_Plate.Vehicle_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
            }

            else
            {
                Plate_Model.OperarionPlate(Current_Plate, "Insert");
                //Current_Plate.Province_name = Selected_Provinces.Province_name;
                Grid_Plate = new ObservableCollection<Plate>();
                Grid_Plate= Plate_Model.GetPlates();
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
        bool CanSave() => Current_Plate != null && !Current_Plate.HasErrors;
        void close()
        {
            Current_Plate = null;
            win.Close();
        }
        void GetExcel()
        {

            Plate_Model.GetExcel(grid_Plate);
            Grid_Plate = new ObservableCollection<Plate>();
            Grid_Plate= Plate_Model.GetPlates();
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
