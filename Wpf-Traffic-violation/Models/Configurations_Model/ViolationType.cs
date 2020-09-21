using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class ViolationType : BindableBase
    {

        int violation_type_id;
        public int Violation_type_id
        {
            get
            {
                return violation_type_id;
            }
            set
            {
                if (violation_type_id != value)
                {
                    violation_type_id = value;
                    RaisePropertyChanged("Violation_type_id");
                }
            }
        }

        string violation_type_name;
        public string Violation_type_name
        {
            get
            {
                return violation_type_name;
            }
            set
            {
                if (violation_type_name != value)
                {
                    violation_type_name = value;
                    Combine();
                    RaisePropertyChanged("Violation_type_name");
                }
            }
        }

        int minimum_price;
        public int Minimum_price
        {
            get
            {
                return minimum_price;
            }
            set
            {
                if (minimum_price != value)
                {
                    minimum_price = value;
                    RaisePropertyChanged("Minimum_price");
                }
            }
        }

        int maximum_price;
        public int Maximum_price
        {
            get
            {
                return maximum_price;
            }
            set
            {
                if (maximum_price != value)
                {
                    maximum_price = value;
                    RaisePropertyChanged("Maximum_price");
                }
            }
        }

        int penalty;
        public int Penalty
        {
            get
            {
                return penalty;
            }
            set
            {
                if (penalty != value)
                {
                    penalty = value;
                    RaisePropertyChanged("Penalty");
                }
            }
        }

        bool interception_status;
        public bool Interception_status
        {
            get
            {
                return interception_status;
            }
            set
            {
                if (interception_status != value)
                {
                    interception_status = value;
                    RaisePropertyChanged("Interception_status");
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
            Search = string.Join("  ", Violation_type_name);
        }












        public override void CollectErrors()
        {
            Errors.Clear();
            if (string.IsNullOrWhiteSpace(Violation_type_name))
            {
                Errors.Add("Violation_type_name", "يجب أن يكون نص ");
            }
    }
    }
}
