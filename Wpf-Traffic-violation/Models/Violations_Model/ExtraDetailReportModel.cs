using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class ExtraDetailReportModel : BindableBase
    {
        string from_date;
        public string From_date
        {
            get
            {
                return from_date;
            }
            set
            {
                if (from_date != value)
                {
                    from_date = value;
                    RaisePropertyChanged("From_date");
                }
            }
        }
        string to_date;
        public string To_date
        {
            get
            {
                return to_date;
            }
            set
            {
                if (to_date != value)
                {
                    to_date = value;
                    RaisePropertyChanged("To_date");
                }
            }
        }
        string dateNow;
        public string DateNow
        {
            get
            {
                return dateNow;
            }
            set
            {
                
                    dateNow =Convert.ToString( DateTime.Now);
                    RaisePropertyChanged("To_date");
               
            }
        }
        public int SumViolationPenaltyCount
        {
            get; set;
        }
        public int SumViolationTypcount
        {
            get; set;
        }

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
