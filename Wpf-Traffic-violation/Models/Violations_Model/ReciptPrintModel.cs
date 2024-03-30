using System;
using System.Collections.Generic;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class ReceiptPrintModel : BindableBase
    {
        private int _receiptId;
        private string _vehicleId;
        private int _violationPenalty;
        private string _paymentStatus;
        private string _violationTypeName;
        private string _vehicleTypeName;
        private int _VounchrNum;
        private string _nameOfPaid;
        private string _reasonOfPaid;
        private string _to; private
            string _dateOfReceipt;
        private int _countOfType;
        private List<KeyValuePair<string, int>> _violationsType = new List<KeyValuePair<string, int>>();

        public int ReceiptId
        {
            get { return _receiptId; }
            set
            {
                _receiptId = value;
                RaisePropertyChanged("ReceiptId");
            }
        }
        public int VounchrNum
        {
            get { return _VounchrNum; }
            set
            {
                _VounchrNum = value;
                RaisePropertyChanged("VounchrNum");
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

        public string VehicleTypeName
        {
            get { return _violationTypeName; }
            set
            {
                _violationTypeName = value;
                RaisePropertyChanged("VehicleTypeName");
            }
        }

        public int ViolationPenalty
        {
            get { return _violationPenalty; }
            set
            {
                _violationPenalty = value;
                RaisePropertyChanged("ViolationPenalty");
            }
        }

        public string PaymentStatus
        {
            get { return _paymentStatus; }
            set
            {
                _paymentStatus = value;
                RaisePropertyChanged("PaymentStatus");
            }
        }

        public List<KeyValuePair<string, int>> ViolationType
        {
            get { return _violationsType; }
            set
            {
                if (value.Count != 0)
                {
                    foreach (var i in value)
                        _violationsType.Add(i);
                    RaisePropertyChanged("_violationsTypeSelected");
                }
            }
        }

        public string NameOfPaid
        {
            get { return _nameOfPaid; }
            set
            {
                if (_nameOfPaid != value)
                {
                    _nameOfPaid = value;
                    RaisePropertyChanged("NameOfPaid");
                }
            }
        }

        public string ReasonOfPaid
        {
            get { return _reasonOfPaid; }
            set
            {
                if (_reasonOfPaid != value)
                {
                    _reasonOfPaid = value;
                    RaisePropertyChanged("ReasonOfPaid");
                }
            }
        }

        public string DateOfReceipt
        {
            get { return _dateOfReceipt; }
            set
            {
                _dateOfReceipt = value;
                RaisePropertyChanged("_dateOfReceipt");
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

        public int CountOfType
        {
            get
            {
                return _countOfType;
            }
            set
            {
                if (_countOfType != value)
                {
                    _countOfType = value;
                    RaisePropertyChanged("_countOfType");
                }
            }
        }
        private string _detalsForOldViolation;
        public string DetalsForOldViolation
        {
            get
            {
                return _detalsForOldViolation;
            }
            set
            {
                if (_detalsForOldViolation != value)
                {
                    _detalsForOldViolation = value;
                    RaisePropertyChanged("DetalsForOldViolation");
                }
            }
        }
        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}