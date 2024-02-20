using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class Streets : BindableBase
    {
        int street_id;
        public int Street_id
        {
            get
            {
                return street_id;
            }
            set
            {
                if (street_id != value)
                {
                    street_id = value;
                    Combine();
                    RaisePropertyChanged("Street_id");
                }
            }
        }
        string street_name;
        public string Street_name
        {
            get
            {
                return street_name;
            }
            set
            {
                if (street_name != value)
                {
                    street_name = value;
                    Combine();
                    RaisePropertyChanged("Street_name");
                }
            }
        }
        int directerate_id;
        public int Directerate_id
        {
            get
            {
                return directerate_id;
            }
            set
            {
                if (directerate_id != value)
                {
                    directerate_id = value;
                    RaisePropertyChanged("Directerate_id");
                }
            }
        }
        string directerate_name;
        public string Directerate_name
        {
            get
            {
                return directerate_name;
            }
            set
            {
                if (directerate_name != value)
                {
                    directerate_name = value;
                    RaisePropertyChanged("Directerate_name");
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

        string search;
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
        void Combine()
        {
            Search = string.Join(" || ", Street_id.ToString(), Street_name);
        }

        public override void CollectErrors()
        {
            Errors.Clear();
            if (string.IsNullOrWhiteSpace(Street_name))
            {
                Errors.Add("Street_name", "يجب ان يكون نص   ");
            }
           
        }
    }
}
