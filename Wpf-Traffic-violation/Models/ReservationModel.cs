using System;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{


    public class ReservationModel : BindableBase
    {
        private int _id;
        private string _nameDriver;
        private int _vehicleId;
        private int _plateTypeId;
        private string _vehicleType;
        private string _reasonReservation;
        private DateTime _dateOfReservation;
        private DateTime _dateOfRelease;
        private DateTime _dateOfreceipt;
        private int _receiptId;
        private decimal _amount;
        private string _releaseSide;
        private string _seatNumber;
        private string _notes;
        private Boolean isEnter;
        private Boolean isRelease;


        public int ID
        {
            get => _id;
            set => SetProperty(_id, value, "ID");
        }

        public DateTime DateOfreceipt
        {
            get => DateOfreceipt;
            set => SetProperty(_dateOfreceipt, value, "DateOfreceipt");
        }
        public string NameDriver
        {
            get => _nameDriver;
            set => SetProperty(_nameDriver, value, "NameDriver");
        }
        public Boolean IsRelease
        {
            get => IsRelease;
            set => SetProperty(isRelease, value, "IsRelease");
        }
        public Boolean IsEnter
        {
            get => isEnter;
            set => SetProperty(isEnter, value, "IsEnter");
        }
        public int VehicleId
        {
            get => _vehicleId;
            set => SetProperty(_vehicleId, value, "VehicleId");
        }

        public int PlateTypeId
        {
            get => _plateTypeId;
            set => SetProperty(_plateTypeId, value, "PlateTypeId");
        }

        public string VehicleType
        {
            get => _vehicleType;
            set => SetProperty(_vehicleType, value, "VehicleType");
        }

        public string ReasonReservation
        {
            get => _reasonReservation;
            set => SetProperty(_reasonReservation, value, "ReasonReservation");
        }

        public DateTime DateOfReservation
        {
            get => _dateOfReservation;
            set => SetProperty(_dateOfReservation, value, "DateOfReservation");
        }

        public DateTime DateOfRelease
        {
            get => _dateOfRelease;
            set => SetProperty(_dateOfRelease, value, "DateOfRelease");
        }

        public int ReceiptId
        {
            get => _receiptId;
            set => SetProperty(_receiptId, value, "ReceiptId");
        }

        public decimal Amount
        {
            get => _amount;
            set => SetProperty(_amount, value, "Amount");
        }

        public string ReleaseSide
        {
            get => _releaseSide;
            set => SetProperty(_releaseSide, value, "ReleaseSide");
        }

        public string SeatNumber
        {
            get => _seatNumber;
            set => SetProperty(_seatNumber, value, "SeatNumber");
        }

        public string Notes
        {
            get => _notes;
            set => SetProperty(_notes, value, "Notes");
        }

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }

        private void SetProperty(object propData, object value, string PropName)
        {
            if (propData != value)
            {
                propData = value;
                RaisePropertyChanged(PropName);
            }
        }
    }

}
