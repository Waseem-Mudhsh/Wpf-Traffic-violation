using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class Vehicle : BindableBase
    {
        int vehicle_card_id;
        public int Vehicle_card_id
        {
            get
            {
                return vehicle_card_id;
            }
            set
            {
                if (vehicle_card_id != value)
                {
                    vehicle_card_id = value;
                       Combine1();
                    RaisePropertyChanged("Vehicle_card_id");
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

        int release_plase;
        public int Release_plase
        {
            get
            {
                return release_plase;
            }
            set
            {
                if (release_plase != value)
                {
                    release_plase = value;
                    RaisePropertyChanged("Release_plase");
                }
            }
        }


        int citizen_id;
        public int Citizen_id
        {
            get
            {
                return citizen_id;
            }
            set
            {
                if (citizen_id != value)
                {
                    citizen_id = value;
                    RaisePropertyChanged("Citizen_id");
                }
            }
        }

        string noties;
        public string Noties
        {
            get
            {
                return noties;
            }
            set
            {
                if (noties != value)
                {
                    noties = value;
                    RaisePropertyChanged("Noties");
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
                    Combine1();
                    RaisePropertyChanged("Status");
                }
            }
        }

        int potty_id;
        public int Potty_id
        {
            get
            {
                return potty_id;
            }
            set
            {
                if (potty_id != value)
                {
                    potty_id = value;
                    Combine1();
                    RaisePropertyChanged("Potty_id");
                }
            }
        }

        int vehicle_engine_num;
        public int Vehicle_engine_num
        {
            get
            {
                return vehicle_engine_num;
            }
            set
            {
                if (vehicle_engine_num != value)
                {
                    vehicle_engine_num = value;
                    RaisePropertyChanged("Vehicle_engine_num");
                }
            }
        }

        string vehicle_color;
        public string Vehicle_color
        {
            get
            {
                return vehicle_color;
            }
            set
            {
                if (vehicle_color != value)
                {
                    vehicle_color = value;
                    RaisePropertyChanged("Vehicle_color");
                }
            }
        }

        string vehicle_shape;
        public string Vehicle_shape
        {
            get
            {
                return vehicle_shape;
            }
            set
            {
                if (vehicle_shape != value)
                {
                    vehicle_shape = value;
                    RaisePropertyChanged("Vehicle_shape");
                }
            }
        }

        string vehicle_model;
        public string Vehicle_model
        {
            get
            {
                return vehicle_model;
            }
            set
            {
                if (vehicle_model != value)
                {
                    vehicle_model = value;
                    RaisePropertyChanged("Vehicle_model");
                }
            }
        }

        int vehicle_customs_num;
        public int Vehicle_customs_num
        {
            get
            {
                return vehicle_customs_num;
            }
            set
            {
                if (vehicle_customs_num != value)
                {
                    vehicle_customs_num = value;
                    RaisePropertyChanged("Vehicle_customs_num");
                }
            }
        }

        string release_date_c;
        public string Release_date_c
        {
            get
            {
                return release_date_c;
            }
            set
            {
                if (release_date_c != value)
                {
                    release_date_c = value;
                    RaisePropertyChanged("Release_date_c");
                }
            }
        }

        string company_manu_name;
        public string Company_manu_name
        {
            get
            {
                return company_manu_name;
            }
            set
            {
                if (company_manu_name != value)
                {
                    company_manu_name = value;
                    RaisePropertyChanged("Company_manu_name");
                }
            }
        }

        int status_v;
        public int Status_v
        {
            get
            {
                return status_v;
            }
            set
            {
                if (status_v != value)
                {
                    status_v = value;
                    RaisePropertyChanged("Status_v");
                }
            }
        }

        int release_palc_c;
        public int Release_palc_c
        {
            get
            {
                return release_palc_c;
            }
            set
            {
                if (release_palc_c != value)
                {
                    release_palc_c = value;
                    RaisePropertyChanged("Release_palc_c");
                }
            }
        }

        string string_Provinces;
        public string String_Provinces
        {
            get
            {
                return string_Provinces;
            }
            set
            {
                if (string_Provinces != value)
                {
                    string_Provinces = value;
                    RaisePropertyChanged("String_Provinces");
                }
            }
        }
        string string_Provinces_vc;
        public string String_Provinces_vc
        {
            get
            {
                return string_Provinces_vc;
            }
            set
            {
                if (string_Provinces_vc != value)
                {
                    string_Provinces_vc = value;
                    RaisePropertyChanged("String_Provinces_vc");
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
                    RaisePropertyChanged("String_Status");
                }
            }
        }

        string string_Citizen;
        public string String_Citizen
        {
            get
            {
                return string_Citizen;
            }
            set
            {
                if (string_Citizen != value)
                {
                    string_Citizen = value;
                    Combine1();
                    RaisePropertyChanged("String_Citizen");
                }
            }
        }

        string string_Status_v;
        public string String_Status_v
        {
            get
            {
                return string_Status_v;
            }
            set
            {
                if (string_Status_v != value)
                {
                    string_Status_v = value;
                    RaisePropertyChanged("String_Status_v");
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
            Search = String.Join(" || ", Potty_id, string_Citizen, Vehicle_card_id, Status);
        }


        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
