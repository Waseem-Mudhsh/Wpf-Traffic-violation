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
    public class ViolationType_ViewModel : BindableBase
    {
        Window_AddTypeOFViolations win = new Window_AddTypeOFViolations();
        #region Objects And Variables
        Models.ViolationTypeModel violationTypeModel = new ViolationTypeModel();
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
        ObservableCollection<ViolationType> grid_ViolationType;
        public ObservableCollection<ViolationType> Grid_ViolationTypes //يربط مع الجرد فيو 
        {
            get
            {
                return grid_ViolationType;
            }
            set
            {
                if (grid_ViolationType != value)
                {
                    grid_ViolationType = value;
                    RaisePropertyChanged("Grid_ViolationTypes");
                }
            }
        }
        ViolationType currunt_ViolationType; //selectedItemيربط مع 

        public ViolationType Currunt_ViolationType
        {
            get
            {
                return currunt_ViolationType;
            }
            set
            {
                if (currunt_ViolationType != value)
                {
                    currunt_ViolationType = value;
                    RaisePropertyChanged("Currunt_ViolationType");
                }
            }
        }
        #endregion
        #region Construcor
        public ViolationType_ViewModel()
        {
            asyncViolationType();

            Addcommand = new RelayCommand(Par => Add());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit());
            Deletecommand = new RelayCommand(par => Delet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());


            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 25;

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events

        async Task asyncViolationType()
        {
            Grid_ViolationTypes = new ObservableCollection<ViolationType>();
            Grid_ViolationTypes = violationTypeModel.GetViolationType();
        }

        public void Add()
        {

            Currunt_ViolationType = new ViolationType();
            Currunt_ViolationType.Violation_type_id = new Class_SqlConnection().Get_Max("Violation_type", "Violation_type_id") + 1;
            win = new Window_AddTypeOFViolations { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;
            win = new Window_AddTypeOFViolations { DataContext = this };
            win.ShowDialog();

        }
        bool CanEdit() => Currunt_ViolationType != null && PermissionUser.Update_opretion == true;





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
                Current_Activity.Form_id = 25;
                Current_Activity.Activity_record_num = Currunt_ViolationType.Violation_type_id;

                //////////////////////////////////////////////////////////

                if (violationTypeModel.OperarionViolationType(Currunt_ViolationType, "Delete"))
                {
                    Grid_ViolationTypes.Remove(Currunt_ViolationType);
                    string message1 = "تمت عملية الحذف بنجاح";
                    string caption1 = "عملية الحذف";
                    MessageBoxImage icon1 = MessageBoxImage.Information;
                    MessageBoxButton buttons1 = MessageBoxButton.OK;
                    MessageBox.Show(message1, caption1, buttons1, icon1);
                    ////////////////////////////////////////////////////////////
                    //Current_Activity.Activity_operation_num = 3;
                    //ActivityModel.OperarionActivity(current_Activity, "Insert");
                    ////////////////////////////////////////////////////////////
                }
                else
                {
                    string message1 = "يوجد سجلات مرتبطة بهذا النوع";
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
        bool CanDelet() => Currunt_ViolationType != null && PermissionUser.Delete_opretion == true;
        void Save()
        {//ComboBoxes.Combo_usertype

            //////////////////////////////////////////////////////////////

            //Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 25;
            Current_Activity.Activity_record_num = Currunt_ViolationType.Violation_type_id;

            //////////////////////////////////////////////////////////

            if (IsEditing)
            {
                violationTypeModel.OperarionViolationType(Currunt_ViolationType, "Update");
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
            else
            {
                violationTypeModel.OperarionViolationType(Currunt_ViolationType, "Insert");
                Grid_ViolationTypes.Add(Currunt_ViolationType);
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية الإضافة";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 1;
                //ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }



            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_ViolationType != null && !Currunt_ViolationType.HasErrors;
        void close()
        {
            Currunt_ViolationType = null;
            win.Close();
        }

        void GetExcel()
        {

            violationTypeModel.GetExcel(Grid_ViolationTypes);
            Grid_ViolationTypes = new ObservableCollection<ViolationType>();
            Grid_ViolationTypes = violationTypeModel.GetViolationTypes();
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
