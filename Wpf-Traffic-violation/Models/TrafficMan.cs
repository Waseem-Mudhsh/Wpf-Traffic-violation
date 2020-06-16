using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class TrafficMan : BindableBase
    {
        int traffic_man_id;
        public int Traffic_man_id
        {
            get
            {
                return traffic_man_id;
            }
            set
            {
                if (traffic_man_id != value)
                {
                    traffic_man_id = value;
                    RaisePropertyChanged("Traffic_man_id");
                }
            }
        }

        string traffic_man_name;
        public string Traffic_man_name
        {
            get
            {
                return traffic_man_name;
            }
            set
            {
                if (traffic_man_name != value)
                {
                    traffic_man_name = value;
                    RaisePropertyChanged("Traffic_man_name");
                }
            }
        }

        int user_id;
        public int User_id
        {
            get
            {
                return user_id;
            }
            set
            {
                if (user_id != value)
                {
                    user_id = value;
                    RaisePropertyChanged("User_id");
                }
            }
        }

        string traffic_man_grade;
        public string Traffic_man_grade
        {
            get
            {
                return traffic_man_grade;
            }
            set
            {
                if (traffic_man_grade != value)
                {
                    traffic_man_grade = value;
                    RaisePropertyChanged("Traffic_man_grade");
                }
            }
        }

        int status;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                if (status != value)
                {
                    status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }





        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
