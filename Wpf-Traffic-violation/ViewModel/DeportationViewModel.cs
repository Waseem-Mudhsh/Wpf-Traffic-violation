using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Account_Mode;
using Wpf_Traffic_violation.Models.Account_Model;

namespace Wpf_Traffic_violation.ViewModel
{
    public class DeportationViewModel : BindableBase
    {

        #region Objects And Variables
        DeportationModel DeportationModel=new DeportationModel();
        ReceiptModel ReceiptModel = new ReceiptModel();
        BondOfExchangeModel BondOfExchangeModel = new BondOfExchangeModel();
        EntryModel EntryModel = new EntryModel();
        #endregion
        #region Proprties
        ObservableCollection<BondOfExchange> grid_BondOfExchange;
        public ObservableCollection<BondOfExchange> Grid_BondOfExchange
        {
            get
            {
                return grid_BondOfExchange;
            }
            set
            {
                if (grid_BondOfExchange != value)
                {
                    grid_BondOfExchange = value;
                    RaisePropertyChanged("Grid_BondOfExchange");
                }
            }
        }
        ObservableCollection<Receipt> grid_Receipt;
        public ObservableCollection<Receipt>  Grid_Receipt
        {
            get
            {
                return grid_Receipt;
            }
            set
            {
                if (grid_Receipt != value)
                {
                    grid_Receipt = value;
                    RaisePropertyChanged("Grid_Receipt");
                }
            }
        }

        Receipt selected_Receipt;
        public Receipt Selected_Receipt
        {
            get
            {
                return selected_Receipt;
            }
            set
            {
                if (selected_Receipt != value)
                {
                    selected_Receipt = value;
                    RaisePropertyChanged("Selected_Receipt");
                }
            }
        }

        BondOfExchange selected_BondOfExchange;
        public BondOfExchange Selected_BondOfExchange
        {
            get
            {
                return selected_BondOfExchange;
            }
            set
            {
                if (selected_BondOfExchange != value)
                {
                    selected_BondOfExchange = value;
                    RaisePropertyChanged("Selected_BondOfExchange");
                }
            }
        }

        bool is_Receipt;
        public bool Is_Receipt
        {
            get
            {
                return is_Receipt;
            }
            set
            {
                if (is_Receipt != value)
                {
                    is_Receipt = value;
                    RaisePropertyChanged("Is_Receipt");
                }
            }
        }


        bool is_day;
        public bool Is_day
        {
            get
            {
                return is_day;
            }
            set
            {
                if (is_day != value)
                {
                    is_day = value;
                    RaisePropertyChanged("Is_day");
                }
            }
        }

        bool is_date;
        public bool Is_date
        {
            get
            {
                return is_date;
            }
            set
            {
                if (is_date != value)
                {
                    is_date = value;
                    RaisePropertyChanged("Is_date");
                }
            }
        }


        string fromDate;
        public string FromDate
        {
            get
            {
                return fromDate;
            }
            set
            {
                if (fromDate != value)
                {
                    fromDate = value;
                    RaisePropertyChanged("FromDate");
                }
            }
        }
        string toDate;
        public string ToDate
        {
            get
            {
                return toDate;
            }
            set
            {
                if (toDate != value)
                {
                    toDate = value;
                    RaisePropertyChanged("ToDate");
                }
            }
        }
        string date_day;
        public string Date_day
        {
            get
            {
                return date_day;
            }
            set
            {
                if (date_day != value)
                {
                    date_day = value;
                    RaisePropertyChanged("Date_day");
                }
            }
        }

        int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }




