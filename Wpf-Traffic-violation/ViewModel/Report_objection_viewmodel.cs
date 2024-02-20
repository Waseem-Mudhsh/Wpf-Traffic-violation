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
using Wpf_Traffic_violation.Views.Reports;
using Wpf_Traffic_violation.Views.Reports.Objections;

namespace Wpf_Traffic_violation.ViewModel
{
   public class Report_objection_viewmodel : BindableBase
    {



        #region Objects And Variables
        DataTable dt;
        ReportDataSource ds;
        Show_Report Show_Report = new Show_Report();
        OpjectionModel OpjectionModel = new OpjectionModel();
        UserControl_Report_Unchecked UserControl_Report_Unchecked;
        UserControl_Report_RightObjection UserControl_Report_RightObjection;
        CitizenModel CitizenModel = new CitizenModel();

        UserControl_Report_allObjections UserControl_Report_allObjections;
        UserControl_Report_Falseobjection UserControl_Report_Falseobjection;
        UserControl_Report_Compareobjection UserControl_Report_Compareobjection;

        ViolationTypeModel ViolationTypeModel;

        #endregion
        #region Proprties
        ObservableCollection<Opjection> grid_objection;
        public ObservableCollection<Opjection> Grid_objection
        {
            get
            {
                return grid_objection;
            }
            set
            {
                if (grid_objection != value)
                {
                    grid_objection = value;
                    RaisePropertyChanged("Grid_objection");
                }
            }
        }

        ObservableCollection<ViolationType> grid_type_viol;
        public ObservableCollection<ViolationType> Grid_type_viol
        {
            get
            {
                return grid_type_viol;
            }
            set
            {
                if (grid_type_viol != value)
                {
                    grid_type_viol = value;
                    RaisePropertyChanged("Grid_type_viol");
                }
            }
        }
        ViolationType selected_vio_type;
        public ViolationType Selected_vio_type
        {
            get
            {
                return selected_vio_type;
            }
            set
            {
                if (selected_vio_type != value)
                {
                    selected_vio_type = value;
                    RaisePropertyChanged("Selected_vio_type");
                }
            }
        }




        Opjection selected_objection;
        public Opjection Selected_objection
        {
            get
            {
                return selected_objection;
            }
            set
            {



                if (selected_objection != value)
                {
                    selected_objection = value;
                    RaisePropertyChanged("Selected_objection");
                }
            }
        }

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

        ObservableCollection<Citizen> grid_citi;
        public ObservableCollection<Citizen> Grid_citi
        {
            get
            {
                return grid_citi;
            }
            set
            {
                if (grid_citi != value)
                {
                    grid_citi = value;
                    RaisePropertyChanged("Grid_citi");
                }
            }
        }

        Citizen selected_citiz;
        public Citizen Selected_citiz
        {
            get
            {
                return selected_citiz;
            }
            set
            {
                if (selected_citiz != value)
                {
                    selected_citiz = value;
                    RaisePropertyChanged("Selected_citiz");
                }
            }
        }

        string onday;
        public string Onday
        {
            get
            {
                return onday;
            }
            set
            {
                if (onday != value)
                {
                    onday = value;
                    RaisePropertyChanged("Onday");
                }
            }
        }

        string from_d;
        public string From_d
        {
            get
            {
                return from_d;
            }
            set
            {
                if (from_d != value)
                {
                    from_d = value;
                    RaisePropertyChanged("From_d");
                }
            }
        }

