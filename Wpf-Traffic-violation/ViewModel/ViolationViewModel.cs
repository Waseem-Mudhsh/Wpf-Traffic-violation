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
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Core.helper;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Enum;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Services;
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
        PlateOfType_Model PlateOfType_Model=new PlateOfType_Model();    
        Provinces_Model provinces_Model = new Provinces_Model();    
        Street_Model Street_Model = new Street_Model();
        TrafficmanModel TrafficmanModel = new TrafficmanModel();
        EntryModel EntryModel = new EntryModel();
        PermissionUser PermissionUser;
        OpenFileDialog op1;
        OpenFileDialog op2;
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
                    RaisePropertyChanged("grid_Violation");
                }
            }
        }
        ObservableCollection<Violation> local_CollectionViolation;
        public ObservableCollection<Violation> Local_CollectionViolation//يربط مع الجرد فيو 
        {
            get
            {
                return local_CollectionViolation;
            }
            set
            {
                if (local_CollectionViolation != value)
                {
                    local_CollectionViolation = value;
                    RaisePropertyChanged("local_CollectionViolation");
                }
            }
        }
        Violation current_Violation;
        Violation _current_Violation; //selectedItemيربط مع 

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
        Searchviolation searchviolation;
        public Searchviolation Searchviolation
        {
            get
            {
                return searchviolation;
            }
            set
            {
                if (searchviolation != value)
                {
                    searchviolation = value;
                    RaisePropertyChanged("Searchviolation");
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
        private List<ViolationType> list1 = new List<ViolationType>();
        public List<ViolationType> Listviolation
        {
            get
            {
                return list1;
            }
            set
            {
                if (list1 != value)
                {
                    list1 = value;
                    RaisePropertyChanged("list1");
                }
            }
        }
        private ObservableCollection<ViolationType> selectViolationType=new  ObservableCollection<ViolationType>(); //selectedItemيربط مع 

        public ObservableCollection<ViolationType> SelectViolationType
        {
            get
            {
                return selectViolationType;
            }
            set
            {
                if (selectViolationType != value)
                {
                    selectViolationType = value;
                    RaisePropertyChanged("selectViolationType");
                }
            }
        }
        public void UpdateViolationtype(ObservableCollection<ViolationType> grid_ViolationType)
        {
            for (int index = 0; index < grid_ViolationType.Count; index++)
            {
                var item = grid_ViolationType[index];

                // Perform your operation with 'item' and 'index'
                Listviolation.Add(item);
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
        ObservableCollection<PlateOfType> plate_Types;
        public ObservableCollection<PlateOfType> GridPlateType
        {
            get
            {
                return plate_Types;
            }
            set
            {
                if (plate_Types != value)
                {
                    plate_Types = value;

                    RaisePropertyChanged("GridPlateType");
                }
            }

        }
        ObservableCollection<Provinces> gridProvinces;
        public ObservableCollection<Provinces> GridProvinces
        {
            get
            {
                return gridProvinces;
            }
            set
            {
                if (gridProvinces != value)
                {
                    gridProvinces = value;

                    RaisePropertyChanged("GridProvinces");
                }
            }

        }
        //ObservableCollection<PlateOfType> plate_Types;
        PlateOfType selectedplateOfType;
        public PlateOfType SelectedPlateType
        {
            get
            {
                return selectedplateOfType;
            }
            set
            {
                if (selectedplateOfType != value)
                {
                    selectedplateOfType = value;

                    RaisePropertyChanged("selectedplateOfType");
                }
            }

        }
        Provinces selectedProvinces;
        public Provinces SelectedProvinces
        {
            get
            {
                return selectedProvinces;
            }
            set
            {
                if (selectedProvinces != value)
                {
                    selectedProvinces = value;

                    RaisePropertyChanged("selectedProvinces");
                }
            }

        }

        ObservableCollection<PlateDetails> grid_plateDetails;
        public ObservableCollection<PlateDetails> Grid_plateDetails
        {
            get
            {
                return grid_plateDetails;
            }
            set
            {
                if (grid_plateDetails != value)
                {
                    grid_plateDetails = value;

                    RaisePropertyChanged("grid_plateDetails");
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
        PlateDetails selected_Plates;
        public PlateDetails Selected_Plates
        {
            get
            {
                return selected_Plates;
            }
            set
            {
                if (selected_Plates != value)
                {
                    selected_Plates = value;
                    RaisePropertyChanged("Selected_Plate");
                }
            }
        }
        PlateDetails selected_Province;
        public PlateDetails Selected_Province
        {
            get
            {
                return selected_Province;
            }
            set
            {
                if (selected_Province != value)
                {
                    selected_Province = value;
                    RaisePropertyChanged("selected_Province");
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
        BitmapImage image1;
        public BitmapImage Image1
        {
            get
            {
                return image1;
            }
            set
            {
                if (image1 != value)
                {
                    image1 = value;
                    RaisePropertyChanged("Image1");
                }
            }
        }
        BitmapImage image2;


        public BitmapImage Image2
        {
            get
            {
                return image2;
            }
            set
            {
                if (image2 != value)
                {
                    image2 = value;
                    RaisePropertyChanged("Image2");
                }
            }
        }



        #endregion
        #region Construcor
        public ViolationViewModel()
        {
           
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            asyncViolation();
            asyncGrid();
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //MessageBox.Show($"Total execution time1:{ elapsedMs}");
           
            Addcommand = new RelayCommand(Par => Add(), Par => CanAdd());//This Bind with Button Add
            Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            Savecommand = new RelayCommand(par => Save(), par => CanSave());
            FilterViolation = new RelayCommand(par => Filter() );
            Closecommand = new RelayCommand(par => close());
            Excelcommand = new RelayCommand(par => GetExcel());
            AddPhoto1command = new RelayCommand(par => AddPhoto1());
            AddPhoto2command = new RelayCommand(par => AddPhoto2());
            Current_Activity = new Activity();
        }
      
        #endregion
        #region Methodes And Events
        private async Task asyncViolation()
        {
            Grid_Violation = new ObservableCollection<Violation>();
            Local_CollectionViolation = new ObservableCollection<Violation>();
            Grid_Violation= await Task.Run(()=> ViolationModel.GetViolation());
            foreach (Violation violation in Grid_Violation)
            {
                Local_CollectionViolation.Add(violation);
            }
          

        }
        private async Task asyncGrid()
        {
            GridPlateType= new ObservableCollection<PlateOfType>();
            GridProvinces = new ObservableCollection<Provinces>();
            Grid_ViolationType = new ObservableCollection<ViolationType>();
            Grid_Streets = new ObservableCollection<Streets>();
            Grid_Plate = new ObservableCollection<Plate>();
            Grid_plateDetails = new ObservableCollection<PlateDetails>();
            Grid_TrafficMan = new ObservableCollection<TrafficMan>();
            Grid_Streets = Street_Model.GetStreets();
            Grid_plateDetails = await Task.Run(() => Plate_Model.GetPlatesDetails());
            Grid_ViolationType = await Task.Run(() => ViolationTypeModel.GetViolationType());
            GridPlateType = await Task.Run(() => PlateOfType_Model.GetPlateOfType());
            GridProvinces=await Task.Run(() => provinces_Model.GetProvinces());

           
        }
        public void Add()
        {
            asyncGrid();
            Image1 = new BitmapImage();
            Image2= new BitmapImage();
            Selected_ViolationType = new ViolationType();
            SelectedPlateType = new PlateOfType();
            Selected_Street = new Streets();
            Selected_TrafficMan = new TrafficMan();
            int maxid =1;
            //int maxid = new Class_SqlConnection().Get_Max("Violation");
            Current_Violation = new Violation { Violation_id = maxid };
            win = new Window_AddViolation { DataContext = this };
            win.ShowDialog();
        }
        bool CanAdd() => true;
            //&& PermissionUser.Add_opretion == true;
    void Filter()
        {
              var selscteProvi = SelectedProvinces; 
            var selectedPlate = SelectedPlateType;
            if (Grid_Violation.Count > 0)
            {

                //var serch = Current_Violation.Search;
                var filteredViolations = new ObservableCollection<Violation>(
                        Grid_Violation.Where(x => x.Provinceid == SelectedProvinces.Province_id
                         && x.Plate_id == SelectedPlateType.Plate_type_id));

                // Clear the Grid_Violation collection and add the filtered items back
                Grid_Violation.Clear();
                foreach (var violation in filteredViolations)
                {
                    Grid_Violation.Add(violation);
                    
                }
                if (Grid_Violation.Count <= 0)
                {
                    MessageBox.Show("لايوجد بيانات");
                    asyncViolation();
                  
                }
            }
          
        }
        void Edit()
        {
            
            Current_Violation.New_amount = 0;
            IsEditing = true;
            string filename1 = "Violation/" + Current_Violation.Violation_photo1 + ".jpg";
            string filename2 = "Violation/" + Current_Violation.Violation_photo2 + ".jpg";


            win = new Window_AddViolation { DataContext = this };
            Current_Violation= ViolationModel.GetViolationForEdit( Current_Violation.Violation_id);
          
            win.street.Text = Current_Violation.String_Street;
            win.selectProvince.Text = Convert.ToString( Current_Violation.Provinceid);
            win.viol_type.Text = Current_Violation.Plate_Type;
            win.a.Text = Current_Violation.Plate_Num;
            win.MultiSelectCombobox.Text = Current_Violation.String_ViolationType;

            try { 
            //BitmapImage image1 = new BitmapImage();
            //image1.BeginInit();
            //image1.CacheOption = BitmapCacheOption.OnLoad;
            //image1.UriSource = new Uri(filename1, UriKind.Relative);
            //image1.EndInit();
            //Image1 = image1;
            }
            catch (Exception e)
            {
                filename1 = @"../Wpf-Traffic-violation\Wpf-Traffic-violation\Assets\car_64px.png";
                BitmapImage image1 = new BitmapImage();
                image1.BeginInit();
                image1.CacheOption = BitmapCacheOption.OnLoad;
                image1.UriSource = new Uri(filename1, UriKind.Relative);
                image1.EndInit();
                win.logo1.Source = image1;
            }
            try {
            //BitmapImage image2 = new BitmapImage();
            //image2.BeginInit();
            //image2.CacheOption = BitmapCacheOption.OnLoad;
            //image2.UriSource = new Uri(filename2, UriKind.Relative);
            //image2.EndInit();
            //Image2 = image2;
            win.ShowDialog();
            }
            catch (Exception e)
            {
                filename2 = @"D:\level 5\ادارة المرور\المشروع\المشروع\نسخة 20_9_2020\Wpf-Traffic-violation\Wpf-Traffic-violation\Assets\car_64px.png";
                BitmapImage image2 = new BitmapImage();
                image2.BeginInit();
                image2.CacheOption = BitmapCacheOption.OnLoad;
                image2.UriSource = new Uri(filename2, UriKind.Relative);
                image2.EndInit();
                win.logo2.Source = image2;
                win.ShowDialog();

            }


        }
        bool CanEdit() => true;
            //Current_Violation != null && PermissionUser.Update_opretion == true;
        void Delet()
        {
            string message = "هل تريد الحذف ؟";
            string caption = "تأكيد";
            MessageBoxButton buttons = MessageBoxButton.YesNo;

            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                //foreach (Plate a in Grid_Plate)
                //{
                //    if (a.Plate_id == Current_Violation.Plate_id)
                //        Selected_Plate = a;
                //}
                //string filename1 = "Violation/" + Current_Violation.Violation_photo1 + ".jpg";
                //string filename2 = "Violation/" + Current_Violation.Violation_photo2 + ".jpg";
                //File.Delete(filename1);
                //File.Delete(filename2);
                //MessageBox.Show(Selected_Plate.Account_id.ToString());
                //MessageBox.Show(Current_Violation.Violation_date);

                //////////////////////////////////////////////////////////////

                //Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
                //Current_Activity.Activity_date = DateTime.Now.Date.ToString();
                //Current_Activity.User_id = Properties.Settings.Default.Userid;
                //Current_Activity.Form_id = 1;
                //Current_Activity.Activity_record_num = Current_Violation.Violation_id;

                //////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                //Current_Activity.Activity_operation_num = 3;
                //ActivityModel.OperarionActivity(current_Activity,"Insert");
                ////////////////////////////////////////////////////////////

                ViolationModel.ExcutOperarionViolation(Current_Violation, (int)OperationEnum.DeleteOperation);
                //EntryModel.DeleteEntry(Selected_Plate.Account_id, 345, Current_Violation.Violation_date);
                Grid_Violation.Remove(Current_Violation);
            }
            else
            {
                return;
            }

        }
        bool CanDelet() => true;
            //Current_Violation != null && PermissionUser.Delete_opretion == true;

        void Save()
        {
            Current_Violation.CreatedBy= Properties.Settings.Default.Userid;
            Current_Violation.CreatedOn = DateTime.Now.Date.ToString();
            Current_Violation.Violation_type_id = Selected_ViolationType.Violation_type_id;
            //Current_Violation.Plate_id = 1; 
            Current_Violation.Plate_id = SelectedPlateType.Plate_type_id;
            Current_Violation.Provinceid = SelectedProvinces.Province_id;
            Current_Violation.Street_id = Selected_Street.Street_id;
            //Current_Violation.Street_id =4;
            Current_Violation.Violation_penalty = Selected_ViolationType.Maximum_price;

            bool isExist = false;
          
            
            if (IsEditing && isExist)
                {

                if (op1 != null)
                {
                    File.Delete("Violation/photo1" + Current_Violation.Violation_id + ".jpg");
                    File.Copy(op1.FileName, "Violation/photo1" + Current_Violation.Violation_id + ".jpg");
                    Current_Violation.Violation_photo1 = Convert.ToByte("photo1" + Current_Violation.Violation_id);
                    op1 = null;
                }
                else
                {
                    Current_Violation.Violation_photo1 = Convert.ToByte("-");
                }

                if (op2 != null)
                {
                    File.Delete("Violation/photo2" + Current_Violation.Violation_id + ".jpg");
                    File.Copy(op2.FileName, "Violation/photo2" + Current_Violation.Violation_id + ".jpg");
                    Current_Violation.Violation_photo2 = Convert.ToByte("photo2" + Current_Violation.Violation_id);
                    op2 = null;
                }
                else
                {

                    Current_Violation.Violation_photo2 = Convert.ToByte("-");
                }


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
                     asyncViolation();
                close();
                }

            else if (isExist)
            {
                string message = "رقم المستخدم موجود مسبقا";
                string caption = "رسالة خطا";
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBox.Show(message, caption, buttons, icon);

            }
            else
                {

                //if (op1 != null)
                //{
                //    File.Delete("Violation/photo1" + Current_Violation.Violation_id + ".jpg");
                //    File.Copy(op1.FileName, "Violation/photo1" + Current_Violation.Violation_id + ".jpg");
                //    Current_Violation.Violation_photo1 = Convert.ToByte("photo1" + Current_Violation.Violation_id);
                //    op1 = null;
                //}
                //else
                //{
                //    Current_Violation.Violation_photo1 = Convert.ToByte("-");
                //}


                //if (op2 != null)
                //{
                //    File.Delete("Violation/photo2" + Current_Violation.Violation_id + ".jpg");
                //    File.Copy(op2.FileName, "Violation/photo2" + Current_Violation.Violation_id + ".jpg");
                //    Current_Violation.Violation_photo2 =Convert.ToByte( "photo2" + Current_Violation.Violation_id);
                //    op2 = null;
                //}
                //else
                //{

                //    Current_Violation.Violation_photo2 = Convert.ToByte("-");
                //}

                    OperationEnum operationEnum = OperationEnum.insertOperation;
                    if (ViolationModel.ExcutOperarionViolation(Current_Violation,(int) operationEnum))
                {
                    string message = "تمت عملية الإضافة بنجاح";
                    string caption = "عملية الإضافة";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                    asyncViolation();

                }
                        asyncViolation();
               
                    close();
                    //string message = "تمت عملية الإضافة بنجاح";
                    //string caption = "عملية الإضافة";
                    //MessageBoxImage icon = MessageBoxImage.Information;
                    //MessageBoxButton buttons = MessageBoxButton.OK;
                    //MessageBox.Show(message, caption, buttons, icon);

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

          var isSave=  ViolationModel.GetExcel(Grid_Violation);

            Grid_Violation = new ObservableCollection<Violation>();
            Grid_Violation= ViolationModel.GetViolation();
        }
        void AddPhoto1()
        {
             op1 = new OpenFileDialog();
            op1.Title = "Select a picture";
            op1.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op1.ShowDialog() == true)
            {
                Image1 = null;
                Image1 = new BitmapImage(new Uri(op1.FileName));
               
            }
           
        }

        void AddPhoto2()
        {
             op2 = new OpenFileDialog();
            op2.Title = "Select a picture";
            op2.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op2.ShowDialog() == true)
            {
                Image2 = null;
                Image2 = new BitmapImage(new Uri(op2.FileName));

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
        public RelayCommand FilterViolation { get; set; }

        #endregion






        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
