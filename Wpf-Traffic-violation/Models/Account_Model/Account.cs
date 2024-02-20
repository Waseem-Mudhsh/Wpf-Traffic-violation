using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class Account : BindableBase
    {


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
                    Combine1();
                    RaisePropertyChanged("Account_id");
                }
            }
        }
        int account_parent;
        public int Account_parent
        {
            get
            {
                return account_parent;
            }
            set
            {
                if (account_parent != value)
                {
                    account_parent = value;
                    RaisePropertyChanged("Account_parent");
                }
            }
        }
        string account_name;
        public string Account_name
        {
            get
            {
                return account_name;
            }
            set
            {
                if (account_name != value)
                {
                    account_name = value;
                    RaisePropertyChanged("Account_name");
                }
            }
        }
        int account_type;
        public int Account_type
        {
            get
            {
                return account_type;
            }
            set
            {
                if (account_type != value)
                {
                    account_type = value;
                    RaisePropertyChanged("Account_type");
                }
            }
        }
        int account_order;
        public int Account_order
        {
            get
            {
                return account_order;
            }
            set
            {
                if (account_order != value)
                {
                    account_order = value;
                    RaisePropertyChanged("Account_order");
                }
            }
        }
        int account_debtor;
        public int Account_debtor
        {
            get
            {
                return account_debtor;
            }
            set
            {
                if (account_debtor != value)
                {
                    account_debtor = value;
                    RaisePropertyChanged("Account_debtor");
                }
            }
        }
        int account_creditor;
        public int Account_creditor
        {
            get
            {
                return account_creditor;
            }
            set
            {
                if (account_creditor != value)
                {
                    account_creditor = value;
                    RaisePropertyChanged("Account_creditor");
                }
            }
        }
        string string_AccType;
        public string String_AccType
        {
            get
            {
                return string_AccType;
            }
            set
            {
                if (string_AccType != value)
                {if(Account_type==1)
                    string_AccType = "رئيسي";
                  else if(Account_type == 2)
                        string_AccType = "فرعي";
                    Combine1();
                    RaisePropertyChanged("String_AccType");
                }
            }
        }
        string string_Acc;
        public string String_Acc
        {
            get
            {
                return string_Acc;
            }
            set
            {
                if (string_Acc != value)
                {
                    string_Acc = value;
                    Combine1();
                    RaisePropertyChanged("String_Acc");
                }
            }
        }
        string string_AccParent;
        public string String_AccParent
        {
            get
            {
                return string_AccParent;
            }
            set
            {
                if (string_AccParent != value)
                {
                    string_AccParent = value;
                    Combine1();
                    RaisePropertyChanged("String_AccParent");
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
        string account_date;
        public string Account_date
        {
            get
            {
                return account_date;
            }
            set
            {
                if (account_date != value)
                {
                    account_date = value;
                    RaisePropertyChanged("Account_date");
                }
            }
        }
        bool account_status;
        public bool Account_status
        {
            get
            {
                return account_status;
            }
            set
            {
                if (account_status != value)
                {
                    account_status = value;
                    RaisePropertyChanged("Account_status");
                }
            }
        }
        private void Combine1()
        {
            Search = String.Join(" || ", Account_id, String_Acc, String_AccParent,String_AccType);
        }



        public override void CollectErrors()
        {
            Errors.Clear();
            if (Account_id == 0)
            {
                Errors.Add("Account_id", "يجب أن لايكون فارغ أو يحمل القيمة صفر");
            }
            //if (string.IsNullOrEmpty(Username))
            //{
            //    Errors.Add("Username", "يجب أن يكون نص ");
            //}
            if (String.IsNullOrWhiteSpace(Account_name))

            {
                Errors.Add("Account_name", "يجب أن لايكون فارغ ");
            }
            if (Account_order == 0&&Account_order<=Properties.Settings.Default.Account_Order)
            {
                Errors.Add("Account_order", "   "+ Properties.Settings.Default.Account_Order + "  يجب أن لايكون فارغ واصغر من");
            }

        }

      
    }
}
