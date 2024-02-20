using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Services;

namespace Wpf_Traffic_violation.Models
{
    public class LoginModel
    {
        UserServices _userServices;
        public LoginModel( )
        {
            _userServices = new UserServices();
        }
        public bool Login(string user_name,string password)
        {

           var result= _userServices.Login(user_name, password);
            return result;
           
        }

    }
}
