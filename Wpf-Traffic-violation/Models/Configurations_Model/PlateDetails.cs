using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
   public class PlateDetails: BindableBase
    {
        int plate_id;
        public int Plate_id
        {
            get
            {
                return plate_id;
            }
            set
            {
                if (plate_id != value)
                {
                    plate_id = value;
                    RaisePropertyChanged("Plate_id");
                }
            }
        }
        string province_name;
        public string Province_name
        {
            get
            {
                return province_name;
            }
            set
            {
                if (province_name != value)
                {
                    province_name = value;
                    RaisePropertyChanged("province_name");
                }
            }
        }
       
        string plateName;
        public string PlateName
        {
            get
            {
                return plateName;
            }
            set
            {
                if (plateName != value)
                {
                    plateName = value;
              
                    RaisePropertyChanged("Plate_num");
                }
            }
        }
        
        int province_id;
        public int Province_id
        {
            get
            {
                return province_id;
            }
            set
            {
                if (province_id != value)
                {
                    province_id = value;
                    RaisePropertyChanged("Province_id");
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
                    RaisePropertyChanged("status");
                }
            }
        }

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
