using System;
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
                    Combine();
                    RaisePropertyChanged("Receipt_id");
                }
            }
        }
        int userId;
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                if (userId != value)
                {
                    userId = value;
                    RaisePropertyChanged("UserId");
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
                    Combine();
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
        string string_Account;
        public string String_Account
        {
            get
            {
                return string_Account;
            }
            set
            {
                if (string_Account != value)
                {
                    string_Account = value;
                    Combine();
                    RaisePropertyChanged("String_Account");
                }
            }
        }
        bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    RaisePropertyChanged("IsSelected");
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
        string resonOfPaid;

        public string ResonOfPaid
        {
            get
            {
                return resonOfPaid;
            }
            set
            {
                if (resonOfPaid != value)
                {
                    resonOfPaid = value;
                    RaisePropertyChanged("resonOfPaid");
                }
            }
        }
        string nameOfPaid;
        public string NameOfPaid
        {
            get
            {
                return nameOfPaid;
            }
            set
            {
                if (nameOfPaid != value)
                {
                    nameOfPaid = value;
                    RaisePropertyChanged("nameOfPaid");
                }
            }
        }
        int receipt_amountwithdiscont;


        public int Receipt_amountwithdiscont
        {
            get
            {
                return receipt_amountwithdiscont;
            }
            set
            {
                if (receipt_amountwithdiscont != value)
                {

                    RaisePropertyChanged("receipt_amountwithdiscont");
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

                    RaisePropertyChanged("violation_id");
                }
            }
        }

        public int CountViolation { get; internal set; }

        void Combine()
        {
            Search = string.Join(" || ", Receipt_id.ToString(), String_Account, Receipt_statement);
        }


        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
