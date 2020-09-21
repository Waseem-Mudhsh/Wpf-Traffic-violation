using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Account_Model
{
    public class Bond_Exchange_detail : BindableBase
    {
        int bond_Exchange_detail_id;
        public int Bond_Exchange_detail_id
        {
            get
            {
                return bond_Exchange_detail_id;
            }
            set
            {
                if (bond_Exchange_detail_id != value)
                {
                    bond_Exchange_detail_id = value;
                    RaisePropertyChanged("Bond_Exchange_detail_id");
                }
            }
        }

        int bond_Exchange_id;
        public int Bond_Exchange_id
        {
            get
            {
                return bond_Exchange_id;
            }
            set
            {
                if (bond_Exchange_id != value)
                {
                    bond_Exchange_id = value;
                    RaisePropertyChanged("Bond_Exchange_id");
                }
            }
        }
        string bond_Exchange_detail_statement;
        public string Bond_Exchange_detail_statement
        {
            get
            {
                return bond_Exchange_detail_statement;
            }
            set
            {
                if (bond_Exchange_detail_statement != value)
                {
                    bond_Exchange_detail_statement = value;
                    RaisePropertyChanged("Bond_Exchange_detail_statement");
                }
            }
        }
        int bond_Exchange_detail_amount;
        public int Bond_Exchange_detail_amount
        {
            get
            {
                return bond_Exchange_detail_amount;
            }
            set
            {
                if (bond_Exchange_detail_amount != value)
                {
                    bond_Exchange_detail_amount = value;
                    RaisePropertyChanged("Bond_Exchange_detail_amount");
                }
            }
        }








        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
