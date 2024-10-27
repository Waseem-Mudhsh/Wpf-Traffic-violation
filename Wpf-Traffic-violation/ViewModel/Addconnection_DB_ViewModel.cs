using Microsoft.Win32;
using System;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Users_Model;

namespace Wpf_Traffic_violation.ViewModel
{
    public class Addconnection_DB_ViewModel : BindableBase
    {
        #region Objects And Variables

        DataServerModel DataServerModel;
        SaveFileDialog choofdlog;
        ActivityModel ActivityModel = new ActivityModel();
        #endregion
        #region Proprties

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

        DataServer current_DataServer;
        public DataServer Current_DataServer
        {
            get
            {
                return current_DataServer;
            }
            set
            {
                if (current_DataServer != value)
                {
                    current_DataServer = value;
                    RaisePropertyChanged("Current_DataServer");
                }
            }
        }

        #endregion
        #region Construcor
        public Addconnection_DB_ViewModel()
        {

            AddConnect = new RelayCommand(Par => addConnects());//This Bind with Button Add\
            SaveConnect = new RelayCommand(Par => SaveValues());
            BackupConnect = new RelayCommand(Par => Backup());
            OpenConnect = new RelayCommand(Par => opendug());
            RestorConnect = new RelayCommand(Par => Restor());
            OpenrestorConnect = new RelayCommand(Par => opendugrestor());
            addConnects();

            Current_Activity = new Activity();

        }
        #endregion
        #region Methodes And Events

        public void addConnects()
        {
            Current_DataServer = new DataServer
            {
                ServerName = Properties.Settings.Default.ServerName,
                DBName = Properties.Settings.Default.DatabaseName,
                UserName = Properties.Settings.Default.UserName,
                Pass = Properties.Settings.Default.Password
            };
        }
        public void SaveValues()
        {
            Properties.Settings.Default.ServerName = Current_DataServer.ServerName;
            Properties.Settings.Default.DatabaseName = Current_DataServer.DBName;
            Properties.Settings.Default.UserName = Current_DataServer.UserName;
            Properties.Settings.Default.Password = Current_DataServer.Pass;
            Properties.Settings.Default.Save();

            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 11;
            Current_Activity.Activity_record_num = 34;

            //////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            Current_Activity.Activity_operation_num = 1;
            ActivityModel.OperarionActivity(current_Activity, "Insert");
            ////////////////////////////////////////////////////////////
        }
        public void Backup()
        {
            DataServerModel = new DataServerModel();
            //Properties.Settings.Default.ba
            //string filename = System.IO.Path.GetDirectoryName(Current_DataServer.Backup + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak");
            string filename = "BackUpdatabase" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
            DataServerModel.setBackup(filename);
            //////////////////////////////////////////////////////////////

            //Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            //Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            //Current_Activity.User_id = Properties.Settings.Default.Userid;
            //Current_Activity.Form_id = 11;
            //Current_Activity.Activity_record_num = 35;

            ////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            //Current_Activity.Activity_operation_num = 1;
            //ActivityModel.OperarionActivity(current_Activity, "Insert");
            ////////////////////////////////////////////////////////////
        }
        public void Restor()
        {
            DataServerModel = new DataServerModel();
            DataServerModel.restore(Current_DataServer.Backup);
            //////////////////////////////////////////////////////////////

            Current_Activity.Activity_id = new Class_SqlConnection().Get_Max("Activity");
            Current_Activity.Activity_date = DateTime.Now.Date.ToString();
            Current_Activity.User_id = Properties.Settings.Default.Userid;
            Current_Activity.Form_id = 11;
            Current_Activity.Activity_record_num = 36;

            //////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////
            Current_Activity.Activity_operation_num = 1;
            ActivityModel.OperarionActivity(current_Activity, "Insert");
            ////////////////////////////////////////////////////////////
        }

        public void opendug()
        {

            choofdlog = new SaveFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;

            if (choofdlog.ShowDialog() == true)
            {
                Current_DataServer.Backup = choofdlog.FileName;

                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }


        }
        public void opendugrestor()
        {

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == true)
            {
                string sFileName = choofdlog.FileName;
                Current_DataServer.Backup = sFileName;
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }


        }

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Commands
        public RelayCommand AddConnect { get; private set; }
        public RelayCommand SaveConnect { get; private set; }
        public RelayCommand BackupConnect { get; private set; }
        public RelayCommand OpenConnect { get; private set; }
        public RelayCommand OpenrestorConnect { get; private set; }
        public RelayCommand RestorConnect { get; private set; }
        #endregion







    }
}
