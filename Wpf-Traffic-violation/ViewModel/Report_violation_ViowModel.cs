using Microsoft.Reporting.WinForms;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Views.Reports;
using Wpf_Traffic_violation.Views.Reports.Violations;
namespace Wpf_Traffic_violation.ViewModel
{
    public class Report_violation_ViowModel : BindableBase
    {

        #region Objects And Variables
        DataTable dt;
        ReportDataSource ds;
        UserControl_Report_Statistics UserControl_Report_Statistics;
        UserControlviolationReceipt userControlviolationReceipt;
        //UserControl_Report_Violations UserControl_Report_Violations;
        UserControlviolationReceipt userControlviolationReceipt1;
        UserControl_ReportAllViolations UserControl_ReportAllViolations;
        VoilationModel VoilationModel;
        VoilationModel ViolationModel = new VoilationModel();
        ViolationTypeModel ViolationTypeModel;
        Street_Model Street_Model;
        Plate_Model Plate_Model;
        Provinces_Model Provinces_Model;
        Show_Report ShowReport = new Show_Report();

        helper helper;

        #endregion
        #region Proprties
        UserControl curent_usercontrol;
        public UserControl Curent_usercontrol//يربط مع الجرد فيو 
        {
            get
            {
                return curent_usercontrol;
            }
            set
            {
                if (curent_usercontrol != value)
                {
                    curent_usercontrol = value;
                    RaisePropertyChanged("Curent_usercontrol");
                }
            }
        }

        ObservableCollection<ViolationType> grid_violation_typ;
        public ObservableCollection<ViolationType> Grid_violation_typ
        {
            get
            {
                return grid_violation_typ;
            }
            set
            {
                if (grid_violation_typ != value)
                {
                    grid_violation_typ = value;
                    RaisePropertyChanged("Grid_violation_typ");
                }
            }
        }

        ObservableCollection<Streets> grid_streets;
        public ObservableCollection<Streets> Grid_street
        {
            get
            {
                return grid_streets;
            }
            set
            {
                if (grid_streets != value)
                {
                    grid_streets = value;
                    RaisePropertyChanged("Grid_street");
                }
            }
        }

        ObservableCollection<PlateDetails> grid_plate;
        public ObservableCollection<PlateDetails> Grid_plate
        {
            get
            {
                return grid_plate;
            }
            set
            {
                if (grid_plate != value)
                {
                    grid_plate = value;
                    RaisePropertyChanged("Grid_plate");
                }
            }
        }

        ObservableCollection<Provinces> grid_provinces;
        public ObservableCollection<Provinces> Grid_province
        {
            get
            {
                return grid_provinces;
            }
            set
            {
                if (grid_provinces != value)
                {
                    grid_provinces = value;
                    RaisePropertyChanged("Grid_province");
                }
            }
        }

