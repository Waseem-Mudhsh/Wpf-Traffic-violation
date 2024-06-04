using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows;
using Wpf_Traffic_violation.Core.DataAccess;
using Wpf_Traffic_violation.Models.Users_Model;
using Wpf_Traffic_violation.Services.DataBase.Storedprocedures;
using Wpf_Traffic_violation.Services.helper;

namespace Wpf_Traffic_violation.Models
{
    public class UserModel
    {
        Isphelper sphelper;
        SP_Query sP_Query;
        ValidationRegex validationRegex;
        public UserModel()
        {
            validationRegex = new ValidationRegex();
            sphelper = new configuration();
            sP_Query = new SP_Query();
        }

        ///////////////////////////////// start GetUsers/////////////////////////////////////
        ObservableCollection<User> Users = new ObservableCollection<User>();
        ObservableCollection<User_type> UsersTypes = new ObservableCollection<User_type>();


        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
            var response = sphelper.GetCollection(sP_Query.getUsers, "getUsers");
            if (response.Count > 0)
            {
                foreach (DataRow row in response)
                {
                    User per = new User
                    {
                        Userid = (int)row[0],
                        Username = (string)row[1],
                        Userpassword = (string)row[2],
                        String_usertype = (string)row[3],
                        Userstatus = Convert.ToBoolean(row[4])


                    };
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

        public ObservableCollection<User_type> GetUserType()
        {
            ObservableCollection<User_type> users = new ObservableCollection<User_type>();
            var response = sphelper.GetCollection(sP_Query.GetUsertype, "GetUsertype");
            if (response.Count > 0)
            {
                foreach (DataRow row in response)
                {
                    User_type per = new User_type
                    {
                        UserTypeid = (int)row[0],
                        UserTypeName = (string)row[1],
                        Isactive = (bool)row[2],
                    };


                    //}
                    UsersTypes.Add(per); //الي بنربطه مع الجريد فيو
                }
            }
            return UsersTypes;
        }
        /////////////////////////////////evd GetExcel/////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
