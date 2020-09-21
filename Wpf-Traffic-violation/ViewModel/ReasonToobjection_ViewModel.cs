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

    public class ReasonToobjection_ViewModel : BindableBase
    {
        Window_AddReasonsToObject win;

        #region Objects And Variables
        Models.ReasonsToObjection_Model Reason_Model = new ReasonsToObjection_Model();
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

        ObservableCollection<ReasonsToObject> gird_ReasonToObjecrion;
        public ObservableCollection<ReasonsToObject> Gird_ReasonToObjecrion
        {
            get
            {
                return gird_ReasonToObjecrion;
            }
            set
            {
                if (gird_ReasonToObjecrion != value)
                {
                    gird_ReasonToObjecrion = value;
                    RaisePropertyChanged("Gird_ReasonToObjecrion");
                }
            }
        }
        ReasonsToObject current_ReasonToobjection;
        public ReasonsToObject Current_ReasonToobjection
        {
            get
            {
                return current_ReasonToobjection;
            }
            set
            {
                if (current_ReasonToobjection != value)
                {
                    current_ReasonToobjection = value;
                    RaisePropertyChanged("Current_ReasonToobjection");
                }
            }
        }



        #endregion
        #region Construcor
        public ReasonToobjection_ViewModel()
        {
            Gird_ReasonToObjecrion = new ObservableCollection<ReasonsToObject>();
            Reason_Model.GetReasonToObjection(Gird_ReasonToObjecrion);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 28;
            new AllPermissions().getPermission(PermissionUser);

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events

        public void Add()
        {
            int maxid = new Class_SqlConnection().Get_Max("Reason_interception");

            Current_ReasonToobjection = new ReasonsToObject { Reason_inter_id = maxid };
            win = new Window_AddReasonsToObject { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;

            win = new Window_AddReasonsToObject { DataContext = this };
            win.textBox_idReason.IsReadOnly = true;
            win.ShowDialog();

        }
        bool CanEdit() => Current_ReasonToobjection != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                Reason_Model.OperarionReasonToOblection(Current_ReasonToobjection, "Delete");
                Gird_ReasonToObjecrion.Remove(Current_ReasonToobjection);

                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 24;
                Current_Activity.Activity_record_num = Current_ReasonToobjection.Reason_inter_id;

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
        bool CanDelet() => Current_ReasonToobjection != null && PermissionUser.Delete_opretion == true;
        void Save()
        {//ComboBoxes.Combo_usertype
         //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 24;
            Current_Activity.Activity_record_num = Current_ReasonToobjection.Reason_inter_id;

            //////////////////////////////////////////////////////////
            

            if (IsEditing && Reason_Model.Check_Exsit(Current_ReasonToobjection.Reason_inter_id))
            {
                Reason_Model.OperarionReasonToOblection(Current_ReasonToobjection, "Update");
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
            else if (Reason_Model.Check_Exsit(Current_ReasonToobjection.Reason_inter_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                win.textBox_idReason.Focus();
                win.textBox_idReason.SelectionStart = 0;
                win.textBox_idReason.SelectionLength = win.textBox_idReason.Text.Length;
            }



            else
            {
                Reason_Model.OperarionReasonToOblection(Current_ReasonToobjection, "Insert");
                Gird_ReasonToObjecrion = new ObservableCollection<ReasonsToObject>();
                Reason_Model.GetReasonToObjection(Gird_ReasonToObjecrion);
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
        bool CanSave() => Current_ReasonToobjection != null && !Current_ReasonToobjection.HasErrors;
        void close()
        {
            Current_ReasonToobjection = null;
            win.Close();
        }
        void GetExcel()
        {

            Reason_Model.GetExcel(Gird_ReasonToObjecrion);
            Gird_ReasonToObjecrion = new ObservableCollection<ReasonsToObject>();
            Reason_Model.GetReasonToObjection(Gird_ReasonToObjecrion);
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
