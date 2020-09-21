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

namespace Wpf_Traffic_violation.Models
{
    public class UserModel
    {

        ///////////////////////////////// start GetUsers/////////////////////////////////////
        ObservableCollection<User> Users = new ObservableCollection<User>();


        public ObservableCollection<User> GetUsers()
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
                //SqlCommand Command = new SqlCommand("Select * from Person", con);
                SqlCommand Command = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetUsers",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        User per = new User
                        {
                            Userid = (int)row[0],
                            Username = row[1].ToString(),
                            Userpassword = row[2].ToString(),
                            Usertype = (int)row[3],
                            Userstatus = (bool)row[4]


                        };
                        if (per.Usertype == 1)
                        {
                            per.String_usertype = "النظام";
                        }
                        else
                        {
                            per.String_usertype = "التطبيق";
                        }
                        if (per.Userstatus == true)
                        {
                            per.String_userstatus = "نشط";
                        }
                        else
                        {
                            per.String_userstatus = "غير نشط";
                        }

                        //}
                        Users.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
                return Users;
            }
        }
        ///////////////////////////////// end GetUsers/////////////////////////////////////


        ///////////////////////////////// start OperarionUser/////////////////////////////////////



        public static bool OperarionUser(User user, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[6];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@user_id", SqlDbType.Int)
            {
                Value = user.Userid
            };
            param[1] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50)
            {
                Value = user.Username
            };
            param[2] = new SqlParameter("@user_pass", SqlDbType.NVarChar, 50)
            {
                Value = user.Userpassword
            };
            param[3] = new SqlParameter("@user_type", SqlDbType.Int)
            {
                Value = user.Usertype
            };
            param[4] = new SqlParameter("@user_status", SqlDbType.Bit)
            {
                Value = user.Userstatus
            };
            param[5] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opUser", param))
            {
                return false;

            }



            return true;
        }
        ///////////////////////////////// end OperarionUser/////////////////////////////////////


        /////////////////////////////////start Check_Exsit /////////////////////////////////////
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
                    CommandText = "checkuser",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@user_id", value);


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


        /////////////////////////////////end Check_Exsit/////////////////////////////////////


        /////////////////////////////////start GetExcel/////////////////////////////////////



        public ObservableCollection<User> GetExcel()
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
                        User per = new User
                        {
                            Userid = Convert.ToInt32(row[0]),
                            Username = row[1].ToString(),
                            Userpassword = row[2].ToString(),
                            Usertype = Convert.ToInt32(row[3]),
                            Userstatus = Convert.ToBoolean(row[4])


                        };
                        OperarionUser(per, "Insert");
                        if (per.Usertype == 1)
                        {
                            per.String_usertype = "النظام";
                        }
                        else
                        {
                            per.String_usertype = "التطبيق";
                        }


                        Users.Add(per); //الي بنربطه مع الجريد فيو
                    }
                    string message = "عدد السجلات المستوردة = " + dt.Rows.Count;
                    string caption = "عملية الاستيراد";
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBoxButton buttons = MessageBoxButton.OK;
                    MessageBox.Show(message, caption, buttons, icon);
                }
            }

            return Users;
        }
        /////////////////////////////////evd GetExcel/////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
