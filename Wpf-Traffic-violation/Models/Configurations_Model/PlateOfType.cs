using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class PlateOfType : BindableBase
    {
        int plate_type_id;
        public int Plate_type_id
        {
            get
            {
                return plate_type_id;
            }
            set
            {
                if (plate_type_id != value)
                {
                    plate_type_id = value;
                    Combine();
                    RaisePropertyChanged("Plate_type_id");
                }
            }
        }
        string plate_type_name;
        public string Plate_type_name
        {
            get
            {
                return plate_type_name;
            }
            set
            {
                if (plate_type_name != value)
                {
                    plate_type_name = value;
                   
                    Combine();
                    RaisePropertyChanged("Plate_type_name");
                }
            }
        }
        string search ;
        public string Search
        {
            get
            {
                return search;
            }
            set
            {
                if (search != value)
                {
                    search = value;
                    RaisePropertyChanged("Search");
                }
            }
        }

        private void Combine()
        {
            Search = string.Join("    ", Plate_type_id.ToString(), Plate_type_name);
        }
        public override void CollectErrors()
        {
            Errors.Clear();
            if (String.IsNullOrWhiteSpace(Plate_type_name))
            {
                Errors.Add("Plate_type_name", "يجب أن يكون نص");
            }
        }
    }
}
