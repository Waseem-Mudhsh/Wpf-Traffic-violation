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
    public class OpjectionModel
    {

        ///////////////////////////////// start GetOpjection/////////////////////////////////////

        public void GetOpjection(ObservableCollection<Opjection> Opjections)
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
                    CommandText = "GetOpjection",
                    Connection = con

                };
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Opjection per = new Opjection
                        {
                            Interception_id = (int)row[0],
                            Reason_Interception = row[1].ToString(),
                            Violation_id = (int)row[2],
                            Identity_id = (int)row[3],
                            Status = (int)row[4],
                            Interception_date = row[5].ToString(),

                        };
                        per.String_Ciziten = new Class_SqlConnection().Get_row("getCitizenName", per.Identity_id);
                        if (per.Status == 0)
                            per.String_Status = "لم يتم الفحص";
                        else if (per.Status == 1)
                            per.String_Status = "مقبول";
                        else
                            per.String_Status = "غير مقبول";

                        Opjections.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }


        }
        ///////////////////////////////// end GetOpjection/////////////////////////////////////


        ///////////////////////////////// start OperarionReasonToOblection/////////////////////////////////////

        public bool OperarionOpjection(Opjection Opjection, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@Interception_id", SqlDbType.Int)
            {
                Value = Opjection.Interception_id
            };
            param[1] = new SqlParameter("@Reason_Interception", SqlDbType.NVarChar, 50)
            {
                Value = Opjection.Reason_Interception
            };
            param[2] = new SqlParameter("@Violation_id", SqlDbType.Int)
            {
                Value = Opjection.Violation_id
            };
            param[3] = new SqlParameter("@Identity_id", SqlDbType.Int)
            {
                Value = Opjection.Identity_id
            };
            param[4] = new SqlParameter("@Status", SqlDbType.Int)
            {
                Value = Opjection.Status
            };
            param[5] = new SqlParameter("@Interception_date", SqlDbType.NVarChar, 50)
            {
                Value = Opjection.Interception_date
            };
            param[6] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };
            if (!sql.Operarion("opOpjection", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionReasonToOblection/////////////////////////////////////

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
                    CommandText = "checkOpjection",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Interception_id", value);


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










    }
}
