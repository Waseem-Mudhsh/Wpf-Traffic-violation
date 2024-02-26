using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Views;
using Wpf_Traffic_violation.Views.Reports;
using Plate = Wpf_Traffic_violation.Models.Configurations_Model.Plate;
using Receipt = Wpf_Traffic_violation.Models.Receipt;
using Vehicle = Wpf_Traffic_violation.Models.Vehicle;
using Violation = Wpf_Traffic_violation.Models.Violations_Model.Violation;

namespace Wpf_Traffic_violation.ViewModel
{
    public class QureyIdNumber_ViewModel : BindableBase
    {
        #region Objects And Variables

        Models.ViolationTypeModel violationTypeModel = new ViolationTypeModel();
        PlateOfType_Model PlateOfType_Model = new PlateOfType_Model();
        Provinces_Model provinces_Model = new Provinces_Model();
        QureyIdNumberModel QureyIdNumberModel = new QureyIdNumberModel();
        Street_Model Street_Model = new Street_Model();
        Plate_Model Plate_Model = new Plate_Model();
        Window_PayViolation win;
        ReceiptWindow receiptWindow;
        ReceiptModel ReceiptModel;
        VoilationModel VoilationModel;
        EntryModel EntryModel = new EntryModel();
        helper _helper;
        #endregion
        #region Proprties
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

        ObservableCollection<Violation> grid_Violation1;
        public ObservableCollection<Violation> Grid_Violation1 //يربط مع الجرد فيو 
        {
            get
            {
                return grid_Violation1;
            }
            set
            {
                if (grid_Violation1 != value)
                {
                    grid_Violation1 = value;
                    RaisePropertyChanged("Grid_Violation1");
                }
            }
        }
        ObservableCollection<Violation> grid_Violation;
        public ObservableCollection<Violation> Grid_Violation //يربط مع الجرد فيو 
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

