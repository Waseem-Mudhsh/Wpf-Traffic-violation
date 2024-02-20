using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Views.Reports;
using Wpf_Traffic_violation.Views.Reports.Configurations;

namespace Wpf_Traffic_violation.ViewModel
{
  public  class Report_configuration_viewmodel : BindableBase
  {


        #region Objects And Variables
        DataTable dt;
        ReportDataSource ds;
        CitizenModel CitizenModel = new CitizenModel();
        TrafficmanModel TrafficmanModel = new TrafficmanModel();
        UserControl_Report_DataTrafficMan UserControl_Report_DataTrafficMan;
        UserControl_Report_DataCitizen UserControl_Report_DataCitizen;
        UserControl_Report_DataDrivingLicense UserControl_Report_DataDrivingLicense;
        UserControl_Report_DataVehicle UserControl_Report_DataVehicle;
        UserControl_Report_DataPlate UserControl_Report_DataPlate;
        UserControl_Report_Streets UserControl_Report_Streets;
        Show_Report Show_Report = new Show_Report();
        Street_Model Street_Model = new Street_Model();
        Directorate_Model Directorate_Model = new Directorate_Model();


        PlateOfType_Model PlateOfType_Model = new PlateOfType_Model();
        VehicleModel VehicleModel = new VehicleModel();


        DrivingLicense_Model DrivingLicense_Model = new DrivingLicense_Model();
        Provinces_Model Provinces_Model = new Provinces_Model();
        CategoriesOfLicenses_Model CategoriesOfLicenses_Model = new CategoriesOfLicenses_Model();
        Plate_Model Plate_Model = new Plate_Model();
        #endregion
        #region Proprties


