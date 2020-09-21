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



        #endregion
        #region Construcor
        public Plate_ViewModel()
        {
            Grid_PlateType = new ObservableCollection<PlateOfType>();
            plateOfType_Model.GetPlateOfType(Grid_PlateType);
            Grid_Provinces = new ObservableCollection<Provinces>();
            Provinces_Model.GetProvinces(Grid_Provinces);
            Grid_Plate = new ObservableCollection<Plate>();
            Plate_Model.GetPlates(Grid_Plate);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 24;
            new AllPermissions().getPermission(PermissionUser);

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events



        public void Add()
        {
            Selected_PlateType = new PlateOfType();
            Selected_Provinces = new Provinces();
            int maxid = new Class_SqlConnection().Get_Max("Plate");


            Current_Plate = new Plate { Plate_id = maxid, Province_name = "تعز", String_Status = "نشطه" };
            //Selected_PlateType = new PlateOfType();
            //Selected_Provinces = new Provinces();
            win = new Window_AddDataPlate { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            Selected_PlateType = new PlateOfType();
            Selected_Provinces = new Provinces();
            //  Current_Plate.String_Plate_type = "aaa";

            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;


            //Selected_Provinces = new Provinces {
            //    Province_name = Current_Plate.Province_name,
            //     Province_id = Current_Plate.Province_id
            // };
            //Selected_PlateType = new PlateOfType {
            //   Plate_type_name = Current_Plate.String_Plate_type,
            //   Plate_type_id = Current_Plate.Plate_type
            //};
            win = new Window_AddDataPlate { DataContext = this };
            Selected_PlateType.Plate_type_name = "aaaa";
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

                Plate_Model.OperarionPlate(Current_Plate, "Delete");
                Grid_Plate.Remove(Current_Plate);

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

            }
            else
            {
                return;
            }


        }
        bool CanDelet() => Current_Plate != null && PermissionUser.Delete_opretion == true;
        void Save()
        {//////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 24;
            Current_Activity.Activity_record_num = Current_Plate.Plate_id;

            //////////////////////////////////////////////////////////
            
            //Current_Plate.Province_name = "تعز";
            Current_Plate.Plate_type = Selected_PlateType.Plate_type_id;
            Current_Plate.Province_id = Selected_Provinces.Province_id;
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
                Plate_Model.GetPlates(Grid_Plate);
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
                Plate_Model.GetPlates(Grid_Plate);
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
            Plate_Model.GetPlates(Grid_Plate);
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
