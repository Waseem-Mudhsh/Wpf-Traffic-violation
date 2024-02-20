using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models.Users_Model
{
    public class PermissionSet_Model
    {
        ///////////////////////////////// start GetPermissionSet/////////////////////////////////////

        public ObservableCollection<PermissionSet> GetPermissionSet()
        {
            ObservableCollection<PermissionSet> PermissionSets = new ObservableCollection<PermissionSet>();
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
                    CommandText = "GetPermissionSet",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PermissionSet per = new PermissionSet
                        {
                            Group_id = (int)row[0],
                            Group_name = row[1].ToString(),
                            Group_status = (int)row[2]

                        };
                        if (per.Group_status == 1)
                        {
                            per.String_Status = "نشط";
                        }
                        else
                        {
                            per.String_Status = "غير نشط";
                        }

                        PermissionSets.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }
            return PermissionSets;

        }
        ///////////////////////////////// end GetPermissionSet/////////////////////////////////////

        ///////////////////////////////// start OperarionPermissionSet/////////////////////////////////////

        public bool OperarionPermissionSet(PermissionSet PermissionSet, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[4];


            param[0] = new SqlParameter("@Group_id", SqlDbType.Int)
            {
                Value = PermissionSet.Group_id
            };
            param[1] = new SqlParameter("@Group_name", SqlDbType.NVarChar, 20)
            {
                Value = PermissionSet.Group_name
            };
            param[2] = new SqlParameter("@Group_status", SqlDbType.Int)
            {
                Value = PermissionSet.Group_status
            };
            param[3] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opPermissionSet", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionPermissionSet/////////////////////////////////////

        ///////////////////////////////// start Check_Exsit/////////////////////////////////////
        public bool Check_Exsit(int value)
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
                    CommandText = "checkPermissionSet",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Id", value);


                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }


            }
        }
        ///////////////////////////////// end Check_Exsit/////////////////////////////////////


        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<PermissionSet> PermissionSets)
        {

            OleDbConnection con;
            OleDbDataAdapter da;
            DataTable dt;
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a Excel File";
            op.Filter = "AllFiles | *.* | Excel Files |*.XLSX";
            if (op.ShowDialog() == true)
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + op.FileName + "; Extended Properties=Excel 12.0");
                da = new OleDbDataAdapter("select * from [page$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        PermissionSet per = new PermissionSet
                        {
                            Group_id = (int)row[0],
                            Group_name = row[1].ToString(),
                            Group_status = (int)row[2]

                        };
                        OperarionPermissionSet(per, "Insert");



                        PermissionSets.Add(per); //الي بنربطه مع الجريد فيو
                    }
                    string message = "عدد السجلات المستوردة = " + dt.Rows.Count;
                    string caption = "عملية الاستيراد";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }


        }

        /////////////////////////////////end GetExcel/////////////////////////////////////
    }
}
