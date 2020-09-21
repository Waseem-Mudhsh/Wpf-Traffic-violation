using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models
{
    public class LoginModel
    {

        public bool Login(string user_name,string password)
        {
            Class_SqlConnection sql = new Class_SqlConnection();
            using (sql.con)
            {
                try
                {
                    sql.con.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cant Open Conncation");

                }
                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "checkLogin",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Username", user_name);
                Command.Parameters.AddWithValue("@Passeord", password);


                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Properties.Settings.Default.Userid = (int)row[0];
                        Properties.Settings.Default.UserNameSystem = row[1].ToString();
                        Properties.Settings.Default.Save();
                    }
                        
                        return true;
                }

                else
                {
                    return false;
                }
            }  
        }

    }
}
