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
    public class PermissionGroupModel
    {
        ///////////////////////////////// start GetPermissionSet/////////////////////////////////////

        public void GetPermisstionGroup(ObservableCollection<PermissionGroup> PermissionGroups, string menu, int group_id)
        {
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
                    CommandText = "GetPermissionGroup",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@menu", menu);
                Command.Parameters.AddWithValue("@group_id", group_id);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PermissionGroup per = new PermissionGroup
                        {
                            Id = (int)row[0],
                            Form_id = (int)row[1],
                            Add_opretion = (bool)row[2],
                            Delete_opretion = (bool)row[3],
                            Update_opretion = (bool)row[4],
                            Select_opretion = (bool)row[5],
                            Form = (bool)row[6]

                        };
                        per.String_Id = new Class_SqlConnection().Get_row("getGroupName", per.Id);
                        per.String_form = new Class_SqlConnection().Get_row("getFormName", per.Form_id);

                        PermissionGroups.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }


        }
        ///////////////////////////////// end GetPermissionGroup/////////////////////////////////////
        ///////////////////////////////// start OperarionPermissionGroup/////////////////////////////////////

        public bool OperarionPermissionGroup(PermissionGroup PermissionGroup, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[8];


            param[0] = new SqlParameter("@Group_id", SqlDbType.Int)
            {
                Value = PermissionGroup.Id
            };
            param[1] = new SqlParameter("@Form_id", SqlDbType.Int)
            {
                Value = PermissionGroup.Form_id
            };
            param[2] = new SqlParameter("@Add_opretion", SqlDbType.Bit)
            {
                Value = PermissionGroup.Add_opretion
            };
            param[3] = new SqlParameter("@Delete_opretion", SqlDbType.Bit)
            {
                Value = PermissionGroup.Delete_opretion
            };
            param[4] = new SqlParameter("@Update_opretion", SqlDbType.Bit)
            {
                Value = PermissionGroup.Update_opretion
            };
            param[5] = new SqlParameter("@Select_opretion", SqlDbType.Bit)
            {
                Value = PermissionGroup.Select_opretion
            };
            param[6] = new SqlParameter("@Form", SqlDbType.Bit)
            {
                Value = PermissionGroup.Form
            };
            param[7] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opPermissionGroup", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionPermissionSet/////////////////////////////////////
    }
}
