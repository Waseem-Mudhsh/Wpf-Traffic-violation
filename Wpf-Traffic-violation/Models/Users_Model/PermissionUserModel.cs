using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models.Users_Model
{
    public class PermissionUserModel
    {
        ///////////////////////////////// start GetPermissionUser/////////////////////////////////////

        public ObservableCollection<PermissionUser> GetPermissionUser( string menu, int user_Id)
        {
            ObservableCollection<PermissionUser> PermissionUsers = new ObservableCollection<PermissionUser>();
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
                    CommandText = "GetPermissionUser",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@menu", menu);
                Command.Parameters.AddWithValue("@user_id", user_Id);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PermissionUser per = new PermissionUser
                        {
                            User_id = (int)row[0],
                            Form_id = (int)row[1],
                            Add_opretion = (bool)row[2],
                            Delete_opretion = (bool)row[3],
                            Update_opretion = (bool)row[4],
                            Select_opretion = (bool)row[5],
                            Form = (bool)row[6]

                        };
                        per.String_Id = new Class_SqlConnection().Get_row("getUserName", per.User_id);
                        per.String_form = new Class_SqlConnection().Get_row("getFormName", per.Form_id);

                        PermissionUsers.Add(per);
                    }
                }
            }
            return PermissionUsers;

        }
        ///////////////////////////////// end GetPermissionGroup/////////////////////////////////////

        ///////////////////////////////// start OperarionPermissionGroup/////////////////////////////////////

        public bool OperarionPermissionUser(PermissionUser PermissionUser, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[8];


            param[0] = new SqlParameter("@User_id", SqlDbType.Int)
            {
                Value = PermissionUser.User_id
            };
            param[1] = new SqlParameter("@Form_id", SqlDbType.Int)
            {
                Value = PermissionUser.Form_id
            };
            param[2] = new SqlParameter("@Add_opretion", SqlDbType.Bit)
            {
                Value = PermissionUser.Add_opretion
            };
            param[3] = new SqlParameter("@Delete_opretion", SqlDbType.Bit)
            {
                Value = PermissionUser.Delete_opretion
            };
            param[4] = new SqlParameter("@Update_opretion", SqlDbType.Bit)
            {
                Value = PermissionUser.Update_opretion
            };
            param[5] = new SqlParameter("@Select_opretion", SqlDbType.Bit)
            {
                Value = PermissionUser.Select_opretion
            };
            param[6] = new SqlParameter("@Form", SqlDbType.Bit)
            {
                Value = PermissionUser.Form
            };
            param[7] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opPermissionUser", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionPermissionUser/////////////////////////////////////

    }
}
