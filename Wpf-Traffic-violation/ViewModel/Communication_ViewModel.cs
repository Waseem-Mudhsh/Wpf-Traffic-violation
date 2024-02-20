using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xaml;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Views;
using System.Data;
using System.Drawing;
using System.Windows.Controls;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Models.Users_Model;

namespace Wpf_Traffic_violation.ViewModel
{
    public class Communication_ViewModel : BindableBase
    {

        #region Objects And Variables
        CommunicationModel CommunicationModel = new CommunicationModel();
        Plate_Model Plate_Model = new Plate_Model();
        ActivityModel ActivityModel = new ActivityModel();
        UserModel UserModel = new UserModel();
        Window_AddCommunication win;
        Window_ScanCommunication win1;
        Window_AddViolation win2;
        PermissionUser PermissionUser;
        PermissionUser PermissionUser1;
      
        #endregion
        #region Proprties
        ObservableCollection<Communication> grid_Communication;
        public ObservableCollection<Communication> Grid_Communication
        {
            get
            {
                return grid_Communication;
            }
            set
            {
                if (grid_Communication != value)
                {
                    grid_Communication = value;

                    RaisePropertyChanged("Grid_Communication");
                }
            }
        }
        Communication current_Communication;
        public Communication Current_Communication
        {
            get
            {
                return current_Communication;
            }
            set
            {
                if (current_Communication != value)
                {
                    current_Communication = value;
                    RaisePropertyChanged("Current_Communication");
                }
            }
        }

        Violation current_Violation;
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

