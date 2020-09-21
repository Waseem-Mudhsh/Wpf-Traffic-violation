using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Account_Model
{
    public class BondOfExchange : BindableBase
    {
        int Bond_exchange_id;
        public int Bond_Exchange_id
        {
            get
            {
                return Bond_exchange_id;
            }
            set
            {
                if (Bond_exchange_id != value)
                {
                    Bond_exchange_id = value;
                    RaisePropertyChanged("Bond_Exchange_id");
                }
            }
        }
        string bond_Exchange_date;
        public string Bond_Exchange_date
        {
            get
            {
                return bond_Exchange_date;
            }
            set
            {
                if (bond_Exchange_date != value)
                {
                    bond_Exchange_date = value;
                    RaisePropertyChanged("Bond_Exchange_date");
                }
            }
        }

        int account_from_id;
        public int Account_from_id
        {
            get
            {
                return account_from_id;
            }
            set
            {
                if (account_from_id != value)
                {
                    account_from_id = value;
                    RaisePropertyChanged("Account_from_id");
                }
            }
        }
        int account_to_id;
        public int Account_to_id
        {
            get
            {
                return account_to_id;
            }
            set
            {
                if (account_to_id != value)
                {
                    account_to_id = value;
                    RaisePropertyChanged("Account_to_id");
                }
            }
        }


        string bond_Exchange_statement;
        public string Bond_Exchange_statement
        {
            get
            {
                return bond_Exchange_statement;
            }
            set
            {
                if (bond_Exchange_statement != value)
                {
                    bond_Exchange_statement = value;
                    RaisePropertyChanged("Bond_Exchange_statement");
                }
            }
        }
        int bond_Exchange_amount;
        public int Bond_Exchange_amount
        {
            get
            {
                return bond_Exchange_amount;
            }
            set
            {
                if (bond_Exchange_amount != value)
                {
                    bond_Exchange_amount = value;
                    RaisePropertyChanged("Bond_Exchange_amount");
                }
            }
        }
        bool bond_Exchange_status;
        public bool Bond_Exchange_status
        {
            get
            {
                return bond_Exchange_status;
            }
            set
            {
                if (bond_Exchange_status != value)
                {
                    bond_Exchange_status = value;
                    RaisePropertyChanged("Bond_Exchange_status");
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
        int reference_number;
        public int Reference_number
        {
            get
            {
                return reference_number;
            }
            set
            {
                if (reference_number != value)
                {
                    reference_number = value;
                    RaisePropertyChanged("Reference_number");
                }
            }
        }
        string string_Accountfrom;
        public string String_Accountfrom
        {
            get
            {
                return string_Accountfrom;
            }
            set
            {
                if (string_Accountfrom != value)
                {
                    string_Accountfrom = value;
                    RaisePropertyChanged("String_Accountfrom");
                }
            }
        }
        string string_Accountto;
        public string String_Accountto
        {
            get
            {
                return string_Accountto;
            }
            set
            {
                if (string_Accountto != value)
                {
                    string_Accountto = value;
                    RaisePropertyChanged("String_Accountto");
                }
            }
        }









        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
