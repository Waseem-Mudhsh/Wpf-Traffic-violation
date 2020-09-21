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
    public class PlateOfType_ViewModel : BindableBase
    {

        #region Objects And Variables
        PlateOfType_Model Plates_Model = new PlateOfType_Model();
        Window_AddTypeOfplates win;
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

        ObservableCollection<PlateOfType> grid_PlateOftype;
        public ObservableCollection<PlateOfType> Grid_PlateOftype
        {
            get
            {
                return grid_PlateOftype;
            }
            set
            {
                if (grid_PlateOftype != value)
                {
                    grid_PlateOftype = value;

                    RaisePropertyChanged("Grid_PlateOftype");
                }
            }
        }
        PlateOfType current_PlateOfType;
        public PlateOfType Current_PlateOfType
        {
            get
            {
                return current_PlateOfType;
            }
            set
            {
                if (current_PlateOfType != value)
                {
                    current_PlateOfType = value;
                    RaisePropertyChanged("Current_PlateOfType");
                }
            }
        }


        #endregion
        #region Construcor
        public PlateOfType_ViewModel()
        {

            Grid_PlateOftype = new ObservableCollection<PlateOfType>();
            Plates_Model.GetPlateOfType(Grid_PlateOftype);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 23;
            new AllPermissions().getPermission(PermissionUser);

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events
       
        public void Add()
        {
            int maxid = new Class_SqlConnection().Get_Max("Plate_type");
            Current_PlateOfType = new PlateOfType { Plate_type_id = maxid };
            win = new Window_AddTypeOfplates { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;

            win = new Window_AddTypeOfplates { DataContext = this };

            win.ShowDialog();

        }
        bool CanEdit() => Current_PlateOfType != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 23;
                Current_Activity.Activity_record_num = Current_PlateOfType.Plate_type_id;
                Plates_Model.OperarionPlateOfType(Current_PlateOfType, "Delete");
                Grid_PlateOftype.Remove(Current_PlateOfType);
                //////////////////////////////////////////////////////////////

                

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
        bool CanDelet() => Current_PlateOfType != null && PermissionUser.Delete_opretion == true;
        void Save()
        {//ComboBoxes.Combo_usertype
         //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 23;
            Current_Activity.Activity_record_num = Current_PlateOfType.Plate_type_id;

            //////////////////////////////////////////////////////////
            

            if (IsEditing && Plates_Model.Check_Exsit(Current_PlateOfType.Plate_type_id))
            {
                Plates_Model.OperarionPlateOfType(Current_PlateOfType, "Update");
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
            else if (Plates_Model.Check_Exsit(Current_PlateOfType.Plate_type_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                win.textBox_idPlate.Focus();
                win.textBox_idPlate.SelectionStart = 0;
                win.textBox_idPlate.SelectionLength = win.textBox_idPlate.Text.Length;
            }



            else
            {
                Plates_Model.OperarionPlateOfType(Current_PlateOfType, "Insert");
                Grid_PlateOftype = new ObservableCollection<PlateOfType>();
                Plates_Model.GetPlateOfType(Grid_PlateOftype);
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية الأضافة";
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
        bool CanSave() => Current_PlateOfType != null && !Current_PlateOfType.HasErrors;
        void close()
        {
            Current_PlateOfType = null;
            win.Close();
        }

        void GetExcel()
        {

            Plates_Model.GetExcel(Grid_PlateOftype);
            Grid_PlateOftype = new ObservableCollection<PlateOfType>();
            Plates_Model.GetPlateOfType(Grid_PlateOftype);
        }

        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; set; }
        public RelayCommand Excelcommand
        {
            get; private set;
        }
        #endregion




        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
