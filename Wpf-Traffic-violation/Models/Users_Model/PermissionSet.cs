using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Users_Model
{
    public class PermissionSet : BindableBase
    {
        int group_id;
        public int Group_id
        {
            get
            {
                return group_id;
            }
            set
            {
                if (group_id != value)
                {
                    group_id = value;
                    RaisePropertyChanged("Group_id");
                }
            }
        }

        string group_name;
        public string Group_name
        {
            get
            {
                return group_name;
            }
            set
            {
                if (group_name != value)
                {
                    group_name = value;
                    RaisePropertyChanged("Group_name");
                }
            }
        }
        int group_status;
        public int Group_status
        {
            get
            {
                return group_status;
            }
            set
            {
                if (group_status != value)
                {
                    group_status = value;
                    RaisePropertyChanged("Group_status");
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



        public override void CollectErrors()
        {
            throw new NotImplementedException();
        }
    }
}
