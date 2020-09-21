using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class Activity : BindableBase
    {
        int activity_id;
        public int Activity_id
        {
            get
            {
                return activity_id;
            }
            set
            {
                if (activity_id != value)
                {
                    activity_id = value;
                    RaisePropertyChanged("Activity_id");
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
        int form_id;
        public int Form_id
        {
            get
            {
                return form_id;
            }
            set
            {
                if (form_id != value)
                {
                    form_id = value;
                    RaisePropertyChanged("Form_id");
                }
            }
        }
        int activity_operation_num;
        public int Activity_operation_num
        {
            get
            {
                return activity_operation_num;
            }
            set
            {
                if (activity_operation_num != value)
                {
                    activity_operation_num = value;
                    RaisePropertyChanged("Activity_operation_num");
                }
            }
        }
        int activity_record_num;
        public int Activity_record_num
        {
            get
            {
                return activity_record_num;
            }
            set
            {
                if (activity_record_num != value)
                {
                    activity_record_num = value;
                    RaisePropertyChanged("Activity_record_num");
                }
            }
        }
        string activity_date;
        public string Activity_date
        {
            get
            {
                return activity_date;
            }
            set
            {
                if (activity_date != value)
                {
                    activity_date = value;
                    RaisePropertyChanged("Activity_date");
                }
            }
        }

        string string_User_id;
        public string String_User_id
        {
            get
            {
                return string_User_id;
            }
            set
            {
                if (string_User_id != value)
                {
                    string_User_id = value;
                    RaisePropertyChanged("String_User_id");
                }
            }
        }
        string string_Form_id;
        public string String_Form_id
        {
            get
            {
                return string_Form_id;
            }
            set
            {
                if (string_Form_id != value)
                {
                    string_Form_id = value;
                    RaisePropertyChanged("String_Form_id");
                }
            }
        }
        string string_Activity_operation_num;
        public string String_Activity_operation_num
        {
            get
            {
                return string_Activity_operation_num;
            }
            set
            {
                if (string_Activity_operation_num != value)
                {
                    string_Activity_operation_num = value;
                    RaisePropertyChanged("String_Activity_operation_num");
                }
            }
        }


        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
