using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class Receipt : BindableBase
    {
        int receipt_id;
        public int Receipt_id
        {
            get
            {
                return receipt_id;
            }
            set
            {
                if (receipt_id != value)
                {
                    receipt_id = value;
                    RaisePropertyChanged("Receipt_id");
                }
            }
        }
        int account_id;
        public int Account_id
        {
            get
            {
                return account_id;
            }
            set
            {
                if (account_id != value)
                {
                    account_id = value;
                    RaisePropertyChanged("Account_id");
                }
            }
        }
        string receipt_statement;
        public string Receipt_statement
        {
            get
            {
                return receipt_statement;
            }
            set
            {
                if (receipt_statement != value)
                {
                    receipt_statement = value;
                    RaisePropertyChanged("Receipt_statement");
                }
            }
        }
        int receipt_amount;
        public int Receipt_amount
        {
            get
            {
                return receipt_amount;
            }
            set
            {
                if (receipt_amount != value)
                {
                    receipt_amount = value;
                    RaisePropertyChanged("Receipt_amount");
                }
            }
        }
        bool receipt_status;
        public bool Receipt_status
        {
            get
            {
                return receipt_status;
            }
            set
            {
                if (receipt_status != value)
                {
                    receipt_status = value;
                    RaisePropertyChanged("Receipt_status");
                }
            }
        }
        string receipt_date;
        public string Receipt_date
        {
            get
            {
                return receipt_date;
            }
            set
            {
                if (receipt_date != value)
                {
                    receipt_date = value;
                    RaisePropertyChanged("Receipt_date");
                }
            }
        }
        string post_date;
        public string Post_date
        {
            get
            {
                return post_date;
            }
            set
            {
                if (post_date != value)
                {
                    post_date = value;
                    RaisePropertyChanged("Post_date");
                }
            }
        }




        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
