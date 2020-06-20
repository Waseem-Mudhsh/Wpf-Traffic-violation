using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

       
            
        public void GetTrafficMans(ObservableCollection<TrafficMan> TrafficMans)
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


        }
        ///////////////////////////////// end GetTrafficMans/////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////// start opTrafficMan/////////////////////////////////////
        public  bool OperarionTrafficMan(TrafficMan trafficMan, string operartion)
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

    }
}