        Violation searchViolation; //selectedItemيربط مع 
        public Violation SearchViolation
        {
            get
            {
                return searchViolation;
            }
            set
            {
                if (searchViolation != value)
                {
                    searchViolation = value;

                    RaisePropertyChanged("searchViolation");
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

        public string nameOfPaid;
        public string NameOfPaid
        {
            get
            {
                return nameOfPaid;
            }
            set
            {
                if (nameOfPaid != value)
                {
                    nameOfPaid = value;
                    RaisePropertyChanged("nameOfPaid");
                }
            }

        }
        public string resonOfPaid;
        public string ResonOfPaid
        {
            get
            {
                return resonOfPaid;
            }
            set
            {
                if (resonOfPaid != value)
                {
                    resonOfPaid = value;
                    RaisePropertyChanged("resonOfPaid");
                }
            }

        }


        int count; //selectedItemيربط مع 
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (count != value)
                {
                    count = value;
                    RaisePropertyChanged("Count");
                }
            }
        }
        int amountSelected;
        public int AmountSelected
        {
            get
            {
                return amountSelected;
            }
            set
            {
                if (amountSelected != value)
                {
                    amountSelected = value;
                    RaisePropertyChanged("AmountSelected");
                }
            }
        }
        int discontAmnt;
        public int DiscontAmnt
        {
            get
            {
                return discontAmnt;
            }
            set
            {
                if (discontAmnt != value)
                {
                    discontAmnt = value;
                    RaisePropertyChanged("DiscontAmnt");
                }
            }
        }

        int totalAmount; //selectedItemيربط مع 
        public int TotalAmount
        {

            get
            {
                return totalAmount;
            }
            set
            {
                if (totalAmount != value)
                {
                    totalAmount = value;
                    RaisePropertyChanged("TotalAmount");
                }
            }
        }
        Vehicle currunt_Vehicle;
        public Vehicle Currunt_Vehicle
        {
            get
            {
                return currunt_Vehicle;
            }
            set
            {
                if (currunt_Vehicle != value)
                {
                    currunt_Vehicle = value;
                    RaisePropertyChanged("Currunt_Vehicle");
                }
            }
        }
        ObservableCollection<PlateDetails> grid_Plate;
        public ObservableCollection<PlateDetails> Grid_Plate //يربط مع الجرد فيو 
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
        Plate selected_Plate; //selectedItemيربط مع 

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
        ObservableCollection<ReceiptPrintModel> _reciptPrintModel;
        public ObservableCollection<ReceiptPrintModel> ReciptPrintData
        {
            get
            {
                return _reciptPrintModel;
            }
            set
            {
                if (_reciptPrintModel != value)
                {
                    _reciptPrintModel = value;
                    RaisePropertyChanged("_reciptPrintModel");
                }
            }
        }


        int cuontviolation_selected;
        public int Cuontviolation_selected
        {
            get
            {
                return cuontviolation_selected;
            }
            set
            {
                if (cuontviolation_selected != value)
                {
                    cuontviolation_selected = value;
                    RaisePropertyChanged("Cuontviolation_selected");
                }
            }
        }
        //private bool _selectAll;

        //public bool SelectAll
        //{
        //    get { return _selectAll; }
        //    set
        //    {
        //        if (_selectAll != value)
        //        {
        //            _selectAll = value;
        //            RaisePropertyChanged(nameof(SelectAll));

        //            // Set the IsSelected property for all items in your collection
        //            foreach (Violation item in Grid_Violation)
        //            {
        //                item.Isselected = value;
        //            }
        //        }
        //    }
        //}

        Receipt current_Receipt;


        public Receipt Current_Receipt
        {
            get
            {
                return current_Receipt;
            }
            set
            {
                if (current_Receipt != value)
                {
                    current_Receipt = value;
                    RaisePropertyChanged("Current_Receipt");
                }
            }
        }

        #endregion
        #region Construcor
        public QureyIdNumber_ViewModel()
        {
            _helper = new helper();
            asyncQureyIdNumber();
            SelectedAll = new RelayCommand(Par => SeelctedAll(), Par => true);
            Showcommand = new RelayCommand(Par => Show(), Par => CanShow());
            Paycommand = new RelayCommand(Par => Pay(), Par => CanPay());
            ConfimPaycommand = new RelayCommand(Par => Confimpay(1), Par => CanConfimpay());
            ShowDetaileForViolation = new RelayCommand(Par => Confimpay(2), Par => true);
            ShowDetaileForViolationNull = new RelayCommand(Par => Confimpay(3), Par => true);
            //Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            //Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            //Savecommand = new RelayCommand(par => Save(), par => CanSave());
            //Closecommand = new RelayCommand(par => close());
            //Excelcommand = new RelayCommand(par => GetExcel());

        }
        #endregion
        #region Methodes And Events
        async Task asyncQureyIdNumber()
        {
            GridPlateType = new ObservableCollection<PlateOfType>();
            GridProvinces = new ObservableCollection<Provinces>();
            Grid_ViolationType = await Task.Run(() => violationTypeModel.GetViolationType());
            Current_Violation = new Violation { Violation_id = 0, Plate_Num = "" };
            SearchViolation = new Violation();
            GridPlateType = await Task.Run(() => PlateOfType_Model.GetPlateOfType());
            Grid_Plate = new ObservableCollection<PlateDetails>();
            GridProvinces = await Task.Run(() => provinces_Model.GetProvinces());
            Grid_Plate = await Task.Run(() => Plate_Model.GetPlatesDetails());
            Grid_Streets = Street_Model.GetStreets();


        }

        async Task Show()
        {
            AmountSelected = 0;
            if (SelectedProvinces == null || SelectedPlateType == null || Current_Violation.Plate_Num == null)
            {
                MessageBox.Show("يجب تحديد رقم اللوحة و نوع اللوحة ورمز المحافظة لتتمكن من البحث بشكل اسرع😊");
            }
            else
            {
                Current_Violation.Provinceid = SelectedProvinces.Province_id;
                Current_Violation.Plate_TypeId = SelectedPlateType.Plate_type_id;
                TotalAmount = 0;
                //Currunt_Vehicle = new Vehicle();
                //Currunt_Vehicle= await Task.Run(() => QureyIdNumberModel.GetVehicleCard( Selected_Plate.Plate_id));
                Grid_Violation = new ObservableCollection<Violation>();
                Grid_Violation = await Task.Run(() => QureyIdNumberModel.GetViolationQurey(Current_Violation));


                if (Grid_Violation.Count <= 0)
                {
                    MessageBox.Show("لايوجد بيانات");
                }

                Count = Grid_Violation.Count;
                foreach (Violation a in Grid_Violation)
                {

                    TotalAmount += a.Violation_penalty;
                    a.Isselected = true;

                }
            }





        }
        void SeelctedAll()
        {
            // Set the IsSelected property for all items in your collection
            foreach (Violation item in Grid_Violation)
            {
                item.Isselected = true;
            }

        }
        bool CanShow() => true;

        void Pay()
        {
            //AmountSelected = 0;
            //Cuontviolation_selected = 0;
            //Grid_Violation1 = new ObservableCollection<Violation>();
            //foreach (Violation a in Grid_Violation)
            //{
            //    if (a.Isselected == true)
            //    {
            //        Grid_Violation1.Add(a);
            //        Cuontviolation_selected += 1;
            //        AmountSelected += a.Violation_penalty;
            //    }
            //}
            //Current_Receipt = new Receipt
            //{
            //    Account_id = 1,
            //    Receipt_amount = AmountSelected,
            //    Receipt_amountwithdiscont = (AmountSelected - discontAmnt),
            //    Receipt_status = false,
            //    Receipt_date = DateTime.Now.ToString(),
            //    Post_date = ""

            //};
            ////Update Amount Selected With Discount to Appeare On Window_PayViolation Win
            //AmountSelected = (AmountSelected - discontAmnt);
            prepareviolation();
            win = new Window_PayViolation { DataContext = this };
            win.datep.Text = DateTime.Now.ToString();
            win.butn_pay.IsEnabled = true;
            //MessageBox.Show(date.Date.ToString());
            if (Cuontviolation_selected > 0)
                win.ShowDialog();

        }

        public void prepareviolation()
        {
            AmountSelected = 0;
            Cuontviolation_selected = 0;
            Grid_Violation1 = new ObservableCollection<Violation>();
            if (Grid_Violation != null)
            {
                foreach (Violation a in Grid_Violation)
                {
                    if (a.Isselected == true)
                    {
                        Grid_Violation1.Add(a);
                        Cuontviolation_selected += 1;
                        AmountSelected += a.Violation_penalty;
                    }
                }
                Current_Receipt = new Receipt
                {
                    Account_id = 1,
                    Receipt_amount = AmountSelected,
                    Receipt_amountwithdiscont = (AmountSelected - discontAmnt),
                    Receipt_status = false,
                    Receipt_date = DateTime.Now.ToString(),
                    Post_date = ""

                };
                //Update Amount Selected With Discount to Appeare On Window_PayViolation Win
                AmountSelected = (AmountSelected - discontAmnt);

            }

        }
        bool CanPay() => Current_Violation != null;

        public void Confimpay(int action)
        {

            ObservableCollection<Violation> result = new ObservableCollection<Violation>();
            prepareviolation();

            if (Cuontviolation_selected > 0)
            {
                result = Grid_Violation1;

            }
            int x = 1;
            if (action == 1)
            {
                if (string.IsNullOrEmpty(NameOfPaid))
                {
                    MessageBox.Show("يرجى ادخال بيانات الدافع");
                    Pay();
                }
                else
                {
                    var ReciptPrint = new ReceiptPrintModel();
                    ReceiptModel = new ReceiptModel();
                    ///Add Detaile for receipt
                    Current_Receipt.NameOfPaid = NameOfPaid;
                    Current_Receipt.ResonOfPaid = ResonOfPaid;
                    Current_Receipt.Receipt_amountwithdiscont = (AmountSelected - DiscontAmnt);
                    VoilationModel = new VoilationModel();
                    var receiptid = ReceiptModel.CreateReceipt(Current_Receipt, Count);
                    if (receiptid.Receipt_id != 0)
                    {
                        foreach (Violation v in Grid_Violation1)
                        {
                            //amount = v.Amount + v.Violation_penalty;

                            var isCreated = ReceiptModel.OperarionReceiptdetail(x, receiptid.Receipt_id, v.String_ViolationType, v.Violation_id, v.Amount, NameOfPaid, ResonOfPaid, AmountSelected);


                            if (isCreated.Receipt_detail_id != 0 || isCreated.Receipt_detail_id != null)
                            {
                                ReciptPrint.NameOfPaid = isCreated.NameOfPaid;
                                ReciptPrint.ReasonOfPaid = isCreated.ResonOfPaid;
                                ReciptPrint.VehicleId = result.FirstOrDefault().Plate_Num;//Convert.ToInt32(v.Plate_Num);
                                ReciptPrint.ReceiptId = receiptid.Receipt_id;
                                ReciptPrint.ViolationPenalty = (int)isCreated.Receipt_amountwithdiscont;
                                ReciptPrint.DateOfReceipt = DateTime.Now.ToString("dd/mm/yyyy");
                                foreach (var type in Grid_ViolationType)
                                {
                                    if (type.Violation_type_id == v.Violation_type_id)
                                    {
                                        ReciptPrint.ViolationType.Add(new KeyValuePair<string, int>(type.Violation_type_name, type.Maximum_price));
                                        break;
                                    }

                                }

                                v.Payment_status = 1;
                                //VoilationModel.OperarionViolation(v, "Update");
                                VoilationModel.updateVilation(v.Violation_id);
                            }
                            x++;
                        }
                        if (receiptid.Receipt_id != 0)
                        {
                            ObservableCollection<ReceiptPrintModel> model = new ObservableCollection<ReceiptPrintModel>();

                            ReciptPrint.CountOfType = ReciptPrint.ViolationType.Count;
                            ReciptPrint.ViolationPenalty = AmountSelected;
                            ReciptPrint.DateOfReceipt = DateTime.Now.ToString("dd/mm/yyyy");
                            ReciptPrint.VounchrNum = (int)result.FirstOrDefault()?.VounchrNum;
                            ReciptPrint.To = (DateTime.Now).AddDays(-30).ToString();
                            ReciptPrint.VehicleTypeName = (string)result.FirstOrDefault()?.Plate_Type + "/" + Convert.ToString(result.FirstOrDefault()?.Provinceid);
                            model.Add(ReciptPrint);
                            Show_Report ShowReport = new Show_Report();
                            ReportDataSource ds;
                            ShowReport.ReportViewerDemo.Reset();
                            ds = new ReportDataSource("DataSetRecipt", model);
                            ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                            printerSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);
                            //printerSettings.DefaultPageSettings.Landscape = true;
                            ShowReport.ReportViewerDemo.SetPageSettings(printerSettings.DefaultPageSettings);
                            ShowReport.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Violations.Recipt_Print.rdlc";
                            ShowReport.ReportViewerDemo.RefreshReport();
                            ShowReport.Show();

                        }
                        MessageBox.Show("تمت عملية السداد بنجاح");
                        win.Close();
                        Grid_Violation.Clear();
                    }
                    else
                    {
                        MessageBox.Show("هناك مشكله في انشاء السند");
                        win.Close();

                    }
                }

            }
            else
            {
                RrivewViolation rrivewViolation = new RrivewViolation
                {
                    DateReview = Convert.ToString(DateTime.Now),
                    vehicleId = Convert.ToInt32(Current_Violation.Plate_Num),
                    violationprov = Convert.ToString(SelectedProvinces.Province_id),
                    violationType = SelectedPlateType.Plate_type_name,
                };
                var GetReviewOfplate = Plate_Model.GetReviewOfplate(rrivewViolation);
                if (GetReviewOfplate != null)
                {
                    if (MessageBox.Show("تم طباعة الافادة سابقا بتاريخ " + GetReviewOfplate.DateReview + "اذا اردت اعادة طباعة الافادة اضغط Yes ",
                      "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        reviewViolationRecipt(result);
                    }
                    else
                    {
                        //close the window 
                    }

                }
            }
            Grid_Violation1 = null;

        }
        public void reviewViolationRecipt(ObservableCollection<Violation> result)
        {
            var ReciptPrint = new ReceiptPrintModel();
            ReportDataSource ds;
            ObservableCollection<ReceiptPrintModel> model = new ObservableCollection<ReceiptPrintModel>();
            Show_Report ShowReport = new Show_Report();
            System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();

            if (Grid_Violation1.Count <= 0)
            {
                ReciptPrint.VehicleTypeName = SelectedPlateType.Plate_type_name + "/" + Convert.ToString(SelectedProvinces.Province_id);
                ReciptPrint.VehicleId = Current_Violation.Plate_Num;
                model.Add(ReciptPrint);
                ShowReport.ReportViewerDemo.Reset();
                ds = new ReportDataSource("DataSetViolation", result);
                ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                ds = new ReportDataSource("DataSetReport", model);
                ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                printerSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);
                printerSettings.DefaultPageSettings.Landscape = true;
                ShowReport.ReportViewerDemo.SetPageSettings(printerSettings.DefaultPageSettings);
                ShowReport.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Violations.ReviewViolationsReportNull.rdlc";
                ShowReport.ReportViewerDemo.RefreshReport();
                ShowReport.Show();

            }
            else
            {
                foreach (Violation v in Grid_Violation1)
                {

                    foreach (var type in Grid_ViolationType)
                    {
                        if (type.Violation_type_id == v.Violation_type_id)
                        {
                            ReciptPrint.ViolationType.Add(new KeyValuePair<string, int>(type.Violation_type_name, type.Maximum_price));
                            break;
                        }

                    }
                }
                var dataTableForViolationtype = new ObservableCollection<ViolationType>();
                var violationsTypeSelected = new List<KeyValuePair<string, int>>();
                ReciptPrint.ViolationPenalty = AmountSelected;
                ReciptPrint.DateOfReceipt = DateTime.Now.ToString();
                ReciptPrint.CountOfType = ReciptPrint.ViolationType.Count;
                ReciptPrint.VounchrNum = (int)result.FirstOrDefault()?.VounchrNum;
                ReciptPrint.To = (DateTime.Now).AddDays(-30).ToString();
                ReciptPrint.VehicleTypeName = (string)result.FirstOrDefault()?.Plate_Type + "/" + Convert.ToString(result.FirstOrDefault()?.Provinceid);
                //ObservableCollection<ReceiptPrintModel> model = new ObservableCollection<ReceiptPrintModel>();
                model.Add(ReciptPrint);
                //Show_Report ShowReport = new Show_Report();
                //ReportDataSource ds;
                ShowReport.ReportViewerDemo.Reset();
                ds = new ReportDataSource("DataSetViolation", result);
                ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                ds = new ReportDataSource("DataSetReport", model);
                ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);

                //System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                printerSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);
                printerSettings.DefaultPageSettings.Landscape = true;
                ShowReport.ReportViewerDemo.SetPageSettings(printerSettings.DefaultPageSettings);
                ShowReport.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Violations.ReviewViolationsReport.rdlc";
                ShowReport.ReportViewerDemo.RefreshReport();
                ShowReport.Show();


            }

        }
        bool CanConfimpay() => true;
        //Current_Receipt != null;

        //private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    foreach (var item in Grid_Violation)
        //    {
        //        // Set the IsSelected property of each item to true
        //        item.Isselected = true;
        //    }
        //}

        //private void SelectAllCheckBox_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    foreach (var item in Grid_Violation)
        //    {
        //        // Set the IsSelected property of each item to false
        //        item.Isselected = false;
        //    }
        //}
        #endregion
        #region Commands
        public RelayCommand SelectedAll { get; private set; }
        public RelayCommand Showcommand { get; private set; }
        public RelayCommand Paycommand { get; private set; }
        public RelayCommand changecontrolForButton { get; private set; }
        public RelayCommand ConfimPaycommand { get; private set; }
        public RelayCommand ShowDetaileForViolation { get; private set; }
        public RelayCommand ShowDetaileForViolationNull { get; private set; }
        #endregion





        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
