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
    class CategoriesOfLicenses_ViewModel : BindableBase
    {
        Window_AddCategoriesOfLicenses win;
        #region Objects And Variables
        CategoriesOfLicenses_Model categoriesOfLicenses_Model = new CategoriesOfLicenses_Model();
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
        ObservableCollection<CategoriesOfLicenses> grid_CategoriesOfLicenses;
        public ObservableCollection<CategoriesOfLicenses> Grid_CategoriesOfLicenses
        {
            get
            {
                return grid_CategoriesOfLicenses;
            }
            set
            {
                if (grid_CategoriesOfLicenses != value)
                {
                    grid_CategoriesOfLicenses = value;
                    RaisePropertyChanged("Grid_CategoriesOfLicenses");
                }
            }
        }
        CategoriesOfLicenses current_CategoriesOfLicenses;
        public CategoriesOfLicenses Current_CategoriesOfLicenses
        {
            get
            {
                return current_CategoriesOfLicenses;
            }
            set
            {
                if (current_CategoriesOfLicenses != value)
                {
                    current_CategoriesOfLicenses = value;
                    RaisePropertyChanged("Current_CategoriesOfLicenses");
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
        public CategoriesOfLicenses_ViewModel()
        {
            Grid_CategoriesOfLicenses = new ObservableCollection<CategoriesOfLicenses>();
            categoriesOfLicenses_Model.GetCategoriesOfLicenses(Grid_CategoriesOfLicenses);
            //Grid_Provinces = new ObservableCollection<Provinces>();//بنحتاجه لما نتعامل مع اكثر من محافظة
            //provinces_Model.GetProvinces(Grid_Provinces);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 21;
            new AllPermissions().getPermission(PermissionUser);

            Current_Activity = new Activity();

        }
        #endregion
        #region Methodes And Events



        public void Add()
        {
            int maxid = new Class_SqlConnection().Get_Max("Class_licence");

            Current_CategoriesOfLicenses = new CategoriesOfLicenses { Class_licence_ID = maxid, Province_name = "تعز" };
            Selected_Provinces = new Provinces();
            win = new Window_AddCategoriesOfLicenses { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;

            win = new Window_AddCategoriesOfLicenses { DataContext = this };
            win.textBox_id.IsReadOnly = true;

            win.ShowDialog();

        }
        bool CanEdit() => Current_CategoriesOfLicenses != null && PermissionUser.Update_opretion == true;

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
                Current_Activity.Form_id = 21;
                Current_Activity.Activity_record_num = Current_CategoriesOfLicenses.Class_licence_ID;
                categoriesOfLicenses_Model.OperarionCategoriesOfLicenses(Current_CategoriesOfLicenses, "Delete");
                Grid_CategoriesOfLicenses.Remove(Current_CategoriesOfLicenses);

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
        bool CanDelet() => Current_CategoriesOfLicenses != null && PermissionUser.Delete_opretion == true;
        void Save()
        {//////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 21;
            Current_Activity.Activity_record_num = Current_CategoriesOfLicenses.Class_licence_ID;

            //////////////////////////////////////////////////////////

            Current_CategoriesOfLicenses.Province_id = 4;

            if (IsEditing && categoriesOfLicenses_Model.Check_Exsit(Current_CategoriesOfLicenses.Class_licence_ID))
            {
                categoriesOfLicenses_Model.OperarionCategoriesOfLicenses(Current_CategoriesOfLicenses, "Update");
                IsEditing = false;
                close();
                string message = "تمت عملية التعديل بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
             
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num =2;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

            }
            else if (categoriesOfLicenses_Model.Check_Exsit(Current_CategoriesOfLicenses.Class_licence_ID))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);


            }



            else
            {
                categoriesOfLicenses_Model.OperarionCategoriesOfLicenses(Current_CategoriesOfLicenses, "Insert");
                Current_CategoriesOfLicenses.Province_name = Selected_Provinces.Province_name;
                Grid_CategoriesOfLicenses = new ObservableCollection<CategoriesOfLicenses>();
                categoriesOfLicenses_Model.GetCategoriesOfLicenses(Grid_CategoriesOfLicenses);
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
        bool CanSave() => Current_CategoriesOfLicenses != null && !Current_CategoriesOfLicenses.HasErrors;
        void close()
        {
            Current_CategoriesOfLicenses = null;
            win.Close();
        }

        void GetExcel()
        {

            categoriesOfLicenses_Model.GetExcel(Grid_CategoriesOfLicenses);
            Grid_CategoriesOfLicenses = new ObservableCollection<CategoriesOfLicenses>();
            categoriesOfLicenses_Model.GetCategoriesOfLicenses(Grid_CategoriesOfLicenses);
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
