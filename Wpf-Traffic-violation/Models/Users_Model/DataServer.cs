using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Users_Model
{
    public class DataServer : BindableBase
    {
        string serverName;
        public string ServerName
        {
            get
            {
                return serverName;
            }
            set
            {
                if (serverName != value)
                {
                    serverName = value;
                    RaisePropertyChanged("ServerName");
                }
            }
        }
        string dBName;
        public string DBName
        {
            get
            {
                return dBName;
            }
            set
            {
                if (dBName != value)
                {
                    dBName = value;
                    RaisePropertyChanged("DBName");
                }
            }
        }
        string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }
        string pass;
        public string Pass
        {
            get
            {
                return pass;
            }
            set
            {
                if (pass != value)
                {
                    pass = value;
                    RaisePropertyChanged("Pass");
                }
            }
        }
        string backup;
        public string Backup
        {
            get
            {
                return backup;
            }
            set
            {
                if (backup != value)
                {
                    backup = value;
                    RaisePropertyChanged("Backup");
                }
            }
        }


        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
