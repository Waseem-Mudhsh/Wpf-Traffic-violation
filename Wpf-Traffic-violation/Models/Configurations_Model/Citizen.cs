using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
   public class Citizen : BindableBase
    {
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
                    Combine();
                    RaisePropertyChanged("Citizen_id");
                }
            }
        }

        string citizen_name;
        public string Citizen_name
        {
            get
            {
                return citizen_name;
            }
            set
            {
                if (citizen_name != value)
                {
                    citizen_name = value;
                    Combine();
                    RaisePropertyChanged("Citizen_name");
                }
            }
        }

        string citizen_address;
        public string Citizen_address
        {
            get
            {
                return citizen_address;
            }
            set
            {
                if (citizen_address != value)
                {
                    citizen_address = value;
                    RaisePropertyChanged("Citizen_address");
                }
            }
        }

        String citizen_date_pirth;
        public String Citizen_date_pirth
        {
            get
            {
                return citizen_date_pirth;
            }
            set
            {
                if (citizen_date_pirth != value)
                {
                    citizen_date_pirth = value;
                    RaisePropertyChanged("Citizen_date_pirth");
                }
            }
        }

        string citizen_religion;
        public   string Citizen_religion
        {
            get
            {
                return citizen_religion;
            }
            set
            {
                if (citizen_religion != value)
                {
                    citizen_religion = value;
                    RaisePropertyChanged("Citizen_religion");
                }
            }
        }


        string citizen_blood_type;
        public string Citizen_blood_type
        {
            get
            {
                return citizen_blood_type;
            }
            set
            {
                if (citizen_blood_type != value)
                {
                    citizen_blood_type = value;
                    RaisePropertyChanged("Citizen_blood_type");
                }
            }
        }

        bool citizen_social_status;
        public bool Citizen_social_status
        {
            get
            {
                return citizen_social_status;
            }
            set
            {
                if (citizen_social_status != value)
                {
                    citizen_social_status = value;
                    RaisePropertyChanged("Citizen_social_status");
                }
            }
        }
      
       



        int user_id;
        public int User_id
        {
            get
            {
                return user_id;
            }
            set
            {
                if (user_id != value)
                {
                    user_id = value;
                    RaisePropertyChanged("User_id");
                }
            }
        }

        string citizen_nationality;
        public string Citizen_nationality
        {
            get
            {
                return citizen_nationality;
            }
            set
            {
                if (citizen_nationality != value)
                {
                    citizen_nationality = value;
                    RaisePropertyChanged("Citizen_nationality");
                }
            }
        }

       
       


        string citizen_identitytype;
        public string Citizen_identitytype
        {
            get
            {
                return citizen_identitytype;
            }
            set
            {
                if (citizen_identitytype != value)
                {
                    citizen_identitytype = value;
                    RaisePropertyChanged("Citizen_identitytype");
                }
            }
        }

        string citizen_phone;
        public string Citizen_phone
        {
            get
            {
                return citizen_phone;
            }
            set
            {
                if (citizen_phone != value)
                {
                    citizen_phone = value;
                    RaisePropertyChanged("Citizen_phone");
                }
            }
        }

        string string_social_status;
        public string String_social_status
        {
            get
            {
                return string_social_status;
            }
            set
            {
                if (string_social_status != value)
                {
                    string_social_status = value;
                    RaisePropertyChanged("String_social_status");
                }
            }
        }

        string string_gender;
        public string String_gender
        {
            get
            {
                return string_gender;
            }
            set
            {
                if (string_gender != value)
                {
                    string_gender = value;
                    RaisePropertyChanged("String_gender");
                }
            }
        }
        private void Combine()
        {
            Search = string.Join("  ", Citizen_id.ToString(), Citizen_name);
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
       



        public override void CollectErrors()
        {
            Errors.Clear();
            if (Citizen_id == 0)
            {
                Errors.Add("Citizen_id", "يجب أن لايكون فارغ ");
            }
            if (string.IsNullOrWhiteSpace(Citizen_name))
            {
                Errors.Add("Citizen_name", "يجب أن يكون نص ");
            }
            
        }
    }
}