        #endregion
        #region Construcor
        public DeportationViewModel()
        {
            Grid_BondOfExchange = new ObservableCollection<BondOfExchange>();
            Grid_Receipt = new ObservableCollection<Receipt>();

            Showcommand = new RelayCommand(par => Show());
            Deportationcommand = new RelayCommand(par => Deportation());
            CancelDeportationcommand = new RelayCommand(par => CancelDeportation());

        }
        #endregion
        #region Methodes And Events
        void Show()
        {
            SqlParameter[] param = new SqlParameter[6];
            if (Is_Receipt==true)
            {
                Grid_Receipt = new ObservableCollection<Receipt>();

                param[0] = new SqlParameter("@type", SqlDbType.NVarChar,50)
                {
                    Value = "Receipt"
                };
                
                if (Is_day==true)
                {
                    param[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value ="day"
                    };
                    param[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = Date_day
                    };
                    param[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = Date_day
                    };
                    param[5] = new SqlParameter("@id", SqlDbType.NVarChar, 50)
                    {
                        Value = 1
                    };
                    MessageBox.Show(Date_day);
                }
                else if(Is_date==true)
                {
                    param[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "date"
                    };
                    param[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = FromDate
                    };
                    param[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = ToDate
                    };
                    param[5] = new SqlParameter("@id", SqlDbType.NVarChar, 50)
                    {
                        Value = 1
                    };
                }
                else
                {
                    param[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "id"
                    };
                    param[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = Id
                    };
                    param[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = ""
                    };
                    param[5] = new SqlParameter("@id", SqlDbType.NVarChar, 50)
                    {
                        Value = Id
                    };

                }
                param[4] = new SqlParameter("@as", SqlDbType.Int)
                {
                    Value = Properties.Settings.Default.Deportationtype
                };
                DeportationModel.GetReceipt_Deportation(Grid_Receipt,param);
            }
            else
            {
                Grid_BondOfExchange = new ObservableCollection<BondOfExchange>();
                param[0] = new SqlParameter("@type", SqlDbType.NVarChar, 50)
                {
                    Value = "BondOfExchange"
                };
                if (Is_day == true)
                {
                    param[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "day"
                    };
                    param[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = Date_day
                    };
                    param[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = Date_day
                    };
                    param[5] = new SqlParameter("@id", SqlDbType.NVarChar, 50)
                    {
                        Value = 1
                    };
                }
                else if (Is_date == true)
                {
                    param[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "date"
                    };
                    param[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = FromDate
                    };
                    param[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = ToDate
                    };
                    param[5] = new SqlParameter("@id", SqlDbType.NVarChar, 50)
                    {
                        Value = 1
                    };
                }
                else
                {
                    param[1] = new SqlParameter("@date", SqlDbType.NVarChar, 50)
                    {
                        Value = "id"
                    };
                    param[2] = new SqlParameter("@fromdate", SqlDbType.NVarChar, 50)
                    {
                        Value = Id
                    };
                    param[3] = new SqlParameter("@todate", SqlDbType.NVarChar, 50)
                    {
                        Value = id
                    };
                    param[5] = new SqlParameter("@id", SqlDbType.NVarChar, 50)
                    {
                        Value = Id
                    };

                }
                param[4] = new SqlParameter("@as", SqlDbType.Int)
                {
                    Value = Properties.Settings.Default.Deportationtype
                };
                DeportationModel.GetBondOfExchanges_Deportation(Grid_BondOfExchange, param);
            }
        }
        
        void Deportation()
        {
            int x = 0;
           if(Is_Receipt==true && Grid_Receipt!=null)
            {
            foreach(Receipt a in Grid_Receipt)
                {
                    if (a.IsSelected == true)
                    {
                        a.Receipt_status = true;
                        a.Post_date = DateTime.Now.Date.ToString(); 
                        ReceiptModel.OperarionReceipt(a, "Update");
                        EntryModel.AddEntry(new Class_SqlConnection().Get_Max("Entry"), a.Receipt_statement, DateTime.Now.Date.ToString(), 111101, a.Account_id, a.Receipt_amount);
                 
                        x++;
                    }
                }
            } 
            else
            {
                foreach (BondOfExchange a in Grid_BondOfExchange)
                {
                    if (a.IsSelected == true)
                    {
                        a.Bond_Exchange_status = true;
                        a.Post_date = DateTime.Now.Date.ToString();
                        BondOfExchangeModel.OperarionBondOfExchange(a, null, "Update");
                        EntryModel.AddEntry(new Class_SqlConnection().Get_Max("Entry"), a.Bond_Exchange_statement, DateTime.Now.Date.ToString(),a.Account_to_id, 111101, a.Bond_Exchange_amount);

                        x++;
                    }
                }

            }
            Show();
        }
        void CancelDeportation()
        {
            int x = 0;
            if (Is_Receipt == true && Grid_Receipt != null)
            {

                foreach (Receipt a in Grid_Receipt)
            {
                if (a.IsSelected == true)
                {
                        MessageBox.Show(a.Post_date);
                        EntryModel.DeleteEntry(111101, a.Account_id, a.Post_date);
                        a.Receipt_status = false;
                        a.Post_date = "-";
                        ReceiptModel.OperarionReceipt(a, "Update");
                   

                    x++;
                }
            }
        } 
            else
            {
                foreach (BondOfExchange a in Grid_BondOfExchange)
                {
                    if (a.IsSelected == true)
                    {
                        
                        EntryModel.DeleteEntry(111101,a.Account_to_id,a.Post_date);
                        a.Bond_Exchange_status = false;
                        a.Post_date = "-";
                        BondOfExchangeModel.OperarionBondOfExchange(a, null,"Update");
                        
                        x++;
                    }
}

            }
            Show();

        }
        #endregion
        #region Commands
        public RelayCommand Showcommand { get; private set; }
        public RelayCommand Deportationcommand { get; private set; }
        public RelayCommand CancelDeportationcommand { get; private set; }

        #endregion









        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
