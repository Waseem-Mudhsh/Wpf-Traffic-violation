using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Commands;
using Wpf_Traffic_violation.Models;
using Wpf_Traffic_violation.Models.Configurations_Model;
using Wpf_Traffic_violation.Models.Violations_Model;
using Wpf_Traffic_violation.Views;

namespace Wpf_Traffic_violation.ViewModel
{
    public class QueryReferenceNumberViewModel : BindableBase

    {

        #region Objects And Variables
        QueryReferenceNumberModel QueryReferenceNumberModel = new QueryReferenceNumberModel();
        Window_PayViolation win;
        Plate_Model Plate_Model = new Plate_Model();
        VoilationModel ViolationModel = new VoilationModel();
        ReceiptModel ReceiptModel;
        VoilationModel VoilationModel;
        EntryModel EntryModel = new EntryModel();
        #endregion
        #region Proprties
        ObservableCollection<Violation> query_Violation;
        public ObservableCollection<Violation> Query_Violation //يربط مع الجرد فيو 
        {
            get
            {
                return query_Violation;
            }
            set
            {
                if (query_Violation != value)
                {
                    query_Violation = value;
                    RaisePropertyChanged("Query_Violation");
                }
            }
        }
        ObservableCollection<Plate> grid_Plate;
        public ObservableCollection<Plate> Grid_Plate //يربط مع الجرد فيو 
        {
            get
            {
                return grid_Plate;
            }
            set
            {
                if (grid_Plate != value)
                {
                    grid_Plate = value;
                    RaisePropertyChanged("Grid_Plate");
                }
            }
        }
        ObservableCollection<Violation> grid_Violation1;
        public ObservableCollection<Violation> Grid_Violation1 //يربط مع الجرد فيو 
        {
            get
            {
                return grid_Violation1;
            }
            set
            {
                if (grid_Violation1 != value)
                {
                    grid_Violation1 = value;
                    RaisePropertyChanged("Grid_Violation1");
                }
            }
        }
        ObservableCollection<Violation> grid_Violation;
        public ObservableCollection<Violation> Grid_Violation //يربط مع الجرد فيو 
        {
            get
            {
                return grid_Violation;
            }
            set
            {
                if (grid_Violation != value)
                {
                    grid_Violation = value;
                    RaisePropertyChanged("Grid_Violation");
                }
            }
        }
        Violation selected_Violation; //selectedItemيربط مع 

        public Violation Selected_Violation
        {
            get
            {
                return selected_Violation;
            }
            set
            {
                if (selected_Violation != value)
                {
                    selected_Violation = value;
                    RaisePropertyChanged("Selected_Violation");
                }
            }
        }
        Violation currunt_Violation; //selectedItemيربط مع 