        ObservableCollection<User> grid_User;
        public ObservableCollection<User> Grid_User
        {
            get
            {
                return grid_User;
            }
            set
            {
                if (grid_User != value)
                {
                    grid_User = value;

                    RaisePropertyChanged("Grid_User");
                }
            }
        }
        User selected_User;
        public User Selected_User
        {
            get
            {
                return selected_User;
            }
            set
            {
                if (selected_User != value)
                {
                    selected_User = value;
                    RaisePropertyChanged("Selected_User");
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
        #endregion
        #region Construcor
        public Communication_ViewModel()
        {
            asyncCommunication();
          
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Scancommand = new RelayCommand(par => Scan(), par => CanScan());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            Closecommand = new RelayCommand(par => close());
            AddPhoto1command = new RelayCommand(par => AddPhoto1());
            AddPhoto2command = new RelayCommand(par => AddPhoto2());
            Addviolationcommand = new RelayCommand(par => AddViolation());

            PermissionUser = new PermissionUser();
            PermissionUser.Form_id = 10;
           
            PermissionUser1 = new PermissionUser();
            PermissionUser1.Form_id = 11;
            new AllPermissions().getPermission(PermissionUser1);

            ActivityModel = new ActivityModel();
        }
        #endregion
        #region Methodes And Events

        private async Task asyncCommunication()
        {
            Grid_Communication = new ObservableCollection<Communication>();
            Grid_Communication=await Task.Run(()=>CommunicationModel.GetCommunication());


            Grid_User = new ObservableCollection<User>();
           await Task.Run(()=> Grid_User = UserModel.GetUsers());
            Grid_Plate = new ObservableCollection<Plate>();
            Grid_Plate = await Task.Run(() => Plate_Model.GetPlates());
        }
        public void Add()
        {
            Selected_User = new User();
            Selected_Plate = new Plate();
            int maxid = new Class_SqlConnection().Get_Max("Communication");

            Current_Communication = new Communication { Communication_id = maxid };
            win = new Window_AddCommunication { DataContext = this };
            win.ShowDialog();




        }
        bool CanAdd() => true && PermissionUser.Add_opretion == true;
        void Edit()
        {

           
            IsEditing = true;
            string filename1 = "aa/" + Current_Communication.Communication_photo1 + ".jpg";
            string filename2 = "aa/" + Current_Communication.Communication_photo2 + ".jpg";

            win = new Window_AddCommunication { DataContext = this };
            foreach (Plate a in Grid_Plate)
            {
                if (a.Plate_id == Current_Communication.Plate_id)
                    Selected_Plate = a;
            }
            win.a.SelectedItem = Selected_Plate;
            win.b.SelectedItem = Selected_Plate;

            foreach (User a in Grid_User)
            {
                if (a.Userid == Current_Communication.User_id)
                    Selected_User = a;
            }

            // win.a.Text = Current_Communication.PlateNumr;
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
        bool CanEdit() => Current_Communication != null && PermissionUser.Update_opretion == true;

        void Scan()
        {

            //Selected_User = new User();
            //Selected_Plate = new Plate();
            foreach (Plate a in Grid_Plate)
            {
                if (a.Plate_id == Current_Communication.Plate_id)
                    Selected_Plate = a;
            }
            //win.a.SelectedItem = Selected_Plate;
            //win.b.SelectedItem = Selected_Plate;

            foreach (User a in Grid_User)
            {
                if (a.Userid == Current_Communication.User_id)
                    Selected_User = a;
            }

            IsScaning = true;

            string filename1 = "aa/" + Current_Communication.Communication_photo1 + ".jpg";
            string filename2 = "aa/" + Current_Communication.Communication_photo2 + ".jpg";

            win1 = new Window_ScanCommunication { DataContext = this };

            BitmapImage image1 = new BitmapImage();
            image1.BeginInit();
            image1.CacheOption = BitmapCacheOption.OnLoad;
            image1.UriSource = new Uri(filename1, UriKind.Relative);
            image1.EndInit();
            win1.logo1.Source = image1;

            BitmapImage image2 = new BitmapImage();
            image2.BeginInit();
            image2.CacheOption = BitmapCacheOption.OnLoad;
            image2.UriSource = new Uri(filename2, UriKind.Relative);
            image2.EndInit();
            win1.logo2.Source = image2;

            win1.ShowDialog();


        }
        bool CanScan() => Current_Communication != null && PermissionUser1.Form == true;

        public void AddViolation()
        {
            if (win1.RadioButton1.IsChecked == true)
            {

                ViolationViewModel ViolationViewModel1 = new ViolationViewModel();
                ViolationViewModel1.Current_Violation = new Violation();
                ViolationViewModel1.Selected_ViolationType = new ViolationType();
                ViolationViewModel1.Selected_Plate = new Plate();
                ViolationViewModel1.Selected_Street = new Streets();
                ViolationViewModel1.Selected_TrafficMan = new TrafficMan();
                ViolationViewModel1.Current_Violation.Violation_date = DateTime.Now.Date.ToString();
                foreach (Plate a in Grid_Plate)
                {
                    if (a.Plate_id == Current_Communication.Plate_id)
                        ViolationViewModel1.Selected_Plate = a;
                }
                //Current_Violation = new Violation();
                ViolationViewModel1.Current_Violation.Violation_id = new Class_SqlConnection().Get_Max("Violation");
                win2 = new Window_AddViolation { DataContext = ViolationViewModel1 };
                string filename1 = "aa/" + Current_Communication.Communication_photo1 + ".jpg";
                string filename2 = "aa/" + Current_Communication.Communication_photo2 + ".jpg";
                ViolationViewModel1.Current_Violation.Violation_photo1 = Convert.ToByte(Current_Communication.Communication_photo1);
                ViolationViewModel1.Current_Violation.Violation_photo1 = Convert.ToByte(Current_Communication.Communication_photo1);


                win2.buttnsave.IsEnabled = true;
                //win2.a.SelectedItem = Selected_Plate;
                //win2.b.SelectedItem = Selected_Plate;

                BitmapImage image1 = new BitmapImage();
                image1.BeginInit();
                image1.CacheOption = BitmapCacheOption.OnLoad;
                image1.UriSource = new Uri(filename1, UriKind.Relative);
                image1.EndInit();
                win2.logo1.Source = image1;

                BitmapImage image2 = new BitmapImage();
                image2.BeginInit();
                image2.CacheOption = BitmapCacheOption.OnLoad;
                image2.UriSource = new Uri(filename2, UriKind.Relative);
                image2.EndInit();
                win2.logo2.Source = image2;
                try
                {
                    File.Copy("aa/" + Current_Communication.Communication_photo1 + ".jpg", "Violation/photo1" + ViolationViewModel1.Current_Violation.Violation_id + ".jpg");
                    File.Copy("aa/" + Current_Communication.Communication_photo2 + ".jpg", "Violation/photo2" + ViolationViewModel1.Current_Violation.Violation_id + ".jpg");
                }
                catch (Exception e) { }
                ViolationViewModel1.Current_Violation.Violation_photo1 = Convert.ToByte("photo1" + ViolationViewModel1.Current_Violation.Violation_id);
                ViolationViewModel1.Current_Violation.Violation_photo2 = Convert.ToByte("photo2" + ViolationViewModel1.Current_Violation.Violation_id);



                win2.ShowDialog();
            }




        }

        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                //////////////////////////////////////////////////////////////
                Current_Activity = new Activity();
                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 10;
                Current_Activity.Activity_record_num = Current_Communication.Communication_id;

                //////////////////////////////////////////////////////////
                string filename1 = "aa/" + Current_Communication.Communication_photo1 + ".jpg";
                string filename2 = "aa/" + Current_Communication.Communication_photo2 + ".jpg";
                File.Delete(filename1);
                File.Delete(filename2);
                CommunicationModel.OperarionCommunication(Current_Communication, "Delete");
                Grid_Communication.Remove(Current_Communication);

               
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
        bool CanDelet() => Current_Communication != null && PermissionUser.Delete_opretion == true;
        void Save()
        {//ComboBoxes.Combo_usertype
            Current_Communication.Plate_id = Selected_Plate.Plate_id;
            Current_Communication.User_id = Selected_User.Userid;

            if (IsEditing && CommunicationModel.Check_Exsit(Current_Communication.Communication_id))
            {
                CommunicationModel.OperarionCommunication(Current_Communication, "Update");
                IsEditing = false;
                close();
                string message = "تمت عملية التعديل بنجاح";
                string caption = "عملية التعديل";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 10;
                Current_Activity.Activity_record_num = Current_Communication.Communication_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 2;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }
            else if (IsScaning && CommunicationModel.Check_Exsit(Current_Communication.Communication_id))
            {
                if (win1.RadioButton1.IsChecked == true)
                    Current_Communication.Communication_status = 2;
                else if (win1.RadioButton2.IsChecked == true)
                    Current_Communication.Communication_status = 3;
                else
                    Current_Communication.Communication_status = 1;
                CommunicationModel.OperarionCommunication(Current_Communication, "Scan");
                IsScaning = false;
                close();
                string message = "تمت عملية الفحص بنجاح";
                string caption = "عملية الفحص";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;

                MessageBox.Show(message, caption, buttons, icon);


                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 11;
                Current_Activity.Activity_record_num = Current_Communication.Communication_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 4;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////

            }
            else if (CommunicationModel.Check_Exsit(Current_Communication.Communication_id))
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                // win.textBox_idPlate.Focus();
                //win.textBox_idPlate.SelectionStart = 0;
                //win.textBox_idPlate.SelectionLength = win.textBox_idPlate.Text.Length;
            }
            else
            {
                CommunicationModel.OperarionCommunication(Current_Communication, "Insert");
                Grid_Communication = new ObservableCollection<Communication>();
                Grid_Communication=CommunicationModel.GetCommunication();
                close();
                string message = "تمت عملية الإضافة بنجاح";
                string caption = "عملية الأضافة";
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

                //////////////////////////////////////////////////////////////

                Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                Current_Activity.User_id = Properties.Settings.Default.Userid;
                Current_Activity.Form_id = 10;
                Current_Activity.Activity_record_num = Current_Communication.Communication_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                Current_Activity.Activity_operation_num = 1;
                ActivityModel.OperarionActivity(current_Activity, "Insert");
                ////////////////////////////////////////////////////////////
            }



            //Enable_Grid = false;
        }
        bool CanSave() => Current_Communication != null && !Current_Communication.HasErrors;
        void close()
        {
            Current_Communication = null;
            try
            {
                win.Close();
            }
            catch (Exception e)
            {
                win1.Close();
            }

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
                File.Copy(op.FileName, "aa/photo1" + Current_Communication.Communication_id + ".jpg");
                Current_Communication.Communication_photo1 = "photo1" + Current_Communication.Communication_id;


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

                File.Copy(op1.FileName, "aa/photo2" + Current_Communication.Communication_id + ".jpg");
                Current_Communication.Communication_photo2 = "photo2" + Current_Communication.Communication_id;
            }
        }

        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        public RelayCommand Editcommand { get; private set; }
        public RelayCommand Scancommand { get; private set; }
        public RelayCommand Deletecommand { get; private set; }
        public RelayCommand Savecommand { get; private set; }
        public RelayCommand Closecommand { get; set; }
        public RelayCommand AddPhoto1command { get; set; }
        public RelayCommand AddPhoto2command { get; set; }
        public RelayCommand Addviolationcommand { get; set; }
        #endregion





        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
