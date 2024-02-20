using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Views.Reports.Accounts;
using System.Data.SqlClient;
using Wpf_Traffic_violation.Models;
using System.Windows;
using System.Collections.ObjectModel;
using Wpf_Traffic_violation.Views.Reports;

namespace Wpf_Traffic_violation.ViewModel
{
    public class ReprtAcountViowModel : BindableBase
    {
        #region Objects And Variables
        DataTable dt;
        ReportDataSource ds;
        UserControl_Report_OneAccount UserControl_Report_OneAccount;
        UserControl_Report_AllAccounts UserControl_Report_AllAccounts;
        AccountModel AccountModel = new AccountModel();
        Show_Report Show_Report;
        // UserControl_Report_AllAccounts UserControl_Report_AllAccounts;
        #endregion
        #region Proprties



        ObservableCollection<Account> grid_Accounts;
        public ObservableCollection<Account> Grid_Accounts //يربط مع الجرد فيو 
        {
            get
            {
                return grid_Accounts;
            }
            set
            {
                
                if (grid_Accounts != value)
                {
                    grid_Accounts = value;
                    RaisePropertyChanged("Grid_Accounts");
                }
            }
        }
        Account current_Account;
        public Account Current_Account //يربط مع الجرد فيو 
        {
            get
            {
                return current_Account;
            }
            set
            {
                if (current_Account != value)
                {
                    current_Account = value;
                    RaisePropertyChanged("Current_Account");
                }
            }
        }
        bool parint;
        public bool Parint//يربط مع الجرد فيو 
        {
            get
            {
                return parint;
            }
            set
            {
                if (parint != value)
                {
                    parint = value;
                    RaisePropertyChanged("Parint");
                    if (parint == true)
                    {
                       // parint = true;
                        Grid_Accounts.Clear();
                        Grid_Accounts= new  AccountModel().GetAccountParent();
                    }
                }
            }
        }
        bool child;
        public bool Child//يربط مع الجرد فيو 
        {
            get
            {
                return child;
            }
            set
            {
                if (child != value)
                {
                    child = value;
                    RaisePropertyChanged("Child");
                    if (child == true)
                    {
                        Grid_Accounts.Clear();
                        Grid_Accounts= new AccountModel().GetAccountChild();
                    }
                }
            }
        }
        bool day;
        public bool Day//يربط مع الجرد فيو 
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
        bool typeReport;
        public bool TypeReport//يربط مع الجرد فيو 
        {
            get
            {
                return typeReport;
            }
            set
            {
                if (typeReport != value)
                {
                    typeReport = value;
                    RaisePropertyChanged("TypeReport");

                }
            }
        }
        string fromdate;
        public string Fromdate//يربط مع الجرد فيو 
        {
            get
            {
                return fromdate;
            }
            set
            {
                if (fromdate != value)
                {
                    fromdate = value;
                    RaisePropertyChanged("Fromdate");
                   
                }
            }
        }
        string todate;
        public string Todate//يربط مع الجرد فيو 
        {
            get
            {
                return todate;
            }
            set
            {
                if (todate != value)
                {
                    todate = value;
                    RaisePropertyChanged("Todate");

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
        #endregion
        #region Construcor
        public  ReprtAcountViowModel()
        {
            Showcommand1 = new RelayCommand(Par => ShowReport1());
            Showcommand2 = new RelayCommand(Par => ShowReport2());
            Showcommand3 = new RelayCommand(Par => ShowReport3());

            
            ShowAllAccountcommand = new RelayCommand(Par => ShowAccount());
            ShowOneAccountcommand = new RelayCommand(Par => ShowOneAccount());
            Grid_Accounts = new ObservableCollection<Account>();
            Grid_Accounts=new AccountModel().GetAccountParent();


        }
        #endregion
        #region Methodes And Events
        public void ShowReport1()
        {
             UserControl_Report_AllAccounts=  new UserControl_Report_AllAccounts { DataContext = this };
            Curent_usercontrol = UserControl_Report_AllAccounts;

        }
        public void ShowReport2()
        {
             UserControl_Report_OneAccount=  new UserControl_Report_OneAccount { DataContext = this };
            Curent_usercontrol = UserControl_Report_OneAccount;

        }
        public void ShowReport3()
        {
            Curent_usercontrol = new UserControl_Report_Bonds { DataContext = this };

        }
        public void ShowAccount()
        {
            SqlParameter[] par = new SqlParameter[5];
            if (UserControl_Report_AllAccounts.RadioButton_all.IsChecked==true)
            {
                par[0] = new SqlParameter("@opretion", SqlDbType.NVarChar, 50)
                {
                    Value = "all"
                };
            }
            else if (UserControl_Report_AllAccounts.RadioButton_main.IsChecked == true)
            {
                par[0] = new SqlParameter("@opretion", SqlDbType.NVarChar, 50)
                {
                    Value = "parint"
                };

            }
            else if (UserControl_Report_AllAccounts.RadioButton_sub.IsChecked == true)
            {
                par[0] = new SqlParameter("@opretion", SqlDbType.NVarChar, 50)
                {
                    Value = "child"
                };

            }

            if (UserControl_Report_AllAccounts.RadioButton_date.IsChecked == true)
            {
                par[1] = new SqlParameter("@date", SqlDbType.NVarChar,50)
                {
                    Value = "fromto"
                };
                par[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_AllAccounts.from.Text.ToString()
                };


            }
            else if (UserControl_Report_AllAccounts.RadioButton_day.IsChecked == true)
            {
                par[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                {
                    Value = "day"
                };
                par[3] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                {
                    Value = UserControl_Report_AllAccounts.date.Text.ToString()
                };
            }

            if (UserControl_Report_AllAccounts.RadioButton_yes.IsChecked == true)
            {
                par[2] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "name"
                };


            }
            else if (UserControl_Report_AllAccounts.RadioButton_no.IsChecked == true)
            {
                par[2] = new SqlParameter("@by", SqlDbType.NVarChar, 50)
                {
                    Value = "id"
                };

            }
          
            par[4] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
            {
                Value = UserControl_Report_AllAccounts.to.Text.ToString()
            };

            Show_Report = new Show_Report();
            Show_Report.ReportViewerDemo.Reset();
            dt = new Class_SqlConnection().GetData("Report_Account", par);
            ds = new ReportDataSource("DataSet1", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.RefreshReport();
           
            
            dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Accounts.AllAccountReport.rdlc";

            Show_Report.ReportViewerDemo.RefreshReport();

            Show_Report.Show();


        }
        public void ShowOneAccount()   
        {
            Show_Report = new Show_Report();

               dt = new Class_SqlConnection().GetData("GetCompanys", null);
            ds = new ReportDataSource("DataSet2", dt);
            Show_Report.ReportViewerDemo.LocalReport.DataSources.Add(ds);
            Show_Report.ReportViewerDemo.LocalReport.ReportEmbeddedResource = "Wpf_Traffic_violation.Views.Reports.Accounts.Report_One_Account.rdlc";

            ReportParameter[] r = new ReportParameter[] {new ReportParameter("Acc_id",Current_Account.Account_id.ToString()),
                new ReportParameter("Acc_parint",Current_Account.Account_parent.ToString()), new ReportParameter("Acc_name",Current_Account.Account_name.ToString()), new ReportParameter("Acc_date",Current_Account.Account_date.ToString()),new ReportParameter("Acc_order",Current_Account.Account_order.ToString()),new ReportParameter("Acc_type",Current_Account.Account_type.ToString()),new ReportParameter("Acc_debtor",Current_Account.Account_debtor.ToString()),new ReportParameter("Acc_creditor",Current_Account.Account_creditor.ToString())};
            Show_Report.ReportViewerDemo.LocalReport.SetParameters(r);
            Show_Report.ReportViewerDemo.RefreshReport();

            Show_Report.Show();

            

        }
        #endregion
            #region Commands
        public RelayCommand Showcommand1 { get; private set; }
        public RelayCommand Showcommand2 { get; private set; }
        public RelayCommand Showcommand3 { get; private set; }
        public RelayCommand ShowAllAccountcommand { get; private set; }
        public RelayCommand ShowOneAccountcommand { get; private set; }
        #endregion
        

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
