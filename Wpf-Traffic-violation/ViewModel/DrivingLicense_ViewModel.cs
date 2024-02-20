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
    public class DrivingLicense_ViewModel : BindableBase
    {

        #region Objects And Variables
        CitizenModel CitizenModel = new CitizenModel();
        CategoriesOfLicenses_Model CategoriesOfLicenses_Model = new CategoriesOfLicenses_Model();
        DrivingLicense_Model drivingModel = new DrivingLicense_Model();
        Window_AddDataDrivinglicense win;
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

        ObservableCollection<CategoriesOfLicenses> grid_Class_license;
        public ObservableCollection<CategoriesOfLicenses> Grid_Class_license
        {
            get
            {
                return grid_Class_license;
            }
            set
            {
                if (grid_Class_license != value)
                {
                    grid_Class_license = value;
                    RaisePropertyChanged("Grid_Class_license");
                }
            }
        }
        CategoriesOfLicenses selected_Class_license;
        public CategoriesOfLicenses Selected_Class_license
        {
            get
            {
                return selected_Class_license;
            }
            set
            {
                if (selected_Class_license != value)
                {
                    selected_Class_license = value;
                    RaisePropertyChanged("Selected_Class_license");
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
        ObservableCollection<DrivingLicense> grid_DrivingLicense;
        public ObservableCollection<DrivingLicense> Grid_DrivingLicense
        {
            get
            {
                return grid_DrivingLicense;
            }
            set
            {
                if (grid_DrivingLicense != value)
                {
                    grid_DrivingLicense = value;
                    RaisePropertyChanged("Grid_DrivingLicense");
                }
            }
        }
        DrivingLicense current_DrivingLicense;
        public DrivingLicense Current_DrivingLicense
        {
            get
            {
                return current_DrivingLicense;
            }
            set
            {
                if (current_DrivingLicense != value)
                {
                    current_DrivingLicense = value;
                    RaisePropertyChanged("Current_DrivingLicense");
                }
            }
        }
        #endregion
        #region Construcor
        public DrivingLicense_ViewModel()
        {
            asyncDrivingLicense();
            asyncGrid();

            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit( Grid_Class_license), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 22;
           

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events
        private async Task asyncDrivingLicense()
        {
            Grid_DrivingLicense = new ObservableCollection<DrivingLicense>();
            Grid_DrivingLicense = await Task.Run(() => drivingModel.GetDrivingLicenses());

           
        }
        private async Task asyncGrid()
        {
           

            Grid_Citizen = new ObservableCollection<Citizen>();
            Grid_Citizen = await Task.Run(() => CitizenModel.GetCitizens());

            Grid_Class_license = new ObservableCollection<CategoriesOfLicenses>();
            Grid_Class_license = await Task.Run(() => CategoriesOfLicenses_Model.GetCategoriesOfLicenses());
        }
        public void Add()
        {
            asyncGrid();
            Selected_Citizen = new Citizen();
            Selected_Class_license = new CategoriesOfLicenses();

            //int maxid = new Class_SqlConnection().Get_Max("Driving_license");


            Current_DrivingLicense = new DrivingLicense ();

            win = new Window_AddDataDrivinglicense { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit(ObservableCollection<CategoriesOfLicenses> grid_Class_license)
        {
            ObservableCollection<Citizen> Grid_Citizen = new ObservableCollection<Citizen>();
            Grid_Citizen = grid_Citizen;
            ObservableCollection<CategoriesOfLicenses> Grid_Class_license = new ObservableCollection<CategoriesOfLicenses>();
            Grid_Class_license = grid_Class_license;
            Selected_Citizen = new Citizen();
            Selected_Class_license = new CategoriesOfLicenses();

            IsEditing = true;
            foreach (Citizen a in Grid_Citizen)
            {
                if (a.Citizen_id == Current_DrivingLicense.Citizen_id)
                    Selected_Citizen = a;
            }

            foreach (CategoriesOfLicenses a in Grid_Class_license)
            {
                if (a.Class_licence_ID == Current_DrivingLicense.Class_license_id)
                    Selected_Class_license = a;
            }
            win = new Window_AddDataDrivinglicense { DataContext = this };
            win.nembercitizen.IsEnabled = false;
          
           
            win.ShowDialog();


        }
        bool CanEdit() => Current_DrivingLicense != null && PermissionUser.Update_opretion == true;
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
                Current_Activity.Form_id = 22;
                Current_Activity.Activity_record_num = Current_DrivingLicense.Driving_license_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

               if( drivingModel.OperarionDrivingLicense(Current_DrivingLicense, "Delete"))
                {
                    Grid_DrivingLicense.Remove(Current_DrivingLicense);
                    asyncDrivingLicense();

                    string message1 = "تمت عملية الحذف بنجاح";
                    string caption1 = "عملية الحذف";
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxButton buttons1 = MessageBoxButton.OK;
                    MessageBox.Show(message1, caption1, buttons1, icon1);
                }
                else
                {
                    string message1 = "يوجد سجلات مرتبطة بهذي الرخصة";
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
        bool CanDelet() => Current_DrivingLicense != null && PermissionUser.Delete_opretion == true;
        void Save()
        {
            //Current_Plate.Province_name = "تعز";
            Current_DrivingLicense.Citizen_id = Selected_Citizen.Citizen_id;
            Current_DrivingLicense.Class_license_id = Selected_Class_license.Class_licence_ID;

            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 22;
            Current_Activity.Activity_record_num = Current_DrivingLicense.Driving_license_id;

            //////////////////////////////////////////////////////////
            


            if (IsEditing && drivingModel.Check_Exsit(Current_DrivingLicense.Driving_license_id))
            {

                drivingModel.OperarionDrivingLicense(Current_DrivingLicense, "Update");
                IsEditing = false;
                Grid_DrivingLicense = new ObservableCollection<DrivingLicense>();
                Grid_DrivingLicense=drivingModel.GetDrivingLicenses();
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
            else if (drivingModel.Check_Exsit(Current_DrivingLicense.Driving_license_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
            }

            else
            {
               //if(string.IsNullOrWhiteSpace(Current_DrivingLicense.Driving_license_notice))
               // {
               //     Current_DrivingLicense.Driving_license_notice = "لا شي";
               // }
                drivingModel.OperarionDrivingLicense(Current_DrivingLicense, "Insert");
                //Current_Plate.Province_name = Selected_Provinces.Province_name;
                Grid_DrivingLicense = new ObservableCollection<DrivingLicense>();
                Grid_DrivingLicense= drivingModel.GetDrivingLicenses();
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

        }
        bool CanSave() => Current_DrivingLicense != null && !Current_DrivingLicense.HasErrors;
        void close()
        {
            Current_DrivingLicense = null;
            win.Close();
        }
        void GetExcel()
        {

            drivingModel.GetExcel(Grid_DrivingLicense);
            Grid_DrivingLicense = new ObservableCollection<DrivingLicense>();
            Grid_DrivingLicense= drivingModel.GetDrivingLicenses();
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
