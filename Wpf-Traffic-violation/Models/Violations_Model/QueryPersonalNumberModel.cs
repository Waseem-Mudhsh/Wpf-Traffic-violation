using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Traffic_violation.Models.Configurations_Model;

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class QueryPersonalNumberModel
    {
        ///////////////////////////////// start GetCitizens/////////////////////////////////////



        public DrivingLicense GetDriving( int Id)
        {
            DrivingLicense DrivingLicense = new DrivingLicense();
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
                    CommandText = "GetDrivinglicenseByCitizen",
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
                        DrivingLicense.Driving_license_id = (int)row[0];
                        DrivingLicense.Release_date = row[1].ToString();
                        DrivingLicense.Citizen_id = (int)row[2];
                        DrivingLicense.Class_license_id = (int)row[3];
                        DrivingLicense.Date_frist_license = row[4].ToString();
                        DrivingLicense.Driving_license_notice = row[5].ToString();
                        DrivingLicense.Status = row[6].ToString();
                        DrivingLicense.String_Class_license = row[7].ToString();

                    }
                }

            }
            return DrivingLicense;
        }
        ///////////////////////////////// end GetCitizens/////////////////////////////////////



        ///////////////////////////////// start GetViolation/////////////////////////////////////



        public ObservableCollection<Violation> GetViolation( int Id)
        {
            ObservableCollection<Violation> Violations = new ObservableCollection<Violation>();
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
                    CommandText = "getViolationByCitizen",
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
                            Violation_photo1 = Convert.ToByte(row[2].ToString())
                         ,
                            Violation_photo2 = Convert.ToByte(row[3].ToString())
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
                        per.Plate_Num = new Class_SqlConnection().Get_row("getPlateNum", per.Plate_id);


                        per.String_Status = (per.Payment_status == 1) ? "مسدد" : "غير مسدد";
                        Violations.Add(per); //الي بنربطه مع الجريد فيو


                    }
                }
            }

            return Violations;
        }

        ///////////////////////////////// end GetPlateOfType/////////////////////////////////////

    }
}
