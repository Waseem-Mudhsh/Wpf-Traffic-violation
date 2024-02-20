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
using System.Windows.Media;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Views;
using Wpf_Traffic_violation.Views.Reports;
using Wpf_Traffic_violation.Views.Reports.Accounts;
using Wpf_Traffic_violation.Views.Reports.Users;

namespace Wpf_Traffic_violation.ViewModel
{
    public class ReportUser_ViewModel : BindableBase
    {

        #region Objects And Variables
        DataTable dt;
        ReportDataSource ds;
        UserControl_ReportAllUserss UserControl_ReportAllUserss;
        UserControl_ReportOneUser UserControl_ReportOneUser;
        UserControl_ReportUsertraffic UserControl_ReportUsertraffic;
        UserControl_ReportGroups UserControl_ReportGroups;
        UserModel UserModel = new UserModel();
        PermissionSet_Model PermissionSet_Model = new PermissionSet_Model();
        SqlParameter[] par;
        Show_Report Show_Report=new Show_Report();
        #endregion
        #region Proprties

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

        ObservableCollection<PermissionSet> grid_PermissionGroup;
        public ObservableCollection<PermissionSet> Grid_PermissionGroup
        {
            get
            {
                return grid_PermissionGroup;
            }
            set
            {
                if (grid_PermissionGroup != value)
                {
                    grid_PermissionGroup = value;
                    RaisePropertyChanged("Grid_PermissionGroup");
                }
            }
        }

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

