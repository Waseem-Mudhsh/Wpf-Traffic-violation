using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.MagrationDB;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public  class ReceiptReportModel: BindableBase
    {
            private int _receiptId;
            private string _vehicleId;
            private int  _violationPenalty;
            private int _paymentStatus;
            private string _violationTypeName;
            private int _violationTypcount;
            private string _nameOfPaid;
            private string _reasonOfPaid;
            private string _to; 
            private string _from;
            private string _plateType;
            private int _provinceid;
        


            public int ReceiptId
            {
                get { return _receiptId; }
                set
                {
                    _receiptId = value;
                    RaisePropertyChanged("ReceiptId");
                }
            }

            public string VehicleId
            {
                get { return _vehicleId; }
                set
                {
                    _vehicleId = value;
                
                    RaisePropertyChanged("VehicleId");
                }
            }

            public int  ViolationPenalty
            {
                get { return _violationPenalty; }
                set
                {
                    _violationPenalty = value;
     
                    RaisePropertyChanged("ViolationPenalty");
                }
            }

      

   


        public int PaymentStatus
            {
                get { return _paymentStatus; }
                set
                {
                    _paymentStatus = value;
                    RaisePropertyChanged("PaymentStatus");
                }
            }
        public int ViolationTypcount
        {
            get { return _violationTypcount; }
            set
            {
                _violationTypcount = value;
   
                RaisePropertyChanged("ViolationTypcount");
            }
        }



        public string ViolationTypeName
            {
                get { return _violationTypeName; }
                set
                {
                    _violationTypeName = value;
                    RaisePropertyChanged("ViolationTypeName");
                }
            }

            public string NameOfPaid
            {
                get { return _nameOfPaid; }
                set
                {
                    _nameOfPaid = value;
                    RaisePropertyChanged("NameOfPaid");
                }
            }

            public string ReasonOfPaid
            {
                get { return _reasonOfPaid; }
                set
                {
                    _reasonOfPaid = value;
                    RaisePropertyChanged("ReasonOfPaid");
                }
            }
        public string PlateType
        {
            get { return _plateType; }
            set
            {
                _plateType = value;
                RaisePropertyChanged("PlateType");
            }
        }
        public int Provinceid
        {
            get { return _provinceid; }
            set
            {
                _provinceid = value;
                RaisePropertyChanged("Provinceid");
            }
        }
        public string From
        {
            get { return _from; }
            set
            {
                _from = value;
                RaisePropertyChanged("from");
            }
        }
        public string To
        {
            get { return _to; }
            set
            {
                _to = value;
                RaisePropertyChanged("_to");
            }
        }

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }

    }
