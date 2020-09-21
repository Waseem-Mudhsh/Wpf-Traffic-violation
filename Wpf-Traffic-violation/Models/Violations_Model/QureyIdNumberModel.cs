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
    public class QureyIdNumberModel
    {
        ///////////////////////////////// start GetCitizens/////////////////////////////////////



        public void GetVehicleCard(Vehicle Vehicle, int Id)
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
                SqlCommand Command1 = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetVehicleCard",
                    Connection = con

                };
                Command1.Parameters.AddWithValue("@Id", Id);
                DataTable dt1 = new DataTable();
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(Command1);
                dataAdapter1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow row in dt1.Rows)
                    {

                        Vehicle.Potty_id = (int)row[0];
                        Vehicle.Vehicle_engine_num = (int)row[1];
                        Vehicle.Vehicle_color = row[2].ToString();
                        Vehicle.Vehicle_shape = row[3].ToString();
                        Vehicle.Vehicle_model = row[4].ToString();
                        Vehicle.Vehicle_customs_num = (int)row[5];
                        Vehicle.Company_manu_name = row[6].ToString();
                        Vehicle.Status_v = (int)row[7];
                        Vehicle.Release_palc_c = (int)row[8];
                        Vehicle.Release_date_c = row[9].ToString();
                        Vehicle.Vehicle_card_id = (int)row[10];
                        Vehicle.Release_date = row[11].ToString();
                        Vehicle.Release_plase = (int)row[12];
                        Vehicle.Noties = row[13].ToString();
                        Vehicle.Status = (int)row[14];
                        Vehicle.Citizen_id = (int)row[15];
                        Vehicle.String_Citizen = row[16].ToString();
                        Vehicle.String_Provinces = new Class_SqlConnection().Get_row("GetProvince_name", Vehicle.Release_palc_c);
                        Vehicle.String_Provinces_vc = new Class_SqlConnection().Get_row("GetProvince_name", Vehicle.Release_plase);


                    }
                }

            }
        }
        ///////////////////////////////// end GetCitizens/////////////////////////////////////



        ///////////////////////////////// start GetViolation/////////////////////////////////////



        public void GetViolation(ObservableCollection<Violation> Violations, int Id)
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
                    CommandText = "getViolationById",
                    Connection = con

                };
                Command.Parameters.AddWithValue("@Id", Id);
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
                         ,
                            Plate_Type = row[11].ToString()
                         ,
                            String_Street = row[12].ToString()
                        ,
                            String_TrafficMan = row[13].ToString()
                        ,
                            String_ViolationType = row[14].ToString()
                        };
                        per.Amount = new Class_SqlConnection().Get_number("GetViolationTypeMount", per.Violation_type_id);
                        per.Plate_Num = new Class_SqlConnection().Get_row("getPlateNum", Id);


                        per.String_Status = (per.Payment_status == 1) ? "مسدد" : "غير مسدد";
                        Violations.Add(per); //الي بنربطه مع الجريد فيو


                    }
                }
            }


        }

        ///////////////////////////////// end GetPlateOfType/////////////////////////////////////

    }
}