        string to_d;
        public string To_d
        {
            get
            {
                return to_d;
            }
            set
            {
                if (to_d != value)
                {
                    to_d = value;
                    RaisePropertyChanged("To_d");
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

        bool num_obj;
        public bool Num_obj
        {
            get
            {
                return num_obj;
            }
            set
            {
                if (num_obj != value)
                {
                    num_obj = value;
                    RaisePropertyChanged("Num_obj");
                }
            }
        }


        bool citi;
        public bool Citi
        {
            get
            {
                return citi;
            }
            set
            {
                if (citi != value)
                {
                    citi = value;
                    RaisePropertyChanged("Citi");
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



        #endregion
        #region Construcor
        public Report_objection_viewmodel()
        {
            Showcommand1 = new RelayCommand(Par => ShowReport1());
            Showcommand2 = new RelayCommand(Par => ShowReport2());
            Showcommand3 = new RelayCommand(Par => ShowReport3());
            Showcommand4 = new RelayCommand(Par => ShowReport4());
            Showcommand5 = new RelayCommand(Par => ShowReport5());
            //Showcommand6 = new RelayCommand(Par => ShowReport6());
            close_command = new RelayCommand(Par => close_showreport());
            Show_report_allobjection = new RelayCommand(Par => show_report_allobjection());
            Show_report_false_objection = new RelayCommand(Par => show_false_objection());
            Show_report_noscan_objection = new RelayCommand(Par => show_noscan_objection());
            Show_report_right_objection = new RelayCommand(Par => show_right_objection());
            Show_report_compare_objection = new RelayCommand(Par => compare_objection());
            Grid_objection = new ObservableCollection<Opjection>();
            OpjectionModel = new OpjectionModel();
            OpjectionModel.GetOpjection(Grid_objection);

            Grid_citi = new ObservableCollection<Citizen>();
            CitizenModel = new CitizenModel();
            Grid_citi=CitizenModel.GetCitizens();

            Grid_type_viol = new ObservableCollection<ViolationType>();
            ViolationTypeModel = new ViolationTypeModel();
            Grid_type_viol=ViolationTypeModel.GetViolationTypes();

        }
        #endregion
        #region Methodes And Events
        public void ShowReport1()
        {
            UserControl_Report_allObjections = new UserControl_Report_allObjections { DataContext = this };
            Curent_usercontrol = UserControl_Report_allObjections;
        }
        public void ShowReport2()
        {
            Selected_objection = new Opjection();
            UserControl_Report_Falseobjection = new UserControl_Report_Falseobjection { DataContext = this };
            Curent_usercontrol = UserControl_Report_Falseobjection;
        }
        public void ShowReport3()
        {
            Selected_objection = new Opjection();
            UserControl_Report_Unchecked = new UserControl_Report_Unchecked { DataContext = this };
            Curent_usercontrol = UserControl_Report_Unchecked;
        }
        public void ShowReport4()
        {
            Selected_objection = new Opjection();
            UserControl_Report_RightObjection = new UserControl_Report_RightObjection { DataContext = this };
            Curent_usercontrol = UserControl_Report_RightObjection;
        }
        public void ShowReport5()
        {

            UserControl_Report_Compareobjection = new UserControl_Report_Compareobjection { DataContext = this };
            Curent_usercontrol = UserControl_Report_Compareobjection;
        }
        public void close_showreport()
        {
           
            Show_Report.Close();
        }
        public void show_report_allobjection()
        {
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "تقرير الاعتراضات ";
            SqlParameter[] par = new SqlParameter[4];

            if (All == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value= "all"
                };
                par[1] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = 0
                };
                par[2] = new SqlParameter("@num_opj", SqlDbType.Int)
                {
                    Value = 0
                };
                par[3] = new SqlParameter("@date_obj", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
            }
            else if(Citi==true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value= "name_ci"
                };
                par[1] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value= Selected_citiz.Citizen_id
                };
                par[2] = new SqlParameter("@num_opj", SqlDbType.Int)
                {
                    Value =0
                };
                par[3] = new SqlParameter("@date_obj", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
            }
            else if (UserControl_Report_allObjections.RadioButton_id.IsChecked == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "obj_num"
                };
                par[1] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = 0
                };

                par[2] = new SqlParameter("@num_opj", SqlDbType.Int)
                {
                    Value=Selected_objection.Interception_id
                };
                par[3] = new SqlParameter("@date_obj", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
            }
            else if (UserControl_Report_allObjections.RadioButton_datemade.IsChecked == true)
            {
                par[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "obj_date"
                };
                par[1] = new SqlParameter("@name_cit", SqlDbType.Int)
                {
                    Value = 0
                };
                par[2] = new SqlParameter("@num_opj", SqlDbType.Int)
                {
                    Value = 0
                };
                par[3] = new SqlParameter("@date_obj", SqlDbType.NVarChar, 50)
                {
                    Value = Selected_objection.Interception_date
                };
            }
            dt = new Class_SqlConnection().GetData("Report_All_objection", par);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Objections.Report_all_objection.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();

            Show_Report.Show();

          
      

           

           
        }
        public void show_false_objection()
        {
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "الاعتراضات الغير مقبولة";

            SqlParameter[] par1 = new SqlParameter[5];
            if (All == true)
            {
                par1[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "All"
                };
                par1[4] = new SqlParameter("@obj_num", SqlDbType.Int)
                {
                    Value = 0

                };
           
                   if (Fromto== false)
                {
                    par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "day"
                    };
                    par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = Selected_objection.Interception_date
                    };
                    MessageBox.Show(Selected_objection.Interception_date);
                    par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = Selected_objection.Interception_date
                    };
                }
                   else if (Fromto == true)
                {
                    par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "from_to"
                    };
                    par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = From_d
                    };
                    par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = To_d
                    };

                }


            }
            else if (Num_obj == true)
            {
                par1[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_obj"
                };
                par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                {
                    Value = " "
                };
                par1[4] = new SqlParameter("@obj_num", SqlDbType.Int)
                {
                    Value = Selected_objection.Interception_id

                };
               

            }

            



            dt = new Class_SqlConnection().GetData("Report_false_objection", par1);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Objections.Report_false_objectio.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void show_noscan_objection()
        {
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "الاعتراضات الغير مفحوصة";

            SqlParameter[] par1 = new SqlParameter[5];
            if (All == true)
            {
                par1[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "All"
                };
                par1[4] = new SqlParameter("@obj_num", SqlDbType.Int)
                {
                    Value = 0

                };

                if (Fromto == false)
                {
                    par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "day"
                    };
                    par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = Selected_objection.Interception_date
                    };
                    MessageBox.Show(Selected_objection.Interception_date);
                    par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = Selected_objection.Interception_date
                    };
                }
                else if (Fromto == true)
                {
                    par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "from_to"
                    };
                    par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = From_d
                    };
                    par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = To_d
                    };

                }


            }
            else if (Num_obj == true)
            {
                par1[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_obj"
                };
                par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                {
                    Value = " "
                };
                par1[4] = new SqlParameter("@obj_num", SqlDbType.Int)
                {
                    Value = Selected_objection.Interception_id

                };


            }





            dt = new Class_SqlConnection().GetData("Repot_no_scan_objection", par1);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Objections.Report__Unchecked_objection.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void show_right_objection()
        {
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "الاعتراضات المقبولة ";

            SqlParameter[] par1 = new SqlParameter[5];
            if (All == true)
            {
                par1[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "All"
                };
                par1[4] = new SqlParameter("@obj_num", SqlDbType.Int)
                {
                    Value = 0

                };

                if (Fromto == false)
                {
                    par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "day"
                    };
                    par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = Selected_objection.Interception_date
                    };
                    MessageBox.Show(Selected_objection.Interception_date);
                    par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = Selected_objection.Interception_date
                    };
                }
                else if (Fromto == true)
                {
                    par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "from_to"
                    };
                    par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = From_d
                    };
                    par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = To_d
                    };

                }


            }
            else if (Num_obj == true)
            {
                par1[0] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "num_obj"
                };
                par1[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par1[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par1[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                {
                    Value = " "
                };
                par1[4] = new SqlParameter("@obj_num", SqlDbType.Int)
                {
                    Value = Selected_objection.Interception_id

                };


            }





            dt = new Class_SqlConnection().GetData("Report_right_objection", par1);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Objections.Report_right_objection.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();
            Show_Report.Show();
        }
        public void compare_objection()
        {
            Show_Report = new Show_Report();
            //Show_Report.win_name.Text = "مقارنة الاعتراضات ";
               SqlParameter[] par3 = new SqlParameter[5];
            if (UserControl_Report_Compareobjection.RadioButton_Right.IsChecked == true)
            {
                par3[0] = new SqlParameter("@opration", SqlDbType.NVarChar, 50)
                {
                    Value = "acept_inter"
                };
                par3[1] = new SqlParameter("@typ_viol", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par3[2] = new SqlParameter("@reson_interce", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par3[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_Compareobjection.from.Text.ToString()
                };
            }

            else if (UserControl_Report_Compareobjection.RadioButton_False.IsChecked == true)
            {
                par3[0] = new SqlParameter("@opration", SqlDbType.NVarChar, 50)
                {
                    Value = "noacept_inter"
                };
                par3[1] = new SqlParameter("@typ_viol", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par3[2] = new SqlParameter("@reson_interce", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par3[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_Compareobjection.from.Text.ToString()
                };
            }
            else if (UserControl_Report_Compareobjection.RadioButton_typeviolation.IsChecked == true)
            {
                par3[0] = new SqlParameter("@opration", SqlDbType.NVarChar, 50)
                {
                    Value = "viol_typ"
                };
                par3[1] = new SqlParameter("@typ_viol", SqlDbType.NVarChar, 50)
                {
                    Value = Selected_vio_type.Violation_type_name
                };
                par3[2] = new SqlParameter("@reson_interce", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par3[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_Compareobjection.from.Text.ToString()
                };
            }
            else if (UserControl_Report_Compareobjection.RadioButton_reason.IsChecked == true)
            {
                par3[0] = new SqlParameter("@opration", SqlDbType.NVarChar, 50)
                {
                    Value = "viol_typ"
                };
                par3[1] = new SqlParameter("@typ_viol", SqlDbType.NVarChar, 50)
                {
                    Value = ""
                };
                par3[2] = new SqlParameter("@reson_interce", SqlDbType.NVarChar, 50)
                {
                    Value = Selected_objection.Reason_Interception
                };
                par3[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_Compareobjection.from.Text.ToString()
                };
            }
            par3[4] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
            {
                Value = UserControl_Report_Compareobjection.to.Text.ToString()
            };

            dt = new Class_SqlConnection().GetData("Report_compare_interception", par3);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet5", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Objections.Report_compare_objection.rdlc";

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
        //public RelayCommand Showcommand6 { get; private set; }
        public RelayCommand close_command { get; private set; }
        public RelayCommand Show_report_allobjection { get; private set; }
        public RelayCommand Show_report_noscan_objection { get; private set; }
        public RelayCommand Show_report_false_objection { get; private set; }
        public RelayCommand Show_report_right_objection { get; private set; }
        public RelayCommand Show_report_compare_objection { get; private set; }
        #endregion





        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
