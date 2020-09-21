using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class DrivingLicense : BindableBase
    {
        int driving_license_id;
        public int Driving_license_id
        {
            get
            {
                return driving_license_id;
            }
            set
            {
                if (driving_license_id != value)
                {
                    driving_license_id = value;
                    Combine();
                    RaisePropertyChanged("Driving_license_id");
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
                    Combine();
                    RaisePropertyChanged("Release_date");
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
        int class_license_id;
        public int Class_license_id
        {
            get
            {
                return class_license_id;
            }
            set
            {
                if (class_license_id != value)
                {
                    class_license_id = value;
                    RaisePropertyChanged("Class_license_id");
                }
            }
        }
        string date_frist_license;
        public string Date_frist_license
        {
            get
            {
                return date_frist_license;
            }
            set
            {
                if (date_frist_license != value)
                {
                    date_frist_license = value;
                    RaisePropertyChanged("Date_frist_license");
                }
            }
        }
        string driving_license_notice;
        public string Driving_license_notice
        {
            get
            {
                return driving_license_notice;
            }
            set
            {
                if (driving_license_notice != value)
                {
                    driving_license_notice = value;
                    RaisePropertyChanged("Driving_license_notice");
                }
            }
        }
        string status;
        public string Status
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
                    Combine();
                    RaisePropertyChanged("Status");
                }
            }
        }

        string string_citizen;
        public string String_citizen
        {
            get
            {
                return string_citizen;
            }
            set
            {
                if (string_citizen != value)
                {
                    string_citizen = value;
                    Combine();
                    RaisePropertyChanged("String_citizen");
                }
            }
        }

        string string_Class_license;
        public string String_Class_license
        {
            get
            {
                return string_Class_license;
            }
            set
            {
                if (string_Class_license != value)
                {
                    string_Class_license = value;
                    Combine();
                    RaisePropertyChanged("String_Class_license");
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


        private void Combine()
        {
            Search = String.Join(" || ", Driving_license_id, Release_date, String_citizen, String_Class_license,Status);
        }


        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
