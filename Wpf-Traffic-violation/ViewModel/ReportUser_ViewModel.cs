using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Views;
using Wpf_Traffic_violation.Views.Reports;
using Wpf_Traffic_violation.Views.Reports.Users;

namespace Wpf_Traffic_violation.ViewModel
{
    public class ReportUser_ViewModel : BindableBase
    {

        #region Objects And Variables
        //UserControl_Report_Users report_Users;
        #endregion
        #region Proprties
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
            Addcommand = new RelayCommand(Par => Add());
        }
        #endregion
        #region Methodes And Events
        public void Add()
        {
            Random rand = new Random();
            
            
            
           // report_Users.Frame_Search_users.Content = new UserControl_AddObjection {DataContext=this };




        }
        #endregion
        #region Commands
        public RelayCommand Addcommand { get; private set; }
        
        #endregion

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