        PermissionSet selected_permissiongroup;
        public PermissionSet Selected_permissiongroup
        {
            get
            {
                return selected_permissiongroup;
            }
            set
            {



                if (selected_permissiongroup != value)
                {
                    selected_permissiongroup = value;
                    RaisePropertyChanged("Selected_permissiongroup");
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

        PermissionSet current_permissiongroup;
        public PermissionSet Current_permissiongroup
        {
            get
            {
                return current_permissiongroup;
            }
            set
            {
                if (current_permissiongroup != value)
                {
                    current_permissiongroup = value;
                    RaisePropertyChanged("Current_permissiongroup");
                }
            }
        }

        bool name_user;
        public bool Name_user
        {
            get
            {
                return name_user;
            }
            set
            {
                if (name_user != value)
                {
                    name_user = value;
                    RaisePropertyChanged("Name_user");
                }
            }
        }

        bool num_user;
        public bool Num_user
        {
            get
            {
                return num_user;
            }
            set
            {
                if (num_user != value)
                {
                    num_user = value;
                    RaisePropertyChanged("Num_user");
                }
            }
        }

        bool yes_p;
        public bool Yes_p
        {
            get
            {
                return yes_p;
            }
            set
            {
                if (yes_p != value)
                {
                    yes_p = value;
                    RaisePropertyChanged("Yes_p");
                }
            }
        }

        bool no_p;
        public bool No_p
        {
            get
            {
                return no_p;
            }
            set
            {
                if (no_p != value)
                {
                    no_p = value;
                    RaisePropertyChanged("No_p");
                }
            }
        }

        bool user_search;
        public bool User_search
        {
            get
            {
                return user_search;
            }
            set
            {
                if (user_search != value)
                {
                    user_search = value;
                    RaisePropertyChanged("User_search");
                }
            }
        }

        bool all_search;
        public bool All_search
        {
            get
            {
                return all_search;
            }
            set
            {
                if (all_search != value)
                {
                    all_search = value;
                    RaisePropertyChanged("All_search");
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

        bool one_group;
        public bool One_group
        {
            get
            {
                return one_group;
            }
            set
            {
                if (one_group != value)
                {
                    one_group = value;
                    RaisePropertyChanged("One_group");
                }
            }
        }

        bool all_group;
        public bool All_group
        {
            get
            {
                return all_group;
            }
            set
            {
                if (all_group != value)
                {
                    all_group = value;
                    RaisePropertyChanged("All_group");
                }
            }
        }

        bool active_group;
        public bool Active_group
        {
            get
            {
                return active_group;
            }
            set
            {
                if (active_group != value)
                {
                    active_group = value;
                    RaisePropertyChanged("Active_group");
                }
            }
        }

        bool noactive_group;
        public bool Noactive_group
        {
            get
            {
                return noactive_group;
            }
            set
            {
                if (noactive_group != value)
                {
                    noactive_group = value;
                    RaisePropertyChanged("Noactive_group");
                }
            }
        }

        bool all_active_group;
        public bool All_active_group
        {
            get
            {
                return all_active_group;
            }
            set
            {
                if (all_active_group != value)
                {
                    all_active_group = value;
                    RaisePropertyChanged("All_active_group");
                }
            }
        }

        bool yes_group;
        public bool Yes_group
        {
            get
            {
                return yes_group;
            }
            set
            {
                if (yes_group != value)
                {
                    yes_group = value;
                    RaisePropertyChanged("Yes_group");
                }
            }
        }

        bool no_group;
        public bool No_group
        {
            get
            {
                return no_group;
            }
            set
            {
                if (no_group != value)
                {
                    no_group = value;
                    RaisePropertyChanged("No_group");
                }
            }
        }

        User current_user;
        public User Current_user
        {
            get
            {
                return current_user;
            }
            set
            {
                if (current_user != value)
                {
                    current_user = value;
                    RaisePropertyChanged("Current_user");
                }
            }
        }

        string comb_box;
        public string Comb_box
        {
            get
            {
                return comb_box;
            }
            set
            {
                if (comb_box != value)
                {
                    comb_box = value;
                    RaisePropertyChanged("Comb_box");
                }
            }
        }

        string com_oneuser;
        public string Com_oneuser
        {
            get
            {
                return com_oneuser;
            }
            set
            {
                if (com_oneuser != value)
                {
                    com_oneuser = value;
                    RaisePropertyChanged("Com_oneuser");
                }
            }
        }

        bool active_user;
        public bool Active_user
        {
            get
            {
                return active_user;
            }
            set
            {
                if (active_user != value)
                {
                    active_user = value;
                    RaisePropertyChanged("Active_user");
                }
            }
        }

        bool no_active_user;
        public bool No_active_user
        {
            get
            {
                return no_active_user;
            }
            set
            {
                if (no_active_user != value)
                {
                    no_active_user = value;
                    RaisePropertyChanged("No_active_user");
                }
            }
        }

        User currunt_User; //selectedItemيربط مع 
        public User Currunt_User
        {
            get
            {
                return currunt_User;
            }
            set
            {
                if (currunt_User != value)
                {
                    currunt_User = value;
                    RaisePropertyChanged("Currunt_User");
                }
            }
        }
        #endregion
        #region Construcor
        public ReportUser_ViewModel()
        {
            Grid_user = new ObservableCollection<User>();
            Grid_PermissionGroup = new ObservableCollection<PermissionSet>();

           // asyncReportUser();

            Showcommand1 = new RelayCommand(Par => ShowReport1());
            Showcommand2 = new RelayCommand(Par => ShowReport2());
            Showcommand3 = new RelayCommand(Par => ShowReport3());
            Showcommand4 = new RelayCommand(Par => ShowReport4());
            Show_reportcommand = new RelayCommand(Par => showreport_Alluser());
            Show_report_onecommand = new RelayCommand(par => showreportoneusers());
            Show_report_searchcommand = new RelayCommand(par => showreporsearchusers());
            Show_report_groupcommand = new RelayCommand(par => showreporgroup());

            Grid_user = new ObservableCollection<User>();
           
            PermissionSet_Model = new PermissionSet_Model();
            //////  
            Grid_user = new UserModel().GetUsers();
            Grid_PermissionGroup = PermissionSet_Model.GetPermissionSet();
            ///////
            par = new SqlParameter[2];
        }
      
        #endregion
        #region Methodes And Events
        public void ShowReport1()
        {
            UserControl_ReportAllUserss = new UserControl_ReportAllUserss { DataContext = this };
            Curent_usercontrol = UserControl_ReportAllUserss;

        }

        public void ShowReport2()
        {
            UserControl_ReportOneUser = new UserControl_ReportOneUser { DataContext = this };
            Curent_usercontrol = UserControl_ReportOneUser;

        }

        public void ShowReport3()
        {
            UserControl_ReportUsertraffic = new UserControl_ReportUsertraffic { DataContext = this };
            Curent_usercontrol = UserControl_ReportUsertraffic;

        }

        public void ShowReport4()
        {
            UserControl_ReportGroups = new UserControl_ReportGroups { DataContext = this };
            Curent_usercontrol = UserControl_ReportGroups;

        }

        public void showreporsearchusers()
        {
            Show_Report = new Show_Report();
            SqlParameter[] par3 = new SqlParameter[5];
            if (User_search == true)
            {
                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "name_users"
                };
                par3[1] = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = Selected_users.Userid
                };

            }
            else if (All_search == true)
            {
                par3[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "all"
                };
                par3[1] = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = 1
                };
            }
            if (Date == true)
            {
                par3[2] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "fromto"
                };
                par3[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = From_date
                };
                par3[4] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                {
                    Value = To_date
                };
            }
            else if (Date == false)
            {
                par3[2] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "day"
                };
                par3[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = From_date
                };
                par3[4] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                {
                    Value = From_date
                };
            }

            Show_Report.ReportViewerDemo.Reset();
            dt = new Class_SqlConnection().GetData("Report_active_us", par3);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Users.Report_active_userss.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();

        }

        public void showreportoneusers()
        {
            Show_Report = new Show_Report();
               SqlParameter[] par1 = new SqlParameter[1];
            par1[0] = new SqlParameter("@use", SqlDbType.Int)
            {
                Value = Selected_users.Userid
            };

            Show_Report.ReportViewerDemo.Reset();
            dt = new Class_SqlConnection().GetData("Report_one_user", par1);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.RefreshReport();


            if (No_p == true)
            {
                par1[0] = new SqlParameter("@use", SqlDbType.Int)
                {
                    Value = 0
                };

                dt = new Class_SqlConnection().GetData("Report_one_user_Permission", par1);
                ds = new ReportDataSource("DataSet2", dt);
                Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                dt = new Class_SqlConnection().GetData("GetCompanys", null);
                ds = new ReportDataSource("DataSet3", dt);
                Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Users.Report_one_userss.rdlc";

                ReportParameter[] r = new ReportParameter[] { new ReportParameter("vis_us", "0") };
                Show_Report.ReportViewerDemo.LocalReport.SetParameters(r);

                Show_Report.ReportViewerDemo.RefreshReport();

                Show_Report.Show();


            }
            else
            {
                par1[0] = new SqlParameter("@use", SqlDbType.Int)
                {
                    Value = Selected_users.Userid
                };

                dt = new Class_SqlConnection().GetData("Report_one_user_Permission", par1);
                ds = new ReportDataSource("DataSet2", dt);
                Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                dt = new Class_SqlConnection().GetData("GetCompanys", null);
                ds = new ReportDataSource("DataSet3", dt);
                Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
                Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Users.Report_one_userss.rdlc";
                ReportParameter[] r = new ReportParameter[] { new ReportParameter("vis_us", "1") };
                Show_Report.ReportViewerDemo.LocalReport.SetParameters(r);
                Show_Report.ReportViewerDemo.RefreshReport();

                Show_Report.Show();


            }

        }

        public void showreport_Alluser()
        {
            Show_Report = new Show_Report();
            if (Comb_box == "نظام")
            {
                par[0] = new SqlParameter("@type", SqlDbType.Int)
                {
                    Value = 1
                };


            }
            else if (Comb_box == "تطبيق")
            {
                par[0] = new SqlParameter("@type", SqlDbType.Int)
                {
                    Value = 2
                };
            }
            if (Active_user == true)
            {

                par[1] = new SqlParameter("@user_act", SqlDbType.Int)
                {
                    Value = 1
                };
            }
            if (No_active_user == true)
            {

                par[1] = new SqlParameter("@user_act", SqlDbType.Int)
                {
                    Value = 2
                };
            }
            else
            {

                par[1] = new SqlParameter("@user_act", SqlDbType.Int)
                {
                    Value = 3
                };

            }

            //   UserControl_ReportAllUserss = new UserControl_ReportAllUserss();
            Show_Report.ReportViewerDemo.Reset();
            dt = new Class_SqlConnection().GetData("Report_all_user", par);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Users.Report_alluser.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();







        }

        public void showreporgroup()
        {
            Show_Report = new Show_Report();
               SqlParameter[] par4 = new SqlParameter[3];
            if (One_group == true)                     //////جروب واحد/////
            {



                par4[0] = new SqlParameter("@typ", SqlDbType.NVarChar, 20)
                {
                    Value = "groupo"
                };
                par4[1] = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = Selected_permissiongroup.Group_id
                };
                par4[2] = new SqlParameter("@act", SqlDbType.Int)
                {
                    Value = 1
                };




            }
            else               //////////مجموعة جروبات 
            {
                par4[0] = new SqlParameter("@typ", SqlDbType.NVarChar, 20)
                {
                    Value = "groupa"
                };
                par4[1] = new SqlParameter("@Id", SqlDbType.Int)
                {
                    Value = 1
                };


                if (Active_group == true)   //////// نشط
                {


                    par4[2] = new SqlParameter("@act", SqlDbType.Int)
                    {
                        Value = 1

                    };
                }

                else if (Noactive_group == true)      ////////////غير نشط
                {

                    par4[2] = new SqlParameter("@act", SqlDbType.Int)
                    {
                        Value = 2

                    };
                }
                else         //////////الكل 
                {

                    par4[2] = new SqlParameter("@act", SqlDbType.Int)
                    {
                        Value = 3
                    };
                }
            }

            dt = new Class_SqlConnection().GetData("Report_group_per", par4);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Users.Report_group_us.rdlc";
            ReportParameter[] r;
            if (Yes_group == true)
            {
                r = new ReportParameter[] { new ReportParameter("act_gr", "1") };
            }
            else
            {
                r = new ReportParameter[] { new ReportParameter("act_gr", "0") };
            }

            Show_Report.ReportViewerDemo.LocalReport.SetParameters(r);

            Show_Report.ReportViewerDemo.RefreshReport();

            Show_Report.Show();

        }
        #endregion
        #region Commands
        public RelayCommand Showcommand1 { get; private set; }
        public RelayCommand Showcommand2 { get; private set; }
        public RelayCommand Showcommand3 { get; private set; }
        public RelayCommand Showcommand4 { get; private set; }
        public RelayCommand Show_reportcommand { get; private set; }
        public RelayCommand Show_report_onecommand { get; private set; }
        public RelayCommand Show_report_searchcommand { get; private set; }
        public RelayCommand Show_report_groupcommand { get; private set; }
        #endregion

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
