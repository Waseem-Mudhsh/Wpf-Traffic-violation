using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class Directorate : BindableBase
    {
        int directorate_id;
        public int Directorate_id
        {
            get
            {
                return directorate_id;
            }
            set
            {
                if (directorate_id != value)
                {
                    directorate_id = value;
                    Combine();
                    RaisePropertyChanged("Directorate_id");
                }
            }
        }
        string directorate_name;
        public string Directorate_name
        {
            get
            {
                return directorate_name;
            }
            set
            {
                if (directorate_name != value)
                {
                    directorate_name = value;
                    Combine();
                    RaisePropertyChanged("Directorate_name");
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

        private void Combine()
        {
            Search = String.Join(" || ", Directorate_id.ToString(), Directorate_name);
        }
        public override void CollectErrors()
        {
            Errors.Clear();
            if (string.IsNullOrWhiteSpace(Directorate_name))
            {
                Errors.Add("Directorate_name", "يجب أن يكون نص ");
            }
        }
    }
}
