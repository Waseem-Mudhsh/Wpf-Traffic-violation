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

namespace Wpf_Traffic_violation.Models.Configurations_Model
{
    public class CommunicationModel
    {

        public void GetCommunication(ObservableCollection<Communication> Communications)
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
                    CommandText = "GetCommunications",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Communication per = new Communication
                        {
                            Communication_id = (int)row[0],
                            Communication_name = row[1].ToString(),
                            Communication_date = row[2].ToString(),
                            User_id = (int)row[3],
                            Plate_id = (int)row[4],
                            Communication_photo1 = row[5].ToString(),
                            Communication_photo2 = row[6].ToString(),
                            Communication_notice = row[7].ToString(),
                            Communication_status = (int)row[8],
                            Communication_place = row[9].ToString(),
                            Citizen_id = (int)row[10]
                        };
                        if (per.Communication_status == 1)
                        {
                            per.String_Status = "لم يتم الفحص";
                        }
                        else if (per.Communication_status == 2)
                        {
                            per.String_Status = "مقبول";
                        }
                        else
                        {
                            per.String_Status = "غير مقبول";
                        }

                        per.String_Ciziten = new Class_SqlConnection().Get_row("getUserName", per.User_id);
                        per.PlateNum = new Class_SqlConnection().Get_row("getPlateNum", per.Plate_id);
                        per.PlateNumr = new Class_SqlConnection().Get_row("getPlateNumber", per.Plate_id);
                        Communications.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }



        }

        public bool OperarionCommunication(Communication Communication, string operartion)
        {
            // MessageBox.Show(Communication.Citizen_id.ToString() + "-" + Communication.User_id);
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[12];

            param[0] = new SqlParameter("@Communication_id", SqlDbType.Int)
            {
                Value = Communication.Communication_id
            };
            param[1] = new SqlParameter("@Communication_name", SqlDbType.NVarChar, 50)
            {
                Value = Communication.Communication_name
            };
            param[2] = new SqlParameter("@Communication_date", SqlDbType.NVarChar, 50)
            {
                Value = Communication.Communication_date
            };
            param[3] = new SqlParameter("@User_id", SqlDbType.Int)
            {
                Value = Communication.User_id
            };
            param[4] = new SqlParameter("@Plate_id", SqlDbType.Int)
            {
                Value = Communication.Plate_id
            };
            param[5] = new SqlParameter("@Communication_photo1", SqlDbType.NVarChar, 50)
            {
                Value = Communication.Communication_photo1
            };
            param[6] = new SqlParameter("@Communication_photo2", SqlDbType.NVarChar, 50)
            {
                Value = Communication.Communication_photo2
            };
            param[7] = new SqlParameter("@Communication_notice", SqlDbType.NVarChar, 50)
            {
                Value = Communication.Communication_notice
            };
            param[8] = new SqlParameter("@Communication_status", SqlDbType.Int)
            {
                Value = Communication.Communication_status
            };
            param[9] = new SqlParameter("@Communication_place", SqlDbType.NVarChar, 50)
            {
                Value = Communication.Communication_place
            };
            param[10] = new SqlParameter("@Citizen_id", SqlDbType.Int)
            {
                Value = Communication.Citizen_id
            };
            param[11] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opCommunication", param))
            {
                return false;

            }
            return true;
        }

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
                    CommandText = "checkCommunication",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Communication_id", value);


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


        /////////////////////////////////start GetExcel/////////////////////////////////////




    }
}
