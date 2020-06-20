using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class Provinces : BindableBase
    {
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
                    RaisePropertyChanged("Province_name");
                }
            }
        }



        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
