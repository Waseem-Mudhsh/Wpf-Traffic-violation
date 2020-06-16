using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
   public class Citizen : BindableBase
    {
        int citizen_id;
        public int Citizen_id
        {
            get
            {
                return citizen_id;
            }
            set
            {
                if (citizen_id != value)
                {
                    citizen_id = value;
                    RaisePropertyChanged("Citizen_id");
                }
            }
        }

        string citizen_name;
        public string Citizen_name
        {
            get
            {
                return citizen_name;
            }
            set
            {
                if (citizen_name != value)
                {
                    citizen_name = value;
                    RaisePropertyChanged("Citizen_name");
                }
            }
        }

        string citizen_address;
        public string Citizen_address
        {
            get
            {
                return citizen_address;
            }
            set
            {
                if (citizen_address != value)
                {
                    citizen_address = value;
                    RaisePropertyChanged("Citizen_address");
                }
            }
        }










        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
