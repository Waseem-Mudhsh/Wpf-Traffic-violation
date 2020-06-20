using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Traffic_violation.ViewModel;

namespace Wpf_Traffic_violation.Models
{
    public class User : BindableBase
    {
        public UserTypes Type{ get; set; }
        int userid;
        public int Userid
        {
            get
            {
                return userid;
            }
            set
            {
                if (userid != value)
                {
                    userid = value;
                    Combine();
                    RaisePropertyChanged("Userid");
                }
            }
        }
       

        private void Combine()
        {
            Search = string.Join("  ", Userid.ToString(), Username);
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


        string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username != value)
                {
                    username = value;
                    Combine();

                    RaisePropertyChanged("Username");
                }
            }
        }
        string userpassword;
        public string Userpassword
        {
            get
            {
                return userpassword;
            }
            set
            {
                if (userpassword != value)
                {
                    userpassword = value;
                    RaisePropertyChanged("Userpassword");
                }
            }
        }
        int usertype;
        public int Usertype
        {
            get
            {
                return usertype;
            }
            set
            {
                if (usertype != value)
                {
                    usertype = value;
                    RaisePropertyChanged("Usertype");
                }
            }
        }
        bool  userstatus;
        public bool Userstatus
        {
            get
            {
                return userstatus;
            }
            set
            {
                if (userstatus != value)
                {
                    userstatus = value;
                    RaisePropertyChanged("Userstatus");
                }
            }
        }
        string string_usertype;
        public string String_usertype
        {
            get
            {
                return string_usertype;
            }
            set
            {
                if (string_usertype != value)
                {
                    string_usertype = value;
                    RaisePropertyChanged("String_usertype");
                }
            }
        }
        string string_userstatus;
        public string String_userstatus
        {
            get
            {
                return string_userstatus;
            }
            set
            {
                if (string_userstatus != value)
                {
                    string_userstatus = value;
                    RaisePropertyChanged("String_userstatus");
                }
            }
        }
        


       
            







        public override void CollectErrors()
        {
            Errors.Clear();
            if(Userid==0)
            {
                Errors.Add("Userid", "يجب أن لايكون فارغ أو يحمل القيمة صفر");
            }
            //if (string.IsNullOrWhiteSpace(Username))
            //{
            //    Errors.Add("Username", "يجب أن يكون نص ");
            //}
            if (String.IsNullOrWhiteSpace(Userpassword))
            
            {
                Errors.Add("Userpassword", "يجب أن لايكون فارغ ");
            }
            
        }
    }
}