        public Violation Currunt_Violation
        {
            get
            {
                return currunt_Violation;
            }
            set
            {
                if (currunt_Violation != value)
                {
                    currunt_Violation = value;
                    RaisePropertyChanged("Currunt_Violation");
                }
            }
        }
        int count; //selectedItemيربط مع 
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (count != value)
                {
                    count = value;
                    RaisePropertyChanged("Count");
                }
            }
        }
        int amountSelected;
        public int AmountSelected
        {
            get
            {
                return amountSelected;
            }
            set
            {
                if (amountSelected != value)
                {
                    amountSelected = value;
                    RaisePropertyChanged("AmountSelected");
                }
            }
        }

        int totalAmount; //selectedItemيربط مع 
        public int TotalAmount
        {

            get
            {
                return totalAmount;
            }
            set
            {
                if (totalAmount != value)
                {
                    totalAmount = value;
                    RaisePropertyChanged("TotalAmount");
                }
            }
        }
        int cuontviolation_selected;
        public int Cuontviolation_selected
        {
            get
            {
                return cuontviolation_selected;
            }
            set
            {
                if (cuontviolation_selected != value)
                {
                    cuontviolation_selected = value;
                    RaisePropertyChanged("Cuontviolation_selected");
                }
            }
        }
        Receipt current_Receipt;
        public Receipt Current_Receipt
        {
            get
            {
                return current_Receipt;
            }
            set
            {
                if (current_Receipt != value)
                {
                    current_Receipt = value;
                    RaisePropertyChanged("Current_Receipt");
                }
            }
        }

        #endregion
        #region Construcor
        public QueryReferenceNumberViewModel()
        {
            Grid_Plate = new ObservableCollection<Plate>();
            Plate_Model.GetPlates(Grid_Plate);
            Query_Violation = new ObservableCollection<Violation>();
            ViolationModel.GetViolation(Query_Violation);
            Showcommand = new RelayCommand(Par => Show(), Par => CanShow());
            Paycommand = new RelayCommand(Par => Pay(), Par => CanPay());
            ConfimPaycommand = new RelayCommand(Par => Confimpay(), Par => CanConfimpay());

            //This Bind with Button Add
            //Editcommand = new RelayCommand(par => Edit(), par => CanEdit());
            //Deletecommand = new RelayCommand(par => Delet(), par => CanDelet());
            //Savecommand = new RelayCommand(par => Save(), par => CanSave());
            //Closecommand = new RelayCommand(par => close());
            //Excelcommand = new RelayCommand(par => GetExcel());
        }
        #endregion
        #region Methodes And Events
        void Show()
        {
            TotalAmount = 0;

            Grid_Violation = new ObservableCollection<Violation>();
            QueryReferenceNumberModel.GetViolation(Grid_Violation, Selected_Violation.Violation_id);
            Count = Grid_Violation.Count;
           
            TotalAmount = Selected_Violation.Amount + Selected_Violation.Violation_penalty;
          


        }
        bool CanShow() => Selected_Violation != null;
        void Pay()
        {


            AmountSelected = 0;
            Cuontviolation_selected = 0;
            Grid_Violation1 = new ObservableCollection<Violation>();
          //  Grid_Violation1 = Grid_Violation;
            foreach (Violation a in Grid_Violation)
            {
                if (a.Isselected == true)
                { Grid_Violation1.Add(a);
                    Cuontviolation_selected = 1;
                    AmountSelected = a.Amount + a.Violation_penalty;
                }
            }


        Current_Receipt = new Receipt
            {

                Receipt_id = new Class_SqlConnection().Get_Max("Receipt"),
                //Account_id = Selected_Plate.Account_id,
                Receipt_amount = AmountSelected,
                Receipt_status = false,
                Receipt_date = DateTime.Now.Date.ToString(),
                Post_date = ""

            };

            win = new Window_PayViolation { DataContext = this };
            win.datep.Text = DateTime.Now.Date.ToString();
            //MessageBox.Show(date.Date.ToString());
            if (Cuontviolation_selected > 0)
                win.ShowDialog();

        }
        bool CanPay() => Currunt_Violation != null;

        public void Confimpay()
        {
            int x = 1;
            ReceiptModel = new ReceiptModel();
            VoilationModel = new VoilationModel();
             int amount;
                foreach (Violation v in Grid_Violation1)
                {
                    amount = v.Amount + v.Violation_penalty;
                    ReceiptModel.OperarionReceiptdetail(x, Current_Receipt.Receipt_id, v.String_ViolationType, v.Violation_id, amount,"Insert");

                    v.Payment_status = 1;
                    VoilationModel.OperarionViolation(v, "Update");
                    foreach (Plate aa in Grid_Plate)
                    {
                        if (aa.Plate_id == v.Plate_id)
                        {
                        Current_Receipt.Receipt_id = new Class_SqlConnection().Get_Max("Receipt");
                        Current_Receipt.Account_id = aa.Account_id;
                        Current_Receipt.Receipt_amount = amount;
                        ReceiptModel.OperarionReceipt(Current_Receipt, "Insert");
                        ReceiptModel.OperarionReceiptdetail(new Class_SqlConnection().Get_Max("Receipt_detail"), Current_Receipt.Receipt_id, v.String_ViolationType, v.Violation_id, amount, "Insert");

                        EntryModel.AddEntry(new Class_SqlConnection().Get_Max("Entry"), Current_Receipt.Receipt_statement, Current_Receipt.Receipt_date, 111101, aa.Account_id, v.Amount + v.Violation_penalty);
                        }
                    }

                    x++;
                }


                MessageBox.Show("تمت عملية السداد بنجاح");
            win.Close();
            Grid_Violation.Clear();
            QueryReferenceNumberModel.GetViolation(Grid_Violation, Selected_Violation.Violation_id);


        }
        bool CanConfimpay() => Current_Receipt != null;

        #endregion
        #region Commands
        public RelayCommand Showcommand { get; private set; }
        public RelayCommand Paycommand { get; private set; }
        public RelayCommand ConfimPaycommand { get; private set; }
        #endregion





        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
