using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class Communication : BindableBase
    {
        int communication_id;
        public int Communication_id
        {
            get
            {
                return communication_id;
            }
            set
            {
                if (communication_id != value)
                {
                    communication_id = value;
                    Combine();
                    RaisePropertyChanged("Communication_id");
                }
            }
        }

        string communication_name;
        public string Communication_name
        {
            get
            {
                return communication_name;
            }
            set
            {
                if (communication_name != value)
                {
                    communication_name = value;
                    Combine();
                    RaisePropertyChanged("Communication_name");
                }
            }
        }

        string communication_date;
        public string Communication_date
        {
            get
            {
                return communication_date;
            }
            set
            {
                if (communication_date != value)
                {
                    communication_date = value;
                    Combine();
                    RaisePropertyChanged("Communication_date");
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

        string communication_photo1;
        public string Communication_photo1
        {
            get
            {
                return communication_photo1;
            }
            set
            {
                if (communication_photo1 != value)
                {
                    communication_photo1 = value;
                    RaisePropertyChanged("Communication_photo1");
                }
            }
        }

        string communication_photo2;
        public string Communication_photo2
        {
            get
            {
                return communication_photo2;
            }
            set
            {
                if (communication_photo2 != value)
                {
                    communication_photo2 = value;
                    RaisePropertyChanged("Communication_photo2");
                }
            }
        }
        string communication_notice;
        public string Communication_notice
        {
            get
            {
                return communication_notice;
            }
            set
            {
                if (communication_notice != value)
                {
                    communication_notice = value;
                    RaisePropertyChanged("Communication_notice");
                }
            }
        }
        int communication_status;
        public int Communication_status
        {
            get
            {
                return communication_status;
            }
            set
            {
                if (communication_status != value)
                {
                    communication_status = value;
                    
                    RaisePropertyChanged("Communication_status");
                }
            }
        }
        string communication_place;
        public string Communication_place
        {
            get
            {
                return communication_place;
            }
            set
            {
                if (communication_place != value)
                {
                    communication_place = value;
                    Combine();
                    RaisePropertyChanged("Communication_place");
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
                    Combine();
                    RaisePropertyChanged("String_Status");
                }
            }
        }
        string string_Ciziten;
        public string String_Ciziten
        {
            get
            {
                return string_Ciziten;
            }
            set
            {
                if (string_Ciziten != value)
                {
                    string_Ciziten = value;
                    Combine();
                    RaisePropertyChanged("String_Ciziten");
                }
            }
        }
        string plateNum;
        public string PlateNum
        {
            get
            {
                return plateNum;
            }
            set
            {
                if (plateNum != value)
                {
                    plateNum = value;
                    Combine();
                    RaisePropertyChanged("PlateNum");
                }
            }
        }
        //-------------------------
        string plateNumr;
        public string PlateNumr
        {
            get
            {
                return plateNumr;
            }
            set
            {
                if (plateNumr != value)
                {
                    plateNumr = value;
                    Combine();
                    RaisePropertyChanged("PlateNumr");
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

        private void Combine()
        {
            Search = string.Join("  ", Communication_id.ToString(), communication_name, communication_date, PlateNum, communication_place, string_Ciziten);
        }



        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
