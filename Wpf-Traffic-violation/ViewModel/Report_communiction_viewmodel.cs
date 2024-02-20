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
using Wpf_Traffic_violation.Views.Reports;
using Wpf_Traffic_violation.Views.Reports.Communications;

namespace Wpf_Traffic_violation.ViewModel
{
   public class Report_communiction_viewmodel : BindableBase
    {



        #region Objects And Variables
        DataTable dt;
        ReportDataSource ds;
        UserControl_Report_allCommunications UserControl_Report_allCommunications;
        CommunicationModel CommunicationModel = new CommunicationModel();
        UserControl_Report_FlaseCommunications UserControl_Report_FlaseCommunications;
        UserControl_Report_RightCommunications UserControl_Report_RightCommunications;
        UserModel UserModel = new UserModel();
        Plate_Model Plate_Model = new Plate_Model();
        Show_Report Show_Report = new Show_Report();

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
        ObservableCollection<Communication> grid_communiction;
        public ObservableCollection<Communication> Grid_communiction
        {
            get
            {
                return grid_communiction;
            }
            set
            {

                if (grid_communiction != value)
                {
                    grid_communiction = value;
                    RaisePropertyChanged("Grid_communiction");
                }
            }
        }
        Communication selected_communiction;
        public Communication Selected_communiction
        {
            get
            {
                return selected_communiction;
            }
            set
            {


            
                if (selected_communiction != value)
                {
                    selected_communiction = value;
                    RaisePropertyChanged("Selected_communiction");
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

        ObservableCollection<User> grid_user;
        public ObservableCollection<User> Grid_user
        {
            get
            {
                return grid_user;
            }
            set
            {
                if (grid_user != value)
                {
                    grid_user = value;
                    RaisePropertyChanged("Grid_user");
                }
            }
        }
        User selected_users;
        public User Selected_users
        {
            get
            {
                return selected_users;
            }
            set
            {
                


                if (selected_users != value)
                {
                    selected_users = value;
                    RaisePropertyChanged("Selected_users");
                }
            }
        }
        bool num_plat;
        public bool Num_plat
        {
            get
            {
                return num_plat;
            }
            set
            {
                if (num_plat != value)
                {
                    num_plat = value;
                    RaisePropertyChanged("Num_plat");
                }
            }
        }
        bool spac_comm;
        public bool Spac_comm
        {
            get
            {
                return spac_comm;
            }
            set
            {
                if (spac_comm != value)
                {
                    spac_comm = value;
                    RaisePropertyChanged("Spac_comm");
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
        bool name_comm;
        public bool Name_comm
        {
            get
            {
                return name_comm;
            }
            set
            {
                if (name_comm != value)
                {
                    name_comm = value;
                    RaisePropertyChanged("Name_comm");
                }
            }
        }
        bool numb_comm;
        public bool Numb_comm
        {
            get
            {
                return numb_comm;
            }
            set
            {
                if (numb_comm != value)
                {
                    numb_comm = value;
                    RaisePropertyChanged("Numb_comm");
                }
            }
        }
        bool day;
        public bool Day
        {
            get
            {
                return day;
            }
            set
            {
                if (day != value)
                {
                    day = value;
                    RaisePropertyChanged("Day");
                }
            }
        }
        bool fromto;
        public bool Fromto
        {
            get
            {
                return fromto;
            }
            set
            {
                if (fromto != value)
                {
                    fromto = value;
                    RaisePropertyChanged("Fromto");
                }
            }
        }
        string from;
        public string From
        {
            get
            {
                return from;
            }
            set
            {
                if (from != value)
                {
                    from = value;
                    RaisePropertyChanged("From");
                }
            }
        }
        string to;
        public string To
        {
            get
            {
                return to;
            }
            set
            {
                if (to != value)
                {
                    to = value;
                    RaisePropertyChanged("To");
                }
            }
        }




        bool date_comm;
        public bool Date_comm
        {
            get
            {
                return date_comm;
            }
            set
            {
                if (date_comm != value)
                {
                    date_comm = value;
                    RaisePropertyChanged("Date_comm");
                }
            }
        }



        #endregion
        #region Construcor
        public Report_communiction_viewmodel()
        {
                   Showcommand1 = new RelayCommand(Par => ShowReport1());
                   Showcommand2 = new RelayCommand(Par => ShowReport2());
                   Showcommand3 = new RelayCommand(Par => ShowReport3());
                   ShowREPORT_allcommuniction = new RelayCommand(Par => show_report_allcommunci());
                   ShowREPORT_false_communction = new RelayCommand(Par => show_false_communiction());
                   close_command = new RelayCommand(Par => close_showreport());
                   ShowREPORT_right_communction = new RelayCommand(Par => show_right_communicton());
                   Grid_user = new ObservableCollection<User>();
                   Grid_user = UserModel.GetUsers();
                   Grid_communiction = new ObservableCollection<Communication>();
            Grid_communiction= CommunicationModel.GetCommunication();
                   Grid_plate = new ObservableCollection<Plate>();
                   Grid_plate=Plate_Model.GetPlates();
                  
                  
                  
                  
        }
        #endregion
        #region Methodes And Events
        public void ShowReport1()
        {
            UserControl_Report_allCommunications = new UserControl_Report_allCommunications { DataContext = this };
            Curent_usercontrol = UserControl_Report_allCommunications;

        }
        public void ShowReport2()
        {
            UserControl_Report_FlaseCommunications = new UserControl_Report_FlaseCommunications { DataContext = this };
            Curent_usercontrol = UserControl_Report_FlaseCommunications;

        }

        public void ShowReport3()
        {
            UserControl_Report_RightCommunications = new UserControl_Report_RightCommunications { DataContext = this };
            Curent_usercontrol = UserControl_Report_RightCommunications;
        }
        public void close_showreport()
        {
            Show_Report.Close();
        }
        public void show_report_allcommunci()
        {
            Show_Report = new Show_Report();

            SqlParameter[] par = new SqlParameter[6];
            if (All == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "All"
                };
                par[1] = new SqlParameter("@name_user", SqlDbType.Int)
                {
                    Value = 0
                };
                par[2] = new SqlParameter("@number_com", SqlDbType.Int)
                {
                    Value = 0
                };
                par[3] = new SqlParameter("@date_com", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par[4] = new SqlParameter("@number_plat", SqlDbType.Int)
                {
                    Value = 0
                };
                par[5] = new SqlParameter("@place_co", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            else if (Name_comm == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "name_us"
                };
                par[1] = new SqlParameter("@name_user", SqlDbType.Int)
                {
                    Value = Selected_users.Userid
                };
                par[2] = new SqlParameter("@number_com", SqlDbType.Int)
                {
                    Value = 0
                };
                par[3] = new SqlParameter("@date_com", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par[4] = new SqlParameter("@number_plat", SqlDbType.Int)
                {
                    Value = 0
                };
                par[5] = new SqlParameter("@place_co", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            else if (Numb_comm == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_co"
                };
                par[1] = new SqlParameter("@name_user", SqlDbType.Int)
                {
                    Value = 0
                };
                par[2] = new SqlParameter("@number_com", SqlDbType.Int)
                {
                    Value = Selected_communiction.Communication_id
                };
                par[3] = new SqlParameter("@date_com", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par[4] = new SqlParameter("@number_plat", SqlDbType.Int)
                {
                    Value = 0
                };
                par[5] = new SqlParameter("@place_co", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            else if (Date_comm == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "date_co"
                };
                par[1] = new SqlParameter("@name_user", SqlDbType.Int)
                {
                    Value = 0
                };
                par[2] = new SqlParameter("@number_com", SqlDbType.Int)
                {
                    Value = 0
                };
                par[3] = new SqlParameter("@date_com", SqlDbType.NVarChar, 50)
                {
                    Value = Selected_communiction.Communication_date
                };
                par[4] = new SqlParameter("@number_plat", SqlDbType.Int)
                {
                    Value = 0
                };
                par[5] = new SqlParameter("@place_co", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            else if (Num_plat == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_co"
                };
                par[1] = new SqlParameter("@name_user", SqlDbType.Int)
                {
                    Value = 0
                };
                par[2] = new SqlParameter("@number_com", SqlDbType.Int)
                {
                    Value = 0
                };
                par[3] = new SqlParameter("@date_com", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par[4] = new SqlParameter("@number_plat", SqlDbType.Int)
                {
                    Value = Selected_plate.Plate_num
                };
                par[5] = new SqlParameter("@place_co", SqlDbType.Int)
                {
                    Value = 0

                };
            }
            else if (Spac_comm == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_co"
                };
                par[1] = new SqlParameter("@name_user", SqlDbType.Int)
                {
                    Value = 0
                };
                par[2] = new SqlParameter("@number_com", SqlDbType.Int)
                {
                    Value = 0
                };
                par[3] = new SqlParameter("@date_com", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par[4] = new SqlParameter("@number_plat", SqlDbType.Int)
                {
                    Value = 0
                };
                par[5] = new SqlParameter("@place_co", SqlDbType.Int)
                {
                    Value = Selected_communiction.Communication_id

                };
            }
            dt = new Class_SqlConnection().GetData("Report_communiction", par);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Communications.Report_all_communiction.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }

        public void show_false_communiction()
        {
            Show_Report = new Show_Report();

            SqlParameter[] par1 = new SqlParameter[5];
            if (All == true)
            {
                par1[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "All"
                };
                par1[4] = new SqlParameter("@comm_num", SqlDbType.NVarChar, 50)
                {
                    Value = 0

                };
                ///
              
            }
            else if (Numb_comm == true)
            {
                par1[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_com"
                };
                par1[4] = new SqlParameter("@comm_num", SqlDbType.NVarChar, 50)
                {
                    Value = Selected_communiction.Communication_id

                };

            }


            if (Fromto == true)
            {
                par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "fromto"
                };
                par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_FlaseCommunications.from.Text.ToString()
                };


            }
            else if (Day == true)
            {
                par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "day"
                };
                par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_FlaseCommunications.date.Text.ToString()
                };
            }
            par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
            {
                Value = UserControl_Report_FlaseCommunications.to.Text.ToString()
            };

            dt = new Class_SqlConnection().GetData("false_communiction", par1);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Communications.Report_false_commuinction.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void show_right_communicton()
        {
            Show_Report = new Show_Report();

            SqlParameter[] par2 = new SqlParameter[5];
            if (All == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "All"
                };
                par2[4] = new SqlParameter("@comm_num", SqlDbType.NVarChar, 50)
                {
                    Value = 0

                };
                ///

            }
            else if (Numb_comm == true)
            {
                par2[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_com"
                };
                par2[4] = new SqlParameter("@comm_num", SqlDbType.NVarChar, 50)
                {
                    Value = Selected_communiction.Communication_id

                };

            }
           
           if (Day == true)
            {
                par2[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "day"
                };
                par2[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_RightCommunications.date.Text.ToString()
                };
            }
           else if (Fromto == true)
            {
                par2[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "fromto"
                };
                par2[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_RightCommunications.from.Text.ToString()
                };


            }
            par2[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
            {
                Value = UserControl_Report_RightCommunications.to.Text.ToString()
            };

            dt = new Class_SqlConnection().GetData("Report_Right_Communications", par2);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Communications.Report_right_commuinction.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();

        }
        #endregion
        #region Commands
        public RelayCommand Showcommand1 { get; private set; }
        public RelayCommand Showcommand2 { get; private set; }
        public RelayCommand Showcommand3 { get; private set; }
        public RelayCommand ShowREPORT_allcommuniction { get; private set; }
        public RelayCommand ShowREPORT_false_communction { get; private set; }
        public RelayCommand ShowREPORT_right_communction { get; private set; }
        public RelayCommand close_command { get; private set; }
        #endregion





        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
