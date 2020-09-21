using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Models.Users_Model;

namespace Wpf_Traffic_violation.Models
{
    public class AllPermissions
    {

        public void getAllPermissions()
        {
            Properties.Settings.Default.permission = null;
            Properties.Settings.Default.Save();
             SqlConnection con = new SqlConnection(@"server=" + Properties.Settings.Default.ServerName + " ;DataBase=" + Properties.Settings.Default.DatabaseName + " ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            //Class_SqlConnection sql = new Class_SqlConnection();
            using (con)
            {
                try
                {
                    con.Open();
                }
                catch (Exception)
                {

                    MessageBox.Show("Cant Open con");
                }

                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "getAllPermissions",
                    Connection = con

                };
                //Command.Parameters.AddWithValue("@menu", menu);
                Command.Parameters.AddWithValue("@user_id", Properties.Settings.Default.Userid);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                Properties.Settings.Default.permission = dt;
               
               
            }


        }
        public void getPermission(PermissionUser PermissionUser)
        {
            if (Properties.Settings.Default.permission.Rows.Count > 0)
            {
                foreach (DataRow row in Properties.Settings.Default.permission.Rows)
                {
                    if ((int)row[1] == PermissionUser.Form_id)
                    {

                       PermissionUser.User_id = (int)row[0];
                       PermissionUser.Form_id = (int)row[1];
                       PermissionUser.Add_opretion = (bool)row[2];
                       PermissionUser.Delete_opretion = (bool)row[3];
                       PermissionUser.Update_opretion = (bool)row[4];
                       PermissionUser.Select_opretion = (bool)row[5];
                        PermissionUser.Form = (bool)row[6];

                        //PermissionUser.String_Id = new Class_SqlConnection().Get_row("getUserName", PermissionUser.User_id);
                        //PermissionUser.String_form = new Class_SqlConnection().Get_row("getFormName", PermissionUser.Form_id);
                       
                    }

                }
            }



        }
    }
}