        UserControl curent_usercontrol;
        public UserControl Curent_usercontrol
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
        ObservableCollection<Vehicle> grid_vehicle;
        public ObservableCollection<Vehicle> Grid_vehicle
        {
            get
            {
                return grid_vehicle;
            }
            set
            {

                if (grid_vehicle != value)
                {
                    grid_vehicle = value;
                    RaisePropertyChanged("Grid_vehicle");
                }
            }
        }
        ObservableCollection<Streets> grid_streets;
        public ObservableCollection<Streets> Grid_streets
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
                    RaisePropertyChanged("Grid_streets");
                }
            }
        }
        ObservableCollection<Directorate> grid_directore;
        public ObservableCollection<Directorate> Grid_directore
        {
            get
            {
                return grid_directore;
            }
            set
            {
                if (grid_directore != value)
                {
                    grid_directore = value;
                    RaisePropertyChanged("Grid_directore");
                }
            }
        }
        Streets selected_streets;
        public Streets Selected_streets
        {
            get
            {
                return selected_streets;
            }
            set
            {

                if (selected_streets != value)
                {
                    selected_streets = value;
                    RaisePropertyChanged("Selected_streets");
                }
            }
        }
        Directorate selected_directo;
        public Directorate Selected_directo
        {
            get
            {
                return selected_directo;
            }
            set
            {
                if (selected_directo != value)
                {
                    selected_directo = value;
                    RaisePropertyChanged("Selected_directo");
                }
            }
        }



        bool directore;
        public bool Directore
        {
            get
            {
                return directore;
            }
            set
            {
                if (directore != value)
                {
                    directore = value;
                    RaisePropertyChanged(" Directore");
                }
            }
        }


        Vehicle selected_vehicle;
        public Vehicle Selected_vehicle
        {
            get
            {
                return selected_vehicle;
            }
            set
            {



                if (selected_vehicle != value)
                {
                    selected_vehicle = value;
                    RaisePropertyChanged("Selected_vehicle");
                }
            }
        }


        ObservableCollection<Citizen> grid_citizen;
        public ObservableCollection<Citizen> Grid_citizen
        {
            get
            {
                return grid_citizen;
            }
            set
            {
                if (grid_citizen != value)
                {
                    grid_citizen = value;
                    RaisePropertyChanged("Grid_citizen");
                }
            }
        }
        public Citizen Selected_Citizen
        {
            get
            {
                return selected_Citizen;
            }
            set
            {




                if (selected_Citizen != value)
                {
                    selected_Citizen = value;
                    RaisePropertyChanged("Selected_Citizen");
                }
            }
        }
        ObservableCollection<Provinces> grid_provice;
        public ObservableCollection<Provinces> Grid_provice
        {
            get
            {
                return grid_provice;
            }
            set
            {
                if (grid_provice != value)
                {
                    grid_provice = value;
                    RaisePropertyChanged("Grid_provice");
                }
            }
        }
        Provinces selected_province;
        public Provinces Selected_province
        {
            get
            {
                return selected_province;
            }
            set
            {

                if (selected_province != value)
                {
                    selected_province = value;
                    RaisePropertyChanged("Selected_province");
                }
            }
        }
        ObservableCollection<PlateOfType> grid_plate_type;
        public ObservableCollection<PlateOfType> Grid_plate_type
        {
            get
            {
                return grid_plate_type;
            }
            set
            {
                if (grid_plate_type != value)
                {
                    grid_plate_type = value;
                    RaisePropertyChanged("Grid_plate_type");
                }
            }
        }
        PlateOfType selected_platetype;
        public PlateOfType Selected_platetype
        {
            get
            {
                return selected_platetype;
            }
            set
            {



                if (selected_platetype != value)
                {
                    selected_platetype = value;
                    RaisePropertyChanged("Selected_platetype");
                }
            }
        }




        ObservableCollection<TrafficMan> grid_trafficman;
        public ObservableCollection<TrafficMan> Grid_trafficman
        {
            get
            {
                return grid_trafficman;
            }
            set
            {

                if (grid_trafficman != value)
                {
                    grid_trafficman = value;
                    RaisePropertyChanged("Grid_trafficman");
                }
            }
        }


        TrafficMan selectted_traffic_man;
        public TrafficMan Selectted_traffic_man
        {
            get
            {
                return selectted_traffic_man;
            }
            set
            {

                if (selectted_traffic_man != value)
                {
                    selectted_traffic_man = value;
                    RaisePropertyChanged("Selectted_traffic_man");
                }
            }
        }
        ObservableCollection<DrivingLicense> grid_DrivingLicense;
        public ObservableCollection<DrivingLicense> Grid_DrivingLicense
        {
            get
            {
                return grid_DrivingLicense;
            }
            set
            {
                if (grid_DrivingLicense != value)
                {
                    grid_DrivingLicense = value;
                    RaisePropertyChanged("Grid_DrivingLicense");
                }
            }
        }
        DrivingLicense selected_DrivingLicense;
        public DrivingLicense Selected_DrivingLicense
        {
            get
            {
                return selected_DrivingLicense;
            }
            set
            {



                if (selected_DrivingLicense != value)
                {
                    selected_DrivingLicense = value;
                    RaisePropertyChanged("Selected_DrivingLicense");
                }
            }
        }

        ObservableCollection<CategoriesOfLicenses> grid_CategoriesOfLicenses;
        public ObservableCollection<CategoriesOfLicenses> Grid_CategoriesOfLicenses
        {
            get
            {
                return grid_CategoriesOfLicenses;
            }
            set
            {
                if (grid_CategoriesOfLicenses != value)
                {
                    grid_CategoriesOfLicenses = value;
                    RaisePropertyChanged("Grid_CategoriesOfLicenses");
                }
            }
        }
        CategoriesOfLicenses selected_CategoriesOfLicenses;
        public CategoriesOfLicenses Selected_CategoriesOfLicenses
        {
            get
            {
                return selected_CategoriesOfLicenses;
            }
            set
            {



                if (selected_CategoriesOfLicenses != value)
                {
                    selected_CategoriesOfLicenses = value;
                    RaisePropertyChanged("Selected_CategoriesOfLicenses");
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
        Plate selected_plate;
        public Plate Selected_plate
        {
            get
            {
                return selected_plate;
            }
            set
            {


                if (selected_plate != value)
                {
                    selected_plate = value;
                    RaisePropertyChanged("Selected_plate");
                }
            }
        }

        bool decu_veh;
        public bool Decu_veh
        {
            get
            {
                return decu_veh;
            }
            set
            {
                if (decu_veh != value)
                {
                    decu_veh = value;
                    RaisePropertyChanged("Decu_veh");
                }
            }
        }
        bool num_stad;
        public bool Num_stad
        {
            get
            {
                return num_stad;
            }
            set
            {
                if (num_stad != value)
                {
                    num_stad = value;
                    RaisePropertyChanged("Num_stad");
                }
            }
        }
        bool num_engin;
        public bool Num_engin
        {
            get
            {
                return num_engin;
            }
            set
            {
                if (num_engin != value)
                {
                    num_engin = value;
                    RaisePropertyChanged("Num_engin");
                }
            }
        }
        bool num_coust;/// رقم الجمرك
        public bool Num_coust
        {
            get
            {
                return num_coust;
            }
            set
            {
                if (num_coust != value)
                {
                    num_coust = value;
                    RaisePropertyChanged("Num_coust");
                }
            }
        }


        Citizen selected_Citizen;

        bool all_traffic;
        public bool All_traffic
        {
            get
            {
                return all_traffic;
            }
            set
            {
                if (all_traffic != value)
                {
                    all_traffic = value;
                    RaisePropertyChanged("All_traffic");
                }
            }
        }

        bool numb_traffic;
        public bool Numb_traffic
        {
            get
            {
                return numb_traffic;
            }
            set
            {
                if (numb_traffic != value)
                {
                    numb_traffic = value;
                    RaisePropertyChanged("Numb_traffic");
                }
            }
        }

        bool all;
        public bool All
        {
            get
            {
                return all;
            }
            set
            {
                if (all != value)
                {
                    all = value;
                    RaisePropertyChanged("All");
                }
            }
        }
        bool numb_lis;                     /// رقم الرخصه ورقم اللوحه

        public bool Numb_lis
        {
            get
            {
                return numb_lis;
            }
            set
            {
                if (numb_lis != value)
                {
                    numb_lis = value;
                    RaisePropertyChanged("Numb_lis");
                }
            }
        }
        bool name_citiz;          /// اسم المواطن ونوع اللوحه

        public bool Name_citiz
        {
            get
            {
                return name_citiz;
            }
            set
            {
                if (name_citiz != value)
                {
                    name_citiz = value;
                    RaisePropertyChanged("Name_citiz");
                }
            }
        }
        bool date_liss;         /// تاريخ الاصدار 

        public bool Date_liss
        {
            get
            {
                return date_liss;
            }
            set
            {
                if (date_liss != value)
                {
                    date_liss = value;
                    RaisePropertyChanged("Date_liss");
                }
            }
        }





        bool numb_edi;       //رقم القعاده
        public bool Numb_edi
        {
            get
            {
                return numb_edi;
            }
            set
            {
                if (numb_edi != value)
                {
                    numb_edi = value;
                    RaisePropertyChanged("Numb_edi");
                }
            }
        }

        bool type_liss;
        public bool Type_liss
        {
            get
            {
                return type_liss;
            }
            set
            {
                if (type_liss != value)
                {
                    type_liss = value;
                    RaisePropertyChanged("Type_liss");
                }
            }
        }
        bool state_liss;
        public bool State_liss
        {
            get
            {
                return state_liss;
            }
            set
            {
                if (state_liss != value)
                {
                    state_liss = value;
                    RaisePropertyChanged("State_liss");
                }
            }
        }

        bool act;
        public bool Act
        {
            get
            {
                return act;
            }
            set
            {
                if (act != value)
                {
                    act = value;
                    RaisePropertyChanged("Act");
                }
            }
        }

        bool avt_no;
        public bool Act_no
        {
            get
            {
                return avt_no;
            }
            set
            {
                if (avt_no != value)
                {
                    avt_no = value;
                    RaisePropertyChanged("Act_no");
                }
            }
        }
        bool miss;
        public bool Miss
        {
            get
            {
                return miss;
            }
            set
            {
                if (miss != value)
                {
                    miss = value;
                    RaisePropertyChanged("Miss");
                }
            }
        }





        #endregion
        #region Construcor

        public Report_configuration_viewmodel()
        {

             Showcommand1 = new RelayCommand(Par => ShowReport1());
            Showcommand2 = new RelayCommand(Par => ShowReport2());
            Showcommand3 = new RelayCommand(Par => ShowReport3());
            Showcommand4 = new RelayCommand(Par => ShowReport4());
            Showcommand5 = new RelayCommand(Par => ShowReport5());
            Showcommand6 = new RelayCommand(Par => ShowReport6());
            report_citi_command = new RelayCommand(Par => show_report_citizen());
            Report_trafficman = new RelayCommand(Par => show_report_trafficman());
            report_drivindlcience = new RelayCommand(Par => showreport_driving_lis());
            Report_date_plate = new RelayCommand(Par => show_report_data_plate());
            close_command = new RelayCommand(Par => close_showreport());
            Report_vehiclss = new RelayCommand(Par => show_Report_vehicle());
            Repory_streets = new RelayCommand(Par => show_report_streeat());
            Report_violatio_typ = new RelayCommand(Par => show_report_violationtype());
            Report_type_licence = new RelayCommand(Par => show_report_type_licence());
            Report_type_reson = new RelayCommand(Par => show_report_typ_commun());
            Report_directore = new RelayCommand(Par => show_report_directore());

            

            Grid_citizen = new ObservableCollection<Citizen>();
            Grid_CategoriesOfLicenses = new ObservableCollection<CategoriesOfLicenses>();
            Grid_DrivingLicense = new ObservableCollection<DrivingLicense>();
            Grid_trafficman = new ObservableCollection<TrafficMan>();
            Grid_plate = new ObservableCollection<Plate>();
            Grid_plate_type = new ObservableCollection<PlateOfType>();
            Grid_provice = new ObservableCollection<Provinces>();
            Grid_vehicle = new ObservableCollection<Vehicle>();
            Grid_directore = new ObservableCollection<Directorate>();
           // Selected_Citizen = new Citizen();
          //  Grid_streets = new ObservableCollection<Streets>();
            //asyncGrid();
            
          

        }
       
        #endregion
        #region Methodes And Events

        public void ShowReport1()
        {
            Grid_citizen = CitizenModel.GetCitizens();
            UserControl_Report_DataCitizen = new UserControl_Report_DataCitizen { DataContext = this };
            Curent_usercontrol = UserControl_Report_DataCitizen;

        }
        public void ShowReport2()
        {
            Grid_trafficman = TrafficmanModel.GetTrafficMans();
            UserControl_Report_DataTrafficMan = new UserControl_Report_DataTrafficMan { DataContext = this };
            Curent_usercontrol = UserControl_Report_DataTrafficMan;
        }
        public void ShowReport3()
        {
            Grid_DrivingLicense = DrivingLicense_Model.GetDrivingLicenses();
            Grid_CategoriesOfLicenses = CategoriesOfLicenses_Model.GetCategoriesOfLicenses();
            Grid_citizen = CitizenModel.GetCitizens();
            UserControl_Report_DataDrivingLicense = new UserControl_Report_DataDrivingLicense { DataContext = this };
            Curent_usercontrol = UserControl_Report_DataDrivingLicense;
        }
        public void ShowReport4()
        {
            Grid_provice = Provinces_Model.GetProvinces();
            Grid_plate_type = PlateOfType_Model.GetPlateOfType();
            Grid_plate = Plate_Model.GetPlates();
            UserControl_Report_DataPlate = new UserControl_Report_DataPlate { DataContext = this };
            Curent_usercontrol = UserControl_Report_DataPlate;
        }
        public void ShowReport5()
        {
            //async_vehicle();
          
            Grid_vehicle =  VehicleModel.GetVehicles();
            Grid_citizen =  CitizenModel.GetCitizens();

            UserControl_Report_DataVehicle = new UserControl_Report_DataVehicle { DataContext = this };
            Curent_usercontrol = UserControl_Report_DataVehicle;
        }
        async Task async_vehicle()
        {
            Grid_vehicle = await Task.Run(() => VehicleModel.GetVehicles());
            Grid_citizen = await Task.Run(() => CitizenModel.GetCitizens());

        }
        public void ShowReport6()
        {
            Grid_directore = Directorate_Model.GetDirectorate();
            UserControl_Report_Streets = new UserControl_Report_Streets { DataContext = this };
            Curent_usercontrol = UserControl_Report_Streets;
        }
        public void show_report_violationtype()
        {
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير انواع المخالفات";
            dt = new Class_SqlConnection().GetData("GetViolationTypes", null);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_type_violation.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void show_report_type_licence()
        {
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير انواع الرخص";
            dt = new Class_SqlConnection().GetData("GetCategoriesOfLicenses", null);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_type_lisence.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void show_report_typ_commun()
        {
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير اسباب الإعتراضات";
            dt = new Class_SqlConnection().GetData("GetReasonToObjection", null);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_reso_comm.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void show_report_directore()
        {
           // Grid_directore =Directorate_Model.GetDirectorate();
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير المديريات";
            dt = new Class_SqlConnection().GetData("report_get_directore", null);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report1_GetDirectorate.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void close_showreport()
        {
            Show_Report.Close();
        }
        public void show_report_citizen()
        {
          
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير المواطنين";
            Show_Report.ReportViewerDemo.Reset();
            SqlParameter[] par = new SqlParameter[1];
            if (All == true)
            {

                dt = new Class_SqlConnection().GetData("GetCitizens", null);

            }

            else
            {
                par = new SqlParameter[1];
                par[0] = new SqlParameter("@Citizen_id", SqlDbType.Int)
                {
                    Value = Selected_Citizen.Citizen_id
                };

                dt = new Class_SqlConnection().GetData("checkcitizen", par);

            }

            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_citizon.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
            
        }
        public void show_report_trafficman()
        {
            
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير رجال المرور";
            Show_Report.ReportViewerDemo.Reset();
            SqlParameter[] par1 = new SqlParameter[1];
            if (All_traffic == true)
            {

                dt = new Class_SqlConnection().GetData("GetTrafficMans", null);

            }

            else
            {
                par1 = new SqlParameter[1];
                par1[0] = new SqlParameter("@Traffic_man_id", SqlDbType.Int)
                {
                    Value = Selectted_traffic_man.Traffic_man_id
                };

                dt = new Class_SqlConnection().GetData("checkTrafficMan", par1);

            }

            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_traffic_man.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();


        }

        public void showreport_driving_lis()
        {
            
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير الرخص";
            SqlParameter[] par2 = new SqlParameter[6];
            if (All == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "all"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@lis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@lis_typ", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[5] = new SqlParameter("@lis_act", SqlDbType.NVarChar, 50)
                {
                    Value = ""

                };
            }
            if (Numb_lis == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_lis"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@lis_num", SqlDbType.Int)
                {
                    Value = Selected_DrivingLicense.Driving_license_id
                };
                par2[4] = new SqlParameter("@lis_typ", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[5] = new SqlParameter("@lis_act", SqlDbType.NVarChar, 50)
                {
                    Value = ""

                };
            }
            if (Name_citiz == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "name_citz"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = Selected_Citizen.Citizen_id
                };
                par2[3] = new SqlParameter("@lis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@lis_typ", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[5] = new SqlParameter("@lis_act", SqlDbType.NVarChar, 50)
                {
                    Value = ""

                };
            }
            if (Date_liss == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "relase_date"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = Selected_DrivingLicense.Release_date
                };
                par2[2] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@lis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@lis_typ", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[5] = new SqlParameter("@lis_act", SqlDbType.NVarChar, 50)
                {
                    Value = ""

                };
            }
            if (Type_liss == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "typ_lice"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@lis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@lis_typ", SqlDbType.Int)
                {
                    Value = Selected_CategoriesOfLicenses.Class_licence_ID
                };
                par2[5] = new SqlParameter("@lis_act", SqlDbType.NVarChar, 50)
                {
                    Value = ""

                };
            }
            /////////
            if (State_liss == true)
            {

                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "stat_lis"

                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@lis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@lis_typ", SqlDbType.Int)
                {
                    Value = 0
                };
                if (Act == true)
                {
                    par2[5] = new SqlParameter("@lis_act", SqlDbType.NVarChar, 50)
                    {
                        Value = "act"

                    };
                }
                else if (Act_no == true)
                {
                    par2[5] = new SqlParameter("@lis_act", SqlDbType.NVarChar, 50)
                    {
                        Value = "no_act"

                    };
                }
                else if (Miss == true)
                {
                    par2[5] = new SqlParameter("@lis_act", SqlDbType.NVarChar, 50)
                    {
                        Value = "miss_lis"

                    };
                }

            }
            dt = new Class_SqlConnection().GetData("Report_driving_license", par2);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_datadrivinglici.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();







        }
        public void show_report_data_plate()
        {
            
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير اللوحات";
            SqlParameter[] par2 = new SqlParameter[6];
            if (All == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "all"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@plat_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@typ_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@vis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[5] = new SqlParameter("@plate_act", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Numb_lis == true)
            {

                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_plat"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@plat_num", SqlDbType.Int)
                {
                    Value = Selected_plate.Plate_id
                };
                par2[3] = new SqlParameter("@typ_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@vis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[5] = new SqlParameter("@plate_act", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Name_citiz == true)
            {

                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "typ_plat"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@plat_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@typ_num", SqlDbType.Int)
                {
                    Value = Selected_plate.Plate_type
                };
                par2[4] = new SqlParameter("@vis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[5] = new SqlParameter("@plate_act", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Date_liss == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "releas_date"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = Selected_plate.Release_date
                };
                par2[2] = new SqlParameter("@plat_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@typ_num", SqlDbType.Int)
                {
                    Value = Selected_plate.Plate_type
                };
                par2[4] = new SqlParameter("@vis_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[5] = new SqlParameter("@plate_act", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Numb_edi == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_vehi"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@plat_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@typ_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@vis_num", SqlDbType.Int)
                {
                    Value = Selected_plate.Vehicle_id
                };
                par2[5] = new SqlParameter("@plate_act", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            /////////
            if (State_liss == true)
            {

                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "stat_lis"
                };
                par2[1] = new SqlParameter("@date_relas", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par2[2] = new SqlParameter("@plat_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[3] = new SqlParameter("@typ_num", SqlDbType.Int)
                {
                    Value = 0
                };
                par2[4] = new SqlParameter("@vis_num", SqlDbType.Int)
                {
                    Value = 0
                };

            };
            if (Act == true)
            {
                par2[5] = new SqlParameter("@plate_act", SqlDbType.NVarChar, 50)
                {
                    Value = 1

                };
            }
            else if (Act_no == true)
            {
                par2[5] = new SqlParameter("@plate_act", SqlDbType.NVarChar, 50)
                {
                    Value = 2

                };
            }
            else if (Miss == true)
            {
                par2[5] = new SqlParameter("@plate_act", SqlDbType.NVarChar, 50)
                {
                    Value = 3

                };
            }

            dt = new Class_SqlConnection().GetData("Reeport_plate_data", par2);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_show_platedata.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();


        }
        public void show_Report_vehicle()
        {
            
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير المركبات";
            SqlParameter[] par3 = new SqlParameter[7];
            if (All == true)
            {
                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "all"
                };
                par3[1] = new SqlParameter("@citz", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[2] = new SqlParameter("@ve_card", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[3] = new SqlParameter("@pot_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[4] = new SqlParameter("@engi_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[5] = new SqlParameter("@cust_veh", SqlDbType.Int)
                {
                    Value = 0

                };
                par3[6] = new SqlParameter("@rels_veh", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Name_citiz == true)
            {

                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "city_nam"
                };
                par3[1] = new SqlParameter("@citz", SqlDbType.Int)
                {
                    Value = Selected_Citizen.Citizen_id
                };
                par3[2] = new SqlParameter("@ve_card", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[3] = new SqlParameter("@pot_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[4] = new SqlParameter("@engi_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[5] = new SqlParameter("@cust_veh", SqlDbType.Int)
                {
                    Value = 0

                };
                par3[6] = new SqlParameter("@rels_veh", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Decu_veh == true)
            {

                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "decum_veh"
                };
                par3[1] = new SqlParameter("@citz", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[2] = new SqlParameter("@ve_card", SqlDbType.Int)
                {
                    Value = Selected_vehicle.Vehicle_card_id
                };
                par3[3] = new SqlParameter("@pot_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[4] = new SqlParameter("@engi_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[5] = new SqlParameter("@cust_veh", SqlDbType.Int)
                {
                    Value = 0

                };
                par3[6] = new SqlParameter("@rels_veh", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Num_stad == true)
            {
                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "potty_veh"
                };
                par3[1] = new SqlParameter("@citz", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[2] = new SqlParameter("@ve_card", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[3] = new SqlParameter("@pot_veh", SqlDbType.Int)
                {
                    Value = Selected_vehicle.Potty_id
                };
                par3[4] = new SqlParameter("@engi_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[5] = new SqlParameter("@cust_veh", SqlDbType.Int)
                {
                    Value = 0

                };
                par3[6] = new SqlParameter("@rels_veh", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Num_engin == true)
            {
                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "engin_veh"
                };
                par3[1] = new SqlParameter("@citz", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[2] = new SqlParameter("@ve_card", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[3] = new SqlParameter("@pot_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[4] = new SqlParameter("@engi_veh", SqlDbType.Int)
                {
                    Value = Selected_vehicle.Vehicle_engine_num
                };
                par3[5] = new SqlParameter("@cust_veh", SqlDbType.Int)
                {
                    Value = 0

                };
                par3[6] = new SqlParameter("@rels_veh", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Num_coust == true)
            {
                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "cust_veh"
                };
                par3[1] = new SqlParameter("@citz", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[2] = new SqlParameter("@ve_card", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[3] = new SqlParameter("@pot_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[4] = new SqlParameter("@engi_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[5] = new SqlParameter("@cust_veh", SqlDbType.Int)
                {
                    Value = Selected_vehicle.Vehicle_customs_num

                };
                par3[6] = new SqlParameter("@rels_veh", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            if (Date_liss == true)
            {
                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "releas_veh"
                };
                par3[1] = new SqlParameter("@citz", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[2] = new SqlParameter("@ve_card", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[3] = new SqlParameter("@pot_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[4] = new SqlParameter("@engi_veh", SqlDbType.Int)
                {
                    Value = 0
                };
                par3[5] = new SqlParameter("@cust_veh", SqlDbType.Int)
                {
                    Value = Selected_vehicle.Vehicle_customs_num

                };
                par3[6] = new SqlParameter("@rels_veh", SqlDbType.Int)
                {
                    Value = Selected_vehicle.Release_palc_c

                };


            }
            dt = new Class_SqlConnection().GetData("Report_vehicles", par3);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_vehicl_data.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void show_report_streeat()
        {
           //Grid_directore = new ObservableCollection<Directorate>();
               
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير الشوارع";
            SqlParameter[] par4 = new SqlParameter[2];
            if (All == true)
            {
                par4[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "all"
                };

                par4[1] = new SqlParameter("@derct_id", SqlDbType.Int)
                {
                    Value = 0
                };
               // MessageBox.Show("0");
            }
            else if (Directore == true)
            {
                par4[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "name_direct"
                };
                par4[1] = new SqlParameter("@derct_id", SqlDbType.Int)
                {
                    Value = Selected_directo.Directorate_id
                
                };
                //MessageBox.Show("1");
                
            }
            dt = new Class_SqlConnection().GetData("Report_street", par4);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Configurations.Report_streetss.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        #endregion
        #region Commands

        public RelayCommand Showcommand1 { get; private set; }
        public RelayCommand Showcommand2 { get; private set; }
        public RelayCommand Showcommand3 { get; private set; }
        public RelayCommand Showcommand4 { get; private set; }
        public RelayCommand Showcommand5 { get; private set; }
        public RelayCommand Showcommand6 { get; private set; }

        public RelayCommand report_citi_command { get; private set; }
        public RelayCommand close_command { get; private set; }
        public RelayCommand Report_trafficman { get; private set; }
        public RelayCommand Report_date_plate { get; private set; }
        public RelayCommand report_drivindlcience { get; private set; }
        public RelayCommand Report_vehiclss { get; private set; }
        public RelayCommand Repory_streets { get; private set; }
        public RelayCommand Report_violatio_typ { get; private set; }
        public RelayCommand Report_type_licence { get; private set; }
        public RelayCommand Report_type_reson { get; private set; }
        public RelayCommand Report_directore { get; private set; }

        #endregion


        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }

      
    }
}
