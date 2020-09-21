using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class ReasonsToObject : BindableBase
    {
        int reason_inter_id;
        public int Reason_inter_id
        {
            get
            {
                return reason_inter_id;
            }
            set
            {
                if (reason_inter_id != value)
                {
                    reason_inter_id = value;
                    Combine();
                    RaisePropertyChanged("Reason_inter_id");
                }
            }
        }
        string reason;
        public string Reason
        {
            get
            {
                return reason;
            }
            set
            {
                if (reason != value)
                {
                    reason = value;
                    Combine();
                    RaisePropertyChanged("Reason");
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
            Search = string.Join("||", Reason_inter_id.ToString(), Reason);
        }
        public override void CollectErrors()
        {
            Errors.Clear();
          
            if (string.IsNullOrWhiteSpace(Reason))
            {
                Errors.Add("Reason", "يجب أن يوكن نص");
            }
        }
    }
}
