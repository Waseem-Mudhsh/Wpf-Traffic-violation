using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.MagrationDB;

namespace Wpf_Traffic_violation.Services
{
   public class UserServices
    {
        TrafficViolationEntitiesUat objcontext;
        public UserServices()
        {
            objcontext =new TrafficViolationEntitiesUat();

        }
        public bool Login(string userName, string Pasw)
        {
            bool canLogin = false;   
            try
            {
                
                if (Properties.Settings.Default.Userid != 0 || Properties.Settings.Default.UserNameSystem != null)
                {
                    Properties.Settings.Default.Userid = 0;
                    Properties.Settings.Default.UserNameSystem = null;
                    Properties.Settings.Default.Save();
                }

                var result = from user in objcontext.Users select user;

                foreach (var user in result)
                {
                    if (user.User_short_name == userName && user.User_password == Pasw)
                    {
                        Properties.Settings.Default.Userid = user.User_id;
                        Properties.Settings.Default.UserNameSystem = user.User_short_name;
                        Properties.Settings.Default.Save();
                    }

                }
                if (Properties.Settings.Default.Userid == 0)
                {
                    canLogin= false;
                }

                canLogin= true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return canLogin;
       

      
          
        }

        public object checkforuser()
        {
            throw new NotImplementedException();
        }

      
    }
}
