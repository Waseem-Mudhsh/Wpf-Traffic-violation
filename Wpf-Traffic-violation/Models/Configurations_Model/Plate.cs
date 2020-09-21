using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class Plate : BindableBase
    {
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
        string release_date;
        public string Release_date
        {
            get
            {
                return release_date;
            }
            set
            {
                if (release_date != value)
                {
                    release_date = value;
                    RaisePropertyChanged("Release_date");
                }
            }
        }
        int vehicle_id;
        public int Vehicle_id
        {
            get
            {
                return vehicle_id;
            }
            set
            {
                if (vehicle_id != value)
                {
                    vehicle_id = value;
                    Combine1();
                    RaisePropertyChanged("Vehicle_id");
                }
            }
        }
        string plate_num;
        public string Plate_num
        {
            get
            {
                return plate_num;
            }
            set
            {
                if (plate_num != value)
                {
                    plate_num = value;
                    Combine1();
                    RaisePropertyChanged("Plate_num");
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
        int plate_type;
        public int Plate_type
        {
            get
            {
                return plate_type;
            }
            set
            {
                if (plate_type != value)
                {
                    plate_type = value;
                    RaisePropertyChanged("Plate_type");
                }
            }
        }
        string string_Plate_type;
        public string String_Plate_type
        {
            get
            {
                return string_Plate_type;
            }
            set
            {
                if (string_Plate_type != value)
                {
                    string_Plate_type = value;
                    Combine1();
                    RaisePropertyChanged("String_Plate_type");
                }
            }
        }
        int province_id;
        public int Province_id
        {
            get
            {
                return province_id;
            }
            set
            {
                if (province_id != value)
                {
                    province_id = value;
                    RaisePropertyChanged("Province_id");
                }
            }
        }
        string province_name;
        public string Province_name
        {
            get
            {
                return province_name;
            }
            set
            {
                if (province_name != value)
                {
                    province_name = value;
                    RaisePropertyChanged("Province_name");
                }
            }
        }


        int status;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                if (status != value)
                {
                    status = value;
                    RaisePropertyChanged("Status");
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
        int plate_num_separator;
        public int Plate_num_separator
        {
            get
            {
                return plate_num_separator;
            }
            set
            {
                if (plate_num_separator != value)
                {
                    plate_num_separator = value;
                   // Combine();
                    RaisePropertyChanged("Plate_num_separator");
                }
            }
        }
        int plate_num_Remainder;
        public int Plate_num_Remainder
        {
            get
            {
                return plate_num_Remainder;
            }
            set
            {
                if (plate_num_Remainder != value)
                {
                    plate_num_Remainder = value;
                    //Combine();
                    RaisePropertyChanged("Plate_num_Remainder");
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

       
        private void Combine1()
        {
            Search = String.Join(" || ", Vehicle_id.ToString(), Plate_num, String_Plate_type,string_Status);
        }

        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
