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

namespace Wpf_Traffic_violation.Models.Violations_Model
{
    public class VoilationModel
    {

        ///////////////////////////////// start GetViolation/////////////////////////////////////



        public void GetViolation(ObservableCollection<Violation> Violations)
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
                    CommandText = "getViolation",
                    Connection = con

                };
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
                        per.Plate_Num = new Class_SqlConnection().Get_row("getPlateNum", per.Plate_id);
                        per.Plate_Type = new Class_SqlConnection().Get_row("getPlateTypenames", per.Plate_id);
                        per.String_ViolationType = new Class_SqlConnection().Get_row("GetViolationtype_name", per.Violation_type_id);
                        per.String_TrafficMan = new Class_SqlConnection().Get_row("GetTrafficMan_name", per.Teaffic_man_id);
                        per.String_Street = new Class_SqlConnection().Get_row("GetStreet_name", per.Street_id);
                        per.Amount = new Class_SqlConnection().Get_number("GetViolationTypeMount", per.Violation_type_id) + per.Violation_penalty;
                        per.String_Status = (per.Payment_status == 1) ? "مسدد" : "غير مسدد";
                        Violations.Add(per); //الي بنربطه مع الجريد فيو
                    }
                }
            }


        }

        ///////////////////////////////// end GetPlateOfType/////////////////////////////////////

        ///////////////////////////////// start OperarionReasonToOblection/////////////////////////////////////

        public bool OperarionViolation(Violation Violation, string operartion)
        {
            Class_SqlConnection sql = new Class_SqlConnection();

            SqlParameter[] param = new SqlParameter[12];
            //@user_id, @user_name, @user_pass, @user_type, @user_status

            param[0] = new SqlParameter("@Violation_id", SqlDbType.Int)
            {
                Value = Violation.Violation_id
            };
            param[1] = new SqlParameter("@Violation_date", SqlDbType.NVarChar, 50)
            {
                Value = Violation.Violation_date
            };
            param[2] = new SqlParameter("@Violation_photo1", SqlDbType.NVarChar, 50)
            {
                Value = Violation.Violation_photo1
            };
            param[3] = new SqlParameter("@Violation_photo2", SqlDbType.NVarChar, 50)
            {
                Value = Violation.Violation_photo2
            };
            param[4] = new SqlParameter("@Plate_id", SqlDbType.Int)
            {
                Value = Violation.Plate_id
            };
            param[5] = new SqlParameter("@Street_id", SqlDbType.Int)
            {
                Value = Violation.Street_id
            };
            param[6] = new SqlParameter("@Teaffic_man_id", SqlDbType.Int)
            {
                Value = Violation.Teaffic_man_id
            };
            param[7] = new SqlParameter("@Violation_type_id", SqlDbType.Int)
            {
                Value = Violation.Violation_type_id
            };
            param[8] = new SqlParameter("@Notise", SqlDbType.NVarChar, 50)
            {
                Value = Violation.Notise
            };
            param[9] = new SqlParameter("@Violation_penalty", SqlDbType.Int)
            {
                Value = Violation.Violation_penalty
            };
            param[10] = new SqlParameter("@Payment_status", SqlDbType.Int)
            {
                Value = Violation.Payment_status
            };
            param[11] = new SqlParameter("@Operation", SqlDbType.NVarChar, 50)
            {
                Value = operartion
            };

            if (!sql.Operarion("opViolation", param))
            {
                return false;

            }
            return true;
        }
        ///////////////////////////////// end OperarionReasonToOblection/////////////////////////////////////


        ///////////////////////////////// start OperarionReasonToOblection/////////////////////////////////////





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
                    CommandText = "checkViolation",
                    Connection = sql.con

                };
                Command.Parameters.AddWithValue("@Violation_id", value);


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



        public void GetExcel(ObservableCollection<Violation> Violations)
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

                        Violation per = new Violation
                        {
                            Violation_id = Convert.ToInt32(row[0])
                         ,
                            Violation_date = row[1].ToString()
                         ,
                            Violation_photo1 = row[2].ToString()
                         ,
                            Violation_photo2 = row[3].ToString()
                         ,
                            Plate_id = Convert.ToInt32(row[4])
                         ,
                            Street_id = Convert.ToInt32(row[5])
                         ,
                            Teaffic_man_id = Convert.ToInt32(row[6])
                         ,
                            Violation_type_id = Convert.ToInt32(row[7])
                         ,
                            Notise = row[8].ToString()
                         ,
                            Violation_penalty = Convert.ToInt32(row[9])
                         ,
                            Payment_status = Convert.ToInt32(row[10])
                        };
                        OperarionViolation(per, "Insert");



                        Violations.Add(per); //الي بنربطه مع الجريد فيو
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
