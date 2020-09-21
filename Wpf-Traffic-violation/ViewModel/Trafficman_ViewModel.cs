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

    class Trafficman_ViewModel : BindableBase
    {
        Window_AddTrafficMan win;

        #region Objects And Variables
        Models.TrafficmanModel traffic_Man_Model = new TrafficmanModel();
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

        ObservableCollection<TrafficMan> grid_trafficmans;
        public ObservableCollection<TrafficMan> Grid_trafficmans //يربط مع الجرد فيو 
        {
            get
            {
                return grid_trafficmans;
            }
            set
            {
                if (grid_trafficmans != value)
                {
                    grid_trafficmans = value;
                    RaisePropertyChanged("Grid_trafficmans");
                }
            }
        }
        TrafficMan currunt_trafficman; //selectedItemيربط مع 
        public TrafficMan Currunt_trafficman
        {
            get
            {
                return currunt_trafficman;
            }
            set
            {
                if (currunt_trafficman != value)
                {
                    currunt_trafficman = value;
                    RaisePropertyChanged("Currunt_trafficman");
                }
            }
        }



        #endregion
        #region Proprties
        #endregion
        #region Construcor
        public Trafficman_ViewModel()
        {
            Grid_trafficmans = new ObservableCollection<TrafficMan>();
            traffic_Man_Model.GetTrafficMans(Grid_trafficmans);
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id =18;
            new AllPermissions().getPermission(PermissionUser);
            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events

        public void Add()
        {
            int maxid = new Class_SqlConnection().Get_Max("Traffic_man");
            Currunt_trafficman = new TrafficMan {Traffic_man_id=maxid };
            Currunt_trafficman = new TrafficMan();
            win = new Window_AddTrafficMan { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {
            //Personview PersonView = new Personview();
            //PersonView.textbox1.Text = CurrentPerson.Id.ToString();
            IsEditing = true;

            win = new Window_AddTrafficMan { DataContext = this };
            win.textBox_TrafficMan.IsReadOnly = true;

            win.ShowDialog();

        }
        bool CanEdit() => Currunt_trafficman != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                if (Currunt_trafficman.User_id != 2)
                {
                    string message1 = "يجب عليك أولاً حذف حساب المستخدم  ";
                    string caption1 = "تأكيد";
                    MessageBoxButton buttons1 = MessageBoxButton.OK;
                    MessageBoxImage icon1 = MessageBoxImage.Question;
                    MessageBox.Show(message1, caption1, buttons1, icon1);
                    return;
                }
                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 18;
                Current_Activity.Activity_record_num = Currunt_trafficman.Traffic_man_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

                traffic_Man_Model.OperarionTrafficMan(Currunt_trafficman, "Delete");
                grid_trafficmans.Remove(Currunt_trafficman);
               
            }
            else
            {
                return;
            }


        }
        bool CanDelet() => Currunt_trafficman != null && PermissionUser.Delete_opretion == true;
        void Save()
        {//ComboBoxes.Combo_usertype
         //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 18;
            Current_Activity.Activity_record_num = Currunt_trafficman.Traffic_man_id;

            //////////////////////////////////////////////////////////
            

            if (IsEditing && traffic_Man_Model.Check_Exsit(Currunt_trafficman.Traffic_man_id))
            {
                traffic_Man_Model.OperarionTrafficMan(Currunt_trafficman, "Update");
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
            else if (traffic_Man_Model.Check_Exsit(Currunt_trafficman.Traffic_man_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                win.textBox_TrafficMan.Focus();
                win.textBox_TrafficMan.SelectionStart = 0;
                win.textBox_TrafficMan.SelectionLength = win.textBox_TrafficMan.Text.Length;
            }
            else
            {
                traffic_Man_Model.OperarionTrafficMan(Currunt_trafficman, "Insert");
                grid_trafficmans.Add(Currunt_trafficman);
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



            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_trafficman != null && !Currunt_trafficman.HasErrors;
        void close()
        {
            Currunt_trafficman = null;
            win.Close();
        }
        void GetExcel()
        {

            traffic_Man_Model.GetExcel(Grid_trafficmans);
            Grid_trafficmans = new ObservableCollection<TrafficMan>();
            traffic_Man_Model.GetTrafficMans(Grid_trafficmans);
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
