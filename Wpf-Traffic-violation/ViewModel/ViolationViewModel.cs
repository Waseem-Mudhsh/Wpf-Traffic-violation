using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
    public class ViolationViewModel : BindableBase
    {

        #region Objects And Variables
        Window_AddViolation win;
        ActivityModel ActivityModel = new ActivityModel();
        VoilationModel ViolationModel = new VoilationModel();
        ViolationTypeModel ViolationTypeModel = new ViolationTypeModel();
        Plate_Model Plate_Model = new Plate_Model();
        Street_Model Street_Model = new Street_Model();
        TrafficmanModel TrafficmanModel = new TrafficmanModel();
        EntryModel EntryModel = new EntryModel();
        PermissionUser PermissionUser;
        #endregion
        #region Proprties
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
        Violation current_Violation; //selectedItemيربط مع 

        public Violation Current_Violation
        {
            get
            {
                return current_Violation;
            }
            set
            {
                if (current_Violation != value)
                {
                    current_Violation = value;
                    RaisePropertyChanged("Current_Violation");
                }
            }
        }

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
        public ObservableCollection<ViolationType> Grid_ViolationType//يربط مع الجرد فيو 
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
                    RaisePropertyChanged("Grid_ViolationType");
                }
            }
        }
        ViolationType selected_ViolationType; //selectedItemيربط مع 

        public ViolationType Selected_ViolationType
        {
            get
            {
                return selected_ViolationType;
            }
            set
            {
                if (selected_ViolationType != value)
                {
                    selected_ViolationType = value;
                    RaisePropertyChanged("Selected_ViolationType");
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
        Plate selected_Plate;
        public Plate Selected_Plate
        {
            get
            {
                return selected_Plate;
            }
            set
            {
                if (selected_Plate != value)
                {
                    selected_Plate = value;
                    RaisePropertyChanged("Selected_Plate");
                }
            }
        }
        ObservableCollection<Streets> grid_Streets;
        public ObservableCollection<Streets> Grid_Streets//يربط مع الجرد فيو 
        {
            get
            {
                return grid_Streets;
            }
            set
            {
                if (grid_Streets != value)
                {
                    grid_Streets = value;
                    RaisePropertyChanged("Grid_Streets");
                }
            }
        }
        Streets selected_Street;
        public Streets Selected_Street
        {
            get
            {
                return selected_Street;
            }
            set
            {
                if (selected_Street != value)
                {
                    selected_Street = value;
                    RaisePropertyChanged("Selected_Street");
                }
            }
        }
        ObservableCollection<TrafficMan> grid_TrafficMan;
        public ObservableCollection<TrafficMan> Grid_TrafficMan//يربط مع الجرد فيو 
        {
            get
            {
                return grid_TrafficMan;
            }
            set
            {
                if (grid_TrafficMan != value)
                {
                    grid_TrafficMan = value;
                    RaisePropertyChanged("Grid_TrafficMan");
                }
            }
        }
        TrafficMan selected_TrafficMan;
        public TrafficMan Selected_TrafficMan
        {
            get
            {
                return selected_TrafficMan;
            }
            set
            {
                if (selected_TrafficMan != value)
                {
                    selected_TrafficMan = value;
                    RaisePropertyChanged("Selected_TrafficMan");
                }
            }
        }

        #endregion
        #region Construcor
        public ViolationViewModel()
        {
            Grid_Violation = new ObservableCollection<Violation>();
            ViolationModel.GetViolation(Grid_Violation);
            Grid_ViolationType = new ObservableCollection<ViolationType>();
            ViolationTypeModel.GetViolationTypes(Grid_ViolationType);
            Grid_Plate = new ObservableCollection<Plate>();
            Plate_Model.GetPlates(Grid_Plate);
            Grid_Streets = new ObservableCollection<Streets>();
            Street_Model.GetStreets(Grid_Streets);
            Grid_TrafficMan = new ObservableCollection<TrafficMan>();
            TrafficmanModel.GetTrafficMans(Grid_TrafficMan);
            
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());
            AddPhoto1command = new RelayCommand(par => AddPhoto1());
            AddPhoto2command = new RelayCommand(par => AddPhoto2());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 1;
            new AllPermissions().getPermission(PermissionUser);

            Current_Activity = new Activity();
        }
        #endregion
        #region Methodes And Events
        public void Add()
        {
            Selected_ViolationType = new ViolationType();
            Selected_Plate = new Plate();
            Selected_Street = new Streets();
            Selected_TrafficMan = new TrafficMan();
            int maxid = new Class_SqlConnection().Get_Max("Violation");


            Current_Violation = new Violation { Violation_id = maxid };
            win = new Window_AddViolation { DataContext = this };
            win.ShowDialog();
        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {

            Current_Violation.New_amount = 0;
            IsEditing = true;
            string filename1 = "Violation/" + Current_Violation.Violation_photo1 + ".jpg";
            string filename2 = "Violation/" + Current_Violation.Violation_photo2 + ".jpg";
            win = new Window_AddViolation { DataContext = this };

            //
            //
            //
            foreach (ViolationType a in Grid_ViolationType)
            {
                if (a.Violation_type_id == Current_Violation.Violation_type_id)
                    Selected_ViolationType = a;
            }
            //
            foreach (TrafficMan a in Grid_TrafficMan)
            {
                if (a.Traffic_man_id == Current_Violation.Teaffic_man_id)
                    Selected_TrafficMan = a;
            }

            win.trafficman.SelectedItem = Selected_TrafficMan;
            //
            foreach (Plate a in Grid_Plate)
            {
                if (a.Plate_id == Current_Violation.Plate_id)
                    Selected_Plate = a;
            }
            win.a.SelectedItem = Selected_Plate;
            win.b.SelectedItem = Selected_Plate;


            //
            foreach (Streets a in Grid_Streets)
            {
                if (a.Street_id == Current_Violation.Street_id)
                    Selected_Street = a;
            }
            win.street.SelectedItem = Selected_Street;
            //
            //
            //

            BitmapImage image1 = new BitmapImage();
            image1.BeginInit();
            image1.CacheOption = BitmapCacheOption.OnLoad;
            image1.UriSource = new Uri(filename1, UriKind.Relative);
            image1.EndInit();
            win.logo1.Source = image1;

            BitmapImage image2 = new BitmapImage();
            image2.BeginInit();
            image2.CacheOption = BitmapCacheOption.OnLoad;
            image2.UriSource = new Uri(filename2, UriKind.Relative);
            image2.EndInit();
            win.logo2.Source = image2;
            win.ShowDialog();

        }
        bool CanEdit() => Current_Violation != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                foreach (Plate a in Grid_Plate)
                {
                    if (a.Plate_id == Current_Violation.Plate_id)
                        Selected_Plate = a;
                }
                string filename1 = "Violation/" + Current_Violation.Violation_photo1 + ".jpg";
                string filename2 = "Violation/" + Current_Violation.Violation_photo2 + ".jpg";
                File.Delete(filename1);
                File.Delete(filename2);
                MessageBox.Show(Selected_Plate.Account_id.ToString());
                MessageBox.Show(Current_Violation.Violation_date);

                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 1;
                Current_Activity.Activity_record_num = Current_Violation.Violation_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 3;
                ActivityModel.OperarionActivity(current_Activity,"Insert");
                ////////////////////////////////////////////////////////////

                ViolationModel.OperarionViolation(Current_Violation, "Delete");
                EntryModel.DeleteEntry(Selected_Plate.Account_id, 345, Current_Violation.Violation_date);
                Grid_Violation.Remove(Current_Violation);
            }
            else
            {
                return;
            }

        }
        bool CanDelet() => Current_Violation != null && PermissionUser.Delete_opretion == true;

        void Save()
        {
            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 1;
            Current_Activity.Activity_record_num = Current_Violation.Violation_id;

            //////////////////////////////////////////////////////////


            Current_Violation.Violation_type_id = Selected_ViolationType.Violation_type_id;
            Current_Violation.Teaffic_man_id = Selected_TrafficMan.Traffic_man_id;
            Current_Violation.Plate_id = Selected_Plate.Plate_id;
            Current_Violation.Street_id = Selected_Street.Street_id;

            try
            {

                if (IsEditing && ViolationModel.Check_Exsit(Current_Violation.Violation_id))
                {
                    Current_Violation.New_amount = new Class_SqlConnection().Get_number("GetViolationTypeMount", Current_Violation.Violation_type_id) + Current_Violation.Violation_penalty;

                    if (Current_Violation.New_amount == Current_Violation.Amount)
                    {
                        ViolationModel.OperarionViolation(Current_Violation, "Update");
                    }
                    else
                    {/////////////////////////////
                        ViolationModel.OperarionViolation(Current_Violation, "Update");
                        EntryModel.UpdateEntry(Selected_Plate.Account_id, 345, Current_Violation.Violation_date, Current_Violation.New_amount);
                    }
                    IsEditing = false;
                    ////////////////////////////////////////////////////////////
                    Current_Activity.Activity_operation_num = 2;
                    ActivityModel.OperarionActivity(current_Activity,"Insert");
                    ////////////////////////////////////////////////////////////

                    string message = "تمت عملية التعديل بنجاح";
                    string caption = "عملية التعديل";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                    close();
                }
                else if (ViolationModel.Check_Exsit(Current_Violation.Violation_id))
                {
                    string message = "رقم المستخدم موجود مسبقا";
                    string caption = "رسالة خطا";
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);

                }
                else
                {
                    Current_Violation.Amount = new Class_SqlConnection().Get_number("GetViolationTypeMount", Selected_ViolationType.Violation_type_id) + Current_Violation.Violation_penalty;
                    int x = new Class_SqlConnection().Get_Max("Entry");

                    ////////////////////////////////////////////////////////////
                    Current_Activity.Activity_operation_num = 1;
                    ActivityModel.OperarionActivity(current_Activity, "Insert");
                    ////////////////////////////////////////////////////////////

                    if (ViolationModel.OperarionViolation(Current_Violation, "Insert"))
                        EntryModel.AddEntry(x, Current_Violation.String_ViolationType, Current_Violation.Violation_date, Selected_Plate.Account_id, 4110001, Current_Violation.Amount);
                    Grid_Violation.Add(Current_Violation);
                    close();
                    string message = "تمت عملية الإضافة بنجاح";
                    string caption = "عملية التعديل";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);

                }

            }// end try
            catch (Exception e)
            {
                MessageBox.Show("Error reading from " + e.Message);

                close();

            }

            //Enable_Grid = false;
        }
        bool CanSave() => Current_Violation != null && !Current_Violation.HasErrors;


        void close()
        {
            Current_Violation = null;
            try { win.Close(); }
            catch (Exception e) { this.close(); }
        }
        void GetExcel()
        {

            ViolationModel.GetExcel(Grid_Violation);
            Grid_Violation = new ObservableCollection<Violation>();
            ViolationModel.GetViolation(Grid_Violation);
        }
        void AddPhoto1()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                win.logo1.Source = new BitmapImage(new Uri(op.FileName));
                File.Copy(op.FileName, "Violation/photo1" + Current_Violation.Violation_id + ".jpg");
                Current_Violation.Violation_photo1 = "photo1" + Current_Violation.Violation_id;


            }
        }

        void AddPhoto2()
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Title = "Select a picture";
            op1.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op1.ShowDialog() == true)
            {
                win.logo2.Source = new BitmapImage(new Uri(op1.FileName));

                File.Copy(op1.FileName, "Violation/photo2" + Current_Violation.Violation_id + ".jpg");
                Current_Violation.Violation_photo2 = "photo2" + Current_Violation.Violation_id;
            }
        }


        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; private set; }
        public RelayCommand Excelcommand { get; private set; }
        public RelayCommand AddPhoto1command { get; set; }
        public RelayCommand AddPhoto2command { get; set; }

        #endregion






        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
