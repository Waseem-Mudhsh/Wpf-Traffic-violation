using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class Violation : BindableBase
    {
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
                    violation_id = value;
                    Combine1();
                    RaisePropertyChanged("Violation_id");
                }
            }
        }
        string violation_date;
        public string Violation_date
        {
            get
            {
                return violation_date;
            }
            set
            {
                if (violation_date != value)
                {
                    violation_date = value;
                    RaisePropertyChanged("Violation_date");
                }
            }
        }
        int vounchrNum;
        public int VounchrNum
        {
            get
            {
                return vounchrNum;
            }
            set
            {
                if (vounchrNum != value)
                {
                    vounchrNum = value;
                    RaisePropertyChanged("VounchrNum");
                }
            }
        }
        byte violation_photo1;
        public byte Violation_photo1
        {
            get
            {
                return violation_photo1;
            }
            set
            {
                if (violation_photo1 != value)
                {
                    violation_photo1 = value;
                    RaisePropertyChanged("Violation_photo1");
                }
            }
        }
        byte violation_photo2;
        public byte Violation_photo2
        {
            get
            {
                return violation_photo2;
            }
            set
            {
                if (violation_photo2 != value)
                {
                    violation_photo2 = value;
                    RaisePropertyChanged("Violation_photo2");
                }
            }
        }
        int plate_id;
        public int Plate_id
        {
            get
            {
                return plate_id;
            }
            set
            {
                if (plate_id != value)
                {
                    plate_id = value;
                    RaisePropertyChanged("Plate_id");
                }
            }
        }
        int street_id;
        public int Street_id
        {
            get
            {
                return street_id;
            }
            set
            {
                if (street_id != value)
                {
                    street_id = value;
                    RaisePropertyChanged("Street_id");
                }
            }
        }
        int teaffic_man_id;
        public int Teaffic_man_id
        {
            get
            {
                return teaffic_man_id;
            }
            set
            {
                if (teaffic_man_id != value)
                {
                    teaffic_man_id = value;
                    RaisePropertyChanged("Teaffic_man_id");
                }
            }
        }
        int violation_type_id;
        public int Violation_type_id
        {
            get
            {
                return violation_type_id;
            }
            set
            {
                if (violation_type_id != value)
                {
                    violation_type_id = value;
                    RaisePropertyChanged("Violation_type_id");
                }
            }
        }
        string notise;
        public string Notise
        {
            get
            {
                return notise;
            }
            set
            {
                if (notise != value)
                {
                    notise = value;
                    RaisePropertyChanged("Notise");
                }
            }
        }
        int violation_penalty;
        public int Violation_penalty
        {
            get
            {
                return violation_penalty;
            }
            set
            {
                if (violation_penalty != value)
                {
                    violation_penalty = value;
                    RaisePropertyChanged("Violation_penalty");
                }
            }
        }
        int payment_status;
        public int Payment_status
        {
            get
            {
                return payment_status;
            }
            set
            {
                if (payment_status != value)
                {
                    payment_status = value;
                    RaisePropertyChanged("Payment_status");
                }
            }
        }
        string plate_Num;
        public string Plate_Num
        {
            get
            {
                return plate_Num;
            }
            set
            {
                if (plate_Num != value)
                {
                    plate_Num = value;
                    RaisePropertyChanged("Plate_Num");
                }
            }
        }
        string plate_Type;
        public string Plate_Type
        {
            get
            {
                return plate_Type;
            }
            set
            {
                if (plate_Type != value)
                {
                    plate_Type = value;
                    RaisePropertyChanged("Plate_Type");
                }
            }
        }
        int plate_TypeId;
        public  int Plate_TypeId

        {
            get
            {
                return plate_TypeId;
            }
            set
            {
                if (plate_TypeId != value)
                {
                    plate_TypeId = value;
                    RaisePropertyChanged("plate_TypeId");
                }
            }
        }
        string string_ViolationType;
        public string String_ViolationType
        {
            get
            {
                return string_ViolationType;
            }
            set
            {
                if (string_ViolationType != value)
                {
                    string_ViolationType = value;
                    Combine1();
                    RaisePropertyChanged("String_ViolationType");
                }
            }
        }
        string string_plateDetail;
        public string String_PlateDetail
        {
            get
            {
                return string_plateDetail;
            }
            set
            {
                if (string_plateDetail != value)
                {
                    string_plateDetail = value;
                    Combine1();
                    RaisePropertyChanged("string_plateDetail");
                }
            }
        }
        string string_TrafficMan;
        public string String_TrafficMan
        {
            get
            {
                return string_TrafficMan;
            }
            set
            {
                if (string_TrafficMan != value)
                {
                    string_TrafficMan = value;
                    Combine1();
                    RaisePropertyChanged("String_TrafficMan");
                }
            }
        }
        string string_Status;
        public string String_Status
        {
            get
            {
                return string_Status;
            }
            set
            {
                if (string_Status != value)
                {
                    string_Status = value;
                    Combine1();
                    RaisePropertyChanged("String_Status");
                }
            }
        }
        string string_Street;
        public string String_Street
        {
            get
            {
                return string_Street;
            }
            set
            {
                if (string_Street != value)
                {
                    string_Street = value;
                    
                    RaisePropertyChanged("String_Street");
                }
            }
        }
     
        int amount;
        public int Amount
        {
            get
            {
                return  amount;
            }
            set
            {
                if ( amount != value)
                {
                     amount = value;
                    RaisePropertyChanged("Amount");
                }
            }
        }
        int new_amount;
        public int New_amount
        {
            get
            {
                return new_amount;
            }
            set
            {
                if (new_amount != value)
                {
                    new_amount = value;
                    RaisePropertyChanged("New_amount");
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
        bool isselected;
        public bool Isselected
        {
            get
            {
                return isselected;
            }
            set
            {
                if (isselected != value)
                {
                    isselected = value;
                    RaisePropertyChanged("Isselected");
                }
            }
        }
        private bool _selectAll;

        public bool SelectAll
        {
            get { return _selectAll; }
            set
            {
                if (_selectAll != value)
                {
                    _selectAll = value;
                    RaisePropertyChanged(nameof(SelectAll));

                    // Set the IsSelected property for all items in your collection
                    //foreach (Violation item in Grid_Violation)
                    //{
                    //    item.Isselected = value;
                    //}
                }
            }
        }
        string createdOn;
        public string CreatedOn
        {
            get
            {
                return createdOn;
            }
            set
            {
                if (createdOn != value)
                {
                    createdOn = value;
                    Combine1();
                    RaisePropertyChanged("createdOn");
                }
            }
        }
        int createdBy;
        public int CreatedBy
        {
            get
            {
                return createdBy;
            }
            set
            {
                if (createdBy != value)
                {
                    createdBy = value;
                    Combine1();
                    RaisePropertyChanged("createdBy");
                }
            }
        }

        string updateOn;
        public string UpdateOn
        {
            get
            {
                return updateOn;
            }
            set
            {
                if (updateOn != value)
                {
                    updateOn = value;
                    Combine1();
                    RaisePropertyChanged("updateOn");
                }
            }
        }
        int updateBy;
        public int UpdateBy
        {
            get
            {
                return updateBy;
            }
            set
            {
                if (updateBy != value)
                {
                    updateBy = value;
                    Combine1();
                    RaisePropertyChanged("updateBy");
                }
            }
        }
        int provinceid;
        public int Provinceid
        {
            get
            {
                return provinceid;
            }
            set
            {
                if (provinceid != value)
                {
                    provinceid = value;
                    Combine1();
                    RaisePropertyChanged("provinceid");
                }
            }
        }

        private void Combine1()
        {
            Search = String.Join(" || ", Violation_id, String_ViolationType, String_TrafficMan,String_Status, String_PlateDetail);
        }







        public override void CollectErrors()
        {
            Errors.Clear();
            if (string.IsNullOrWhiteSpace(Violation_date))
            {
                Errors.Add("Violation_date", "يجب تحدبد التاريخ");
            }
          

        }

      
    }
}
