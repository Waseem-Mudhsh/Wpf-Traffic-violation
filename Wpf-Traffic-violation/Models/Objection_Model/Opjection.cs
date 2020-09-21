using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class Opjection : BindableBase
    {
        int interception_id;
        public int Interception_id
        {
            get
            {
                return interception_id;
            }
            set
            {
                if (interception_id != value)
                {
                    interception_id = value;
                    Combine1();
                    RaisePropertyChanged("Interception_id");
                }
            }
        }
        string interception_date;
        public string Interception_date
        {
            get
            {
                return interception_date;
            }
            set
            {
                if (interception_date != value)
                {
                    interception_date = value;
                    Combine1();
                    RaisePropertyChanged("Interception_date");
                }
            }
        }
        string reason_Interception;
        public string Reason_Interception
        {
            get
            {
                return reason_Interception;
            }
            set
            {
                if (reason_Interception != value)
                {
                    reason_Interception = value;
                    RaisePropertyChanged("Reason_Interception");
                }
            }
        }
        string reason_Interception1;
        public string Reason_Interception1
        {
            get
            {
                return reason_Interception1;
            }
            set
            {
                if (reason_Interception1 != value)
                {
                    reason_Interception1 = value;
                    RaisePropertyChanged("Reason_Interception1");
                }
            }
        }
        int violation_id;
        public int Violation_id
        {
            get
            {
                return violation_id;
            }
            set
            {
                if (violation_id != value)
                {
                    violation_id = value;
                    Combine1();
                    RaisePropertyChanged("Violation_id");
                }
            }
        }
        int identity_id;
        public int Identity_id
        {
            get
            {
                return identity_id;
            }
            set
            {
                if (identity_id != value)
                {
                    identity_id = value;
                    RaisePropertyChanged("Identity_id");
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
        int violation_Type;
        public int Violation_Type
        {
            get
            {
                return violation_Type;
            }
            set
            {
                if (violation_Type != value)
                {
                    violation_Type = value;
                    RaisePropertyChanged("Violation_Type");
                }
            }
        }
        string string_Status;
        public string String_Status
        {
            get
            {
                return string_Status;
            }
            set
            {
                if (string_Status != value)
                {
                    string_Status = value;
                    Combine1();
                    RaisePropertyChanged("String_Status");
                }
            }
        }
        string string_Ciziten;
        public string String_Ciziten
        {
            get
            {
                return string_Ciziten;
            }
            set
            {
                if (string_Ciziten != value)
                {
                    string_Ciziten = value;
                    RaisePropertyChanged("String_Ciziten");
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

        private void Combine1()
        {
            Search = String.Join(" || ", Interception_id, Interception_date, Violation_id, String_Status);
        }

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
