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
    class TrafficmanModel
    {

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start GetTrafficMans/////////////////////////////////////



        public ObservableCollection<TrafficMan> GetTrafficMans()
        {
            ObservableCollection<TrafficMan> TrafficMans = new ObservableCollection<TrafficMan>();
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
                    CommandText = "GetTrafficMans",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        TrafficMan per = new TrafficMan
                        {
                            Traffic_man_id = (int)row[0],
                            Traffic_man_name = row[1].ToString(),
                            User_id = (int)row[2],
                            Traffic_man_grade = row[3].ToString(),


                        };

                        TrafficMans.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }

            return TrafficMans;
        }

        ///////////////////////////////// end GetTrafficMans/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start getUserTrafficman/////////////////////////////////////
        public ObservableCollection<TrafficMan> Get_trafficmanNametoUser()
        {
            ObservableCollection<TrafficMan> TrafficMans = new ObservableCollection<TrafficMan>();
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
                    CommandText = "Get_trafficmanNametoUser",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        TrafficMan per = new TrafficMan
                        {
                            Traffic_man_id = (int)row[0],
                            Traffic_man_name = row[1].ToString(),
                            User_id = (int)row[2],
                            Traffic_man_grade = row[3].ToString(),


                        };

                        TrafficMans.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }

            return TrafficMans;
        }
        ///////////////////////////////// end getUserTrafficman/////////////////////////////////////

        ///////////////////////////////// start getUserTrafficman/////////////////////////////////////
        public ObservableCollection<TrafficMan> Get_trafficmanNametoUser_Combbox()
        {
            ObservableCollection<TrafficMan> TrafficMans = new ObservableCollection<TrafficMan>();
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
                    CommandText = "Get_trafficmanNametoUser_Combbox",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        TrafficMan per = new TrafficMan
                        {
                            Traffic_man_id = (int)row[0],
                            Traffic_man_name = row[1].ToString(),
                            User_id = (int)row[2],
                            Traffic_man_grade = row[3].ToString(),


                        };

                        TrafficMans.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }

            return TrafficMans;
        }
        ///////////////////////////////// end getUserTrafficman/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start opTrafficMan/////////////////////////////////////

        public bool OperarionTrafficMan(TrafficMan trafficMan, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[4];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Traffic_man_id", SqlDbType.Int)
            {
                Value = trafficMan.Traffic_man_id
            };
            param[1] = new SqlParameter("@Traffic_man_name", SqlDbType.NVarChar, 50)
            {
                Value = trafficMan.Traffic_man_name
            };
            param[2] = new SqlParameter("@Traffic_man_grade", SqlDbType.NVarChar, 50)
            {
                Value = trafficMan.Traffic_man_grade
            };

            param[3] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opTrafficMan", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end opTrafficMan/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
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
                    CommandText = "checkTrafficMan",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Traffic_man_id", value);


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
        ///////////////////////////////// end Check/////////////////////////////////////
        ///////////////////////////////// start Check_Exsit/////////////////////////////////////
        public bool Update_Uesrid(TrafficMan traffic_user, String opreation)
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
                    CommandText = "Update_Uesrid",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Traffic_man_id", traffic_user.Traffic_man_id);
                Command.Parameters.AddWithValue("@User_id", traffic_user.User_id);
                Command.Parameters.AddWithValue("@operation", opreation);


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
        ///////////////////////////////// end Check/////////////////////////////////////

        /////////////////////////////////start GetExcel/////////////////////////////////////



        public void GetExcel(ObservableCollection<TrafficMan> TrafficMans)
        {

            OleDbConnection con;
            OleDbDataAdapter da;
            DataTable dt;
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a Excel File";
            op.Filter = "Excel Files |*.XLSX";
            if (op.ShowDialog() == true)
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + op.FileName + "; Extended Properties=Excel 12.0");
                da = new OleDbDataAdapter("select * from [Trafficman$]", con);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        TrafficMan per = new TrafficMan
                        {
                            Traffic_man_id = Convert.ToInt32(row[0]),
                            Traffic_man_name = row[1].ToString(),
                            Traffic_man_grade = row[2].ToString()
                        };
                        OperarionTrafficMan(per, "Insert");



                        TrafficMans.Add(per); //الي بنربطه مع الجريد فيو
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
