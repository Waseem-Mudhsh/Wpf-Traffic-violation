using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
    public class OpjectionViewModel : BindableBase
    {

        #region Objects And Variables
        Window_AddObjection win;
        Window_ScanObjection win1;
        OpjectionModel OpjectionModel = new OpjectionModel();
        CitizenModel CitizenModel = new CitizenModel();
        ReasonsToObjection_Model ReasonsToObjection_Model = new ReasonsToObjection_Model();
        VoilationModel VoilationModel = new VoilationModel();
        PermissionUser PermissionUser;
        PermissionUser PermissionUser1;
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

        ObservableCollection<ReasonsToObject> grid_ReasonsToObject;
        public ObservableCollection<ReasonsToObject> Grid_ReasonsToObject//يربط مع الجرد فيو 
        {
            get
            {
                return grid_ReasonsToObject;
            }
            set
            {
                if (grid_ReasonsToObject != value)
                {
                    grid_ReasonsToObject = value;
                    RaisePropertyChanged("Grid_ReasonsToObject");
                }
            }
        }
        ReasonsToObject selected_ReasonsToObject; //selectedItemيربط مع 

        public ReasonsToObject Selected_ReasonsToObject
        {
            get
            {
                return selected_ReasonsToObject;
            }
            set
            {
                if (selected_ReasonsToObject != value)
                {
                    selected_ReasonsToObject = value;
                    RaisePropertyChanged("Selected_ReasonsToObject");
                }
            }
        }
        ObservableCollection<Opjection> grid_Opjection;
        public ObservableCollection<Opjection> Grid_Opjection//يربط مع الجرد فيو 
        {
            get
            {
                return grid_Opjection;
            }
            set
            {
                if (grid_Opjection != value)
                {
                    grid_Opjection = value;
                    RaisePropertyChanged("Grid_Opjection");
                }
            }
        }
        Opjection currunt_Opjection; //selectedItemيربط مع 

        public Opjection Currunt_Opjection
        {
            get
            {
                return currunt_Opjection;
            }
            set
            {
                if (currunt_Opjection != value)
                {
                    currunt_Opjection = value;
                    RaisePropertyChanged("Currunt_Opjection");
                }
            }
        }
        ObservableCollection<Citizen> grid_Citizen;
        public ObservableCollection<Citizen> Grid_Citizen//يربط مع الجرد فيو 
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
        Citizen currunt_Citizen; //selectedItemيربط مع 

        public Citizen Currunt_Citizen
        {
            get
            {
                return currunt_Citizen;
            }
            set
            {
                if (currunt_Citizen != value)
                {

                    currunt_Citizen = value;
                    RaisePropertyChanged("Currunt_Citizen");
                    if (Currunt_Citizen != null)
                    {
                        Grid_Violation.Clear();
                        Grid_Violation = VoilationModel.GetViolation_not_payment(Currunt_Citizen.Citizen_id);
                    }
                }
            }
        }
        ObservableCollection<Violation> grid_Violation;
        public ObservableCollection<Violation> Grid_Violation//يربط مع الجرد فيو 
        {
            get
            {
                return grid_Violation;
            }
            set
            {
                if (grid_Violation != value)
                {
                    grid_Violation = value;
                    RaisePropertyChanged("Grid_Violation");
                }
            }
        }
        Violation selected_Violation; //selectedItemيربط مع 

        public Violation Selected_Violation
        {
            get
            {
                return selected_Violation;
            }
            set
            {
                if (selected_Violation != value)
                {
                    selected_Violation = value;
                    RaisePropertyChanged("Selected_Violation");
                }
            }
        }
        #endregion
        #region Construcor
        public OpjectionViewModel()
        {
            ////var watch = System.Diagnostics.Stopwatch.StartNew();
            asyncgetOpjection();
            Grid_Violation = new ObservableCollection<Violation>();
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //MessageBox.Show($"Total execution time1:{ elapsedMs}");


            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Scancommand = new RelayCommand(par => Scan(), par => CanScan());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Savecommand_scan = new RelayCommand(par => Save_scan(), par => CanSave_scan());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 8;

            PermissionUser1 = new PermissionUser();
            PermissionUser1.Form_id = 9;
            new AllPermissions().getPermission(PermissionUser1);

            Current_Activity = new Activity();


        }
        #endregion
        #region Methodes And Events
        private async Task asyncgetOpjection()
        {
            Grid_Opjection = new ObservableCollection<Opjection>();

            Grid_Opjection = await Task.Run(() => OpjectionModel.GetOpjectionasync());
            Grid_Citizen = new ObservableCollection<Citizen>();

            Grid_Citizen = await Task.Run(() => CitizenModel.GetCitizens());
            Grid_ReasonsToObject = new ObservableCollection<ReasonsToObject>();
            Grid_ReasonsToObject = await Task.Run(() => ReasonsToObjection_Model.GetReasonToObjection());

        }


        public void Add()
        {
            // Selected_Violation.String_ViolationType
            int maxid = new Class_SqlConnection().Get_Max("Interception");


            Selected_ReasonsToObject = new ReasonsToObject();
            Selected_Violation = new Violation();
            Currunt_Citizen = new Citizen();
            Currunt_Opjection = new Opjection { Interception_id = maxid };
            win = new Window_AddObjection { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        public void Edit()
        {
            IsEditing = true;
            win = new Window_AddObjection { DataContext = this };

            foreach (Citizen a in Grid_Citizen)
            {
                if (a.Citizen_id == Currunt_Opjection.Identity_id)
                    Currunt_Citizen = a;
            }

            win.citizenid.SelectedItem = Currunt_Citizen;
            win.citizenname.SelectedItem = Currunt_Citizen;

            foreach (Violation a in Grid_Violation)
            {
                if (a.Violation_id == Currunt_Opjection.Violation_id)
                    Selected_Violation = a;
            }
            win.violatinid.SelectedItem = Selected_Violation;
            win.violationname.SelectedItem = Selected_Violation;


            win.aa.Text = Currunt_Opjection.Reason_Interception;
            win.ShowDialog();
            //   MessageBox.Show(Currunt_Citizen.Citizen_name);

        }
        bool CanEdit() => Currunt_Opjection != null && PermissionUser.Update_opretion;
        public void Scan()
        {
            IsScaning = true;
            win1 = new Window_ScanObjection { DataContext = this };

            foreach (Citizen a in Grid_Citizen)
            {
                if (a.Citizen_id == Currunt_Opjection.Identity_id)
                    Currunt_Citizen = a;
            }
            //win1.citizenid.SelectedItem = Currunt_Citizen;
            //win1.citizenname.SelectedItem = Currunt_Citizen;

            foreach (Violation a in Grid_Violation)
            {
                if (a.Violation_id == Currunt_Opjection.Violation_id)
                    Selected_Violation = a;
            }
            win1.violatinid.SelectedItem = Selected_Violation;
            win1.violationname.SelectedItem = Selected_Violation;
            if (Currunt_Opjection.Status == 1)
                win1.RadioButton1.IsChecked = true;
            else if (Currunt_Opjection.Status == 2)
                win1.RadioButton2.IsChecked = true;

            win1.ShowDialog();
            //   MessageBox.Show(Currunt_Citizen.Citizen_name);

        }
        bool CanScan() => Currunt_Opjection != null && PermissionUser1.Form == true;
        public void Delet()
        {
            OpjectionModel.OperarionOpjection(Currunt_Opjection, "Delete");
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
                Current_Activity.Form_id = 8;
                Current_Activity.Activity_record_num = Currunt_Opjection.Interception_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
                // OpjectionModel.OperarionCitizen(Currunt_Citizen, "Delete");
                Grid_Opjection.Remove(Currunt_Opjection);



            }
            else
            {
                return;
            }


        }
        bool CanDelet() => Currunt_Opjection != null && PermissionUser.Delete_opretion == true;
        public void Save()
        {

            Currunt_Opjection.Identity_id = Currunt_Citizen.Citizen_id;
            Currunt_Opjection.String_Ciziten = Currunt_Citizen.Citizen_name;
            Currunt_Opjection.Violation_id = Selected_Violation.Violation_id;
            Currunt_Opjection.Status = 0;






            //MessageBox.Show(Currunt_Opjection.Interception_date);


            try
            {

                if (IsEditing && OpjectionModel.Check_Exsit(Currunt_Opjection.Interception_id))
                {
                    Currunt_Opjection.Reason_Interception = win.aa.Text.ToString();
                    OpjectionModel.OperarionOpjection(Currunt_Opjection, "Update");
                    IsEditing = false;
                    string message = "تمت عملية التعديل بنجاح";
                    string caption = "عملية التعديل";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);

                    //////////////////////////////////////////////////////////////

                    Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                    Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                    Current_Activity.User_id = Properties.Settings.Default.Userid;
                    Current_Activity.Form_id = 8;
                    Current_Activity.Activity_record_num = Currunt_Opjection.Interception_id;

                    //////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////
                    Current_Activity.Activity_operation_num = 2;
                    ActivityModel.OperarionActivity(current_Activity, "Insert");
                    ////////////////////////////////////////////////////////////

                    close();
                }

                else if (OpjectionModel.Check_Exsit(Currunt_Opjection.Interception_id))
                {
                    //Currunt_Opjection.Reason_Interception = win.aa.Text.ToString();
                    string message = "رقم المستخدم موجود مسبقا";
                    string caption = "رسالة خطا";
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(Selected_ReasonsToObject.Reason))
                    {
                        Currunt_Opjection.Reason_Interception = win.aa.Text.ToString();
                    }
                    else
                        Currunt_Opjection.Reason_Interception = Selected_ReasonsToObject.Reason;
                    OpjectionModel.OperarionOpjection(Currunt_Opjection, "Insert");
                    Grid_Opjection.Add(Currunt_Opjection);
                    close();
                    string message = "تمت عملية الإضافة بنجاح";
                    string caption = "عملية التعديل";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);

                    //////////////////////////////////////////////////////////////

                    Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                    Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                    Current_Activity.User_id = Properties.Settings.Default.Userid;
                    Current_Activity.Form_id = 8;
                    Current_Activity.Activity_record_num = Currunt_Opjection.Interception_id;

                    //////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////
                    Current_Activity.Activity_operation_num = 1;
                    ActivityModel.OperarionActivity(current_Activity, "Insert");
                    ////////////////////////////////////////////////////////////

                }

            }// end try
            catch (Exception e)
            {
                MessageBox.Show("لم يتم إختيار سبب الاعتراض");

                close();

            }

            //Enable_Grid = false;
        }
        bool CanSave() => Currunt_Opjection != null && !Currunt_Opjection.HasErrors && Currunt_Citizen != null && Selected_Violation != null;
        public void close()
        {
            Currunt_Opjection = null;
            try { win.Close(); }
            catch (Exception e)
            { win1.Close(); }
        }

        public void Save_scan()
        {

            Currunt_Opjection.Identity_id = Currunt_Citizen.Citizen_id;
            Currunt_Opjection.String_Ciziten = Currunt_Citizen.Citizen_name;
            Currunt_Opjection.Violation_id = Selected_Violation.Violation_id;


            //MessageBox.Show(Currunt_Opjection.Interception_date);




            if (IsScaning && OpjectionModel.Check_Exsit(Currunt_Opjection.Interception_id))
            {
                if (win1.RadioButton1.IsChecked == true)
                {
                    Currunt_Opjection.Status = 1;
                }

                else if (win1.RadioButton2.IsChecked == true)
                    Currunt_Opjection.Status = 2;
                else
                    Currunt_Opjection.Status = 0;

                OpjectionModel.OperarionOpjection(Currunt_Opjection, "Update");
                IsScaning = false;
                close();
                string message = "تمت عملية الفحص بنجاح";
                string caption = "عملية الفحص";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;

                MessageBox.Show(message, caption, buttons, icon);
                asyncgetOpjection();
                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 9;
                Current_Activity.Activity_record_num = Currunt_Opjection.Interception_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 4;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

            }
            else if (OpjectionModel.Check_Exsit(Currunt_Opjection.Interception_id))
            {
                //Currunt_Opjection.Reason_Interception = win.aa.Text.ToString();
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);
            }




            //Enable_Grid = false;
        }
        bool CanSave_scan() => win1.RadioButton1.IsChecked == true || win1.RadioButton2.IsChecked == true;

        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Scancommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Savecommand_scan { get; private set; }
        public RelayCommand Closecommand { get; private set; }

        #endregion






        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
