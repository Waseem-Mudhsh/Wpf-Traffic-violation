using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models.Users_Model
{
    public class User_type : BindableBase
    {
        public int userTypeid { get; set; }
        public string userTypeName { get; set; }
        public bool isactive { get; set; }
        public int UserTypeid
        {
            get
            {
                return userTypeid;
            }
            set
            {
                if (userTypeid != value)
                {
                    userTypeid = value;
                    RaisePropertyChanged("UserTypeid");
                }
            }
        }
        public string UserTypeName
        {
            get
            {
                return userTypeName;
            }
            set
            {
                if (userTypeName != value)
                {
                    userTypeName = value;
                    RaisePropertyChanged("UserTypeName");
                }
            }
        }
        public bool Isactive
        {
            get
            {
                return isactive;
            }
            set
            {
                if (isactive != value)
                {
                    isactive = value;
                    RaisePropertyChanged("Isactive");
                }
            }
        }

        public override void CollectErrors()
        {
            throw new System.NotImplementedException();
        }
    }
}
