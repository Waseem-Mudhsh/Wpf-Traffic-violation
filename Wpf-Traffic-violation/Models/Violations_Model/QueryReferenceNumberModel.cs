using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class QueryReferenceNumberModel
    {
        public void GetViolation(ObservableCollection<Violation> Violations,int Id)
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
                    CommandText = "getViolation_Query",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@Violation_id", Id);
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Command);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {

                       
                        Violation per = new Violation
                        {
                            Violation_id = (int)row[0]
                         ,
                            Violation_date = row[1].ToString()
                         ,
                            Violation_photo1 = row[2].ToString()
                         ,
                            Violation_photo2 = row[3].ToString()
                         ,
                            Plate_id = (int)row[4]
                         ,
                            Street_id = (int)row[5]
                         ,
                            Teaffic_man_id = (int)row[6]
                         ,
                            Violation_type_id = (int)row[7]
                         ,
                            Notise = row[8].ToString()
                         ,
                            Violation_penalty = (int)row[9]
                         ,
                            Payment_status = (int)row[10]
                         
                        };
                        per.Amount = new Class_SqlConnection().Get_number("GetViolationTypeMount", per.Violation_type_id);
                        per.Plate_Num = new Class_SqlConnection().Get_row("getPlateNum", per.Plate_id);
                        per.String_ViolationType = new Class_SqlConnection().Get_row("GetViolationtype_name", per.Violation_type_id);
                        per.String_Street = new Class_SqlConnection().Get_row("GetStreet_name", per.Street_id);
                        per.String_TrafficMan = new Class_SqlConnection().Get_row("GetTrafficMan_name", per.Teaffic_man_id);

                        per.String_Status = (per.Payment_status == 1) ? "مسدد" : "غير مسدد";
                        Violations.Add(per); //الي بنربطه مع الجريد فيو


                    }
                }
            }


        }

        ///////////////////////////////// end GetPlateOfType/////////////////////////////////////
    }
}