        ViolationType selected_ViolationType;
        public ViolationType Selectes_ViolationType
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
                    RaisePropertyChanged("Selectes_ViolationType");
                }
            }
        }

        Streets selected_Streets;
        public Streets Selected_Streets
        {
            get
            {
                return selected_Streets;
            }
            set
            {
                if (selected_Streets != value)
                {
                    selected_Streets = value;
                    RaisePropertyChanged("Selected_Streets");
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

        bool violation_type;

        public bool Violation_type
        {
            get
            {
                return violation_type;
            }
            set
            {
                if (violation_type != value)
                {
                    violation_type = value;
                    RaisePropertyChanged("Violation_type");
                }
            }
        }

        bool streets;
        public bool Streets
        {
            get
            {
                return streets;
            }
            set
            {
                if (streets != value)
                {
                    streets = value;
                    RaisePropertyChanged("Streets");
                }
            }
        }

        bool plate;
        public bool Plate
        {
            get
            {
                return plate;
            }
            set
            {
                if (plate != value)
                {
                    plate = value;
                    RaisePropertyChanged("Plate");
                }
            }
        }

        bool provinces;
        public bool Provinces
        {
            get
            {
                return provinces;
            }
            set
            {
                if (provinces != value)
                {
                    provinces = value;
                    RaisePropertyChanged("Provinces");
                }
            }
        }

        bool date;
        public bool Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        string from_date;
        public string From_date
        {
            get
            {
                return from_date;
            }
            set
            {
                if (from_date != value)
                {
                    from_date = value;
                    RaisePropertyChanged("From_date");
                }
            }
        }

        string to_date;
        public string To_date
        {
            get
            {
                return to_date;
            }
            set
            {
                if (to_date != value)
                {
                    to_date = value;
                    RaisePropertyChanged("To_date");
                }
            }
        }
        DateTime datetest;
        public DateTime Datetest
        {
            get
            {
                return datetest;
            }
            set
            {
                if (datetest != value)
                {
                    datetest = value;
                    RaisePropertyChanged("To_date");
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

        UserControl viewreport;

        public UserControl Viewreport
        {
            get
            {
                return viewreport;
            }
            set
            {
                if (viewreport != value)
                {
                    viewreport = value;
                    RaisePropertyChanged("viewreport");
                }
            }
        }


        #endregion
        #region Construcor
        public Report_violation_ViowModel()
        {
            helper = new helper();
            Violation_type = true;
            Showcommand1 = new RelayCommand(Par => ShowReport1());
            Showcommand2 = new RelayCommand(Par => ShowReport2());
            Showcommand3 = new RelayCommand(Par => ShowReport3());
            ShowAllViolationcommand = new RelayCommand(Par => Show_allviolation());
            ShowAllViolationcommand_by = new RelayCommand(Par => show_violationByReceiptDetailes());
            userControlviolationReceipt = new UserControlviolationReceipt();
            Grid_plate = new ObservableCollection<PlateDetails>();
            Plate_Model = new Plate_Model();
            //Grid_plate = Plate_Model.GetPlates(); 
            Grid_plate = Plate_Model.GetPlatesDetails();

            //Grid_province = new ObservableCollection<Provinces>();
            //Provinces_Model = new Provinces_Model();
            //Grid_province=Provinces_Model.GetProvinces();

            //Grid_street = new ObservableCollection<Streets>();
            //Street_Model = new Street_Model();
            //Grid_street=Street_Model.GetStreets();

            Grid_violation_typ = new ObservableCollection<ViolationType>();
            ViolationTypeModel = new ViolationTypeModel();
            //= new UserControlviolationReceipt();
            Grid_violation_typ = ViolationTypeModel.GetViolationTypes();

        }

        #endregion
        #region Methodes And Events
        public void ShowReport1()
        {
            UserControl_ReportAllViolations = new UserControl_ReportAllViolations { DataContext = this };
            Curent_usercontrol = UserControl_ReportAllViolations;

        }
        public void ShowReport2()
        {
            UserControl_Report_Statistics = new UserControl_Report_Statistics { DataContext = this };
            Curent_usercontrol = UserControl_Report_Statistics;

        }
        public void ShowReport3()
        {
            userControlviolationReceipt1 = new UserControlviolationReceipt { DataContext = this };
            Curent_usercontrol = userControlviolationReceipt1;
        }
        public void Show_allviolation()
        {
            try
            {
                UserControl_ReportAllViolations UserControl_ReportAllViolations = new UserControl_ReportAllViolations();

                if (To_date == null || To_date == "")
                    To_date = From_date;

                var extraDetailReportModels = new ObservableCollection<ExtraDetailReportModel>();
                var ExtraDetel = new ExtraDetailReportModel();
                var typrviolation = (userControlviolationReceipt.RadioButton_all.IsChecked == true) ? "unPaid" : (userControlviolationReceipt.RadioButton_sub.IsChecked == true) ? "IsPaid" : "All";

                ShowReport = new Show_Report();
                var validationDate = ValidationData(typrviolation, From_date, To_date);
                if (validationDate)
                {
                    //DateTime.Now.ToString("");
                    ExtraDetel.DateNow = System.DateTime.Parse(System.DateTime.Now.ToShortDateString(), CultureInfo.InvariantCulture).ToShortDateString();
                    ExtraDetel.From_date = System.DateTime.Parse(From_date, CultureInfo.InvariantCulture).ToShortDateString();
                    ExtraDetel.To_date = System.DateTime.Parse(To_date, CultureInfo.InvariantCulture).ToShortDateString();
                    extraDetailReportModels.Add(ExtraDetel);
                    var data = ViolationModel.GetAllViolationReport(typrviolation, From_date, To_date);
                    ShowReport.ReportViewerDemo.Reset();
                    //dt = new Class_SqlConnection().GetData("Report_Violation", par);
                    ds = new ReportDataSource("DataSet1", data);
                    ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                    ds = new ReportDataSource("DataSet2", extraDetailReportModels);
                    ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                    System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                    printerSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);
                    printerSettings.DefaultPageSettings.Landscape = true;
                    ShowReport.ReportViewerDemo.SetPageSettings(printerSettings.DefaultPageSettings);
                    ShowReport.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Violations.Report_All_Violation.rdlc";
                    ShowReport.ReportViewerDemo.RefreshReport();
                    ShowReport.Show();
                }
                else
                {
                    MessageBox.Show("Some Data Need To Fill");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                From_date = null;
                To_date = null;
            }


        }
        public void show_violationByReceiptDetailes()
        {
            try
            {
                int sumamount = 0;
                int sumviolationType = 0;

                var extraDetailReportModels = new ObservableCollection<ExtraDetailReportModel>();
                var ExtraDetel = new ExtraDetailReportModel();

                var typrviolation = (userControlviolationReceipt.RadioButton_all.IsChecked == true) ? "unPaid" : (userControlviolationReceipt.RadioButton_sub.IsChecked == true) ? "IsPaid" : "All";
                ShowReport = new Show_Report();
                var validationDate = ValidationData(typrviolation, From_date, To_date);
                if (validationDate)
                {

                    var violations = ViolationModel.GetViolationByReceiptDetailes(From_date, To_date);
                    if (violations != null)
                    {
                        foreach (var item in violations)
                        {
                            sumamount += item.ViolationPenalty;
                            sumviolationType += item.ViolationTypcount;
                        }
                        ExtraDetel.SumViolationTypcount = sumviolationType;
                        ExtraDetel.SumViolationPenaltyCount = sumamount;
                        var date = System.DateTime.Parse(From_date, CultureInfo.InvariantCulture).ToShortDateString();
                        ExtraDetel.From_date = System.DateTime.Parse(From_date, CultureInfo.InvariantCulture).ToShortDateString();//DateTime.ParseExact(DateTime.Now.ToString(),)
                        ExtraDetel.To_date = System.DateTime.Parse(To_date, CultureInfo.InvariantCulture).ToShortDateString();
                        ExtraDetel.DateNow = System.DateTime.Parse(System.DateTime.Now.ToShortDateString(), CultureInfo.InvariantCulture).ToShortDateString();
                        extraDetailReportModels.Add(ExtraDetel);
                        //userControlviolationReceipt.ReportViewerDemo.Reset();
                        ShowReport.ReportViewerDemo.Reset();
                        //Create New Dataset That Content ExtraDetaile for report
                        ds = new ReportDataSource("DataSet1", violations);
                        ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                        ds = new ReportDataSource("DataSet2", extraDetailReportModels);
                        ShowReport.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                        System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                        printerSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom A4", 1027, 1169);
                        printerSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0); // set margins to zero
                        ShowReport.ReportViewerDemo.SetPageSettings(printerSettings.DefaultPageSettings);
                        ShowReport.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Violations.ReportViolationByPayment.rdlc";
                        ShowReport.ReportViewerDemo.RefreshReport();
                        //userControlviolationReceipt.ReportViewerDemo = ShowReport.ReportViewerDemo;
                        ShowReport.Show();

                    }
                    else
                    {
                        MessageBox.Show("لايوجد بيانات");
                    }

                }
                else
                {
                    MessageBox.Show("Some Data Need To Fill");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                From_date = null;
                To_date = null;
            }

        }

        public bool ValidationData(string typrviolation, string from_date, string to_date)
        {
            if (typrviolation != null && (from_date != null))
            {
                return true;
            }
            return false;
        }

        //  public void show_Allviolation
        #endregion
        #region Commands
        public RelayCommand Showcommand1 { get; private set; }
        public RelayCommand Showcommand2 { get; private set; }
        public RelayCommand Showcommand3 { get; private set; }
        public RelayCommand ShowAllViolationcommand_by { get; private set; }
        public RelayCommand ShowAllViolationcommand { get; private set; }
        #endregion










        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
