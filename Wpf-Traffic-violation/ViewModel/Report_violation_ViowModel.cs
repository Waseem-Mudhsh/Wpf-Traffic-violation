using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Views.Reports.Violations;

namespace Wpf_Traffic_violation.ViewModel
{
    public class Report_violation_ViowModel : BindableBase
    {

        #region Objects And Variables
        DataTable dt;
        ReportDataSource ds;
        UserControl_Report_Statistics UserControl_Report_Statistics;
        UserControl_Report_Violations UserControl_Report_Violations;
        UserControl_ReportAllViolations UserControl_ReportAllViolations;
        VoilationModel VoilationModel;
        ViolationTypeModel ViolationTypeModel;
        Street_Model Street_Model;
        Plate_Model Plate_Model;
        Provinces_Model Provinces_Model;


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
        ObservableCollection<Plate> grid_plate;
        public ObservableCollection<Plate> Grid_plate
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









        #endregion
        #region Construcor
       public Report_violation_ViowModel()
        {
            Violation_type = true;
               Showcommand1 = new RelayCommand(Par => ShowReport1());
            Showcommand2 = new RelayCommand(Par => ShowReport2());
            Showcommand3 = new RelayCommand(Par => ShowReport3());
            ShowAllViolationcommand_by = new RelayCommand(Par => Show_allviolation());

            Grid_plate = new ObservableCollection<Plate>();
            Plate_Model = new Plate_Model();
            Plate_Model.GetPlates(Grid_plate);
            
            Grid_province = new ObservableCollection<Provinces>();
            Provinces_Model = new Provinces_Model();
            Provinces_Model.GetProvinces(Grid_province);
         
            Grid_street = new ObservableCollection<Streets>();
            Street_Model = new Street_Model();
            Street_Model.GetStreets(Grid_street);
            
            Grid_violation_typ = new ObservableCollection<ViolationType>();
            ViolationTypeModel = new ViolationTypeModel();
            ViolationTypeModel.GetViolationTypes(Grid_violation_typ);

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
            UserControl_ReportAllViolations = new UserControl_ReportAllViolations { DataContext = this };
            Curent_usercontrol = UserControl_ReportAllViolations;
        }
        public void Show_allviolation()
        {
            SqlParameter[] par = new SqlParameter[5];
            if (Violation_type == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "violationtype"
                };
                par[1] = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = Selectes_ViolationType.Violation_type_id
                };
            }
            if (Streets == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "street"
                };
                par[1] = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = Selected_Streets.Street_id
                };
            }
            if (Plate == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "plat"
                };
                par[1] = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = Selected_Plate.Plate_id
                };
            }
            if (Provinces == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "provinces"
                };
                par[1] = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = Selected_Provinces.Province_id
                };
            }
            if (Date == true)
            {
                par[2] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "fromto"
                };
                par[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = From_date
                };
                par[4] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                {
                    Value = To_date
                };
            } 
            else if (Date == false)
            {
                par[2] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "day"
                };
                par[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = From_date
                };
                par[4] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                {
                    Value = From_date
                };
            }


            UserControl_Report_Statistics.ReportViewerDemo.Reset();
            dt = new Class_SqlConnection().GetData("Report_Violation", par);
            ds = new ReportDataSource("DataSet1", dt);
            UserControl_Report_Statistics.ReportViewerDemo.LocalReport.DataSources.Add(ds);
        

            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            UserControl_Report_Statistics.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            UserControl_Report_Statistics.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Violations.Report_All_Violation.rdlc";
            UserControl_Report_Statistics.ReportViewerDemo.RefreshReport();
            Curent_usercontrol = UserControl_Report_Statistics;

        }
        #endregion
            #region Commands
        public RelayCommand Showcommand1 { get; private set; }
        public RelayCommand Showcommand2 { get; private set; }
        public RelayCommand Showcommand3 { get; private set; }
        public RelayCommand ShowAllViolationcommand_by { get; private set; }
        #endregion










        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
