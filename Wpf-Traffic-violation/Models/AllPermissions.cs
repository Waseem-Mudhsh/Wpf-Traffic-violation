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
        public void getPermission(PermissionUser permissionUser )
        {
            if (Properties.Settings.Default.permission.Rows.Count > 0)
            {
                foreach (DataRow row in Properties.Settings.Default.permission.Rows)
                {
                    if ((int)row[1] == permissionUser.Form_id)
                    {

                        permissionUser.User_id = (int)row[0];
                        permissionUser.Form_id = (int)row[1];
                        permissionUser.Add_opretion = (bool)row[2];
                        permissionUser.Delete_opretion = (bool)row[3];
                        permissionUser.Update_opretion = (bool)row[4];
                        permissionUser.Select_opretion = (bool)row[5];
                        permissionUser.Form = (bool)row[6];

                        //PermissionUser.String_Id = new Class_SqlConnection().Get_row("getUserName", PermissionUser.User_id);
                        //PermissionUser.String_form = new Class_SqlConnection().Get_row("getFormName", PermissionUser.Form_id);

                    }

                }
            }


        }
        public List<PermissionUser> getPermissionForUser()
        {
            List<PermissionUser> pemationLlist=new List<PermissionUser>();
         
            if (Properties.Settings.Default.permission.Rows.Count > 0)
            {
                
                foreach (DataRow row in Properties.Settings.Default.permission.Rows)
                {
                    var permation = new PermissionUser();
                    permation.User_id = (int)row[0];
                        permation.Form_id = (int)row[1];
                        permation.Add_opretion = (bool)row[2];
                        permation.Delete_opretion = (bool)row[3];
                        permation.Update_opretion = (bool)row[4];
                        permation.Select_opretion = (bool)row[5];
                        permation.Form = (bool)row[6];
                         permation.Nameform = (string)row[7];
                       permation.Codeform = (string)row[8];

                    //PermissionUser.String_Id = new Class_SqlConnection().Get_row("getUserName", PermissionUser.User_id);
                    //PermissionUser.String_form = new Class_SqlConnection().Get_row("getFormName", PermissionUser.Form_id);
                    pemationLlist.Add(permation);
                }
            }


            return pemationLlist;
        }
        public PermissionUser GetFormPermation(List<PermissionUser> permation,string code)
        {
            PermissionUser permissionUser = new PermissionUser();
            try
            {
                foreach (var row in permation)
                {
                    if (row.Codeform == code)
                    {
                        permissionUser = row;
                    }
                }
            }
            catch { 
            }
          

            return permissionUser;

        }


    }
}
